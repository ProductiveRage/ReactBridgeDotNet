using System;
using Bridge.React;
using BridgeExamples.Actions;

namespace BridgeExamples.Stores
{
	public class SimpleExampleStore
	{
		private readonly AppDispatcher _dispatcher;
		public SimpleExampleStore(AppDispatcher dispatcher)
		{
			if (dispatcher == null)
				throw new ArgumentNullException("dispatcher");

			_dispatcher = dispatcher;

            LastUpdated = DateTime.Now;
            Message = "Hi!";
            ValidationError = "";

			_dispatcher.Register(message =>
			{
				message
                    .If<MessageChangeAction>(action =>
                    {
                        Message = action.Value;
                        ValidationError = (action.Value.Trim() == "") ? "Why no message??" : "";
                    })
					.Else<TimePassedAction>(action => LastUpdated = DateTime.Now)
					.IfAnyMatched(OnChange);
			});
		}

		public event Action Change;

        public DateTime LastUpdated { get; private set; }

        /// <summary>
        /// This will never be null
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// This will never be null
        /// </summary>
        public string ValidationError { get; private set; }

		private void OnChange()
		{
			if (Change != null)
				Change();
		}
	}
}