using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public sealed class OutputAttributes : DomElementWithEventsAttributes<OutputElement>
    {
        public string DefaultValue { private get; set; }
        public string Name { private get; set; }
        public string Type { private get; set; }
    }
}
