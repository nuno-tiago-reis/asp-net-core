﻿// <auto-generated />
using System;
using Kindly.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kindly.API.Migrations
{
    [DbContext(typeof(KindlyContext))]
    [Migration("20190103143800_AddedMessagesTable")]
    partial class AddedMessagesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kindly.API.Models.Repositories.Likes.Like", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<Guid>("SourceID");

                    b.Property<Guid>("TargetID");

                    b.HasKey("ID");

                    b.HasIndex("SourceID");

                    b.HasIndex("TargetID");

                    b.HasIndex("SourceID", "TargetID")
                        .IsUnique();

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Messages.Message", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<bool?>("IsRead")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("ReadAt");

                    b.Property<bool>("RecipientDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<Guid>("RecipientID");

                    b.Property<bool>("SenderDeleted")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<Guid>("SenderID");

                    b.HasKey("ID");

                    b.HasIndex("RecipientID");

                    b.HasIndex("SenderID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Pictures.Picture", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<bool?>("IsProfilePicture")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<string>("PublicID")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<Guid>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("PublicID")
                        .IsUnique();

                    b.HasIndex("Url")
                        .IsUnique();

                    b.HasIndex("UserID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Users.User", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<int>("Gender")
                        .HasMaxLength(10);

                    b.Property<string>("Interests")
                        .HasMaxLength(250);

                    b.Property<string>("Introduction")
                        .HasMaxLength(500);

                    b.Property<string>("KnownAs")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<DateTime>("LastActiveAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("LookingFor")
                        .HasMaxLength(250);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("ID");

                    b.HasIndex("EmailAddress")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Likes.Like", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Users.User", "Source")
                        .WithMany("LikeTargets")
                        .HasForeignKey("SourceID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Kindly.API.Models.Repositories.Users.User", "Target")
                        .WithMany("LikeSources")
                        .HasForeignKey("TargetID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Messages.Message", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Users.User", "Recipient")
                        .WithMany("MessagesSent")
                        .HasForeignKey("RecipientID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Kindly.API.Models.Repositories.Users.User", "Sender")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("SenderID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Pictures.Picture", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Users.User", "User")
                        .WithMany("Pictures")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
