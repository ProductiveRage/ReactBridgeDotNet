using System;

namespace Bridge.React
{
    [Ignore]
    public class SyntheticEvent
    {
        public bool bubbles;
        public bool cancelable;
        public bool defaultPrevented;
        public Action preventDefault;
        public Action stopPropagation;
        public string type;
    }
}