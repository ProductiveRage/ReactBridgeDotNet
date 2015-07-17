using Bridge.Html5;

namespace Bridge.React
{
    [Name("React")]
    [Ignore]
    public static class React
    {
        [Name("render")]
        public static void Render(ReactElement element, Element container) { } // Implemented in React library
    }
}