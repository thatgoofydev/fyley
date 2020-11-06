using System;
using Fyley.Components.Accounts.Domain;
using NUnit.Framework;

namespace Fyley.Components.Accounts.Tests.Domain
{
    [TestFixture]
    public class AccountIdTests
    {
        [Test]
        public void ShouldEqual()
        {
            var one = new AccountId(Guid.Parse("5a604e0c-3417-4664-8ea6-9f2a5b7b9d64"));
            var two = new AccountId(Guid.Parse("5a604e0c-3417-4664-8ea6-9f2a5b7b9d64"));
            Assert.That(one, Is.EqualTo(two));
        }
        
        [Test]
        public void ShouldNotEqual()
        {
            var one = new AccountId(Guid.Parse("5a604e0c-3417-4664-8ea6-9f2a5b7b9d64"));
            var two = new AccountId(Guid.Empty);
            Assert.That(one, Is.Not.EqualTo(two));
        }
    }
}