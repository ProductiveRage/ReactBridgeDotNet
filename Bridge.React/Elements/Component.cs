using System;

namespace Bridge.React
{
    public abstract class Component<TProps>
    {
        public static ReactElement New<TComponent>(TProps props) where TComponent : Component<TProps>
        {
            if (props == null)
                throw new ArgumentNullException("props");

            return Script.Call<ReactElement>("React.createElement", typeof(TComponent), new PropsWrapper { Props = props });
        }

        [Name("render")]
        public abstract ReactElement Render();

        [Name("unwrappedProps")]
        protected TProps props
        {
            get { return wrappedProps.Props; }
        }

        /// <summary>
        /// When a props reference is passed through React.createElement, it gets torn to pieces and the individual properties that are declared explicitly on the object
        /// are copied on to a new React-approved version of the props data. This means that anything declared on a prototype (such as property getter and setter functions,
        /// for example) will be lost. The workaround for this is to wrap the props data up in an object literal when it's passed to React - this way there is only a
        /// single property to copy around, which React will happily do since it doesn't try to monkey about with nested data. To avoid derived classes from having to be
        /// aware of this props indirection, the real "props" reference is readable with this private property (whose value will be set by React in the createElement call)
        /// and the unwrapped data exposed through the protected props property above (which is mapped onto the name "unwrappedProps" so that it doesn't clash with the real
        /// "props" reference - which is the wrapped data - while allowing it to be called "props" for the C# derived types). While it's not strictly necessary for the
        /// PropsWrapper type to be represented by an ObjectLiteral, it makes no sense to represent it with a full Bridge.net JavaScript and so the ObjectLiteral
        /// attribute is used to decorate that type.
        /// </summary>
        [Name("props")]
        private readonly PropsWrapper wrappedProps = null; // This will be set by React

        [ObjectLiteral]
        private class PropsWrapper
        {
            public TProps Props;
        }
    }
}
