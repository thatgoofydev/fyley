using System;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Components.Financial.Migrations
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var contextFactory = new FinancialContextFactory();
            var context = contextFactory.CreateDbContext(args);
            
            context.Database.Migrate();
            Console.WriteLine("Migrated Financial DB");
        }
    }
}