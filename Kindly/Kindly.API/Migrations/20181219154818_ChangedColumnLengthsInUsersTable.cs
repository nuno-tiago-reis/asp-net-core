﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Kindly.API.Migrations
{
	public partial class ChangedColumnLengthsInUsersTable : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>
			(
				name: "LookingFor",
				table: "Users",
				maxLength: 250,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 200
			);

			migrationBuilder.AlterColumn<string>
			(
				name: "Introduction",
				table: "Users",
				maxLength: 500,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 200
			);

			migrationBuilder.AlterColumn<string>
			(
				name: "Interests",
				table: "Users",
				maxLength: 250,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 200
			);

			migrationBuilder.AlterColumn<bool>
			(
				name: "IsProfilePicture",
				table: "Pictures",
				nullable: false,
				defaultValue: false,
				oldClrType: typeof(bool)
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<string>
			(
				name: "LookingFor",
				table: "Users",
				maxLength: 200,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 250
			);

			migrationBuilder.AlterColumn<string>
			(
				name: "Introduction",
				table: "Users",
				maxLength: 200,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 500
				);

			migrationBuilder.AlterColumn<string>
			(
				name: "Interests",
				table: "Users",
				maxLength: 200,
				nullable: false,
				oldClrType: typeof(string),
				oldMaxLength: 250
				);

			migrationBuilder.AlterColumn<bool>
			(
				name: "IsProfilePicture",
				table: "Pictures",
				nullable: false,
				oldClrType: typeof(bool),
				oldDefaultValue: false
			);
		}
	}
}