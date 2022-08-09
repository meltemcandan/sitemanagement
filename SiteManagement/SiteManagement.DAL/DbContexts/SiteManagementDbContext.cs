using Microsoft.EntityFrameworkCore;
using SiteManagement.Model.Entities;

namespace SiteManagement.DAL.DbContexts
{
    public class SiteManagementDbContext : DbContext
    {
        public SiteManagementDbContext(DbContextOptions<SiteManagementDbContext> options) : base(options)
        {

        }

        public DbSet<BlockEntity> Blocks { get; set; }

        public DbSet<DebtEntity> Debts { get; set; }

        public DbSet<DebtTypeEntity> DebtTypes { get; set; }

        public DbSet<FlatEntity> Flats { get; set; }

        public DbSet<FlatTypeEntity> FlatTypes { get; set; }

        public DbSet<MessageEntity> Messages { get; set; }

        public DbSet<MessageStateEntity> MessageStates { get; set; }

        public DbSet<MonthEntity> Months { get; set; }

        public DbSet<PaymentTypeEntity> PaymentTypes { get; set; }

        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<PersonPasswordEntity> PersonPasswords { get; set; }

        public DbSet<PersonTypeEntity> PersonTypes { get; set; }

        public DbSet<SiteEntity> Sites { get; set; }

        public DbSet<YearEntity> Years { get; set; }
    }
}
