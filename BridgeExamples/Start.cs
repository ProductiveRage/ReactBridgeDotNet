using Bridge.Html5;
using Bridge.React;
using BridgeExamples.Actions;
using BridgeExamples.Components;
using BridgeExamples.Stores;

namespace BridgeExamples
{
    public class Start
    {
        [Ready]
        public static void Main()
        {
            var dispatcher = new AppDispatcher();
            var store = new SimpleExampleStore(dispatcher);

			React.Render(
				new App(store, dispatcher),
				Document.GetElementById("main")
			);

            Window.SetInterval(
                () => dispatcher.HandleServerAction(new TimePassedAction()),
                500
            );
        }
    }
}