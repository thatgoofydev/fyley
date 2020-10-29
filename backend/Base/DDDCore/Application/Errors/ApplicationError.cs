using System;

namespace DDDCore.Application.Errors
{
    public class ApplicationError : Exception
    {
        public ApplicationError()
        {
        }

        public ApplicationError(string message) : base(message)
        {
        }
    }
}