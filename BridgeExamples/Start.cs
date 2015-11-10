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

            // This action would usually be fired off by a router to inform the Store for the current URL that it needs to
            // wake up, but in this example there is only a single Store! Sending it the StoreInitialisedAction means that
            // it can fire its OnChange event which the App component is waiting for, to know that it's show time.
            dispatcher.HandleViewAction(new StoreInitialisedAction(store));

            Window.SetInterval(
                () => dispatcher.HandleServerAction(new TimePassedAction()),
                500
            );
        }
    }
}