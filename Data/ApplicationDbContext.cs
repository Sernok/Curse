using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace MyProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RequestJournal> RequestJournals { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Executor> Executors { get; set; }
        public DbSet<ExternalManagementCompany> ExternalManagementCompanies { get; set; }
        public DbSet<RequestStatus> RequestStatuses { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; } // Added DbSet for RequestType

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestJournal>()
                .HasOne(rj => rj.House)
                .WithMany()
                .HasForeignKey(rj => rj.HouseId);

            modelBuilder.Entity<RequestJournal>()
                .HasOne(rj => rj.Executor)
                .WithMany()
                .HasForeignKey(rj => rj.ExecutorId);

            // Seed RequestTypes
            modelBuilder.Entity<RequestType>().HasData(
                new RequestType { Id = 1, TypeName = "Устранение утечек воды, газа" },
                new RequestType { Id = 2, TypeName = "Заявки на уборку и санитарное обслуживание" },
                new RequestType { Id = 3, TypeName = "Проверка работы систем отопления, вентиляции, кондиционирования" },
                new RequestType { Id = 4, TypeName = "Проверка пожарной сигнализации и систем безопасности" }
            );

            // Seed RequestStatuses
            modelBuilder.Entity<RequestStatus>().HasData(
                new RequestStatus { Id = 1, StatusName = "Зарегистрировано" },
                new RequestStatus { Id = 2, StatusName = "На рассмотрении" },
                new RequestStatus { Id = 3, StatusName = "Отправка специалиста" },
                new RequestStatus { Id = 4, StatusName = "Решено" },
                new RequestStatus { Id = 5, StatusName = "Не решено" }
            );
        }

        
    }
}
