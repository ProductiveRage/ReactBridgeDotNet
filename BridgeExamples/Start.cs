using Bridge.Html5;
using Bridge.React;

namespace BridgeExamples
{
    public class Start
    {
        [Ready]
        public static void Main()
        {
            React.Render(
                TestComponent.New(new TestComponent.Props(label: "Name")),
                Document.GetElementById("main")
            );
        }
    }
}