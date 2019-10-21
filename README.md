# Cosmic
A succinct and powerful command line query tool for Azure Cosmos DB

## Installation
```
dotnet tool install --global cosmic
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

You can pipe data out to a file...
```
cosmic query "SELECT * FROM c" > data.json
```

...and then upsert data back in:
```
cosmic upsert data.json
```
