﻿using System;

using Kindly.API.Models.Repositories.Users;

namespace Kindly.API.Models.Repositories.Pictures
{
	/// <summary>
	/// Defines the picture entity.
	/// </summary>
	public class Picture
	{
		#region [Constants]
		/// <summary>
		/// The picture does not exist message.
		/// </summary>
		public const string DoesNotExist = "The picture does not exist.";

		/// <summary>
		/// The profile picture cannot be deleted message.
		/// </summary>
		public const string CannotDeleteTheProfilePicture = "The profile picture cannot be deleted.";

		/// <summary>
		/// The approved picture cannot be approved message.
		/// </summary>
		public const string CannotApproveApprovedPicture = "The picture is already approved.";

		/// <summary>
		/// The approved picture cannot be rejected message.
		/// </summary>
		public const string CannotRejectApprovedPicture = "The picture is already approved.";
		#endregion

		#region [Properties]
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Gets or sets the url.
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// Gets or sets the public identifier.
		/// </summary>
		public string PublicID { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is approved.
		/// </summary>
		public bool? IsApproved { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is the profile picture.
		/// </summary>
		public bool? IsProfilePicture { get; set; }

		/// <summary>
		/// Gets or sets the date at which the picture was created.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the user identifier.
		/// </summary>
		public Guid UserID { get; set; }

		/// <summary>
		/// Gets or sets the user.
		/// </summary>
		public User User { get; set; }
		#endregion
	}
}