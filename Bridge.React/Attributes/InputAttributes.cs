using System;
using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public sealed class InputAttributes : InputElement
    {
		[Name("onchange")]
		public new Action<EventFor<InputElement>> OnChange;
    }
}
