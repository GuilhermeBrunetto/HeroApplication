﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210830135924_HeroPower")]
    partial class HeroPower
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("API.Entities.Hero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HeroName")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.HasKey("Id");

                    b.ToTable("Heroes");
                });

            modelBuilder.Entity("API.Entities.HeroPower", b =>
                {
                    b.Property<int>("HeroId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PowerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("HeroId", "PowerId");

                    b.HasIndex("PowerId");

                    b.ToTable("HeroPower");
                });

            modelBuilder.Entity("API.Entities.Power", b =>
                {
                    b.Property<int>("PowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PowerName")
                        .HasColumnType("TEXT");

                    b.HasKey("PowerId");

                    b.ToTable("Powers");
                });

            modelBuilder.Entity("API.Entities.HeroPower", b =>
                {
                    b.HasOne("API.Entities.Power", "Power")
                        .WithMany("Heroes")
                        .HasForeignKey("HeroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Hero", "Hero")
                        .WithMany("Powers")
                        .HasForeignKey("PowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hero");

                    b.Navigation("Power");
                });

            modelBuilder.Entity("API.Entities.Hero", b =>
                {
                    b.Navigation("Powers");
                });

            modelBuilder.Entity("API.Entities.Power", b =>
                {
                    b.Navigation("Heroes");
                });
#pragma warning restore 612, 618
        }
    }
}