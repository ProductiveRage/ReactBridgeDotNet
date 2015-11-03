using System;
using Bridge.Html5;
using Bridge.React;
using BridgeExamples.Actions;
using BridgeExamples.Components;

namespace BridgeExamples.Stores
{
	public class SimpleExampleStore
	{
        private readonly Element _renderContainer;
		private readonly AppDispatcher _dispatcher;
        private SimpleExampleStoreViewModel _viewModel;
        public SimpleExampleStore(Element renderContainer, AppDispatcher dispatcher)
		{
            if (renderContainer == null)
                throw new ArgumentNullException("renderContainer");
			if (dispatcher == null)
				throw new ArgumentNullException("dispatcher");

            _renderContainer = renderContainer;
			_dispatcher = dispatcher;
			_viewModel = new SimpleExampleStoreViewModel(lastUpdated: DateTime.Now, message: "Hi!", validationError: "");
            RenderIfActive();

			_dispatcher.Register(message =>
			{
				var recordChange = message.Action as RecordChangeAction<SimpleExampleStoreViewModel>;
				if (recordChange != null)
				{
					UserEdit(recordChange.Value);
					return;
				}

				if (message.Action is TimePassedAction)
				{
					_viewModel = new SimpleExampleStoreViewModel(lastUpdated: DateTime.Now, message: _viewModel.Message, validationError: _viewModel.ValidationError);
                    RenderIfActive();
					return;
				}
			});
		}

		private void UserEdit(SimpleExampleStoreViewModel viewModel)
		{
			if (viewModel == null)
				throw new ArgumentNullException("viewModel");

			_viewModel = viewModel;
            RenderIfActive();
        }

        private void RenderIfActive()
        {
            React.Render(
                DOM.Div(
                    null,
                    DOM.H1(null, "React in Bridge.NET"),
                    new InputRow(
                        className: "example-input-row",
                        label: _viewModel.LastUpdated,
                        value: _viewModel.Message,
                        onChange: UpdateMessage,
                        validationError: _viewModel.ValidationError
                    )
                ),
                _renderContainer
            );
        }

        private void UpdateMessage(string message)
        {
            if (message == null)
                throw new ArgumentNullException("message");

			_dispatcher.HandleViewAction(new RecordChangeAction<SimpleExampleStoreViewModel>(
				new SimpleExampleStoreViewModel(lastUpdated: DateTime.Now, message: message, validationError: (message.Trim() == "") ? "Why no message??" : "")
            ));
		}
	}
}