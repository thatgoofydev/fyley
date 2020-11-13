using System;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class TransactionDateTime : SingleValueObject<string>
    {
        private const string Format = "yyyyMMdd HH:mm:ss";
        public static TransactionDateTime Now => new TransactionDateTime(DateTime.Now);
        
        public TransactionDateTime(string value) : base(value)
        {
        }

        private TransactionDateTime(DateTime dateTime) : this(dateTime.ToString(Format))
        {
        }
        
        // public DateTime AsDateTime()
        // {
        //     return DateTime.ParseExact(Value, Format, null, DateTimeStyles.None);
        // }

    }
}