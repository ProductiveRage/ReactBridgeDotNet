using System;
using Bridge.Html5;
using Bridge.React;

namespace BridgeExamples.Components
{
    public class InputRow : Component<InputRow.Props>
    {
        public static ReactElement New(string label, string value, Action<string> onChange, string validationError, string className = "")
        {
            // July 2015: When the version of Bridge.net after 1.7 is released, the following
            // line can be uncommented and the more verbose line below it remove
            //return New<TestComponent>(
            return Component<InputRow.Props>.New<InputRow>(
                new Props(label, value, onChange, validationError, className)
            );
        }
        private InputRow() { }

        public override ReactElement Render()
        {
            return DOM.Div(new HTMLAttributes { className = props.ClassName },
                DOM.Span(new HTMLAttributes { className = "label" }, props.Label),
                DOM.Input(new InputAttributes
                {
                    onChange = ev => props.OnChange(ev.target.value),
                    value = props.Value,
                }),
                DOM.Span(new HTMLAttributes { className = "error" }, props.ValidationError)
            );
        }

        public class Props
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
            /// This will be null, blank or whitespace-only
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