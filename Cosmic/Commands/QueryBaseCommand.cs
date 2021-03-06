﻿using Cosmic.Aliases;
using Cosmic.Data;
using Cosmic.Extensions;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmic.Commands
{
    public abstract class QueryBaseCommand<TOptions> : OperationCommand<TOptions>
        where TOptions : QueryBaseOptions
    {
        protected List<dynamic> Docs { get; private set; }

        protected async override Task<int> ExecuteCommandAsync(TOptions options)
        {
            await base.ExecuteCommandAsync(options);

            string query = null;
            QueryData queryData = null;

            if (options.Query.Contains(' '))
            {
                query = options.Query;
            }
            else
            {
                DirectoryInfo queriesDir = null;

                if (options.Global)
                {
                    var appDir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
                    var cosmicDir = appDir.CreateSubdirectory("cosmic");
                    queriesDir = cosmicDir.CreateSubdirectory("queries");
                }
                else
                {
                    queriesDir = new DirectoryInfo(".");
                }

                var queryLocation = $"{queriesDir}/{options.Query}";
                if (queryLocation.EndsWith(".json"))
                {
                    queryLocation = queryLocation.Substring(0, queryLocation.Length - 5);
                }

                var queryFile = await File.ReadAllTextAsync($"{queryLocation}.json");
                queryData = JsonConvert.DeserializeObject<QueryData>(queryFile);
                query = queryData.Query;
            }

            var parameters = new string[]
            {
                options.Value1, options.Value2, options.Value3,
                options.Value4, options.Value5, options.Value6,
                options.Value7, options.Value8, options.Value9
            };

            var paramId = 0;

            parameters
                .TakeWhile(x => x != null)
                .ToList()
                .ForEach(x => {
                    paramId++;
                    query = query.ReplaceFirst("%%", x);
                });

            while (query.Contains("%%"))
            {
                query = query.ReplaceFirst("%%", queryData.Parameters[paramId].DefaultValue);
                paramId++;
            }

            query = new AliasProcessor().Process(query, DateTime.UtcNow, iterator);

            if (options.OutputQuery)
            {
                Console.WriteLine(query);
            }

            var queryDefinition = new QueryDefinition(query);
            var queryResultSetIterator = Container.GetItemQueryIterator<dynamic>(queryDefinition);

            Docs = new List<dynamic>();

            while (queryResultSetIterator.HasMoreResults)
            {
                var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                LogRequestCharge(currentResultSet.RequestCharge);
                foreach (dynamic doc in currentResultSet)
                {
                    Docs.Add(doc);
                }
            }

            return 0;
        }
    }
}
