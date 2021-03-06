﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kindly.API.Models.Repositories.Identity
{
	/// <summary>
	/// Implements the user claim entity framework configuration.
	/// </summary>
	/// 
	/// <seealso cref="IEntityTypeConfiguration{User}" />
	public sealed class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
	{
		/// <inheritdoc />
		public void Configure(EntityTypeBuilder<UserClaim> builder)
		{
			// Properties
			builder.Property(userClaim => userClaim.UserId)
				.IsRequired()
				.HasColumnName(nameof(UserClaim.UserID));

			// Properties - Ignored
			builder.Ignore(userClaim => userClaim.UserID);
		}
	}
}