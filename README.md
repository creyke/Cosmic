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

Query an Azure Cosmos DB account:
```
cosmic query foo/db/container "SELECT * FROM c"
```
