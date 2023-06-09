﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheCircleBackend.DBInfra;

#nullable disable

namespace TheCircleBackend.Migrations
{
    [DbContext(typeof(DomainContext))]
    [Migration("20230608195042_Added chat entity")]
    partial class Addedchatentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TheCircleBackend.Domain.Models.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreamId")
                        .HasColumnType("int");

                    b.Property<int>("WebUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StreamId");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.Stream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Stream");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.WebsiteUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("WebsiteUser");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.ChatMessage", b =>
                {
                    b.HasOne("TheCircleBackend.Domain.Models.Stream", "LiveStream")
                        .WithMany("StreamChatMessages")
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheCircleBackend.Domain.Models.WebsiteUser", "Writer")
                        .WithMany("UserChatMessages")
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LiveStream");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.Stream", b =>
                {
                    b.Navigation("StreamChatMessages");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.WebsiteUser", b =>
                {
                    b.Navigation("UserChatMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
