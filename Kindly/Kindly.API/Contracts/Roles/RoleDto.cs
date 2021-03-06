﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Kindly.API.Contracts.Roles
{
	/// <summary>
	/// The data transfer object for the role entity.
	/// </summary>
	[SuppressMessage("ReSharper", "UnusedMember.Global")]
	public sealed class RoleDto
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		[Required]
		public Guid ID { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Required]
		public string Name { get; set; }
	}
}