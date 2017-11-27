using HamsterSqueaks.Server.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Helpers
{
    /// <summary>
    /// Helpers for services.
    /// </summary>
    public static class ServiceHelpers
    {
        /// <summary>
        /// Throws a ModelMissingException if the model equals null.
        /// </summary>
        /// <param name="model">The model to be checked.</param>
        public static void ThrowIfMissing(object model)
        {
            if (model == null)
                throw new ModelMissingException($"The model is missing in the view model. Cannot edit the database entity.");
        }

        /// <summary>
        /// Throws a EntityNotFoundException if the dbModel equals null.
        /// </summary>
        /// <param name="dbModel">The dbModel to be checked.</param>
        public static void ThrowIfNotFound(object dbModel)
        {
            if (dbModel == null)
                throw new EntityNotFoundException($"The entity could not be found in the db. Are you sure the entity exists?");
        }
    }
}
