﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Task_1.Data;

#nullable disable

namespace Task_1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231016171454_InitialDB")]
    partial class InitialDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Task_1.Models.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Task_1.Models.Experiment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Experiments");
                });

            modelBuilder.Entity("Task_1.Models.ExperimentOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("ExperimentId")
                        .HasColumnType("int");

                    b.Property<int>("Probability")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExperimentId");

                    b.ToTable("ExperimentOption");
                });

            modelBuilder.Entity("Task_1.Models.Result", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("ExperimentId")
                        .HasColumnType("int");

                    b.Property<int>("ResultValueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("ExperimentId");

                    b.HasIndex("ResultValueId");

                    b.ToTable("Results");
                });

            modelBuilder.Entity("Task_1.Models.ExperimentOption", b =>
                {
                    b.HasOne("Task_1.Models.Experiment", null)
                        .WithMany("Options")
                        .HasForeignKey("ExperimentId");
                });

            modelBuilder.Entity("Task_1.Models.Result", b =>
                {
                    b.HasOne("Task_1.Models.Device", null)
                        .WithMany("Results")
                        .HasForeignKey("DeviceId");

                    b.HasOne("Task_1.Models.Experiment", "Experiment")
                        .WithMany()
                        .HasForeignKey("ExperimentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Task_1.Models.ExperimentOption", "ResultValue")
                        .WithMany()
                        .HasForeignKey("ResultValueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Experiment");

                    b.Navigation("ResultValue");
                });

            modelBuilder.Entity("Task_1.Models.Device", b =>
                {
                    b.Navigation("Results");
                });

            modelBuilder.Entity("Task_1.Models.Experiment", b =>
                {
                    b.Navigation("Options");
                });
#pragma warning restore 612, 618
        }
    }
}
