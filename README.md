<image src="https://raw.githubusercontent.com/creyke/Cosmic/master/Cosmic/icon.png" alt="Cosmic">

# Cosmic
A succinct and powerful command line query tool for Azure Cosmos DB.

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/CosmicCli/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)

## Summary
Cosmic makes it effortless to run ad-hoc or prepared queries against your Azure Cosmos DB containers for common usage scenarios such as:
- Selecting data
- Upserting data
- Deleting data
- Backing up data
- Troubleshooting performance or cost issues
- Sharing reusable, parameterisable queries

Cosmic is a tool for operating on **existing** Azure Cosmos DB collections. If you want to create and modify accounts, databases, and collections, then you should use the official Microsoft Azure CLI tool [az cosmosdb](https://docs.microsoft.com/en-us/cli/azure/cosmosdb).

## Installation
```
dotnet tool install -g cosmic
```

## Basic Usage
Connect to an Azure Cosmos DB account:
```
cosmic connect -n foo -c "AccountEndpoint=https://****.documents.azure.com:443/;AccountKey=****==;"
```

Switch to an active container you want to work with (optional):
```
cosmic switch foo/db/container
```

Query an Azure Cosmos DB account:
```
cosmic query "SELECT * FROM c"
```

## Documentation
The latest auto-generated [commands reference documentation](./Commands.md) is a good place to start. If you have a feature request or a bug then raise it as an [issue](https://github.com/creyke/Cosmic/issues). If you have any questions then visit the [Gitter community](https://gitter.im/CosmicCli/community).

## Further Examples
Delete documents from an Azure Cosmos DB account:
```
cosmic delete "SELECT * FROM c"
```

You can pipe data out to a file:
```
cosmic query "SELECT * FROM c" > data.json
```

...and then upsert data back in:
```
cosmic upsert data.json
```

...or  upsert a document directly:
```
cosmic upsert "{'id':'foo'}"
```

Measure RU cost:
```
cosmic query "SELECT * FROM c" -r
```

Check which container is active:
```
cosmic active
```

Store a query for later with default query parameters:
```
cosmic store -n myquery "SELECT * FROM c WHERE c.Type = '%%'" car
```

Execute a previously stored query with it's default query parameters:
```
cosmic query myquery
```

Execute a previously stored query with defined query parameter values:
```
cosmic query myquery boat
```

Output query text before result:
```
cosmic query myquery boat -q
```

Common aliases can be used either within a query or as a query parameter:
```
cosmic query "SELECT * FROM c WHERE c.Start >= %TODAY% AND c.Start <= %TOMORROW%"
```

Available aliases can be listed:
```
cosmic aliases
```

List connected Azure Cosmos DB accounts:
```
cosmic accounts
```

Loop using iterators:
```
cosmic upsert "{'id':'%I%'}" -l 10
```
