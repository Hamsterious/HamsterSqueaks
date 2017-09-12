using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Exceptions
{
    [Serializable]
    public class InvalidModelStateException : Exception
    {
        public ModelStateDictionary ModelState { get; set; }

        public InvalidModelStateException() { }

        public InvalidModelStateException(string message) : base(message) { }

        public InvalidModelStateException(ModelStateDictionary modelState)
        {
            ModelState = modelState;
        }

        public InvalidModelStateException(string message, Exception inner) : base(message, inner) { }

        public InvalidModelStateException(string message, ModelStateDictionary modelState) : base(message)
        {
            ModelState = modelState;
        }

        public InvalidModelStateException(string message, Exception inner, ModelStateDictionary modelState) : base(message, inner)
        {
            ModelState = modelState;
        }

        protected InvalidModelStateException(
          SerializationInfo info,
          StreamingContext context
        ) : base(info, context) { }
    }
}
