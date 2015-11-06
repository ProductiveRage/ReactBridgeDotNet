using Bridge.Html5;

namespace Bridge.React
{
	[Ignore]
	public sealed class EventFor<T> : Event where T : Element
	{
		private EventFor(string type) : base(type) { }
		private EventFor(string type, EventInit eventInit) : base(type, eventInit) { }

		public new readonly T CurrentTarget;
	}
}
