﻿using Bridge.Html5;

namespace Bridge.React
{
    [Name("React")]
    [Ignore]
    public static class React
    {
        [Name("render")]
        public extern static void Render(ReactElement element, Element container);
    }
}