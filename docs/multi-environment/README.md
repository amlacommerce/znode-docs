# Managing Multiple Environments

It's common for a Znode developer to maintain many Znode environments on their machine side-by-side. This makes it easy to switch between implementations for different customers. This page provides guidance on handling such as setup for the best development experience.

## Database Configuration

While possible (and most straightforward) to maintain a 1:1 relationship between instances of the Znode apps and Znode databases, it's also possible to juggle connections more aggressively when helpful in development situations.

### An Example Development Scenario

For example, a develop may be working on implementations for 4 different customers, suppose:

* `CustomerA` has a straightforward implementation with some minimal customizations.
* `CustomerB` has a complex situation involving a significant upgrade from an older version of Znode to a newer version of Znode.
* `CustomerC` and `CustomerD` have no customizations and run on out-of-the-box Znode.

An efficient setup for the developer working on these implementations may look like the following:

* 3 instances of the Znode application solutions
  * 1 instance for `CustomerA`
  * 1 instance for `CustomerB`
  * 1 instance for `CustomerC` and `CustomerD` to share
* 5+ instances of the Znode databases
  * 1 set of databases for `CustomerA`
  * 2+ sets of databases for `CustomerB`, supporting the upgrade process
  * 1 set of databases for `CustomerC`
  * 1 set of databases for `CustomerD`

This example scenario illustrates

Note that this example scenario recommends separate databases per customer, but that isn't stricty necessary. Znode's support for multi-site allows multiple catalogs and stores to be managed on a single Znode instance.

### Efficiently Switching DB Configuration

In the scenario that one set of Znode applications is continually pointed at different sets of databases, a couple of approaches can be taken.

The most "professional" approach would be to setup [Web.config file transformations](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/visual-studio-web-deployment/web-config-transformations) for each configuration, overidding the necessary settings as desired.

The second approach is less "professional" but simpler and just as functional; commenting out unused settings. For example, separate sets of connection strings can be commented/un-commented to quickly switch databases:

```xml
<!-- Settings for CustomerA -->
<!--<add name="ZnodeECommerceDB" connectionString="..." />
<add name="Znode_Entities" connectionString="..." />
<add name="ZnodeMongoDB" connectionString="..." />
<add name="ZnodeMongoDBForLog" connectionString="..." />-->

<!-- Settings for CustomerB, DB set 1 -->
<<add name="ZnodeECommerceDB" connectionString="..." />
<add name="Znode_Entities" connectionString="..." />
<add name="ZnodeMongoDB" connectionString="..." />
<add name="ZnodeMongoDBForLog" connectionString="..." />

<!-- Settings for CustomerB, DB set 2 -->
<!--<add name="ZnodeECommerceDB" connectionString="..." />
<add name="Znode_Entities" connectionString="..." />
<add name="ZnodeMongoDB" connectionString="..." />
<add name="ZnodeMongoDBForLog" connectionString="..." />-->
```

## Elasticsearch Index Names

In addition to understanding how to switch databases entirely, it's also good to follow an orderly convention when naming Elasticsearch indices.

Znode creates a single Elasticsearch index for each catalog in the system; there is a 1:1 mapping between Znode catalogs and Elasticsearch indices.

By default, Znode names the Elasticsearch index based on the catalog name. Specifically, Znode will name the index with the patten '{CATALOG_NAME}index', all lowercase. For example, if the catalog in Znode is named 'CarSupplies', then the index will be named 'carsuppliesindex' by default.

### Specifying Custom Elasticsearch Index Name

As mentioned, it's good to follow an orderly convention when choosing Elasticsearch index names.

In the Znode Admin UI, a custom index name can be specified for each catalog. This is available on the `Marketing` > `Site Search` page > `Manage Index` tab. The catalog must first be specified the `Catalog` field, and then the index name can be specified in the `Index Name` field.
