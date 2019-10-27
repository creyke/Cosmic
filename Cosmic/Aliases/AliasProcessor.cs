using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmic.Aliases
{
    public class AliasProcessor
    {
        public List<AliasGroup> Groups { get; }

        public AliasProcessor()
        {
            Groups = new List<AliasGroup>
            {
                new AliasGroup
                {
                    Name = "Time",
                    Aliases = new List<Alias>
                    {
                        new YesterdayAlias(),
                        new TodayAlias(),
                        new TomorrowAlias(),
                        new Tomorrow_EndAlias(),
                        new Last_WeekAlias(),
                        new This_WeekAlias(),
                        new Next_WeekAlias(),
                        new Next_Week_EndAlias()
                    }
                }
            };
        }

        public string Process(string query, DateTime utcNow)
        {
            Groups.ForEach(x => x.Aliases.ForEach(y =>
            {
                if (query.Contains(y.Key))
                {
                    query = query.Replace(y.Key, y.Generate(utcNow));
                }
            }));

            return query;
        }
    }
}
