using DDDCore.Domain.ValueObjects;

namespace Fyley.Services.Transactions.Domain
{
    /// <summary>
    /// Currencies as described by ISO 4217
    /// <remarks>https://www.currency-iso.org/en/home/tables/table-a1.html</remarks>
    /// </summary>
    public class Currency : Enumeration<Currency>
    {
        public static Currency Euro = new Currency(978, "EUR");
        
        private Currency(int value, string name) : base(value, name)
        { }
    }
}