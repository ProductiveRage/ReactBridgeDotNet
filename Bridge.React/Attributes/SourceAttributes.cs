using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public sealed class SourceAttributes : DomElementWithEventsAttributes<SourceElement>
    {
        public string Media { private get; set; }
        public string Src { private get; set; }
        public string Type { private get; set; }
    }
}
