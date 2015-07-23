using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private ViewModel _viewModel;
        public SimpleExampleStore(Element renderContainer, AppDispatcher dispatcher)
        {
            if (renderContainer == null)
                throw new ArgumentNullException("renderContainer");
            if (dispatcher == null)
                throw new ArgumentNullException("dispatcher");

            _renderContainer = renderContainer;
            _dispatcher = dispatcher;
            _viewModel = new ViewModel(lastUpdated: DateTime.Now, message: "Hi!", validationError: "");
            RenderIfActive();

            _dispatcher.Register(message =>
            {
                var recordChange = message.Action as RecordChangeAction<ViewModel>;
                if (recordChange != null)
                {
                    UserEdit(recordChange.Value);
                    return;
                }

                if (message.Action is TimePassedAction)
                {
                    _viewModel = new ViewModel(lastUpdated: DateTime.Now, message: _viewModel.Message, validationError: _viewModel.ValidationError);
                    RenderIfActive();
                    return;
                }
            });
        }

        private void UserEdit(ViewModel viewModel)
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
                    InputRow.New(
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

            _dispatcher.HandleViewAction(new RecordChangeAction<ViewModel>(
                new ViewModel(lastUpdated: DateTime.Now, message: message, validationError: (message.Trim() == "") ? "Why no message??" : "")
            ));
        }

        private class ViewModel
        {
            public ViewModel(DateTime lastUpdated, string message, string validationError)
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