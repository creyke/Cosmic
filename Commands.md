# Commands
This page is auto-generated from the source code of Cosmic.
## Accounts
List connected Azure Cosmos DB accounts.
```
cosmic accounts
```
## Active
Outputs the current active container.
```
cosmic active
```
## Aliases
List query aliases for common functions.
```
cosmic aliases
```
## Connect
Connect to an Azure Cosmos DB account.
```
cosmic connect
```
| Argument | Description |
| - | - | 
| -n, --name | A unique name for this Azure Cosmos DB connection. |
| -c, --connection-string | A valid Azure Cosmos DB account connection string. |
## Delete
Delete documents from an Azure Cosmos DB container based on a query.
```
cosmic delete
```
| Argument | Description |
| - | - | 
| -p, --partition-key | Partition key of container e.g. 'id' |
| -q, --output-query | Output query before result. |
| -g, --global | Use queries from global store. |
| -c, --container-path | Container path e.g. \<connection>/\<database>/\<container> |
| -r, --output-request-charge | Output request charge (in RUs). |
| -l, --loop | Loops this operation multiple specified times with %I% as the iterator. |
## Query
Query an Azure Cosmos DB container.
```
cosmic query
```
| Argument | Description |
| - | - | 
| -q, --output-query | Output query before result. |
| -g, --global | Use queries from global store. |
| -c, --container-path | Container path e.g. \<connection>/\<database>/\<container> |
| -r, --output-request-charge | Output request charge (in RUs). |
| -l, --loop | Loops this operation multiple specified times with %I% as the iterator. |
## Store
Stores a query for later.
```
cosmic store
```
| Argument | Description |
| - | - | 
| -n, --name | A unique name for this query. |
| -g, --global | Store queries in global store. |
## Switch
Switches to a specific default container.
```
cosmic switch
```
| Argument | Description |
| - | - | 
## Upsert
Load data into an Azure Cosmos DB container.
```
cosmic upsert
```
| Argument | Description |
| - | - | 
| -d, --output-document | Output document before result. |
| -f, --file | File e.g. 'data.json' |
| -c, --container-path | Container path e.g. \<connection>/\<database>/\<container> |
| -r, --output-request-charge | Output request charge (in RUs). |
| -l, --loop | Loops this operation multiple specified times with %I% as the iterator. |
