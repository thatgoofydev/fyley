using Fyley.Components.Dossiers.Domain;
using Fyley.Components.Dossiers.Domain.Errors;
using NUnit.Framework;

namespace Fyley.Components.Dossiers.Tests.Domain
{
    [TestFixture]
    public class DossierNameTests
    {
        public class ConstructorShould : DossierNameTests
        {
            [TestCase("1")]
            [TestCase("12")]
            public void ThrowDossierNameToShort_WhenValueHasALengthShorterThanThree(string value)
            {
                Assert.Throws<DossierNameToShort>(() =>
                {
                    var _ = new DossierName(value);
                });
            }

            [TestCase("dossier#2")]
            [TestCase("dossier@home")]
            [TestCase("dossier()")]
            [TestCase("dossier{}")]
            public void ThrowInvalidDossierName_WhenValueContainsAnyNonAlphanumericCharacter(string value)
            {
                Assert.Throws<InvalidDossierName>(() =>
                {
                    var _ = new DossierName(value);
                });
            }

            [Test]
            public void ReturnDossierName()
            {
                const string value = "validDossierName";

                Assert.DoesNotThrow(() =>
                {
                    var _ = new DossierName(value);
                });
            }
        }
        
        public class EqualsShould : DossierNameTests
        {
            [Test]
            public void ReturnFalse_WhenValueIsNotTheSame()
            {
                var dossierName1 = new DossierName("dossier1");
                var dossierName2 = new DossierName("dossier2");

                var result = dossierName1.Equals(dossierName2);
                
                Assert.That(result, Is.False);
            }
            
            [Test]
            public void ReturnTrue_WhenValueIsTheSame()
            {
                var dossierName1 = new DossierName("dossier1");
                var dossierName2 = new DossierName("dossier1");

                var result = dossierName1.Equals(dossierName2);
                
                Assert.That(result, Is.True);
            }
        }

        public class EqualsOperatorShould : DossierNameTests
        {
            [Test]
            public void ReturnFalse_WhenValueIsNotTheSame()
            {
                var dossierName1 = new DossierName("dossier1");
                var dossierName2 = new DossierName("dossier2");

                var result = dossierName1 == dossierName2;
                
                Assert.That(result, Is.False);
            }
            
            [Test]
            public void ReturnTrue_WhenValueIsTheSame()
            {
                var dossierName1 = new DossierName("dossier1");
                var dossierName2 = new DossierName("dossier1");

                var result = dossierName1 == dossierName2;
                
                Assert.That(result, Is.True);
            }
        }

        public class NotEqualsOperatorShould : DossierNameTests
        {
            [Test]
            public void ReturnTrue_WhenValueIsNotTheSame()
            {
                var dossierName1 = new DossierName("dossier1");
                var dossierName2 = new DossierName("dossier2");

                var result = dossierName1 != dossierName2;
                
                Assert.That(result, Is.True);
            }
            
            [Test]
            public void ReturnFalse_WhenValueIsTheSame()
            {
                var dossierName1 = new DossierName("dossier1");
                var dossierName2 = new DossierName("dossier1");

                var result = dossierName1 != dossierName2;
                
                Assert.That(result, Is.False);
            }
        }
    }
}