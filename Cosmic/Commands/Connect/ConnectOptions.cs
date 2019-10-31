using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Connect
{
    [Verb("connect", HelpText = "Connect to an Azure Cosmos DB account.")]
    [Example("connect -n myaccount -c \"AccountEndpoint=https://myaccount.documents.azure.com:443/;AccountKey=****==;\"", HelpText = "Connect to an Azure Cosmos DB account.")]
    public class ConnectOptions
    {
        [Option('n', "name", Required = true, HelpText = "A unique name for this Azure Cosmos DB connection.")]
        public string Name { get; set; }

        [Option('c', "connection-string", Required = true, HelpText = "A valid Azure Cosmos DB account connection string.")]
        public string ConnectionString { get; set; }
    }
}
