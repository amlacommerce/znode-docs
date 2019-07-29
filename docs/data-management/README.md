# Data Management

Znode persists data to a Elasticsearch, MongoDB, and SQL Server databases. The SQL Server database is the system of record for everything, with the Elasticsearch and MongoDB data being derived from the SQL data.

It can be helpful for developers to know more details about this flow of data, especially if working on customizations to backend behavior.

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
