using System;
using Microsoft.EntityFrameworkCore;

namespace Fyley.Services.Account.Infrastructure.Migrations
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var contextFactory = new AccountContextFactory();
            var context = contextFactory.CreateDbContext(args);
            
            context.Database.Migrate();
            Console.WriteLine("Migrated Financial DB");
        }
    }
}