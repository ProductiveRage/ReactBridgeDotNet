namespace Bridge.React
{
    [Ignore]
    public class FormEvent : SyntheticEvent
    {
        public EventTarget target;
    }

    [Ignore]
    public class FormEvent<T> : FormEvent where T : EventTarget
    {
        public new T target;
    }
}