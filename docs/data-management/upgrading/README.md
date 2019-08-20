# Database Scripts

When new versions of Znode are released, the SQL DB typically (but not always) needs to be updated. When the DB *does* need to be updated, a single SQL script is always provided to make it easy to perform the update.

## Versioning Conventions

Znode's versioning conventions are slightly different than the [Semantic Versioning](https://semver.org/) conventions most developers are used to.

Semantic Versioning operates with this convention:

```
MAJOR.MINOR.PATCH
```

However, Znode operates with this convention:

```
PLATFORM.MAJOR.MINOR.PATCH
```

Note that Znode introduces an additional `PLATFORM` version segment at the front. This number is currently at `9` (as of 2019). This segment is incremented on a very sparing basis; typically every 3+ years when a major technology stack change occurs.

For example, Znode v9.2.1.5 would have a `PLATFORM` version of `9`, a `MAJOR` version of `2`, a `MINOR` version of `1`, a `PATCH` version of `5`.

## Types of DB Scripts

There are 3 'types' of DB scripts that are published with Znode:

### Create Scripts

With each feature release, a new 'create' script is provided. This script can be run to create a fresh DB.

These scripts are each within their own folder in GitHub, within the [ZnodeMultifront/Database](https://github.com/amlacommerce/znode/tree/master/ZnodeMultifront/Database) folder of the [SDK repository](https://github.com/amlacommerce/znode).

Examples of two **Create Scripts** include:

* [Znode_Multifront_920.sql](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Database/Znode%20Multifront%209.2.0%20Database%20Script%20(for%20fresh%20installation)/Znode_Multifront_920.sql)
  * This script creates a fresh Znode v9.2.0 DB.
* [Znode_Multifront_921.sql](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Database/Znode%20Multifront%209.2.1%20Database%20Script%20(for%20fresh%20installation)/Znode_Multifront_921.sql)
  * This script creates a fresh Znode v9.2.1 DB.

### Feature Update Scripts

With each feature release, a new 'update' script is provided. This script can be run to update a DB from the previous feature version to the target version.

These scripts are all within the [ZnodeMultifront/Database/Znode Multifront Upgrade Scripts](https://github.com/amlacommerce/znode/tree/master/ZnodeMultifront/Database/Znode%20Multifront%20Upgrade%20Scripts) folder of the [SDK repository](https://github.com/amlacommerce/znode).

Examples of two **Feature Update Scripts** include:

* [UpgradeScriptFrom911To920.sql](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Database/Znode%20Multifront%20Upgrade%20Scripts/UpgradeScriptFrom911To920.sql)
  * This script updates a Znode v9.1.1 DB to v9.2.0.
* [UpgradeScriptFrom920To921.sql](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Database/Znode%20Multifront%20Upgrade%20Scripts/UpgradeScriptFrom920To921.sql)
  * This script updates a Znode v9.2.0 DB to v9.2.1.

### Patch Update Scripts

With each patch release, a new 'update' script may or may not be provided. If not provided, that means no DB changes occured with the patch. If provided, the script can be run to update a DB from the previous patch version to the target patch version.

These scripts are all within the [ZnodeMultifront/Database](https://github.com/amlacommerce/znode/tree/master/ZnodeMultifront/Database) folder of the [SDK repository](https://github.com/amlacommerce/znode).

Examples of two **Patch Update Scripts** include:

* ~~Znode_Multifront_9_2_1_1_Patch.sql~~
  * This file does not exist but is listed for explanatory purposes. This file does not exist because the Znode v9.2.1.1 patch did not require any DB changes.
* [Znode_Multifront_9_2_1_2_Patch.sql](https://github.com/amlacommerce/znode/blob/v9.2.1.5/ZnodeMultifront/Database/Znode_Multifront_9_2_1_2_Patch.sql)
  * This script updates a Znode v9.2.1(.0) DB to v9.2.1.2.
* [Znode_Multifront_9_2_1_3_Patch.sql](https://github.com/amlacommerce/znode/blob/v9.2.1.5/ZnodeMultifront/Database/Znode_Multifront_9_2_1_3_Patch.sql)
  * This script updates a Znode v9.2.1.2 DB to v9.2.1.3.

### Note About **Feature** and **Patch** Update Scripts

When a new Znode Feature Release is made available (eg: v9.1.1, v9.2.0, etc.), all of the previous **Patch Update Scripts** are included in the new **Feature Update Script**.

This effectively means that, for example, a DB that is on v9.1.0(.0), v9.1.0.1, v9.1.0.2, v9.1.0.x, etc would be updated to v9.1.1 simply by running the **v9.1.0 -> v9.1.1 Feature Update Script**.

The important point to understand, is that regardless of which `PATCH` version the DB is on, running the next **Feature Update Script** will properly update the DB to that target version.

## Full Example

Below is a full example of steps that a developer may go through, from the time of beginning to work with a version of Znode to the time of upgrading to a later version.

### Step 1: Development Begins with Znode v9.1.1

In this hypothetical example, development begins with Znode v9.1.1.

This means that a Znode DB was initially created by running the [Znode_Multifront_911.sql](https://github.com/amlacommerce/znode/blob/v9.1.1/ZnodeMultifront/Database/Znode%20Multifront%209.1.1%20Database%20Script%20(for%20fresh%20installation)/Znode_Multifront_911.sql) **Create Script**.

### Step 2: Upgrade to Znode v9.2.1.5 Desired

In this hypothetical example, the developers later wish to upgrade to Znode v9.2.1.5.

From the previous step, there is already an existing Znode v9.1.1 DB. This DB now needs to be upgraded to v9.2.1.5 before that version of the application code will be comptible with the DB.

To update, first the following **Feature Update Scripts** scripts would be executed to update the DB from v9.1.1 to v9.2.1:

* [UpgradeScriptFrom911To920.sql](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Database/Znode%20Multifront%20Upgrade%20Scripts/UpgradeScriptFrom911To920.sql)
  * Running this updates the DB from v9.1.1 to v9.2.0.
* [UpgradeScriptFrom920To921.sql](https://github.com/amlacommerce/znode/blob/master/ZnodeMultifront/Database/Znode%20Multifront%20Upgrade%20Scripts/UpgradeScriptFrom920To921.sql)
  * Running this updates the DB from v9.2.0 to v9.2.1.

Next, the following **Patch Update Scripts** would be executed to update the DB from v9.2.1(.0) to v9.2.1.5:

* [Znode_Multifront_9_2_1_2_Patch.sql](https://github.com/amlacommerce/znode/blob/v9.2.1.5/ZnodeMultifront/Database/Znode_Multifront_9_2_1_2_Patch.sql)
  * Running this updates the DB from v9.2.1(.0) to v9.2.1.2.
* [Znode_Multifront_9_2_1_3_Patch.sql](https://github.com/amlacommerce/znode/blob/v9.2.1.5/ZnodeMultifront/Database/Znode_Multifront_9_2_1_3_Patch.sql)
  * Running this updates the DB from v9.2.1.2 to v9.2.1.3.
* [Znode_Multifront_9_2_1_4_Patch.sql](https://github.com/amlacommerce/znode/blob/v9.2.1.5/ZnodeMultifront/Database/Znode_Multifront_9_2_1_4_Patch.sql)
  * Running this updates the DB from v9.2.1.3 to v9.2.1.4.
* [Znode_Multifront_9_2_1_5_Patch.sql](https://github.com/amlacommerce/znode/blob/v9.2.1.5/ZnodeMultifront/Database/Znode_Multifront_9_2_1_5_Patch.sql)
  * Running this updates the DB from v9.2.1.4 to v9.2.1.5.
