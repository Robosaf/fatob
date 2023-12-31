﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using fatob_new.Data;

#nullable disable

namespace fatob_new.Migrations
{
    [DbContext(typeof(ApplicationDataContext))]
    [Migration("20231011143738_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("fatob_new.Models.Bus", b =>
                {
                    b.Property<int>("BusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusId"));

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("RegisterNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BusId");

                    b.ToTable("Buses");
                });

            modelBuilder.Entity("fatob_new.Models.Travel", b =>
                {
                    b.Property<int>("TravelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TravelId"));

                    b.Property<int>("BusId")
                        .HasColumnType("int");

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("EndCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndOfTravel")
                        .HasColumnType("datetime2");

                    b.Property<string>("StartCity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartOfTravel")
                        .HasColumnType("datetime2");

                    b.HasKey("TravelId");

                    b.HasIndex("BusId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("fatob_new.Models.Travel", b =>
                {
                    b.HasOne("fatob_new.Models.Bus", "Bus")
                        .WithMany("Travels")
                        .HasForeignKey("BusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bus");
                });

            modelBuilder.Entity("fatob_new.Models.Bus", b =>
                {
                    b.Navigation("Travels");
                });
#pragma warning restore 612, 618
        }
    }
}
