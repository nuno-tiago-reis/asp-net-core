﻿// <auto-generated />
using System;
using Kindly.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindly.API.Migrations
{
#pragma warning disable 1591
	[DbContext(typeof(KindlyContext))]
	[Migration("20181219110740_AddedPicturesTable")]
	partial class AddedPicturesTable
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
				.HasAnnotation("Relational:MaxIdentifierLength", 128)
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("Kindly.API.Models.Domain.Picture", b =>
			{
				b.Property<Guid>("ID")
					.ValueGeneratedOnAdd();

				b.Property<DateTime>("AddedAt")
					.ValueGeneratedOnAdd();

				b.Property<string>("Description")
					.IsRequired()
					.HasMaxLength(200);

				b.Property<bool>("IsProfilePicture");

				b.Property<string>("Url")
					.IsRequired()
					.HasMaxLength(200);

				b.Property<Guid>("UserID");

				b.HasKey("ID");

				b.HasIndex("UserID");

				b.ToTable("Pictures");
			});

			modelBuilder.Entity("Kindly.API.Models.Domain.User", b =>
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
					.ValueGeneratedOnAdd();

				b.Property<string>("EmailAddress")
					.IsRequired()
					.HasMaxLength(254);

				b.Property<bool>("EmailAddressConfirmed");

				b.Property<int>("Gender")
					.HasMaxLength(10);

				b.Property<string>("Interests")
					.IsRequired()
					.HasMaxLength(200);

				b.Property<string>("Introduction")
					.IsRequired()
					.HasMaxLength(200);

				b.Property<string>("KnownAs")
					.IsRequired()
					.HasMaxLength(25);

				b.Property<DateTime>("LastActiveAt")
					.ValueGeneratedOnAdd();

				b.Property<string>("LookingFor")
					.IsRequired()
					.HasMaxLength(200);

				b.Property<byte[]>("PasswordHash");

				b.Property<byte[]>("PasswordSalt");

				b.Property<string>("PhoneNumber")
					.IsRequired()
					.HasMaxLength(15);

				b.Property<bool>("PhoneNumberConfirmed");

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

			modelBuilder.Entity("Kindly.API.Models.Domain.Picture", b =>
			{
				b.HasOne("Kindly.API.Models.Domain.User", "User")
					.WithMany("Pictures")
					.HasForeignKey("UserID")
					.OnDelete(DeleteBehavior.Cascade);
			});
#pragma warning restore 612, 618
		}
	}
#pragma warning restore 1591
}