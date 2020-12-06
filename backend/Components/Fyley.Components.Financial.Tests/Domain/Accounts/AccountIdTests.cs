using System;
using FluentAssertions;
using Fyley.Components.Financial.Domain.Accounts;
using Xunit;

namespace Fyley.Components.Financial.Tests.Domain.Accounts
{
    public class AccountIdTests
    {
        [Fact]
        public void Constructor()
        {
            var accountId = new AccountId(Guid.Parse("3bd8fce3-0191-4dfe-9ddb-30a70fe88fa6"));
            
            accountId.Value.Should().Be(Guid.Parse("3bd8fce3-0191-4dfe-9ddb-30a70fe88fa6"));
        }
    }
}