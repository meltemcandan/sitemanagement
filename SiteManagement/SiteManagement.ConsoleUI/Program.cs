using SiteManagement.DAL.DbContexts;
using SiteManagement.Model.Entities;
using System;

namespace SiteManagement.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var conn = new SiteManagementDbContext())
            {
                var year = new YearEntity()
                {
                    
                };


                conn.Years.Add(cat2);
                conn.SaveChanges();
            }
        }
    }
}
