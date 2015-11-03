using System;
using Bridge.React;
using BridgeExamples.Actions;

namespace BridgeExamples.Stores
{
	public class SimpleExampleStore
	{
		private readonly AppDispatcher _dispatcher;
		private SimpleExampleStoreViewModel _viewModel;
		public SimpleExampleStore(AppDispatcher dispatcher)
		{
			if (dispatcher == null)
				throw new ArgumentNullException("dispatcher");

			_dispatcher = dispatcher;
			_viewModel = new SimpleExampleStoreViewModel(lastUpdated: DateTime.Now, message: "Hi!", validationError: "");
			OnChange();

			_dispatcher.Register(message =>
			{
				var recordChange = message.Action as RecordChangeAction<SimpleExampleStoreViewModel>;
				if (recordChange != null)
				{
					_viewModel = recordChange.Value;
					OnChange();
					return;
				}

				if (message.Action is TimePassedAction)
				{
					_viewModel = new SimpleExampleStoreViewModel(lastUpdated: DateTime.Now, message: _viewModel.Message, validationError: _viewModel.ValidationError);
					OnChange();
					return;
				}
			});
		}

		public event Action Change;
		public SimpleExampleStoreViewModel State { get { return _viewModel; } }

		private void OnChange()
		{
			if (Change != null)
				Change();
		}
	}
}