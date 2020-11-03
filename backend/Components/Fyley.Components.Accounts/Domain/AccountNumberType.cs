using System.Collections.Generic;
using System.Text.RegularExpressions;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Components.Accounts.Domain
{
    public abstract class AccountNumberType : Enumeration<AccountNumberType>
    {
        public static readonly AccountNumberType Other = new OtherAccountNumberType();
        public static readonly AccountNumberType Iban = new IbanAccountNumberType();

        private AccountNumberType(int value, string name) : base(value, name)
        {
        }

        public abstract bool IsValid(string value);
        
        private sealed class OtherAccountNumberType : AccountNumberType
        {
            public OtherAccountNumberType() : base(1, "Other")
            { }

            public override bool IsValid(string value) => true;
        }
        
        private sealed class IbanAccountNumberType : AccountNumberType
        {
            private const int MinLength = 5;
            private const int MaxLength = 34;
            private static readonly Regex AlphanumericRegex = new Regex("^[a-zA-Z0-9]*$");
            private static readonly Dictionary<string, int> LengthByCountryCode = new Dictionary<string, int>
            {
                { "AL", 28 }, { "AD", 24 }, { "AT", 20 }, { "AZ", 28 }, { "BH", 22 },
                { "BY", 28 }, { "BE", 16 }, { "BA", 20 }, { "BR", 29 }, { "BG", 22 },
                { "CR", 22 }, { "HR", 21 }, { "CY", 28 }, { "CZ", 24 }, { "DK", 18 },
                { "DO", 28 }, { "TL", 23 }, { "EG", 29 }, { "SV", 28 }, { "EE", 20 },
                { "FO", 18 }, { "FI", 18 }, { "FR", 27 }, { "GE", 22 }, { "DE", 22 },
                { "GI", 23 }, { "GR", 27 }, { "GL", 18 }, { "GT", 28 }, { "HU", 28 },
                { "IS", 26 }, { "IQ", 23 }, { "IE", 22 }, { "IL", 23 }, { "IT", 27 },
                { "JO", 30 }, { "KZ", 20 }, { "XK", 20 }, { "KW", 30 }, { "LV", 21 },
                { "LB", 28 }, { "LI", 21 }, { "LT", 20 }, { "LU", 20 }, { "MK", 19 },
                { "MT", 31 }, { "MR", 27 }, { "MU", 30 }, { "MC", 27 }, { "MD", 24 },
                { "ME", 22 }, { "NL", 18 }, { "NO", 15 }, { "PK", 24 }, { "PS", 29 },
                { "PL", 28 }, { "PT", 25 }, { "QA", 29 }, { "RO", 24 }, { "LC", 32 },
                { "SM", 27 }, { "ST", 25 }, { "SA", 24 }, { "RS", 22 }, { "SC", 31 },
                { "SK", 24 }, { "SI", 19 }, { "ES", 24 }, { "SE", 24 }, { "CH", 21 },
                { "TN", 24 }, { "TR", 26 }, { "UA", 29 }, { "AE", 23 }, { "GB", 22 },
                { "VA", 22 }, { "VG", 24 }, { "LY", 25 }
            };
            
            public IbanAccountNumberType() : base(2, "IBAN")
            { }

            public override bool IsValid(string value)
            {
                if (!AlphanumericRegex.IsMatch(value))
                {
                    return false;
                }
                
                if (value.Length < MinLength || value.Length > MaxLength)
                {
                    return false;
                }
                
                var countrycode = value.Substring(0, 2);
                if (!LengthByCountryCode.TryGetValue(countrycode, out var expectedLength))
                {
                    return false;
                }
                
                var actualLength = value.Length;
                if (actualLength != expectedLength)
                {
                    return false;
                }
                
                // TODO validate check digits
                
                return true;
            }
        }
    }
}