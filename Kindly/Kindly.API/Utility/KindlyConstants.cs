﻿namespace Kindly.API.Utility
{
	public static class KindlyConstants
	{
		/// <summary>
		/// The invalid field message.
		/// </summary>
		public const string InvalidFieldMessage = "The {0} field is invalid.";

		/// <summary>
		/// The existing field message.
		/// </summary>
		public const string ExistingFieldMessage = "The {0} field is taken.";

		/// <summary>
		/// The app settings encryption key section.
		/// </summary>
		public const string AppSettingsEncryptionKey = "AppSettings:EncryptionKey";

		/// <summary>
		/// The app settings cloudinary section.
		/// </summary>
		public const string AppSettingsCloudinary = "AppSettings:Cloudinary";

		/// <summary>
		/// The default connection section.
		/// </summary>
		public const string DefaultConnection = "DefaultConnection";
	}

	public enum KindlyClaimTypes
	{
		ID,
		ProfileName
	}
}