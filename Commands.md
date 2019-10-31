# Commands
This page is auto-generated from the source code of Cosmic.
## Accounts
List connected Azure Cosmos DB accounts.
### Examples
List connected Azure Cosmos DB accounts.:
```
cosmic accounts
```
## Active
Output the current active container.
### Examples
Output the current active container.:
```
cosmic active
```
## Aliases
List query aliases for common functions.
### Examples
List query aliases for common functions.:
```
cosmic aliases
```
## Connect
Connect to an Azure Cosmos DB account.
### Examples
Connect to an Azure Cosmos DB account.:
```
cosmic connect -n myaccount -c "AccountEndpoint=https://myaccount.documents.azure.com:443/;AccountKey=****==;"
```
| Argument | Description |
| - | - | 
| -n, --name | A unique name for this Azure Cosmos DB connection. |
| -c, --connection-string | A valid Azure Cosmos DB account connection string. |
## Delete
Delete documents from an Azure Cosmos DB container based on a query.
### Examples
Delete documents from an Azure Cosmos DB container based on a query.:
```
cosmic delete "SELECT * FROM c"
```
Delete with a non-id partition key.:
```
cosmic delete "SELECT * FROM c" -p Tenant
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
### Examples
Query an Azure Cosmos DB container.:
```
cosmic query "SELECT * FROM c"
```
Output query and/or request charges.:
```
cosmic query "SELECT * FROM c" -q -r
```
Query using supported aliases.:
```
cosmic query "SELECT * FROM c WHERE c.UtcStart > %NOW%"
```
Query using arguments.:
```
cosmic query "SELECT * FROM c WHERE c.Size > %% AND c.Vehicle = '%%'" 3 boat
```
Execute a stored query.:
```
cosmic query myquery
```
Execute a stored query using arguments.:
```
cosmic query myquery 3 boat
```
Executes query from global store rather than current working directory.:
```
cosmic query -g myquery
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
### Examples
Stores a query for later.:
```
cosmic store -n myquery "SELECT * FROM c"
```
Stores a parametisable query for later.:
```
cosmic store -n myquery "SELECT * FROM c WHERE c.Size > %% AND c.Vehicle = '%%'" 3 boat
```
Stores query in global store rather than current working directory.:
```
cosmic store -n -g myquery "SELECT * FROM c"
```
| Argument | Description |
| - | - | 
| -n, --name | A unique name for this query. |
| -g, --global | Store queries in global store. |
## Switch
Switches to a specific default container.
### Examples
Switches to a specific default container.:
```
cosmic switch myaccount/mydatabase/mycontainer
```
| Argument | Description |
| - | - | 
## Upsert
Load data into an Azure Cosmos DB container.
### Examples
Load document into an Azure Cosmos DB container.:
```
cosmic upsert "{'id':'0'}"
```
Load documents from file.:
```
cosmic upsert -f mydocs.json
```
Loop and load 3 documents.:
```
cosmic upsert "{'id':'%I%'}" -l 3
```
| Argument | Description |
| - | - | 
| -d, --output-document | Output document before result. |
| -f, --file | File e.g. 'data.json' |
| -c, --container-path | Container path e.g. \<connection>/\<database>/\<container> |
| -r, --output-request-charge | Output request charge (in RUs). |
| -l, --loop | Loops this operation multiple specified times with %I% as the iterator. |
