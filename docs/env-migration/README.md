# Migrating Znode DB From One Environment to Another

TODO: This page will provide high-level documentation on how to handle migrating a dataset (products, content, etc.) from one environment to another.

* Backup DB and restore DB.
* Copy Media.

Replace hardcoded media URL's in content blocks by running this SQL:

```
UPDATE [ZnodeCMSMessage]
SET [Message] = replace(Message, 'source-environment.znode.com', 'target-environment.znode.com')
```