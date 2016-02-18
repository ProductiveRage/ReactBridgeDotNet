using System;
using Bridge.React;

namespace BridgeExamples.Components
{
    public sealed class InputRow : PureComponent<InputRow.Props>
    {
        public InputRow(string label, string value, Action<string> onChange, string validationError, string className = "")
			: base(new Props(label, value, onChange, validationError, className)) { }

        public override ReactElement Render()
        {
			return DOM.Div(new Attributes { ClassName = props.ClassName },
				DOM.Span(new Attributes { ClassName = "label" }, props.Label),
                DOM.Input(new InputAttributes
                {
                    OnChange = ev => props.OnChange(ev.CurrentTarget.Value),
					Value = props.Value,
                }),
				DOM.Span(new Attributes { ClassName = "error" }, props.ValidationError)
            );
        }

        public sealed class Props
        {
            public Props(string label, string value, Action<string> onChange, string validationError, string className = "")
            {
                if (className == null)
                    throw new ArgumentNullException("className");
                if (string.IsNullOrWhiteSpace(label))
                    throw new ArgumentException("Null/blank label specified");
                if (value == null)
                    throw new ArgumentNullException("value");
                if (onChange == null)
                    throw new ArgumentNullException("onChange");
                if (validationError == null)
                    throw new ArgumentNullException("validationError");

                ClassName = className;
                Label = label;
                Value = value;
                OnChange = onChange;
                ValidationError = validationError;
            }

            /// <summary>
            /// This will never be null, though it may be blank
            /// </summary>
            public string ClassName { get; private set; }

            /// <summary>
            /// This will never be null, blank or whitespace-only
            /// </summary>
            public string Label { get; private set; }

            /// <summary>
            /// This will never be null, though it may be blank
            /// </summary>
            public string Value { get; private set; }

            /// <summary>
            /// This will never be null
            /// </summary>
            public Action<string> OnChange { get; private set; }
            
            /// <summary>
            /// This will never be null, though it may be blank
            /// </summary>
            public string ValidationError { get; private set; }
        }
    }
}