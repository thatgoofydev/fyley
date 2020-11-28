using DDDCore.Domain.ValueObjects;
using JetBrains.Annotations;

namespace Fyley.Components.Financial.Domain.Accounts
{
    public class AccountDescription : SingleValueObject<string>
    {
        public AccountDescription([CanBeNull] string value) : base(value)
        { }
    }
}