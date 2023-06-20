﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheCircleBackend.DBInfra;

#nullable disable

namespace TheCircleBackend.Migrations
{
    [DbContext(typeof(DomainContext))]
    partial class DomainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReceiverId")
                        .HasColumnType("int");

                    b.Property<int>("WebUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("WebUserId");

                    b.ToTable("ChatMessage");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.KeyStore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PrivateKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("UserId");

                    b.ToTable("UserKeys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PrivateKey = "MIICeAIBADANBgkqhkiG9w0BAQEFAASCAmIwggJeAgEAAoGBAKHk10g1evWq9t7KEEu8sKUGGKwwjx+X7fsn0ELt71G0jtdo43jjF8x4Q2S1Ho1VGV3XKMagRYf4t/Z3z8THd2c0g4SFwVSvQca/+BeJ9qmuVji7mw5x67PeOUWzJS0240i1tJFXHbLfXAgg666GIrkI135ElhwJH9Alu6xQ2VetAgMBAAECgYB/GuojGUoGo0nbtQ2CSQzvI5AvcJiOF3yS2blbMu/YWEhlu0YM3U8MC8ftw33PPOcDlC/Bcofkr1PPwFVxi6GkOBxDPiHthzruGGlnzbSMA9Ldo9qf/9ZUzKay26fhEVQoACNGsvw4GZxAblJ3UkqBnPea1chGQWh9v2xlo4YRiQJBAMwwtMER3URwxoUZGfyG4tTVfg/TK7AF5Iz6c5YQDx/UoSTrKLIM14f+APdvhMCAL5G+AEDKhesrUNpTXvNND3cCQQDK+MBpmfb/oDnqxVtFoY+pW3d7EjUyNXixM62xSJk5IdAX0gqwiMveb3svAM6SF2ro0b/IGItfNSaVxxtIxcL7AkEAiFwGeeDqOShvCreGqSOTG7svInZNeJGW3abrxc0XrJQcwUDhvnXhAYpZLuSkbMGuAtA17w7QfApDRmniwOw3ZQJBAKZnnkh1pB0bXaBuwU+rDz8H8EMEQHyzfgm5lrN8E7LVV+fPmlf1Lz9kIpf8j18St+G85QDFrq4Vw1aUcHgPOrUCQQDGLgVLCaOe4vE+0RMfwyI1FO8kXfARz0whL/8TevtnvvghLP2ogUNUswhyaZUS5bA8AxeVrHxYre1GGQCyv8DM",
                            PublicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC2v9CGMJwkju9GxJtZ2RP2TUJwmLLy1h4g6TAk+ilxEqNbV2Dzikh7n/pRJze/4vxj3J9q4547CBKrGxFJCP+IY2e32QmSMq5cgePHyv4jzheSixNe0oyqEy9AVaFzcxm1l+vCfSxNYpDiVElEmHyZFDgDVU+dYc85rNGQTXzxPQIDAQAB",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.LogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endpoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubjectUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LogItem");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.Stream", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("EndStream")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartStream")
                        .HasColumnType("datetime2");

                    b.Property<int>("StreamUserId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StreamUserId");

                    b.ToTable("VideoStream");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.Viewer", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StreamId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ConnectionId");

                    b.HasIndex("StreamId");

                    b.HasIndex("UserId");

                    b.ToTable("Viewer");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.WebsiteUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("Base64Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FollowCount")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("WebsiteUser");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsOnline = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.ChatMessage", b =>
                {
                    b.HasOne("TheCircleBackend.Domain.Models.WebsiteUser", "ReceiverUser")
                        .WithMany("StreamChatMessages")
                        .HasForeignKey("ReceiverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheCircleBackend.Domain.Models.WebsiteUser", "Writer")
                        .WithMany("UserChatMessages")
                        .HasForeignKey("WebUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ReceiverUser");

                    b.Navigation("Writer");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.Stream", b =>
                {
                    b.HasOne("TheCircleBackend.Domain.Models.WebsiteUser", "User")
                        .WithMany("StreamList")
                        .HasForeignKey("StreamUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.Viewer", b =>
                {
                    b.HasOne("TheCircleBackend.Domain.Models.Stream", "Stream")
                        .WithMany("ViewList")
                        .HasForeignKey("StreamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TheCircleBackend.Domain.Models.WebsiteUser", "WebsiteUser")
                        .WithMany("CurrentWatchList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stream");

                    b.Navigation("WebsiteUser");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.Stream", b =>
                {
                    b.Navigation("ViewList");
                });

            modelBuilder.Entity("TheCircleBackend.Domain.Models.WebsiteUser", b =>
                {
                    b.Navigation("CurrentWatchList");

                    b.Navigation("StreamChatMessages");

                    b.Navigation("StreamList");

                    b.Navigation("UserChatMessages");
                });
#pragma warning restore 612, 618
        }
    }
}
