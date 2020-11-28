using Fyley.Components.Financial.Domain.Accounts;
using NUnit.Framework;

namespace Fyley.Components.Financial.Tests.Domain.Accounts
{
    [TestFixture]
    public class AccountDescriptionTests
    {
        public class ConstructorShould
        {
            [TestCase("name", "name")]
            [TestCase(null, null)]
            public void SetValue(string value, string expected)
            {
                // Act
                var result = new AccountDescription(value);
                
                // Assert
                Assert.That(result.Value, Is.EqualTo(expected));
            }
        }
    }
}