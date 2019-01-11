﻿// <auto-generated />
using System;
using Kindly.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kindly.API.Migrations
{
    [DbContext(typeof(KindlyContext))]
    partial class KindlyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("RoleID");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.UserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId")
                        .HasColumnName("UserID");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("UserID");

                    b.Property<Guid>("RoleId")
                        .HasColumnName("RoleID");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.UserToken", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnName("UserID");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Likes.Like", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<Guid>("RecipientID");

                    b.Property<Guid>("SenderID");

                    b.HasKey("ID");

                    b.HasIndex("RecipientID");

                    b.HasIndex("SenderID");

                    b.HasIndex("SenderID", "RecipientID")
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

                    b.Property<bool?>("RecipientDeleted")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(false);

                    b.Property<Guid>("RecipientID");

                    b.Property<bool?>("SenderDeleted")
                        .IsRequired()
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

            modelBuilder.Entity("Kindly.API.Models.Repositories.Roles.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("Date");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetUtcDate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254);

                    b.Property<bool>("EmailConfirmed");

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

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("LookingFor")
                        .HasMaxLength(250);

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15);

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PhoneNumber");

                    b.HasIndex("UserName");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.RoleClaim", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Roles.Role")
                        .WithMany("RoleClaims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.UserClaim", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Users.User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.UserLogin", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Users.User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.UserRole", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Roles.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Kindly.API.Models.Repositories.Users.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Identity.UserToken", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Users.User")
                        .WithMany("UserTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Kindly.API.Models.Repositories.Likes.Like", b =>
                {
                    b.HasOne("Kindly.API.Models.Repositories.Users.User", "Recipient")
                        .WithMany("LikeSenders")
                        .HasForeignKey("RecipientID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Kindly.API.Models.Repositories.Users.User", "Sender")
                        .WithMany("LikeRecipients")
                        .HasForeignKey("SenderID")
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
