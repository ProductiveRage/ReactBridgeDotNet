using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public sealed class MeterAttributes : DomElementWithEventsAttributes<MeterElement>
    {
        public double High { private get; set; }
        public double Low { private get; set; }
        public double Max { private get; set; }
        public double Min { private get; set; }
        public double Optimum { private get; set; }
    }
}
