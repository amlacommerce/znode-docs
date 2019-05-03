# Installing Znode
These instructions help with Znode setup from start to finish. The instructions are divided into the following parts:
* Part 1: Getting the Znode Code
* Part 2: Creating a Znode Database
* Part 3: Configuring NuGet
* Part 4: Configuring, Building and Running Znode
* Part 5: Exploring Znode

It is assumed that Znode's dependencies are already installed. If that's not the case, start by [Installing Znode Dependencies](../installing-dependencies/README.md) first.

## Part 1: Getting the Znode Code
It is assumed that [Git](https://git-scm.com/) is already installed. See Git's [official installation guide](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git) if necessary.

Run the `clone` command at a Git Bash window:

`git clone https://github.com/amlacommerce/znode-source.git`

If prompted to do so, provide your GitHub credentials.

## Part 2: Creating a Znode Database
The entire Znode database is maintained inside [its own VS project](https://github.com/amlacommerce/znode-source/blob/master/Database/Znode_Multifront_Dev/Znode_Multifront_Dev.sln), but a [create script](https://github.com/amlacommerce/znode-source/blob/master/Database/Znode%20Multifront%209.2.0%20Database%20Script%20(for%20fresh%20installation)/Znode_Multifront_920.sql) is also kept in the repository to easily create a new database. To run the create script:
1. Open SQL Server Managment Studio (SSMS).
1. In SSMS, open the DB [create script](https://github.com/amlacommerce/znode-source/blob/master/Database/Znode%20Multifront%209.2.0%20Database%20Script%20(for%20fresh%20installation)/Znode_Multifront_920.sql).
1. Run the script. A new Znode DB will be created.

Note that the default DB name is 'Znode_Multifront_X', where X is the version. Search and replace all occurrances of that string in the script to choose a different name.

## Part 3: Configuring NuGet
To successfully build Znode, it is necessary to configure NuGet to access the private Znode NuGet Registry.
1. Request access to the Znode NuGet Registry by emailing support@znode.com.
1. Add a custom NuGet package source in Visual Studio. Microsoft's instructions for doing so are [here](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui#package-sources).
    1. The `Source` that needs to be entered into Visual Studio is: http://nuget.znode.com/nuget.
    1. The `Username` and `Password` that needs to be entered into Visual Studio is that which the Znode team provided.

## Part 4: Configuring, Building and Running Znode
With Znode's dependencies installed and NuGet configured, it is now time to run Znode.
1. Open [the main Znode solution](https://github.com/amlacommerce/znode-source/blob/master/Projects/Znode.Multifront.sln).
1. [Set multiple startup projects](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2017). The following projects need to start:
    - Znode.Engine.Admin
    - Znode.Engine.API
    - Znode.Engine.WebStore
1. Build the solution.
1. Configure SQL connection strings in the API's [Web.config](https://github.com/amlacommerce/znode-source/blob/master/Projects/Znode.Engine.Api/Web.config). The `ZnodeECommerceDB` and `Znode_Entities` strings need to be configured. For both settings, set:
    1. `Data Source`, `User Id`, and `Password` to that which is used to connect with SSMS (or as desired).
    1. `Initial Catalog` to the name of the Znode DB. The default is `Znode_Multifront_{VERSION}` where `{VERSION}` is replaced with the version number.
1. Run the solution. Visual Studio should automatically open the 3 applications in the default browser.

## Part 5: Exploring Znode
Before exploring Znode in-depth, the following points should be known.

### Logging in to the Admin UI
The Admin UI (running on http://localhost:6766 by default) requires credentials to log in. The default `username` and `password` are `admin@znode.com` and `admin12345`, respectively.

### Publishing the Default WebStore Dataset
On a fresh install, the WebStore (running on http://localhost:3288 by default) will be empty. To populate the store with the default dataset:
1. Visit the stores page on the Admin UI (http://localhost:6766/Store/List).
1. Click the globe icon on the Fine Foods row. This will publish the Fine Foods sample content and products.
1. Refresh the WebStore. The WebStore should render with the default theme and the sample Fine Foods content.

### Troubleshooting Common Problems

If you run into problems while trying to get Znode to build and run, see [Troubleshooting Common Problems](/docs/troubleshooting/README.md) for possible answers.

### Next Steps
Congratulations if you have successfully made it this far! Review other parts of this [documentation](/README.md) for more in-depth information where desired.
