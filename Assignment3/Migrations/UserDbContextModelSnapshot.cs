﻿// <auto-generated />
using Assignment3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment3.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("Assignment3.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Kathmandu",
                            Email = "rajin@gmail.com",
                            Name = "Rajin",
                            Password = "R@r12345",
                            PhoneNumber = "9823412254"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Bhaktapur",
                            Email = "milan@gmail.com",
                            Name = "Milan",
                            Password = "M@m12345",
                            PhoneNumber = "9845412354"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Lalitpur",
                            Email = "gagan@gmail.com",
                            Name = "Gagan",
                            Password = "G@g12345",
                            PhoneNumber = "9845214563"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
