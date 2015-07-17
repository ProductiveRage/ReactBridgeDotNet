using System;
using Bridge.Html5;

namespace Bridge.React
{
    [ObjectLiteral]
    public class InputAttributes : HTMLAttributes
    {
        public Action<FormEvent<InputEventTarget>> onChange;
        public string value;
    }
}
