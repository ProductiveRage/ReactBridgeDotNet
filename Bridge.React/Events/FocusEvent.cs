﻿using Bridge.Html5;

namespace Bridge.React
{
    [Ignore]
    public sealed class FocusEvent<TCurrentTarget> : SyntheticEvent<TCurrentTarget> where TCurrentTarget : Element
    {
        private FocusEvent() { }

        public readonly Element RelatedTarget;
    }
}
