using System;
using Bridge.React;
using BridgeExamples.Actions;
using BridgeExamples.Stores;

namespace BridgeExamples.Components
{
	public class App : Component<App.Props, App.State>
	{
		public App(SimpleExampleStore store, AppDispatcher dispatcher) : base(new Props(store, dispatcher)) { }

		protected override void ComponentWillMount() { props.Store.Change += OnChange; }
		protected override void ComponentWillUnmount() { props.Store.Change -= OnChange; }
		private void OnChange()
		{
			SetState(new State(
                props.Store.LastUpdated,
                props.Store.Message,
                props.Store.ValidationError
            ));
        }

		public override ReactElement Render()
		{
            if (this.state == null)
                return null;

			return DOM.Div(
				null,
				DOM.H1(null, "React in Bridge.NET"),
				new InputRow(
					className: "example-input-row",
					label: state.LastUpdated,
					value: state.Message,
					onChange: value => props.Dispatcher.HandleViewAction(new MessageChangeAction(value)),
					validationError: state.ValidationError
				)
			);
		}

		public sealed class Props
		{
			public Props(SimpleExampleStore store, AppDispatcher dispatcher)
			{
				if (store == null)
					throw new ArgumentNullException("store");
				if (dispatcher == null)
					throw new ArgumentNullException("dispatcher");

				Store = store;
				Dispatcher = dispatcher;
			}

			/// <summary>
			/// This will never be null
			/// </summary>
			public SimpleExampleStore Store { get; private set; }

			/// <summary>
			/// This will never be null
			/// </summary>
			public AppDispatcher Dispatcher { get; private set; }
		}

        public sealed class State
        {
            public State(DateTime lastUpdated, string message, string validationError)
            {
                if (message == null)
                    throw new ArgumentNullException("message");
                if (validationError == null)
                    throw new ArgumentNullException("validationError");

                LastUpdated = lastUpdated.ToString("HH:mm:ss");
                Message = message;
                ValidationError = validationError;
            }

            /// <summary>
            /// This will never be null
            /// </summary>
            public string LastUpdated { get; private set; }

            /// <summary>
            /// This will never be null
            /// </summary>
            public string Message { get; private set; }

            /// <summary>
            /// This will never be null
            /// </summary>
            public string ValidationError { get; private set; }
        }
    }
}
