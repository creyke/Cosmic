using CommandLine;
using Cosmic.Attributes;

namespace Cosmic.Commands.Accounts
{
    [Verb("accounts", HelpText = "List connected Azure Cosmos DB accounts.")]
    [Example("accounts", HelpText = "List connected Azure Cosmos DB accounts.")]
    public class AccountsOptions
    {
    }
}