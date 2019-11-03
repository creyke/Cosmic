using CommandLine;
using Cosmic.Attributes;
using Cosmic.Commands;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Cosmic.Docs
{
    class Program
    {
        const string CodeBlock = "```";

        static void Main(string[] args)
        {
            var doc = new StringBuilder();

            doc.AppendLine("# Commands");
            doc.AppendLine("This page is auto-generated from the source code of Cosmic.");

            var types = typeof(Runtime).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(ICommand)) && !x.ContainsGenericParameters)
                .OrderBy(x => x.Name)
                .ToList();

            types.ForEach(x =>
            {
                var name = x.Name.Replace("Command", string.Empty);
                doc.AppendLine($"- [{name}](#{name.ToLowerInvariant()})");
            });

            types.ForEach(x => CreatePage(doc, x, x.BaseType.GenericTypeArguments.First()));

            File.WriteAllText("../../../../Commands.md", doc.ToString());
        }

        private static void CreatePage(StringBuilder doc, Type commandType, Type optionsType)
        {
            var name = commandType.Name.Replace("Command", string.Empty);

            doc.AppendLine($"## {name}");

            var i = 0;
            optionsType.GetCustomAttributes(true)
                .ToList()
                .ForEach(x =>
                {
                    if (i == 0)
                    {
                        doc.AppendLine(((VerbAttribute)x).HelpText);
                    }
                    else
                    {
                        if (i == 1)
                        {
                            doc.AppendLine("### Examples");
                        }
                        var e = (ExampleAttribute)x;
                        doc.AppendLine($"{e.HelpText}:");
                        doc.AppendLine(CodeBlock);
                        doc.AppendLine($"cosmic {e.Example}");
                        doc.AppendLine(CodeBlock);
                    }
                    i++;
                });

            var properties = optionsType.GetProperties();

            if (!properties.Any())
            {
                return;
            }

            doc.AppendLine("| Argument | Description |");
            doc.AppendLine("| - | - | ");

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttributes(true).First();
                switch (attribute)
                {
                    case OptionAttribute o:
                        doc.AppendLine($"| -{o.ShortName}, --{o.LongName} | {o.HelpText.Replace("<", @"\<")} |");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
