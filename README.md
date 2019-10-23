<image src="https://raw.githubusercontent.com/creyke/Cosmic/master/Cosmic/icon.png" alt="Cosmic">

# Cosmic
A succinct and powerful command line query tool for Azure Cosmos DB

## Summary
If you are doing any of the following things you can benefit from Cosmic:
- Developing applications which read and/or write data to Azure Cosmos DB.
- Responsible for supporting an Azure Cosmos DB solution.
- Troubleshooting performance or cost issues with Azure Cosmos DB.
- Wanting to share reusable, parameterisable queries with other members of your team.

## Installation
```
dotnet tool install -g cosmic
```

## Usage
Connect to an Azure Cosmos DB account:
```
cosmic connect -n foo -c AccountEndpoint=https://****.documents.azure.com:443/;AccountKey=****==;
```

Switch to an active container you want to work with (optional):
```
cosmic switch foo/db/container
```

Query an Azure Cosmos DB account (where 'foo' is the name of a previously created connection):
```
cosmic query "SELECT * FROM c"
```

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

List connected Azure Cosmos DB accounts:
```
cosmic accounts
```
