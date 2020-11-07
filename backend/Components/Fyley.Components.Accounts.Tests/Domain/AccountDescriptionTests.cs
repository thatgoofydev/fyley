using System;
using Fyley.Components.Accounts.Domain;
using Fyley.Components.Accounts.Domain.Errors;
using NUnit.Framework;

namespace Fyley.Components.Accounts.Tests.Domain
{
    [TestFixture]
    public class AccountDescriptionTests
    {
        public class ConstructorShould : AccountDescriptionTests
        {
            [Test]
            public void ThrowAccountDescriptionToLong_WhenValueIsLongerThan120()
            {
                Assert.Throws<AccountDescriptionToLong>(() => 
                    new AccountDescription("This is an even more ridiculously long string than the one in the account name test. This is because the description can have a total length of 120 characters. So this one is 179!"));
            }

            [TestCase("A-valid_description#1")]
            [TestCase("A valid description@2")]
            public void ReturnAccountDescription_WhenValueIsValid(string value)
            {
                Assert.DoesNotThrow(() =>
                {
                    var _ = new AccountDescription(value);
                });
            }
        }

        public class Equals : AccountDescriptionTests
        {
            [Test]
            public void DoesEqual()
            {
                Assert.That(new AccountDescription("description123"), Is.EqualTo(new AccountDescription("description123")));
            }
            
            [Test]
            public void DoesNotEqual()
            {
                Assert.That(new AccountDescription("description123"), Is.Not.EqualTo(new AccountDescription("--------------")));
            }
        }
        
        public class HasValueShould : AccountDescriptionTests
        {
            [Test]
            public void ReturnTrue_WhenValueIsNotNull()
            {
                var result = new AccountDescription("something");
                Assert.That(result.HasValue(), Is.True);
            }
            
            [Test]
            public void ReturnFalse_WhenValueIsNotNull()
            {
                var result = new AccountDescription(null);
                Assert.That(result.HasValue(), Is.False);
            }
        }
    }
}