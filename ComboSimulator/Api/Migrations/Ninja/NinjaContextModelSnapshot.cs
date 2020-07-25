﻿// <auto-generated />
using System;
using ComboSimulator.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ComboSimulator.Api.Migrations.Ninja
{
    [DbContext(typeof(NinjaContext))]
    partial class NinjaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ComboSimulator.Shared.Models.Ninja", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AttackId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<long?>("ChaseId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("ChaseId2")
                        .HasColumnType("bigint");

                    b.Property<long?>("ChaseId3")
                        .HasColumnType("bigint");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("MysteryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long?>("PassiveId1")
                        .HasColumnType("bigint");

                    b.Property<long?>("PassiveId2")
                        .HasColumnType("bigint");

                    b.Property<long?>("PassiveId3")
                        .HasColumnType("bigint");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Ninjas");
                });
#pragma warning restore 612, 618
        }
    }
}