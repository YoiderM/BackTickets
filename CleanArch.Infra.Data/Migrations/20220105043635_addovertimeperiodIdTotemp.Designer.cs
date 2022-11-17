﻿// <auto-generated />
using System;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Data.Migrations
{
    [DbContext(typeof(U27ApplicationDBContext))]
    [Migration("20220105043635_addovertimeperiodIdTotemp")]
    partial class addovertimeperiodIdTotemp
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Models.configuration.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CanChanged")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Models.configuration.Configuration", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("BoolId1")
                        .HasColumnType("bit");

                    b.Property<bool?>("BoolId2")
                        .HasColumnType("bit");

                    b.Property<bool?>("BoolId3")
                        .HasColumnType("bit");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("GuidId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GuidId2")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GuidId3")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("IntId")
                        .HasColumnType("int");

                    b.Property<int?>("IntId1")
                        .HasColumnType("int");

                    b.Property<int?>("IntId2")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("Domain.Models.ConfigurationDates.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Day")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastCreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Holidays");
                });

            modelBuilder.Entity("Domain.Models.Groups.PayrollAuthorize", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CampaignId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("PayrollAuthorizes");
                });

            modelBuilder.Entity("Domain.Models.Mekano.CostCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastCreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("CostCenters");
                });

            modelBuilder.Entity("Domain.Models.Mekano.MekanoUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Campaign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CostCenterId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Job")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastCreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CostCenterId");

                    b.ToTable("MekanoUsers");
                });

            modelBuilder.Entity("Domain.Models.Overtimes.OvertimeDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminObservation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Aproved")
                        .HasColumnType("bit");

                    b.Property<Guid?>("AprovedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AuthObservation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<string>("CampaingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CompensatoryApplies")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndHour")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InitialHour")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Names")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OvertimeDay")
                        .HasColumnType("datetime2");

                    b.Property<int?>("OvertimePeriodId")
                        .HasColumnType("int");

                    b.Property<Guid>("OvertimeTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OvertimeTypeName")
                        .HasColumnType("int");

                    b.Property<decimal?>("PaymentPercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("SundayNumber1")
                        .HasColumnType("bit");

                    b.Property<bool>("SundayNumbre2")
                        .HasColumnType("bit");

                    b.Property<decimal?>("TotalHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("User")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("UserStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OvertimePeriodId");

                    b.HasIndex("OvertimeTypeId");

                    b.ToTable("OvertimeDetails");
                });

            modelBuilder.Entity("Domain.Models.Overtimes.OvertimePeriod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndAllowedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndPeriodDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("LastCreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastUpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartAllowedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartPeriodDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("WeekNumber")
                        .HasColumnType("int");

                    b.Property<int?>("fortnight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("OvertimePeriods");
                });

            modelBuilder.Entity("Domain.Models.Overtimes.OvertimeTemp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AdminObservation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthObservation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CampaingName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("CompensatoryApplies")
                        .HasColumnType("bit");

                    b.Property<string>("CompensatoryAppliesText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndHour")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndHourText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("InitialHour")
                        .HasColumnType("datetime2");

                    b.Property<string>("InitialHourText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LoginTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoginTimeText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Names")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OvertimeDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("OvertimeDayText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OvertimePeriodId")
                        .HasColumnType("int");

                    b.Property<int?>("OvertimeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("OvertimeTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentPercent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<bool?>("SundayNumber1")
                        .HasColumnType("bit");

                    b.Property<bool?>("SundayNumbre2")
                        .HasColumnType("bit");

                    b.Property<decimal?>("TotalHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("User")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserDocument")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("UserStatus")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("OvertimeTemps");
                });

            modelBuilder.Entity("Domain.Models.Overtimes.OvertimeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UpdatedByName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("payPercent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("OvertimeTypes");
                });

            modelBuilder.Entity("Core.Models.configuration.Configuration", b =>
                {
                    b.HasOne("Core.Models.configuration.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Models.ConfigurationDates.Holiday", b =>
                {
                    b.HasOne("Core.Models.configuration.Configuration", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Domain.Models.Groups.PayrollAuthorize", b =>
                {
                    b.HasOne("Core.Models.configuration.Configuration", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("Domain.Models.Mekano.MekanoUser", b =>
                {
                    b.HasOne("Domain.Models.Mekano.CostCenter", "CostCenter")
                        .WithMany()
                        .HasForeignKey("CostCenterId");
                });

            modelBuilder.Entity("Domain.Models.Overtimes.OvertimeDetail", b =>
                {
                    b.HasOne("Domain.Models.Overtimes.OvertimePeriod", "OvertimePeriod")
                        .WithMany()
                        .HasForeignKey("OvertimePeriodId");

                    b.HasOne("Domain.Models.Overtimes.OvertimeType", "OvertimeType")
                        .WithMany()
                        .HasForeignKey("OvertimeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
