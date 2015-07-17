using System;
using Bridge.Html5;
using Bridge.React;

namespace BridgeExamples
{
    public class TestComponent : Component<TestComponent.Props>
    {
        public static ReactElement New(Props props)
        {
            // July 2015: When the version of Bridge.net after 1.7 is released, the following
            // line can be uncommented and the more verbose line below it remove
            //return New<TestComponent>(props);
            return Component<TestComponent.Props>.New<TestComponent>(props);
        }
        private TestComponent() { }

        public override ReactElement Render()
        {
            return DOM.Div(new HTMLAttributes { className = "test-wrapper" },
                props.Label,
                DOM.Input(new InputAttributes {
                    className = "text-box",
                    onChange = ev => { Console.WriteLine("onChange: " + ev.target.value); },
                    value = "a"
                })
            );
        }

        public class Props
        {
            public Props(string label)
            {
                if (string.IsNullOrWhiteSpace(label))
                    throw new ArgumentException("Null/blank label specified");
                Label = label;
            }
            public string Label { get; set; }
        }
    }
}