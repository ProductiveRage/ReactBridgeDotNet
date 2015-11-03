using System;
using Bridge.React;
using BridgeExamples.Actions;
using BridgeExamples.Stores;

namespace BridgeExamples.Components
{
	public class App : Component<App.Props, SimpleExampleStoreViewModel>
	{
		public App(SimpleExampleStore store, AppDispatcher dispatcher) : base(new Props(store, dispatcher)) { }

		protected override void ComponentWillMount() { props.Store.Change += OnChange; }
		protected override void ComponentWillUnmount() { props.Store.Change -= OnChange; }
		private void OnChange()
		{
			SetState(props.Store.State);
		}

		public override ReactElement Render()
		{
			var state = this.state ?? props.Store.State;
			return DOM.Div(
				null,
				DOM.H1(null, "React in Bridge.NET"),
				new InputRow(
					className: "example-input-row",
					label: state.LastUpdated,
					value: state.Message,
					onChange: UpdateMessage,
					validationError: state.ValidationError
				)
			);
		}

		private void UpdateMessage(string message)
		{
			if (message == null)
				throw new ArgumentNullException("message");

			props.Dispatcher.HandleViewAction(RecordChangeAction.New(
				new SimpleExampleStoreViewModel(lastUpdated: DateTime.Now, message: message, validationError: (message.Trim() == "") ? "Why no message??" : "")
			));
		}

		public class Props
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
	}
}
