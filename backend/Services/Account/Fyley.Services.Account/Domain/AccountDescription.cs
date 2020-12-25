using DDDCore.Domain.ValueObjects;
using JetBrains.Annotations;

namespace Fyley.Services.Account.Domain
{
    public class AccountDescription : SingleValueObject<string>
    {
        public AccountDescription([CanBeNull] string value) : base(value)
        { }
    }
}