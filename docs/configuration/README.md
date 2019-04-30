# Recommended Development Configuration

Configuring Znode for production differs from configuring Znode for local development in a few key ways. This page offers guidance on configuring Znode for the best development experience.

Znode is primarily configured through API's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config) and the SQL DB itself (often through controls in the Admin UI). The Admin UI's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config) and the the WebStore's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config) have some important configuration settings as well, but these files are not touched as often.

## Disabling Authentication

Local development is easier with authentication disabled, allowing all network traffic to be observed and more easily simulated and manipulated when desired.

To disable authentication, set the `IsGlobalAPIAuthorization` setting to `false`.

```xml
<add key="IsGlobalAPIAuthorization" value="false" />
```

## Disabling Caching

Znode implements caching at numerous layers of the architecture. This caching allows the WebStore to handle sprikes in traffic loads while maintaining high levels of performance. However, when debugging backend logic, it is preferrable to disable caching to eliminate variables, avoid potential race conditions, and ensure a deterministic execution path.

To disable caching at a global level, modify the two records of the `ZnodeApplicationCache` table to be false. The following SQL snippet accomplishes this:

```SQL
UPDATE [dbo].[ZnodeApplicationCache] set IsActive = 'false'
```

## Sharing Databases

For most developers it is recommended to run a full Znode environment locally. This can save time and headaches by allowing developers to each have an isolated laboratory.

However, in certain circumstances it may be preferable for the developers to share certain components of their environment. For example, a frontend developer focused on adjusting color schemes and tweaking cosmetic aspects of the UI could safely use Elasticsearch, MongoDB, and SQL databases from a shared environment such as a development server.

The Znode applications can easily be configured to point at shared Elasticsearch, MongoDB, and SQL Server instances hosted on remote machines. The following sections explain how.

### Shared Elasticsearch

The `ElasticSearchRootUri` setting tells Znode where the Elasticsearch server is running. Elasticsearch hosts itself on port 9200 by default. The `ElasticSearchRootUri` setting is in the API's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config). Here is the default value:

```xml
<add key="ElasticSearchRootUri" value="http://localhost:9200" />
```

The default value (above) assumes Elasticsearch is on the same machine as the application. It's possible tell the applicatoin to use a remote instance of Elasticsearch by updating the setting appropriately. For example:

```xml
<add key="ElasticSearchRootUri" value="http://znode.dev.mycompany.com:9200" />
```

### Shared MongoDB

Znode stores data in two MongoDB databases. One database is for the content that populates the WebStore. The second database is for holding the centralized logs which have no effect on the application's behavior.

#### Shared MongoDB Content Database

The MongoDB database that holds *content* is configured by the `ZnodeMongoDB` setting in the API's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config). The pattern for configuring this setting is as follows:

```xml
<add name="ZnodeMongoDB" connectionString="mongodb://{MONGO_SERVER}/{DATABASE_NAME}" />
```

A typical configuration value, pointing at a remote machine, looks like this:

```xml
<add name="ZnodeMongoDB" connectionString="mongodb://znode.dev.mycompany.com:27017/ZnodeMultifront" />
```

#### Shared MongoDB Application Logs Database

The MongoDB database that holds *logs* is configured by the `ZnodeMongoDBForLog` setting in each of the web.config's; the API's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config), Admin UI's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config), and the WebStore's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config). The pattern for configuring this setting is as follows:

```xml
<add name="ZnodeMongoDBForLog" connectionString="mongodb://{MONGO_SERVER}/{DATABASE_NAME_FOR_LOGS}" />
```

A typical configuration value, pointing at a remote machine, looks like this:

```xml
<add name="ZnodeMongoDBForLog" connectionString="mongodb://znode.dev.mycompany.com:27017/ZnodeMultifront_LogMessages" />
```

### Shared SQL Configuration

Sharing SQL databases is handled by updating the `ZnodeECommerceDB` and `Znode_Entities` settings. Both settings are in the API's [web.config](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Projects/Znode.Engine.Admin/Web.config). The pattern for these settings is as follows:

```xml
<add name="ZnodeECommerceDB" connectionString="Data Source={SQL_SERVER};Initial Catalog={DATABASE_NAME};User Id={USER_ID};Password={PASSWORD};" providerName="System.Data.SqlClient" />

<add name="Znode_Entities" connectionString="metadata=res://*/DataModel.ZnodeEntities.csdl|res://*/DataModel.ZnodeEntities.ssdl|res://*/DataModel.ZnodeEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source={SQL_SERVER};Initial Catalog={DATABASE_NAME};User Id={USER_ID};Password={PASSWORD};MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
```

Typical configuration values, pointing at a remote machine, looks like this:

```xml
<add name="ZnodeECommerceDB" connectionString="Data Source=znodedbsvr.database.windows.net;Initial Catalog=ZnodeMultifront;User Id=sa;Password=zn0d3R0cks;" providerName="System.Data.SqlClient" />

<add name="Znode_Entities" connectionString="metadata=res://*/DataModel.ZnodeEntities.csdl|res://*/DataModel.ZnodeEntities.ssdl|res://*/DataModel.ZnodeEntities.msl;provider=System.Data.SqlClient;provider connection string=&quot;Data Source=znodedbsvr.database.windows.net;Initial Catalog=ZnodeMultifront;User Id=sa;Password=zn0d3R0cks;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
```

Note that these settings point at the same SQL database, but two different types of DB contexts are created for the application; one is an Entity Framework context that is aware of the DB schema, and the other is a raw context that is more typically used for non-CRUD actions against the database; eg: calling stored procedures. Keep these two settings synchronized in terms of `SQL_SERVER`, `DATABASE_NAME`, `USER_ID`, and `PASSWORD`.
