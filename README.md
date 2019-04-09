# Znode Developer Documentation
This is the home to documentation for developing with Znode. Documentation is broken into the following sections:
- Section 1: Installing Dependencies
- Section 2: Creating a Znode Database
- Section 3: Configuring NuGet
- Section 4: Configuring, Building and Running Znode

## Section 1: Installing Dependencies
Znode depends on the following software to properly run:
- .NET Ecosystem:
    - Visual Studio 2017 (or later)
    - IIS (or IIS Express with VS)
    - Microsoft SQL Server
- Non-.NET Ecosystem:
    - Java Development Kit (JDK)
    - Elasticsearch v5.5
    - MongoDB v3.2

It is assumed that a proper .NET development environment is already setup. For that reason, Visual Studio, IIS, and SQL Server installation help is not provided in this guide. This guide covers installation of the JDK, Elasticsearch, and MongoDB. Installers for these dependencies can be retrieved directly from the vendors, or, easily downloaded in this [Setup Files ZIP](https://drive.google.com/file/d/1pecVTQUzrEFd_U04lL823-RWvBgmisss/view?usp=sharing).

### Installing Java Development Kit (JDK)
To run Znode, a recent version of the JDK must be installed on the machine. Note that Znode itself does not depend on Java, but Znode depends on Elasticsearch, which depends on Java.

#### Part 1: Install JDK
Znode uses Elasticsearch v5.5, so any JDK that is compatible with Elasticsearch v5.5 will work. In-house Znode developers run JDK v1.8.0.
1. Acquire a copy of the JDK. A copy is provided in the [Setup Files ZIP](https://drive.google.com/file/d/1pecVTQUzrEFd_U04lL823-RWvBgmisss/view?usp=sharing) (`jdk-8u102-windows-x64.exe`).
1. Run the JDK installer.
2. Follow the steps built in to the installer.

#### Part 2: Configure 'JAVA_HOME' Environment Variable
Elasticsearch also assumes that a Windows Environment Variable will point to the JDK install path. To set this, follow these steps:
1. Open a command prompt as an administrator.
1. Run `setx -m JAVA_HOME "C:\Program Files\Java\jdk1.8.0_102"` at the command prompt. Update the path to match that of the local JDK installation if necessary.
1. The variable can be verified by running `echo %JAVA_HOME%`.

### Installing Elasticsearch
Follow these steps to install Elasticsearch. Znode officially supports Elasticsearch v5.5, but other versions may also work.
1. Acquire a copy of Elasticsearch. A copy is provided in the [Setup Files ZIP](https://drive.google.com/file/d/1pecVTQUzrEFd_U04lL823-RWvBgmisss/view?usp=sharing) (`elasticsearch-5.5.0`).
1. Copy the `elasticsearch-5.5.0` folder to the root of the `C:` drive, or another desired location.
1. Open a command prompt as an administrator and execute the following commands to install the Elasticsearch Windows Service and run it in the background:
    1. C:\\>`cd "C:\elasticsearch-5.5.0\bin"`
    1. C:\elasticsearch-5.5.0\bin>`elasticsearch-service.bat install`
    1. C:\elasticsearch-5.5.0\bin>`elasticsearch-service.bat start`

### Installing MongoDB
Follow these steps to install MongoDB. Znode officially supports MongoDB v3.2, but other versions may also work.
1. Acquire a copy of MongoDB v3.2. A copy is provided in the [Setup Files ZIP](https://drive.google.com/file/d/1pecVTQUzrEFd_U04lL823-RWvBgmisss/view?usp=sharing) (`Mongodb-win32-x86_64-2008plus-ssl-v3.2-latest-signed`).
1. Run the MongoDB installer. Accept the default selections during installation.
1. Once the installation is done, create a folder on the `C:` drive named `MongodbDataFiles`, or locate/name differently if desired.
1. In the `MongodbDataFiles` folder add one file named `logs.txt`.
1. Open a command prompt as an administrator and run the following commands, updating paths if necessary:
    1. C:\\>`cd "C:\Program Files\MongoDB\Server\3.2\bin"`
    1. C:\Program Files\MongoDB\Server\3.2\bin>`mongod --dbpath "C:\MongodbDataFiles" --logpath "C:\MongodbDataFiles\logs.txt" --install --serviceName "MongoDB"`
1. Run the command `NET START MongoDB` to start the newly created MongoDB service.

## Section 2: Creating a Znode Database
The entire Znode database is maintained inside [its own VS project](https://github.com/amlacommerce/znode-source/blob/master/Database/Znode_Multifront_Dev/Znode_Multifront_Dev.sln), but a create script is also kept in the repository to easily create a new database. To run the create script:
1. Open SQL Server Managment Studio (SSMS).
1. In SSMS, open the DB create script. The script is located [here](https://github.com/amlacommerce/znode-source/blob/master/Database/Znode%20Multifront%209.1.1%20Database%20Script%20(for%20fresh%20installation)/Znode_Multifront_911.sql) in the repository.
1. Run the script. A new Znode DB will be created.

Note that the default DB name is 'Znode_Multifront_911'. Search and replace all occurrances of that string to choose a different name.

## Section 3: Configuring NuGet
To successfully build Znode, it is necessary to configure NuGet to access the private Znode NuGet Registry.
1. Request access to the Znode NuGet Registry by emailing support@znode.com.
1. Add a custom NuGet package source in Visual Studio. Microsoft's instructions for doing so are [here](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui#package-sources).
    1. The `Source` that needs to be entered into Visual Studio is: http://nuget.znode.com/nuget.
    1. The `Username` and `Password` that needs to be entered into Visual Studio is that which the Znode team provided.

## Section 4: Configuring, Building and Running Znode
With Znode's dependencies installed and NuGet configured, it is now time to run Znode.
1. Open [the main Znode solution](https://github.com/amlacommerce/znode-source/blob/master/Projects/Znode.Multifront.sln).
1. [Set multiple startup projects](https://docs.microsoft.com/en-us/visualstudio/ide/how-to-set-multiple-startup-projects?view=vs-2017). The following projects need to start:
    - Znode.Engine.Admin
    - Znode.Engine.API
    - Znode.Engine.WebStore
1. Build the solution.
1. Configure SQL connection strings in the API's [Web.config](https://github.com/amlacommerce/znode-source/blob/master/Projects/Znode.Engine.Api/Web.config). The `ZnodeECommerceDB` and `Znode_Entities` strings need to be configured. For both settings, set:
    1. `Data Source`, `User Id`, and `Password` to that which is used to connect with SSMS (or as desired).
    1. `Initial Catalog` to the name of the Znode DB. The default is `Znode_Multifront_911`.
1. Run the solution. Visual Studio should automatically open the 3 applications in the default browser.
