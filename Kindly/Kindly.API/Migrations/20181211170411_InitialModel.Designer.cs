﻿// <auto-generated />
using Kindly.API.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindly.API.Migrations
{
#pragma warning disable 1591
	[DbContext(typeof(KindlyContext))]
	[Migration("20181211170411_InitialModel")]
	partial class InitialModel
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
				.HasAnnotation("Relational:MaxIdentifierLength", 128)
				.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

			modelBuilder.Entity("Kindly.API.Models.Value", b =>
			{
				b.Property<int>("ID")
					.ValueGeneratedOnAdd()
					.HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

				b.Property<string>("Content");

				b.HasKey("ID");

				b.ToTable("Values");
			});
#pragma warning restore 612, 618
		}
	}
#pragma warning restore 1591
}