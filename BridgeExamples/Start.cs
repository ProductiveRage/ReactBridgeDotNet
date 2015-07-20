using Bridge.Html5;
using Bridge.React;
using BridgeExamples.Actions;
using BridgeExamples.Stores;

namespace BridgeExamples
{
    public class Start
    {
        [Ready]
        public static void Main()
        {
            var dispatcher = new AppDispatcher();
            new SimpleExampleStore(
                Document.GetElementById("main"),
                dispatcher
            );
            Window.SetInterval(
                () => dispatcher.HandleServerAction(new TimePassedAction()),
                500
            );
        }
    }
}