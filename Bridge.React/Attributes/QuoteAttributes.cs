using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public sealed class QuoteAttributes : DomElementWithEventsAttributes<QuoteElement>
    {
        public string Cite { private get; set; }
    }
}
