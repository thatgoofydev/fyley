using DDDCore.Domain.ValueObjects;
using Fyley.Components.Accounts.Domain.Errors;
using JetBrains.Annotations;

namespace Fyley.Components.Accounts.Domain
{
    public class AccountDescription : SingleValueObject<string>
    {
        private const int MaxLength = 120;
        
        public AccountDescription([CanBeNull] string value) : base(value)
        {
            if (value != null && value.Length > MaxLength) throw new AccountDescriptionToLong(MaxLength);
        }

        public bool HasValue()
        {
            return Value != null;
        }
    }
}