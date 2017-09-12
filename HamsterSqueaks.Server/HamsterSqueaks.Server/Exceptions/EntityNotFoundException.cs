﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamsterSqueaks.Server.Exceptions
{
    /// <summary>
    /// Throw when a database entity cannot be found.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string message) : base(message)
        {
        }

        public EntityNotFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
