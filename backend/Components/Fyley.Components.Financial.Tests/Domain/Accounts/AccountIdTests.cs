using System;
using Fyley.Components.Financial.Domain.Accounts;
using NUnit.Framework;

namespace Fyley.Components.Financial.Tests.Domain.Accounts
{
    [TestFixture]
    public class AccountIdTests
    {
        [Test]
        public void Constructor()
        {
            var accountId = new AccountId(Guid.Parse("3bd8fce3-0191-4dfe-9ddb-30a70fe88fa6"));
            
            Assert.That(accountId.Value, Is.EqualTo(Guid.Parse("3bd8fce3-0191-4dfe-9ddb-30a70fe88fa6")));
        }
    }
}