﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.WebAPI.Models.Contexts;

#nullable disable

namespace Project.WebAPI.Migrations.Application
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231211150837_FirstApplicationMigration")]
    partial class FirstApplicationMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project.WebAPI.Models.Admin", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Project.WebAPI.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Project.WebAPI.Models.AppointmentRelationship", b =>
                {
                    b.Property<int>("AppointmentRelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentRelationshipId"));

                    b.Property<int>("AppoitmentId")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AppointmentRelationshipId");

                    b.ToTable("AppointmentRelationships");
                });

            modelBuilder.Entity("Project.WebAPI.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("Project.WebAPI.Models.MedicalCard", b =>
                {
                    b.Property<int>("MedicalCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalCardId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diseases")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestResults")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Treatment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicalCardId");

                    b.ToTable("MedicalCards");
                });

            modelBuilder.Entity("Project.WebAPI.Models.Medication", b =>
                {
                    b.Property<int>("MedicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicationId"));

                    b.Property<string>("Contraindications")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MedicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicationId");

                    b.ToTable("Medications");
                });

            modelBuilder.Entity("Project.WebAPI.Models.MedicationRelationship", b =>
                {
                    b.Property<int>("MedicationRelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicationRelationshipId"));

                    b.Property<int>("MedicalCardId")
                        .HasColumnType("int");

                    b.Property<int>("MedicationId")
                        .HasColumnType("int");

                    b.HasKey("MedicationRelationshipId");

                    b.HasIndex("MedicalCardId");

                    b.HasIndex("MedicationId");

                    b.ToTable("MedicationRelationships");
                });

            modelBuilder.Entity("Project.WebAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit");

                    b.Property<int>("MedicalCardId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("MedicalCardId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Project.WebAPI.Models.Appointment", b =>
                {
                    b.HasOne("Project.WebAPI.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.WebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.WebAPI.Models.MedicationRelationship", b =>
                {
                    b.HasOne("Project.WebAPI.Models.MedicalCard", "MedicalCard")
                        .WithMany()
                        .HasForeignKey("MedicalCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.WebAPI.Models.Medication", "Medication")
                        .WithMany()
                        .HasForeignKey("MedicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalCard");

                    b.Navigation("Medication");
                });

            modelBuilder.Entity("Project.WebAPI.Models.User", b =>
                {
                    b.HasOne("Project.WebAPI.Models.MedicalCard", "MedicalCard")
                        .WithMany()
                        .HasForeignKey("MedicalCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MedicalCard");
                });
#pragma warning restore 612, 618
        }
    }
}
