using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public sealed class OListAttributes : DomElementWithEventsAttributes<OListElement>
    {
        public bool Reversed { private get; set; }
        public int Start { private get; set; }
        public OListType Type { private get; set; }
    }
}
