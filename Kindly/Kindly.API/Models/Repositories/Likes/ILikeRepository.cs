﻿using Kindly.API.Utility.Collections;

using System;
using System.Threading.Tasks;

namespace Kindly.API.Models.Repositories.Likes
{
	/// <summary>
	/// Provides CRUD methods over like entities as well as other utility methods.
	/// </summary>
	/// 
	/// <seealso cref="IEntityRepository{Like, LikeParameters}" />
	public interface ILikeRepository : IEntityRepository<Like, LikeParameters>
	{
		/// <summary>
		/// Checks if a like belongs to a user.
		/// </summary>
		/// 
		/// <param name="userID">The user identifier.</param>
		/// <param name="likeID">The like identifier.</param>
		Task<bool> LikeBelongsToUser(Guid userID, Guid likeID);

		/// <summary>
		/// Gets likes by sender user id using pagination.
		/// </summary>
		/// 
		/// <param name="userID">The user identifier.</param>
		/// <param name="parameters">The parameters.</param>
		Task<PagedList<Like>> GetBySenderUser(Guid userID, LikeParameters parameters);

		/// <summary>
		/// Gets likes by recipient user id using pagination.
		/// </summary>
		/// 
		/// <param name="userID">The user identifier.</param>
		/// <param name="parameters">The parameters.</param>
		Task<PagedList<Like>> GetByRecipientUser(Guid userID, LikeParameters parameters);
	}
}