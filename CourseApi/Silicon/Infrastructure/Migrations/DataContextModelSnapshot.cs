﻿// <auto-generated />
using System;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.AuthorDescriptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorFacebookFollowers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AuthorYouTubeSubscribers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("AuthorDescriptions");
                });

            modelBuilder.Entity("Infrastructure.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseDescriptionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LongDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseDescriptions");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BigImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("DiscountPrice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBestseller")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDigital")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LikesInNumbers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LikesInProcent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseIncludeEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IncludeIcon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IncludeText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseIncludes");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseLearnEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LearnText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseLearns");
                });

            modelBuilder.Entity("Infrastructure.Entities.ProgramDetailsEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProgramDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProgramHeader")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("ProgramDetails");
                });

            modelBuilder.Entity("Infrastructure.Entities.AuthorDescriptionEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseDescriptionEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.CategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseIncludeEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Infrastructure.Entities.CourseLearnEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Infrastructure.Entities.ProgramDetailsEntity", b =>
                {
                    b.HasOne("Infrastructure.Entities.CourseEntity", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });
#pragma warning restore 612, 618
        }
    }
}
