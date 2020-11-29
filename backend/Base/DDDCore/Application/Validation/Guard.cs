using System;

namespace DDDCore.Application.Validation
{
    public static class Guard
    {
        public static void ArgumentNotNull(string name, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}