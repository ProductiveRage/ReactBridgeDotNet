namespace Bridge.React
{
    [Name("React.DOM")]
    [Ignore]
    public static class DOM
    {
        [Name("div")]
        public extern static ReactElement Div(HTMLAttributes properties, params ReactElementOrText[] children);

        [Name("h1")]
        public extern static ReactElement H1(HTMLAttributes properties, params ReactElementOrText[] children);

        [Name("input")]
        public extern static ReactElement Input(InputAttributes properties, params ReactElementOrText[] children);
        
        [Name("span")]
        public extern static ReactElement Span(HTMLAttributes properties, params ReactElementOrText[] children);
    }
}
