using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.Models.Submit
{
    public class SubmitAccountRequest
    {
        public string Name { get; [UsedImplicitly] set; }
        public string Description { get; [UsedImplicitly] set; }
        public AccountNumberTypes AccountNumberType { get; [UsedImplicitly] set; }
        public string AccountNumber { get; [UsedImplicitly] set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum AccountNumberTypes
        {
            Other = 1,
            Iban = 2
        }
    }
}