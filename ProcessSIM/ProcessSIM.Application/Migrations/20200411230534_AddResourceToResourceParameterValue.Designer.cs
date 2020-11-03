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
    [Migration("20200411230534_AddResourceToResourceParameterValue")]
    partial class AddResourceToResourceParameterValue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProcessSIM.Domain.Entities.Resource", b =>
                {
                    b.Property<int>("ResourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<int>("ResourceParameterAlias")
                        .HasColumnType("int");

                    b.Property<int>("ResourceParameterName")
                        .HasColumnType("int");

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

            modelBuilder.Entity("ProcessSIM.Domain.Entities.Resource", b =>
                {
                    b.HasOne("ProcessSIM.Domain.Entities.ResourceCategory", "ResourceCategory")
                        .WithMany("Resources")
                        .HasForeignKey("ResourceCategoryId");

                    b.HasOne("ProcessSIM.Domain.Entities.ResourceType", "ResourceType")
                        .WithMany()
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
