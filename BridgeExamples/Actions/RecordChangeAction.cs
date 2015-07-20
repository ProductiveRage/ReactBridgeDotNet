using System;
using Bridge.React;

namespace BridgeExamples.Actions
{
    public class RecordChangeAction<T> : IDispatcherAction
    {
        public RecordChangeAction(T value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            Value = value;
        }

        /// <summary>
        /// This will never be null
        /// </summary>
        public T Value { get; private set; }
    }
}
