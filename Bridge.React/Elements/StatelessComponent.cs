using System;
using System.Linq;

namespace Bridge.React
{
	public abstract class StatelessComponent<TProps>
	{
		protected TProps props { get; private set; }

		private static Func<TProps, ReactElement> _reactStatelessRenderFunction;
		private readonly ReactElement _reactElement;
		protected StatelessComponent(TProps props)
		{
			// Note: When preparing the "_reactStatelessRenderFunction" reference, a local "reactStatelessRenderFunction" alias is used - this is just so that the JavaScript
			// code further down (which calls React.createElement) can use this local alias and not have to know how Bridge stores static references.
			var reactStatelessRenderFunction = _reactStatelessRenderFunction;
			if (reactStatelessRenderFunction == null)
			{
				// The Render method expects there to be a "this.props" reference available. This means that we'll need to take the props argument that React.createElement
				// will pass to the "stateless component function" and set "this.props" in the scope in which the function will be executed. The props value needs "unwrapping"
				// since it gets passed in as a "value" property from createElement (see notes further down). This magic allows us to write a simple C# class for a stateless
				// component that then becomes a simple function call (where props are passed in) as far as React is concerned (and React has some performance tricks it can
				// pull for stateless "component functions" like this).
				Func<TProps, ReactElement> scopeBoundFunction = p =>
				{
					Script.Write("this.props = p ? p.value : p");
					return Render();
				};

				// We have an anonymous function for the renderer now but it would better to name it, since React Dev Tools will use show the function name (if defined) as
				// the component name in the tree. The only way to do this is, unfortunately, with eval - but the only dynamic content is the class name (which should be
				// safe to use since valid C# class names should be valid JavaScript function names, with no escaping required) and this work is only performed once per
				// class, since it is stored in a static variable - so the eval calls will be made very infrequently (so performance is not a concern).
				var className = this.GetClassName().Split(".").Last();
				Func<TProps, ReactElement> namedScopeBoundFunction = null;
				/*@
				eval("namedScopeBoundFunction = function " + className + "(props) { return scopeBoundFunction(props); };");
				 */
				reactStatelessRenderFunction = namedScopeBoundFunction;
				_reactStatelessRenderFunction = reactStatelessRenderFunction;
			}

			// When we pass the props reference to React.createElement, React's internals will rip it apart and reform it - which will cause problems if TProps is a
			// class with property getters and setters (or any other function) defined on the prototype, since members from the class prototype are not maintained
			// in this process. Wrapping the props reference into a "value" property gets around this problem, we just have to remember to unwrap them again when
			// we render. A similar technique is used in the stateful component.
			_reactElement = Script.Write<ReactElement>("React.createElement(reactStatelessRenderFunction, { value: props })");
		}

		public abstract ReactElement Render();

		public static implicit operator ReactElement(StatelessComponent<TProps> component)
		{
			if (component == null)
				throw new ArgumentNullException("component");

			return component._reactElement;
		}

		public static implicit operator ReactElementOrText(StatelessComponent<TProps> component)
		{
			if (component == null)
				throw new ArgumentNullException("component");

			return component._reactElement;
		}
	}
}
