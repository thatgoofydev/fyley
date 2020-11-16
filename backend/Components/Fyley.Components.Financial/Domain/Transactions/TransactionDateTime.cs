using System;
using DDDCore.Domain.ValueObjects;

namespace Fyley.Components.Financial.Domain.Transactions
{
    public class TransactionDateTime : SingleValueObject<string>
    {
        private const string Format = "yyyy-MM-dd HH:mm:ss";
        public static TransactionDateTime Now => new TransactionDateTime(DateTime.Now.ToString(Format));
        
        public TransactionDateTime(string value) : base(value)
        {
        }
    }
}