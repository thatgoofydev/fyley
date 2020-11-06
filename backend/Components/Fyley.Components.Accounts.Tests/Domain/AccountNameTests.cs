using System;
using Fyley.Components.Accounts.Domain;
using Fyley.Components.Accounts.Domain.Errors;
using NUnit.Framework;

namespace Fyley.Components.Accounts.Tests.Domain
{
    [TestFixture]
    public class AccountNameTests
    {
        
        public class ConstructorShould : AccountNameTests
        {
            [TestCase(null)]
            [TestCase("")]
            [TestCase("   ")]
            public void ThrowArgumentNullException_WhenValueIsNullOrEmptyOrWhitespace(string value)
            {
                Assert.Throws<ArgumentNullException>(() => new AccountName(value));
            }

            [Test]
            public void ThrowAccountNameToLong_WhenNameIsLongerThan40()
            {
                Assert.Throws<AccountNameToLong>(() =>
                    new AccountName("Some Weirdly long name that is way more than 40 characters."));
            }

            [TestCase("{}[]&|é\"'(§^è!ç{à})[^$]")]
            [TestCase("¨*ù´µ`%£,?;.:/=~+<>\\²³")]
            public void ThrowInvalidAccountName_WhenNameContainsAnythingNon_Alphanumeric_Spaces_Dashed_Underscore_At_Hashtag_LeftBrace_Or_RightBrace(string value)
            {
                Assert.Throws<InvalidAccountName>(() => new AccountName(value));
            }

            [TestCase("abcdefghijklmnopqrstuvwxyz")]
            [TestCase("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
            [TestCase("0123456789")]
            [TestCase(" - _ @ # ( ) ")]
            public void ReturnAccountName(string value)
            {
                Assert.DoesNotThrow(() =>
                {
                    var _ = new AccountName(value);
                });
            }
        }

        public class Equals : AccountNameTests
        {
            [Test]
            public void DoesEqual()
            {
                Assert.That(new AccountName("account123"), Is.EqualTo(new AccountName("account123")));
            }
            
            [Test]
            public void DoesNotEqual()
            {
                Assert.That(new AccountName("account123"), Is.Not.EqualTo(new AccountName("----------")));
            }
        }
    }
}