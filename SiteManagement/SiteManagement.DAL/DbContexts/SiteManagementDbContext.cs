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

        public DbSet<DebtTypeEntity> DebtTypes { get; set; }

        public DbSet<DebtEntity> Debts { get; set; }

        public DbSet<FlatEntity> Flats { get; set; }

        public DbSet<FlatTypeEntity> FlatTypes { get; set; }

        public DbSet<MessageEntity> Messages { get; set; }

        public DbSet<MessageStateEntity> MessageStates { get; set; }

        public DbSet<MonthEntity> Months { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<UserPasswordEntity> UserPasswords { get; set; }

        public DbSet<UserTypeEntity> UserTypes { get; set; }

        public DbSet<SiteEntity> Sites { get; set; }

        public DbSet<YearEntity> Years { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MessageStateEntity>().HasData(
                   new UserTypeEntity
                   {
                       Id = 1,
                       Name = "Okundu"
                   },
                    new UserTypeEntity
                    {
                        Id = 2,
                        Name = "Okunmadı"
                    }
               );

            modelBuilder.Entity<UserTypeEntity>().HasData(
                   new UserTypeEntity
                   {
                       Id = 1,
                       Name = "Daire Sahibi"
                   },
                    new UserTypeEntity
                    {
                        Id = 2,
                        Name = "Kiracı"
                    }
               );

            modelBuilder.Entity<FlatTypeEntity>().HasData(
                    new FlatTypeEntity
                    {
                        Id = 1,
                        Name = "1 + 1 Daire"
                    },
                     new FlatTypeEntity
                     {
                         Id = 2,
                         Name = "2 + 1 Daire"
                     },
                      new FlatTypeEntity
                      {
                          Id = 3,
                          Name = "3 + 1 Daire"
                      },
                      new FlatTypeEntity
                      {
                          Id = 4,
                          Name = "4 + 1 Daire"
                      },
                      new FlatTypeEntity
                      {
                          Id = 5,
                          Name = "4 + 2 Daire"
                      },
                      new FlatTypeEntity
                      {
                          Id = 6,
                          Name = "6 + 2 Dublex"
                      }
                );

            modelBuilder.Entity<DebtTypeEntity>().HasData(
                  new DebtTypeEntity
                  {
                      Id = 1,
                      Name = "Aidat"
                  },
                   new DebtTypeEntity
                   {
                       Id = 2,
                       Name = "Yakıt"
                   },
                   new DebtTypeEntity
                   {
                       Id = 3,
                       Name = "Elektrik"
                   },
                   new DebtTypeEntity
                   {
                       Id = 4,
                       Name = "Su"
                   },
                   new DebtTypeEntity
                   {
                       Id = 5,
                       Name = "Doğal Gaz"
                   }
              );

            modelBuilder.Entity<YearEntity>().HasData(
                    new YearEntity
                    {
                        Id = 1,
                        Name = "2020"
                    },
                     new YearEntity
                     {
                         Id = 2,
                         Name = "2021"
                     },
                      new YearEntity
                      {
                          Id = 3,
                          Name = "2022"
                      },
                      new YearEntity
                      {
                          Id = 4,
                          Name = "2023"
                      },
                      new YearEntity
                      {
                          Id = 5,
                          Name = "2024"
                      },
                      new YearEntity
                      {
                          Id = 6,
                          Name = "2025"
                      }
                );

            modelBuilder.Entity<MonthEntity>().HasData(
                    new MonthEntity
                    {
                        Id = 1,
                        Name = "Ocak"
                    },
                     new MonthEntity
                     {
                         Id = 2,
                         Name = "Şubat"
                     },
                      new MonthEntity
                      {
                          Id = 3,
                          Name = "Mart"
                      },
                      new MonthEntity
                      {
                          Id = 4,
                          Name = "Nisan"
                      },
                      new MonthEntity
                      {
                          Id = 5,
                          Name = "Mayıs"
                      },
                      new MonthEntity
                      {
                          Id = 6,
                          Name = "Haziran"
                      },
                      new MonthEntity
                      {
                          Id = 7,
                          Name = "Temmuz"
                      },
                      new MonthEntity
                      {
                          Id = 8,
                          Name = "Ağustos"
                      },
                      new MonthEntity
                      {
                          Id = 9,
                          Name = "Eylül"
                      },
                      new MonthEntity
                      {
                          Id = 10,
                          Name = "Ekim"
                      },
                      new MonthEntity
                      {
                          Id = 11,
                          Name = "Kasım"
                      },
                      new MonthEntity
                      {
                          Id = 12,
                          Name = "Aralık"
                      }
                );
        }
    }
}
