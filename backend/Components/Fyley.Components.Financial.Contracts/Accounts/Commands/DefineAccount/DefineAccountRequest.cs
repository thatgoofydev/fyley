namespace Fyley.Components.Financial.Contracts.Accounts.Commands.DefineAccount
{
    public class DefineAccountRequest
    {
        /**
         * The name of the account to define.
         */
        public string Name { get; set; }
        
        /**
         * The description of the account to define.
         */
        public string Description { get; set; }
        
        /**
         * The account number of the account to define.
         */
        public string AccountNumber { get; set; }
        
        /*
         * The type of account number to define.
         * 
         * 1 => Other
         * 2 => Iban
         */
        public int AccountNumberType { get; set; }
    }
}