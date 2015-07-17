namespace Bridge.React
{
    [Ignore]
    public class FormEvent : SyntheticEvent
    {
        [Name("target")]
        public EventTarget target;
    }

    [Ignore]
    public class FormEvent<T> : FormEvent where T : EventTarget
    {
        [Name("target")]
        public new T target;
    }
}