using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Fyley.BFF.Desktop.Components.Financial.Accounts.WebApi.Models.Submit
{
    public class SubmitAccountRequest
    {
        public string Name { get; [UsedImplicitly] set; }
        public string Description { get; [UsedImplicitly] set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountNumberType AccountNumberType { get; [UsedImplicitly] set; }
        public string AccountNumber { get; [UsedImplicitly] set; }
    }

    public enum AccountNumberType
    {
        Iban,
        Other
    }
}