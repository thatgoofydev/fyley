using System;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Accounts.Migrations
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var accountsFactory = new AccountsContextFactory();
            var accountsContext = accountsFactory.CreateDbContext(new string[0]);
            
            accountsContext.Database.Migrate();
            Console.WriteLine("Migrated Accounts");
        }
    }
}