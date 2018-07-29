﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tax.CompanyModuleService.UnitOfWork;

namespace Tax.CompanyModuleService.Migrations
{
    [DbContext(typeof(EfDbContext))]
    [Migration("20180729105905_migrationFirst")]
    partial class migrationFirst
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Tax.ICompanyModuleService.Domain.BaseModel.Models.TbCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addr");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TbCompany");
                });

            modelBuilder.Entity("Tax.ICompanyModuleService.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addr");

                    b.Property<int>("BusinessState");

                    b.Property<string>("LegalPerson");

                    b.Property<int>("LegalPersonPhone");

                    b.Property<string>("LinkMan");

                    b.Property<int>("LinkManPhone");

                    b.Property<string>("Name");

                    b.Property<double>("RegisterCapital");

                    b.Property<DateTime>("RegisterTime");

                    b.Property<string>("TaxNumber");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Tax.ICompanyModuleService.Domain.Entities.Shareholder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<bool>("ElectronicTaxAccount");

                    b.Property<bool>("ElectronicTaxPwd");

                    b.Property<bool>("HaveElectronicTax");

                    b.Property<string>("IDNumber");

                    b.Property<string>("LandTaxLogoffDes");

                    b.Property<string>("LandTaxState");

                    b.Property<string>("Name");

                    b.Property<string>("NationalTaxLogoffDes");

                    b.Property<string>("NationalTaxState");

                    b.Property<double>("Percent");

                    b.Property<string>("RigsterAddr");

                    b.Property<int>("TaxpayerType");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Shareholder");
                });

            modelBuilder.Entity("Tax.ICompanyModuleService.Domain.Entities.Shareholder", b =>
                {
                    b.HasOne("Tax.ICompanyModuleService.Domain.Entities.Company")
                        .WithMany("Shareholders")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}