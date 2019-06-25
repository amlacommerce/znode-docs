using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Znode.Engine.Api.Client;
using Znode.Engine.Api.Models;
using Znode.Engine.WebStore.Agents;
using Znode.WebStore.Custom.Agents.IAgents;

namespace Znode.WebStore.Custom.Agents.Agents
{
    internal class CustomCartAgent : CartAgent, ICustomCartAgent
    {
        public CustomCartAgent(IShoppingCartClient shoppingCartsClient, IPublishProductClient publishProductClient, IAccountQuoteClient accountQuoteClient, IUserClient userClient)
            : base(shoppingCartsClient, publishProductClient, accountQuoteClient, userClient)
        {

        }

        protected override ShoppingCartModel CalculateCart(ShoppingCartModel shoppingCartModel, bool isCalculateTaxAndShipping = true, bool isCalculateCart = true)
        {

            // Step 1: Execute default logic.
            var result = base.CalculateCart(shoppingCartModel, isCalculateTaxAndShipping, isCalculateCart);

            // Step 2: Map default result to a result that will be passed to the ERP integration logic.
            var skusAndQuantities = new Dictionary<string, decimal>();
            foreach (var cartItem in result.ShoppingCartItems)
            {
                skusAndQuantities.Add(cartItem.SKU, cartItem.Quantity);
            }

            // Step 3: Invoke ERP integration logic, getting resulting prices in response.
            var skusAndPrices = _getErpPrices_STUB(skusAndQuantities);

            // Step 4: Apply ERP pricing to Znode cart items.
            foreach (var skuAndPrice in skusAndPrices)
            {
                var sku = skuAndPrice.Key;
                var price = skuAndPrice.Value;

                var cartItem = result.ShoppingCartItems.Where(item => item.SKU.Equals(sku)).SingleOrDefault();
                if (cartItem == null)
                {
                    throw new Exception(
                        $"Problem found with ERP pricing integration. No cart item found for SKU '{sku}'.");
                }

                cartItem.UnitPrice = price;
                cartItem.ExtendedPrice = cartItem.Quantity * cartItem.UnitPrice;
            }

            // Step 5: Sum up the cart based on the newly applied prices from ERP.
            result.SubTotal = 0.0m;
            result.Total = 0.0m;
            foreach (var cartItem in result.ShoppingCartItems)
            {
                result.SubTotal += cartItem.ExtendedPrice;
            }
            result.Total = result.SubTotal + result.ShippingCost;

            return result;
        }

        private IDictionary<string, decimal> _getErpPrices_STUB(IDictionary<string, decimal> skusAndQuantities)
        {
            var skusAndUnitPrices = new Dictionary<string, decimal>();

            // This is where the cart state needs to be sent to the ERP API, and the prices will
            // be received in response.

            foreach (var skuAndQuantity in skusAndQuantities)
            {
                var sku = skuAndQuantity.Key;
                var quantity = skuAndQuantity.Value;

                skusAndUnitPrices.Add(sku, 2.00m);
            }

            return skusAndUnitPrices;
        }
    }
}
