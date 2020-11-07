using Fyley.Components.Accounts.Domain;
using NUnit.Framework;

namespace Fyley.Components.Accounts.Tests.Domain
{
    [TestFixture]
    public class MoneyTests
    {
        [Test]
        public void ShouldEqual()
        {
            var one = new Money(20.00m);
            var two = new Money(20.00m);
            var result = one.Equals(two);
            Assert.That(result, Is.True);
        }
        
        [Test]
        public void ShouldNotEqual()
        {
            var one = new Money(20.00m);
            var two = new Money(25.00m);
            var result = one.Equals(two);
            Assert.That(result, Is.False);
        }
    }
}