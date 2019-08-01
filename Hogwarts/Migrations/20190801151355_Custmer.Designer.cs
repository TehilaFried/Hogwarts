﻿// <auto-generated />
using Hogwarts.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Hogwarts.Migrations
{
    [DbContext(typeof(HogwartsContext))]
    [Migration("20190801151355_Custmer")]
    partial class Custmer
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hogwarts.Models.Atractions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<DateTime>("Date");

                    b.Property<int>("DurationTime");

                    b.Property<int>("Kind");

                    b.Property<int?>("LocationsId");

                    b.Property<string>("Name");

                    b.Property<double>("TicketPrice");

                    b.HasKey("Id");

                    b.HasIndex("LocationsId");

                    b.ToTable("Atractions");
                });

            modelBuilder.Entity("Hogwarts.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("CustomerId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Mark");

                    b.Property<bool>("Opinion");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("Hogwarts.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("MailAdress");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Hogwarts.Models.CustomerAtraction", b =>
                {
                    b.Property<string>("CustomerId");

                    b.Property<int>("AtractionId");

                    b.HasKey("CustomerId", "AtractionId");

                    b.HasIndex("AtractionId");

                    b.ToTable("CustomerAtractions");
                });

            modelBuilder.Entity("Hogwarts.Models.Locations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LocationName");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("Hogwarts.Models.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtractionsId");

                    b.Property<int>("NumOfTickets");

                    b.Property<int?>("SignUpApplicationId");

                    b.Property<DateTime>("Time");

                    b.Property<double>("TotalCost");

                    b.HasKey("Id");

                    b.HasIndex("AtractionsId");

                    b.HasIndex("SignUpApplicationId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Hogwarts.Models.SignUpApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CheckIn");

                    b.Property<DateTime>("CheckOut");

                    b.Property<string>("CustomerId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("SignUpApplication");
                });

            modelBuilder.Entity("Hogwarts.Models.Atractions", b =>
                {
                    b.HasOne("Hogwarts.Models.Locations", "Locations")
                        .WithMany("ArAtractionses")
                        .HasForeignKey("LocationsId");
                });

            modelBuilder.Entity("Hogwarts.Models.Comments", b =>
                {
                    b.HasOne("Hogwarts.Models.Customer", "Customer")
                        .WithMany("Commentses")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Hogwarts.Models.CustomerAtraction", b =>
                {
                    b.HasOne("Hogwarts.Models.Atractions", "Atractions")
                        .WithMany("CustomerAtractions")
                        .HasForeignKey("AtractionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hogwarts.Models.Customer", "Customer")
                        .WithMany("CustomerAtractions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hogwarts.Models.Orders", b =>
                {
                    b.HasOne("Hogwarts.Models.Atractions", "Atractions")
                        .WithMany("Orderses")
                        .HasForeignKey("AtractionsId");

                    b.HasOne("Hogwarts.Models.SignUpApplication", "SignUpApplication")
                        .WithMany("Orderses")
                        .HasForeignKey("SignUpApplicationId");
                });

            modelBuilder.Entity("Hogwarts.Models.SignUpApplication", b =>
                {
                    b.HasOne("Hogwarts.Models.Customer", "Customer")
                        .WithMany("SignUpApplications")
                        .HasForeignKey("CustomerId");
                });
#pragma warning restore 612, 618
        }
    }
}
