﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.SchoolDepartment.Infra.DataStruct.Data.Contexts;

#nullable disable

namespace Project.SchoolDepartment.Infra.DataStruct.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Cellphone", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR");

                    b.Property<Guid>("StudentGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.HasKey("Guid");

                    b.HasIndex("StudentGuid");

                    b.ToTable("Cellphone", (string)null);

                    b.HasData(
                        new
                        {
                            Guid = new Guid("164c3b10-6880-475f-8aec-fb1f24ce93eb"),
                            Number = "99999999999",
                            StudentGuid = new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6")
                        },
                        new
                        {
                            Guid = new Guid("b721dc19-3a29-47e5-8c4f-cb6bfc11ba70"),
                            Number = "88888888888",
                            StudentGuid = new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6")
                        });
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Course", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Guid");

                    b.ToTable("Course", (string)null);

                    b.HasData(
                        new
                        {
                            Guid = new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"),
                            Name = "Ciência da Computação"
                        });
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.School", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CourseGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Period")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Guid");

                    b.HasIndex("CourseGuid");

                    b.ToTable("School", (string)null);

                    b.HasData(
                        new
                        {
                            Guid = new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"),
                            CourseGuid = new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"),
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Period = "Morning",
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Student", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("CHAR");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR");

                    b.Property<Guid>("CourseGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("RA")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("CHAR");

                    b.Property<Guid>("SchoolGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("CHAR");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("VARCHAR");

                    b.Property<Guid>("UserGuid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.HasKey("Guid");

                    b.HasIndex("CPF")
                        .IsUnique();

                    b.HasIndex("CourseGuid");

                    b.HasIndex("RA")
                        .IsUnique();

                    b.HasIndex("SchoolGuid");

                    b.HasIndex("UserGuid");

                    b.ToTable("Student", (string)null);

                    b.HasData(
                        new
                        {
                            Guid = new Guid("c70c3bce-c77a-428a-b8c1-28174b6e0ba6"),
                            CPF = "11111111111",
                            City = "Cidade Qualquer",
                            CourseGuid = new Guid("a69dda80-aed1-452a-afa7-5c09d4885ba1"),
                            District = "Bairro Qualquer",
                            Gender = "Male",
                            Lastname = "Oliveira da Silva",
                            Name = "Eduardo",
                            Number = 278,
                            RA = "SFHJHSJH46JY54JY6JS54GARGHSTAEFGSJ4T65TRYH48TSRJTJ5THS5TRHGHAEJKDLF846531AHKFSFJ",
                            SchoolGuid = new Guid("43b26e0f-93e9-46ca-a574-c5e0b78c7a3b"),
                            State = "SP",
                            Street = "Rua Aleatória",
                            UserGuid = new Guid("9284f301-155a-4642-a526-bd7b941ddd9a")
                        });
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<bool>("IsConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("IsStudent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Guid");

                    b.HasIndex("Token")
                        .IsUnique();

                    b.ToTable("User", (string)null);

                    b.HasData(
                        new
                        {
                            Guid = new Guid("9284f301-155a-4642-a526-bd7b941ddd9a"),
                            Email = "rodrigogeribola@hotmail.com",
                            IsConfirmed = false,
                            IsStudent = false,
                            Login = "diguu_rl",
                            PasswordHash = "8sfM3ZZo4QvV7xKGxIyvg441+YFCuWMicZOM0Aqlj05p5a/buyT+keDIRYv6sd5/wkm1pCaePa+Ry6eAksgJ2w==",
                            Token = "MyFirstToken1234567890++"
                        });
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Cellphone", b =>
                {
                    b.HasOne("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Student", "Student")
                        .WithMany("Cellphones")
                        .HasForeignKey("StudentGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.School", b =>
                {
                    b.HasOne("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Course", "Course")
                        .WithMany("Schools")
                        .HasForeignKey("CourseGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Student", b =>
                {
                    b.HasOne("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Course", "Course")
                        .WithMany("Students")
                        .HasForeignKey("CourseGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.School", "School")
                        .WithMany("Students")
                        .HasForeignKey("SchoolGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("School");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Course", b =>
                {
                    b.Navigation("Schools");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.School", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Project.SchoolDepartment.Infra.DataStruct.Data.Entities.Student", b =>
                {
                    b.Navigation("Cellphones");
                });
#pragma warning restore 612, 618
        }
    }
}