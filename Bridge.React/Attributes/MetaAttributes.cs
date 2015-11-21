using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public sealed class MetaAttributes : DomElementWithEventsAttributes<MetaElement>
    {
        public string Content { private get; set; }
        public string HttpEquiv { private get; set; }
        public string Name { private get; set; }
    }
}
