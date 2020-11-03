﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProcessSIM.Infrastructure.Data;

namespace ProcessSIM.Application.Migrations
{
    [DbContext(typeof(SimContext))]
    [Migration("20200516172018_AddStepToSimHistory")]
    partial class AddStepToSimHistory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Auth.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.ProcedureHistory", b =>
                {
                    b.Property<int>("ProcedureHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EndTime")
                        .HasColumnType("int");

                    b.Property<string>("ProcedureAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProcedureName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SimulationHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("StartTime")
                        .HasColumnType("int");

                    b.Property<int>("WaitingTime")
                        .HasColumnType("int");

                    b.HasKey("ProcedureHistoryId");

                    b.HasIndex("SimulationHistoryId");

                    b.ToTable("ProcedureHistory");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.RandomEventHistory", b =>
                {
                    b.Property<int>("RandomEventHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EndTime")
                        .HasColumnType("int");

                    b.Property<string>("EventAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcedureHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("StartTime")
                        .HasColumnType("int");

                    b.HasKey("RandomEventHistoryId");

                    b.HasIndex("ProcedureHistoryId");

                    b.ToTable("RandomEventHistory");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.ResourceHistory", b =>
                {
                    b.Property<int>("ResourceHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Downtime")
                        .HasColumnType("int");

                    b.Property<int>("ResourceId")
                        .HasColumnType("int");

                    b.Property<string>("ResourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SimulationHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("UseTime")
                        .HasColumnType("int");

                    b.HasKey("ResourceHistoryId");

                    b.HasIndex("SimulationHistoryId");

                    b.ToTable("ResourceHistory");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.ResourceUseHistory", b =>
                {
                    b.Property<int>("ResourceUseHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EndTime")
                        .HasColumnType("int");

                    b.Property<int?>("ResourceHistoryId")
                        .HasColumnType("int");

                    b.Property<int>("StartTime")
                        .HasColumnType("int");

                    b.HasKey("ResourceUseHistoryId");

                    b.HasIndex("ResourceHistoryId");

                    b.ToTable("ResourceUseHistory");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.SimulationHistory", b =>
                {
                    b.Property<int>("SimulationHistoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Complexity")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("SimulationNameId")
                        .HasColumnType("int");

                    b.Property<int>("Step")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WaitingTime")
                        .HasColumnType("int");

                    b.HasKey("SimulationHistoryId");

                    b.HasIndex("SimulationNameId");

                    b.ToTable("SimulationHistory");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.SimulationName", b =>
                {
                    b.Property<int>("SimulationNameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SimulationNameId");

                    b.ToTable("SimulationName");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ResourceCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ResourceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResourceTypeId")
                        .HasColumnType("int");

                    b.HasKey("ResourceId");

                    b.HasIndex("ResourceCategoryId");

                    b.HasIndex("ResourceTypeId");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.ResourceCategory", b =>
                {
                    b.Property<int>("ResourceCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ResourceCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceCategoryId");

                    b.ToTable("ResourceCategory");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.ResourceParameter", b =>
                {
                    b.Property<int>("ResourceParameterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ResourceParameterAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResourceParameterName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResourceTypeId")
                        .HasColumnType("int");

                    b.HasKey("ResourceParameterId");

                    b.HasIndex("ResourceTypeId");

                    b.ToTable("ResourceParameter");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.ResourceParameterValue", b =>
                {
                    b.Property<int>("ResourceParameterValueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ParameterValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResourceId")
                        .HasColumnType("int");

                    b.Property<int?>("ResourceParameterId")
                        .HasColumnType("int");

                    b.HasKey("ResourceParameterValueId");

                    b.HasIndex("ResourceId");

                    b.HasIndex("ResourceParameterId");

                    b.ToTable("ResourceParameterValue");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.ResourceType", b =>
                {
                    b.Property<int>("ResourceTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ResourceCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ResourceTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ResourceTypeId");

                    b.HasIndex("ResourceCategoryId");

                    b.ToTable("ResourceType");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProcessSIM.Domain.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.ProcedureHistory", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.History.SimulationHistory", null)
                        .WithMany("Procedures")
                        .HasForeignKey("SimulationHistoryId");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.RandomEventHistory", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.History.ProcedureHistory", null)
                        .WithMany("RandomEvents")
                        .HasForeignKey("ProcedureHistoryId");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.ResourceHistory", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.History.SimulationHistory", null)
                        .WithMany("Resources")
                        .HasForeignKey("SimulationHistoryId");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.ResourceUseHistory", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.History.ResourceHistory", "Resource")
                        .WithMany("UseHistory")
                        .HasForeignKey("ResourceHistoryId");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.History.SimulationHistory", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.History.SimulationName", "SimulationName")
                        .WithMany("HistoryList")
                        .HasForeignKey("SimulationNameId");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.Resource", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.ResourceCategory", "ResourceCategory")
                        .WithMany("Resources")
                        .HasForeignKey("ResourceCategoryId");

                    b.HasOne("ProcessSIM.Domain.Entities.ResourceType", "ResourceType")
                        .WithMany("Resources")
                        .HasForeignKey("ResourceTypeId");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.ResourceParameter", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.ResourceType", "ResourceType")
                        .WithMany("ResourceParameters")
                        .HasForeignKey("ResourceTypeId");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.ResourceParameterValue", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.Resource", "Resource")
                        .WithMany("ResourceParameterValues")
                        .HasForeignKey("ResourceId");

                    b.HasOne("ProcessSIM.Domain.Entities.ResourceParameter", "ResourceParameter")
                        .WithMany()
                        .HasForeignKey("ResourceParameterId");
                });

            modelBuilder.Entity("ProcessSIM.Domain.Entities.ResourceType", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.ResourceCategory", "ResourceCategory")
                        .WithMany("ResourceTypes")
                        .HasForeignKey("ResourceCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}
