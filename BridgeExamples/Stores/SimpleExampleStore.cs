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
				message
					.If<RecordChangeAction<SimpleExampleStoreViewModel>>(action =>
					{
						_viewModel = action.Value;
					})
					.Else<TimePassedAction>(action =>
					{
						_viewModel = new SimpleExampleStoreViewModel(lastUpdated: DateTime.Now, message: _viewModel.Message, validationError: _viewModel.ValidationError);
					})
					.IfAnyMatched(OnChange);
			});
		}

		public event Action Change;

		/// <summary>
		/// This will never be null
		/// </summary>
		public SimpleExampleStoreViewModel State { get { return _viewModel; } }

		private void OnChange()
		{
			if (Change != null)
				Change();
		}
	}
}