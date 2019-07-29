# Data Management

This documentation is about managing Znode's usage of SQL Server, MongoDB, and ElasticSearch.

## Table of Contents

Documentation is organized into the following areas:

* **[Managing Derived Data (MongoDB and ElasticSearch)](derived-data/README.md)**
  * Creating (and rebuilding) data stored in MongoDB and ElasticSearch.
* **[DB Version Update Scripts](upgrading/README.md)**
  * Handling DB updates when moving to newer versions of Znode.

## Tools

Some helpful tools can be used to more easily manage Znode's databases. The following list of tools are commonly used by Znode developers:

* [SSMS (SQL Server Management Studio)](https://docs.microsoft.com/en-us/sql/ssms/sql-server-management-studio-ssms?view=sql-server-2017)
  * UI for managing SQL Server databases.
* [NoSQLBooster](https://nosqlbooster.com/home)
  * UI for managing MongoDB databases.
* [Postman](https://www.getpostman.com/)
  * UI for sending HTTP requests; useful to interact with Elasticsearche's RESTful API.
