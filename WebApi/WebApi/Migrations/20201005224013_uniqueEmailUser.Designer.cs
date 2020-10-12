﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Models;

namespace WebApi.Migrations
{
    [DbContext(typeof(userDbContext))]
    [Migration("20201005224013_uniqueEmailUser")]
    partial class uniqueEmailUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApi.Models.addressModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("cep")
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("neighborhood")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("state")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("WebApi.Models.userModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("addressModelId")
                        .HasColumnType("int");

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("bloodGroup")
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("cellPhone")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("addressModelId");

                    b.HasIndex("email")
                        .IsUnique()
                        .HasFilter("[email] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("WebApi.Models.userModel", b =>
                {
                    b.HasOne("WebApi.Models.addressModel", "addressModel")
                        .WithMany()
                        .HasForeignKey("addressModelId");
                });
#pragma warning restore 612, 618
        }
    }
}
