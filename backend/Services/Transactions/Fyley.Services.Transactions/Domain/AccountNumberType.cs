using System.Collections.Generic;
using System.Text.RegularExpressions;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Services.Transactions.Domain
{
    public abstract class AccountNumberType : Enumeration<AccountNumberType>
    {
        public static readonly AccountNumberType Other = new OtherAccountNumberType();
        public static readonly AccountNumberType Iban = new IbanAccountNumberType();

        private AccountNumberType(int value, string name) : base(value, name)
        { }

        public abstract ValidationResult IsValid(string value);

        public abstract string Format(string value);
        
        public class ValidationResult
        {
            public bool IsValid { get; }
            public string Error { get; }

            private ValidationResult(bool isValid, string error)
            {
                IsValid = isValid;
                Error = error;
            }

            internal static ValidationResult Failed(string error)
            {
                return new ValidationResult(false, error);
            }

            internal static ValidationResult Success()
            {
                return new ValidationResult(true, null);
            }
        }
        
        private sealed class OtherAccountNumberType : AccountNumberType
        {
            public OtherAccountNumberType() : base(1, "Beneficiary")
            { }

            public override ValidationResult IsValid(string value) => ValidationResult.Success();

            public override string Format(string value) => value;
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
            
            public IbanAccountNumberType() : base(2, "Iban")
            { }

            public override ValidationResult IsValid(string value)
            {
                value = Strip(value);
                
                if (value.Length < MinLength)
                {
                    return ValidationResult.Failed($"A IBAN should have a length of at least '{MinLength}' characters.");
                }

                if (value.Length > MaxLength)
                {
                    return ValidationResult.Failed($"A IBAN cannot exceed the maximum length of '{MaxLength}' characters.");
                }
                
                if (!AlphanumericRegex.IsMatch(value))
                {
                    return ValidationResult.Failed("A IBAN can only contain alphanumeric characters.");
                }
                
                var isoCountryCode = value.Substring(0, 2);
                if (!LengthByCountryCode.TryGetValue(isoCountryCode, out var expectedLength))
                {
                    return ValidationResult.Failed($"'{isoCountryCode}' is not a valid country code for an IBAN");
                }
                
                var actualLength = value.Length;
                if (actualLength != expectedLength)
                {
                    return ValidationResult.Failed($"A IBAN from '{isoCountryCode}' should have a length of '{expectedLength}'.");
                }
                
                // TODO validate check digits
                
                return ValidationResult.Success();
            }

            public override string Format(string value)
            {
                return Strip(value);
            }

            private static string Strip(string value)
            {
                return value.Replace(" ", string.Empty)
                    .Replace("-", string.Empty);
            }
        }
    }
}