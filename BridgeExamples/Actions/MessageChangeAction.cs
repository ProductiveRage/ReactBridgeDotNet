using System;
using Bridge.React;

namespace BridgeExamples.Actions
{
	public class MessageChangeAction : IDispatcherAction
	{
		public MessageChangeAction(string value)
		{
			if (value == null)
				throw new ArgumentNullException("value");

			Value = value;
		}

		/// <summary>
		/// This will never be null
		/// </summary>
		public string Value { get; private set; }
	}
}
