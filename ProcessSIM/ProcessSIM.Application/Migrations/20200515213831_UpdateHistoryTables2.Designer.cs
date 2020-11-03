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
    [Migration("20200515213831_UpdateHistoryTables2")]
    partial class UpdateHistoryTables2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<double>("Complexity")
                        .HasColumnType("float");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WaitingTime")
                        .HasColumnType("int");

                    b.HasKey("SimulationHistoryId");

                    b.ToTable("SimulationHistory");
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
