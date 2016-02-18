using System;
using Bridge.React;

namespace BridgeExamples.Actions
{
    /// <summary>
    /// If your application uses specialised Stores for various views / pages then the router component can send StoreInitialisedAction instances through the
    /// Dispatcher, informing the appropriate Store that it needs to wake up (and allowing Stores for other views / pages to go to sleep). Note that in this
    /// example application, there is no router and there is only a single Store, but this action is still useful in that it kicks everything off after all
    /// of the dependencies have been initialised.
    /// </summary>
	public sealed class StoreInitialisedAction : IDispatcherAction
	{
		public StoreInitialisedAction(object store)
		{
			if (store == null)
				throw new ArgumentNullException("store");

            Store = store;
		}

		/// <summary>
		/// This will never be null
		/// </summary>
		public object Store { get; private set; }
	}
}
