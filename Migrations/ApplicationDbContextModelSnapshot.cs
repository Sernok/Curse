﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyProject.Data;

#nullable disable

namespace Curse.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyProject.Models.Executor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Executors");
                });

            modelBuilder.Entity("MyProject.Models.ExternalManagementCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ContractEndDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ExternalManagementCompanies");
                });

            modelBuilder.Entity("MyProject.Models.House", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExternalManagementCompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("HasExternalManagementContract")
                        .HasColumnType("bit");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsManagedByUs")
                        .HasColumnType("bit");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExternalManagementCompanyId");

                    b.ToTable("Houses");
                });

            modelBuilder.Entity("MyProject.Models.RequestJournal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApartmentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<int>("HouseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsUrgent")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProblemDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestStatusId")
                        .HasColumnType("int");

                    b.Property<int>("RequestTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("RequiresClientPresence")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("HouseId");

                    b.HasIndex("RequestStatusId");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("RequestJournals");
                });

            modelBuilder.Entity("MyProject.Models.RequestStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            StatusName = "Зарегистрировано"
                        },
                        new
                        {
                            Id = 2,
                            StatusName = "На рассмотрении"
                        },
                        new
                        {
                            Id = 3,
                            StatusName = "Отправка специалиста"
                        },
                        new
                        {
                            Id = 4,
                            StatusName = "Решено"
                        },
                        new
                        {
                            Id = 5,
                            StatusName = "Не решено"
                        });
                });

            modelBuilder.Entity("MyProject.Models.RequestType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RequestTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            TypeName = "Устранение утечек воды, газа"
                        },
                        new
                        {
                            Id = 2,
                            TypeName = "Заявки на уборку и санитарное обслуживание"
                        },
                        new
                        {
                            Id = 3,
                            TypeName = "Проверка работы систем отопления, вентиляции, кондиционирования"
                        },
                        new
                        {
                            Id = 4,
                            TypeName = "Проверка пожарной сигнализации и систем безопасности"
                        });
                });

            modelBuilder.Entity("MyProject.Models.House", b =>
                {
                    b.HasOne("MyProject.Models.ExternalManagementCompany", "ExternalManagementCompany")
                        .WithMany()
                        .HasForeignKey("ExternalManagementCompanyId");

                    b.Navigation("ExternalManagementCompany");
                });

            modelBuilder.Entity("MyProject.Models.RequestJournal", b =>
                {
                    b.HasOne("MyProject.Models.Executor", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyProject.Models.House", "House")
                        .WithMany()
                        .HasForeignKey("HouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyProject.Models.RequestStatus", "RequestStatus")
                        .WithMany()
                        .HasForeignKey("RequestStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyProject.Models.RequestType", "RequestType")
                        .WithMany()
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Executor");

                    b.Navigation("House");

                    b.Navigation("RequestStatus");

                    b.Navigation("RequestType");
                });
#pragma warning restore 612, 618
        }
    }
}