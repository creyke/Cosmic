using System;

namespace Cosmic.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExampleAttribute : Attribute
    {
        public string Example { get; }
        public string HelpText { get; set; }

        public ExampleAttribute(string example)
        {
            Example = example;
        }
    }
}
