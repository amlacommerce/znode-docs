# Installing Znode Dependencies
This quickstart guide provides instructions on installing Znode's dependencies to prepare for a Znode installation. The instructions are organized into the following parts:
* Part 1: Installing Java Development Kit (JDK)
* Part 2: Installing Elasticsearch
* Part 3: Installing MongoDB

## Znode's Dependencies
Znode depends on the following software to properly run. Other versions may work, but the following versions are most rigorously tested.
- .NET Ecosystem:
    - .NET Framework 4.8
    - Visual Studio 2017
    - IIS 7.5 or Later (or IIS Express with VS)
    - Microsoft SQL Server 2016 or Later (Standard Edition at least)
- Non-.NET Ecosystem:
    - Java Development Kit (JDK) 11.0
    - Elasticsearch 7.6.0
    - MongoDB 4.2

It is assumed that a proper .NET development environment is already setup. For that reason, Visual Studio, IIS, and SQL Server installation help is not provided in this guide. This guide covers installation of the JDK, Elasticsearch, and MongoDB.

## Setup Files ZIP

Installers for these dependencies can be retrieved directly from the vendors, or, easily downloaded in this [Setup Files ZIP](https://drive.google.com/file/d/17eZQCL2Ggaf-MY7j-uy1Cfxqmys38BKF/view?usp=sharing).

## Part 1: Installing Java Development Kit (JDK)
To run Znode, the JDK must be installed. Note that Znode itself does not depend on Java, but Znode depends on Elasticsearch, which depends on Java.

### Install JDK
Follow these steps to install the JDK. Znode uses Elasticsearch v7.6.0, so any JDK that is compatible with Elasticsearch v7.6.0 will work. In-house Znode developers run JDK v1.8.0.
1. Acquire a copy of the JDK. A copy is provided in the `Setup Files ZIP` (`jdk-11.0.6_windows-x64_bin.exe`).
1. Run the JDK installer.
1. Follow the steps built in to the installer.

### Configure 'JAVA_HOME' Environment Variable
Elasticsearch also assumes that a Windows Environment Variable will point to the JDK install path. To set this, follow these steps:
1. Open a command prompt as an administrator.
1. Run `setx -m JAVA_HOME "C:\Program Files\Java\jdk-11.0.6"` at the command prompt. Update the path to match that of the local JDK installation if necessary.
1. The variable can be verified by restarting the command prompt and running `echo %JAVA_HOME%`.

## Part 2: Installing Elasticsearch
Follow these steps to install Elasticsearch. Znode officially supports Elasticsearch v7.6.0, but other versions may also work.
1. Acquire a copy of Elasticsearch. A copy is provided in the `Setup Files ZIP` (`elasticsearch-7.6.0`). Alternatively, Elastic has it available [here](https://www.elastic.co/downloads/past-releases/elasticsearch-7-6-0).
1. Copy the `elasticsearch-7.6.0` folder to the root of the `C:` drive, or another desired location.
1. Open a command prompt as an administrator and execute the following commands to install the Elasticsearch Windows Service and run it in the background:
    1. C:\\>`cd "C:\elasticsearch-7.6.0\bin"`
    1. C:\elasticsearch-7.6.0\bin>`elasticsearch-service.bat install`
    1. C:\elasticsearch-7.6.0\bin>`elasticsearch-service.bat start`

## Part 3: Installing MongoDB
Follow these steps to install MongoDB. Znode officially supports MongoDB v4.2, but other versions may also work.
1. Acquire a copy of MongoDB v4.2. A copy is provided in the `Setup Files ZIP` (`mongodb-win32-x86_64-2012plus-4.2.3-signed`).
1. Run the MongoDB installer. Choose the "Complete" option during installation.
1. On the next page, the “Install MongoDB Compass” option can be deleselected because it is not needed.
1. On a later page, accept the default options related to installing MongoDB to run as a service.

## Next Steps
Continue on to [Installing Znode](../installing-znode/README.md).
