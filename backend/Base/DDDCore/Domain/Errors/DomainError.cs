using System;

namespace DDDCore.Domain.Errors
{
    public abstract class DomainError : Exception
    {
        protected DomainError()
        { }

        protected DomainError(string message) : base(message)
        { }
    }
}