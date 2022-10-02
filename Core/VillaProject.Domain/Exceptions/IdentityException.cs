﻿using System.Runtime.Serialization;

namespace VillaProject.Domain.Exceptions
{
    public class IdentityException : Exception
    {
        public IdentityException()
        {
        }

        public IdentityException(string? message) : base(message)
        {
        }

        public IdentityException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected IdentityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
