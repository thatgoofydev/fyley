using System;
using Fyley.Components.Financial.Domain.Shared;
using Fyley.Components.Financial.Domain.Shared.Errors;
using NUnit.Framework;

namespace Fyley.Components.Financial.Tests.Domain.Shared
{
    [TestFixture]
    public class AccountNameTests
    { 
        public class ConstructorShould : AccountNameTests
        {
            [Test]
            public void ThrowArgumentNullException_WhenValueIsNull()
            {
                // Act + Assert
                var exception = Assert.Throws<ArgumentNullException>(() =>
                {
                    var _ = new AccountName(null);
                });
                
                Assert.That(exception.ParamName, Is.EqualTo("value"));
            }

            [Test]
            public void ThrowAccountNameToLong_WhenNameToLong()
            {
                var exception = Assert.Throws<AccountNameToLong>(() =>
                {
                    var _ = new AccountName("abcdefghijklmnopqrstuvwxyz abcdefghijklmnopqrstuvwxyz");
                });
                
                Assert.That(exception.Message, Contains.Substring("is to long"));
            }

            [Test]
            public void NowChangeValue()
            {
                // Act
                var accountName = new AccountName("Some account name");
                
                // Assert
                Assert.That(accountName.Value, Is.EqualTo("Some account name"));
            }
        }

        public class EqualShould : AccountNameTests
        {
            [Test]
            public void Equal()
            {
                // Arrange
                var accountName1 = new AccountName("Some account name");
                var accountName2 = new AccountName("Some account name");
                
                // Act
                var result = accountName1.Equals(accountName2);

                // Assert
                Assert.That(result, Is.True);
            }
            
            [Test]
            public void NotEqual()
            {
                // Arrange
                var accountName1 = new AccountName("Some account name");
                var accountName2 = new AccountName("Some other account name");
                
                // Act
                var result = accountName1.Equals(accountName2);

                // Assert
                Assert.That(result, Is.False);
            }
        }
    }
}