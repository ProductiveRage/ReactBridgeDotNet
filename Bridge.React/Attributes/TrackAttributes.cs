using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public sealed class TrackAttributes : DomElementWithEventsAttributes<TrackElement>
    {
        public string Kind { private get; set; }
        public string Src { private get; set; }
        [Name("srclang")]
        public string SrcLang { private get; set; }
        public string Label { private get; set; }
        public bool Default { private get; set; }
    }
}
