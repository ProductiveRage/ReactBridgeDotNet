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

	public static class RecordChangeAction
	{
		/// <summary>
		/// This may be used rather than the constructor so that type inference means that the type of "value" need not be specified in the calling code
		/// </summary>
		public static RecordChangeAction<T> New<T>(T value) { return new RecordChangeAction<T>(value); }
	}
}
