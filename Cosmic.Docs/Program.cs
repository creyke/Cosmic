using CommandLine;
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

            typeof(Runtime).Assembly.GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof(ICommand)) && !x.ContainsGenericParameters)
                .OrderBy(x => x.Name)
                .ToList()
                .ForEach(x => CreatePage(doc, x, x.BaseType.GenericTypeArguments.First()));

            File.WriteAllText("../../../../Commands.md", doc.ToString());
        }

        private static void CreatePage(StringBuilder doc, Type commandType, Type optionsType)
        {
            var name = commandType.Name.Replace("Command", string.Empty);

            doc.AppendLine($"## {name}");

            var verbAttribute = (VerbAttribute)(optionsType.GetCustomAttributes(true).First());

            doc.AppendLine(verbAttribute.HelpText);

            doc.AppendLine(CodeBlock);

            doc.AppendLine($"cosmic {name.ToLowerInvariant()}");

            doc.AppendLine(CodeBlock);

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
