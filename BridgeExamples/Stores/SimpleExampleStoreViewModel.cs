using System;

namespace BridgeExamples.Stores
{
    public class SimpleExampleStoreViewModel
    {
		public SimpleExampleStoreViewModel(DateTime lastUpdated, string message, string validationError)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (validationError == null)
                throw new ArgumentNullException("validationError");

            LastUpdated = lastUpdated.ToString("HH:mm:ss");
            Message = message;
            ValidationError = validationError;
        }

        /// <summary>
        /// This will never be null
        /// </summary>
        public string LastUpdated { get; private set; }

        /// <summary>
        /// This will never be null
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// This will never be null
        /// </summary>
        public string ValidationError { get; private set; }
    }
}