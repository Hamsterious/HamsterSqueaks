using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Exceptions
{
    /// <summary>
    /// Throw when a ViewModels model has not been added.
    /// </summary>
    [Serializable]
    public class ModelMissingException : Exception
    {
        public ModelMissingException()
        {
        }

        public ModelMissingException(string message) : base(message)
        {
        }

        public ModelMissingException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
