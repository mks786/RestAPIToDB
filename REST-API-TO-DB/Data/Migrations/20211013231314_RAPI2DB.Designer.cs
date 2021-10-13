﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using REST_API_TO_DB.Models;

namespace REST_API_TO_DB.Data.Migrations
{
    [DbContext(typeof(RESTAPI2DBContext))]
    [Migration("20211013231314_RAPI2DB")]
    partial class RAPI2DB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("REST_API_TO_DB.Models.Projection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<int>("Description")
                        .HasColumnType("int");

                    b.Property<long>("Minutes")
                        .HasColumnType("bigint");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("Start")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID")
                        .HasName("PK_Projection_ID");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Projections");
                });

            modelBuilder.Entity("REST_API_TO_DB.Models.Schedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ContractTimeMinutes")
                        .HasColumnType("bigint");

                    b.Property<int>("Date")
                        .HasColumnType("int");

                    b.Property<bool>("IsFullDayAbsence")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID")
                        .HasName("PK_Schedule_ID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("REST_API_TO_DB.Models.Projection", b =>
                {
                    b.HasOne("REST_API_TO_DB.Models.Schedule", "Schedule")
                        .WithMany("Projection")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}