﻿using JetBrains.Annotations;

using Kindly.API.Models.Repositories.Likes;
using Kindly.API.Models.Repositories.Pictures;
using Kindly.API.Models.Repositories.Messages;
using Kindly.API.Models.Repositories.Identity;

using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;

namespace Kindly.API.Models.Repositories.Users
{
	/// <summary>
	/// Defines the user entity.
	/// </summary>
	/// 
	/// <seealso cref="IdentityUser{Guid}" />
	public class User : IdentityUser<Guid>
	{
		#region [Constants]
		/// <summary>
		/// The user does not exist message.
		/// </summary>
		public const string DoesNotExist = "The user does not exist.";
		#endregion

		#region [Properties]
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		public Guid ID
		{
			get { return this.Id; }
			set { this.Id = value; }
		}

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		public Gender Gender { get; set; }

		/// <summary>
		/// Gets or sets the birth date.
		/// </summary>
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// Gets or sets the city.
		/// </summary>
		public string City { get; set; }

		/// <summary>
		/// Gets or sets the country.
		/// </summary>
		public string Country { get; set; }

		/// <summary>
		/// Gets or sets the known as name.
		/// </summary>
		public string KnownAs { get; set; }

		/// <summary>
		/// Gets or sets the introduction.
		/// </summary>
		public string Introduction { get; set; }

		/// <summary>
		/// Gets or sets what the user is looking for.
		/// </summary>
		public string LookingFor { get; set; }

		/// <summary>
		/// Gets or sets the interests.
		/// </summary>
		public string Interests { get; set; }

		/// <summary>
		/// Gets or sets the created at date.
		/// </summary>
		public DateTime CreatedAt { get; set; }

		/// <summary>
		/// Gets or sets the last active at date.
		/// </summary>
		public DateTime LastActiveAt { get; set; }

		/// <summary>
		/// Gets or sets the like recipients.
		/// </summary>
		public ICollection<Like> LikeRecipients { get; set; }

		/// <summary>
		/// Gets or sets the likes senders.
		/// </summary>
		public ICollection<Like> LikeSenders { get; set; }

		/// <summary>
		/// Gets or sets the messages sent.
		/// </summary>
		public ICollection<Message> MessagesSent { get; set; }

		/// <summary>
		/// Gets or sets the messages received.
		/// </summary>
		public ICollection<Message> MessagesReceived { get; set; }

		/// <summary>
		/// Gets or sets the pictures.
		/// </summary>
		public ICollection<Picture> Pictures { get; set; }

		/// <summary>
		/// Gets or sets the roles.
		/// </summary>
		public ICollection<UserRole> UserRoles { get; set; }

		/// <summary>
		/// Gets or sets the claims.
		/// </summary>
		public ICollection<UserClaim> UserClaims { get; set; }

		/// <summary>
		/// Gets or sets the logins.
		/// </summary>
		public ICollection<UserLogin> UserLogins { get; set; }

		/// <summary>
		/// Gets or sets the tokens.
		/// </summary>
		public ICollection<UserToken> UserTokens { get; set; }
		#endregion
	}

	/// <summary>
	/// The user genders.
	/// </summary>
	public enum Gender
	{
		/// <summary>
		/// The gender is undefined.
		/// </summary>
		[UsedImplicitly] Undefined = 0,

		/// <summary>
		/// The gender is female.
		/// </summary>
		[UsedImplicitly] Female = 1,

		/// <summary>
		/// The gender is male.
		/// </summary>
		[UsedImplicitly] Male = 2
	}
}