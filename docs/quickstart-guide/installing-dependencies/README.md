# Installing Znode Dependencies
This quickstart guide provides instructions on installing Znode's dependencies to prepare for a Znode installation. The instructions are organized into the following parts:
* Part 1: Installing Java Development Kit (JDK)
* Part 2: Installing Elasticsearch
* Part 3: Installing MongoDB

## Znode's Dependencies
Znode depends on the following software to properly run:
- .NET Ecosystem:
    - Visual Studio 2017 (or later)
    - IIS (or IIS Express with VS)
    - Microsoft SQL Server
- Non-.NET Ecosystem:
    - Java Development Kit (JDK)
    - Elasticsearch v5.5
    - MongoDB v3.2

It is assumed that a proper .NET development environment is already setup. For that reason, Visual Studio, IIS, and SQL Server installation help is not provided in this guide. This guide covers installation of the JDK, Elasticsearch, and MongoDB. Installers for these dependencies can be retrieved directly from the vendors, or, easily downloaded in this [Setup Files ZIP](https://drive.google.com/open?id=1agoIBDxFQo1xKlmzEGvnsYIYt_lAUCH_).

## Part 1: Installing Java Development Kit (JDK)
To run Znode, a recent version of the JDK must be installed. Note that Znode itself does not depend on Java, but Znode depends on Elasticsearch, which depends on Java.

### Install JDK
Follow these steps to install the JDK. Znode uses Elasticsearch v5.5, so any JDK that is compatible with Elasticsearch v5.5 will work. In-house Znode developers run JDK v1.8.0.
1. Acquire a copy of the JDK. A copy is provided in the [Setup Files ZIP](https://drive.google.com/open?id=1agoIBDxFQo1xKlmzEGvnsYIYt_lAUCH_) (`jdk-8u102-windows-x64.exe`).
1. Run the JDK installer.
1. Follow the steps built in to the installer.

### Configure 'JAVA_HOME' Environment Variable
Elasticsearch also assumes that a Windows Environment Variable will point to the JDK install path. To set this, follow these steps:
1. Open a command prompt as an administrator.
1. Run `setx -m JAVA_HOME "C:\Program Files\Java\jdk1.8.0_102"` at the command prompt. Update the path to match that of the local JDK installation if necessary.
1. The variable can be verified by running `echo %JAVA_HOME%`.

## Part 2: Installing Elasticsearch
Follow these steps to install Elasticsearch. Znode officially supports Elasticsearch v5.5, but other versions may also work.
1. Acquire a copy of Elasticsearch. A copy is provided in the [Setup Files ZIP](https://drive.google.com/open?id=1agoIBDxFQo1xKlmzEGvnsYIYt_lAUCH_) (`elasticsearch-5.5.0`). Alternatively, for as long as Elastic continues hosting v5.5, they have it available [here](https://www.elastic.co/downloads/past-releases/elasticsearch-5-5-0).
1. Copy the `elasticsearch-5.5.0` folder to the root of the `C:` drive, or another desired location.
1. Open a command prompt as an administrator and execute the following commands to install the Elasticsearch Windows Service and run it in the background:
    1. C:\\>`cd "C:\elasticsearch-5.5.0\bin"`
    1. C:\elasticsearch-5.5.0\bin>`elasticsearch-service.bat install`
    1. C:\elasticsearch-5.5.0\bin>`elasticsearch-service.bat start`

## Part 3: Installing MongoDB
Follow these steps to install MongoDB. Znode officially supports MongoDB v3.2, but other versions may also work.
1. Acquire a copy of MongoDB v3.2. A copy is provided in the [Setup Files ZIP](https://drive.google.com/open?id=1agoIBDxFQo1xKlmzEGvnsYIYt_lAUCH_) (`Mongodb-win32-x86_64-2008plus-ssl-v3.2-latest-signed`).
1. Run the MongoDB installer. Choose the "Complete" option during installation.
1. Once the installation is done, create a folder on the `C:` drive named `MongodbDataFiles`, or locate/name differently if desired.
1. Open a command prompt as an administrator and run the following commands, updating paths if necessary:
    1. C:\\>`cd "C:\Program Files\MongoDB\Server\3.2\bin"`
    1. C:\Program Files\MongoDB\Server\3.2\bin>`mongod --dbpath "C:\MongodbDataFiles" --logpath "C:\MongodbDataFiles\logs.txt" --install --serviceName "MongoDB"`
1. Run the command `NET START MongoDB` to start the newly created MongoDB service.

## Next Steps
Continue on to [Installing Znode](../installing-znode/README.md).
