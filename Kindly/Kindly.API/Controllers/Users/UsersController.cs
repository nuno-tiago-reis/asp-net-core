﻿using AutoMapper;

using Kindly.API.Contracts;
using Kindly.API.Contracts.Users;
using Kindly.API.Models.Repositories.Users;
using Kindly.API.Utility;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kindly.API.Controllers.Users
{
	/// <summary>
	/// Provides manipulation operations over the user resources (including CRUD).
	/// Certain operations may only be invoked by the resource owner(s).
	/// </summary>
	/// 
	/// <seealso cref="KindlyController" />
	[Authorize]
	[ApiController]
	[ServiceFilter(typeof(KindlyActivityFilter))]
	[Route("api/[controller]")]
	public sealed class UsersController : KindlyController
	{
		#region [Properties]
		/// <summary>
		/// Gets or sets the repository.
		/// </summary>
		private IUserRepository Repository { get; set; }
		#endregion

		#region [Constructors]
		/// <summary>
		/// Initializes a new instance of the <see cref="UsersController"/> class.
		/// </summary>
		/// 
		/// <param name="mapper">The mapper.</param>
		/// <param name="repository">The repository.</param>
		/// <param name="authorizationService">The authorization service.</param>
		public UsersController
		(
			IMapper mapper,
			IUserRepository repository,
			IAuthorizationService authorizationService
		)
		: base(mapper, authorizationService)
		{
			this.Repository = repository;
		}
		#endregion

		#region [Interface Methods]
		/// <summary>
		/// Creates the specified user.
		/// </summary>
		/// 
		/// <param name="createUserInfo">The create information.</param>
		[HttpPost]
		public async Task<IActionResult> Create(CreateUserDto createUserInfo)
		{
			var user = await this.Repository.Create(this.Mapper.Map<User>(createUserInfo));

			return this.Created(new Uri($"{Request.GetDisplayUrl()}/{user.ID}"), this.Mapper.Map<UserDto>(user));
		}

		/// <summary>
		/// Updates the specified user.
		/// </summary>
		/// 
		/// <param name="userID">The user identifier.</param>
		/// <param name="updateUserInfo">The update information.</param>
		[HttpPut("{userID:Guid}")]
		public async Task<IActionResult> Update(Guid userID, UpdateUserDto updateUserInfo)
		{
			var user = new User
			{
				ID = userID
			};

			#region [Authorization]
			var result = await this.AuthorizationService.AuthorizeAsync
			(
				this.User, user, nameof(KindlyPolicies.AllowIfOwner)
			);

			if (result.Succeeded == false)
			{
				return this.Unauthorized();
			}
			#endregion

			this.Mapper.Map(updateUserInfo, user);

			await this.Repository.Update(user);

			return this.Ok();
		}

		/// <summary>
		/// Deletes a user.
		/// </summary>
		/// 
		/// <param name="userID">The user identifier.</param>
		[HttpDelete("{userID:Guid}")]
		public async Task<IActionResult> Delete(Guid userID)
		{
			var user = new User
			{
				ID = userID
			};

			#region [Authorization]
			var result = await this.AuthorizationService.AuthorizeAsync
			(
				this.User, user, nameof(KindlyPolicies.AllowIfOwner)
			);

			if (result.Succeeded == false)
			{
				return this.Unauthorized();
			}
			#endregion

			await this.Repository.Delete(userID);

			return this.Ok();
		}

		/// <summary>
		/// Gets a user.
		/// </summary>
		/// 
		/// <param name="userID">The user identifier.</param>
		[HttpGet("{userID:Guid}")]
		public async Task<IActionResult> Get(Guid userID)
		{
			User user;

			if (userID == this.GetInvocationUserID())
			{
				user = await this.Repository.GetUserWithPictures(userID, true);
			}
			else
			{
				user = await this.Repository.GetUserWithPictures(userID, false);
			}

			var userDto = this.Mapper.Map<UserDetailedDto>(user);

			return this.Ok(userDto);
		}

		/// <summary>
		/// Gets the users.
		/// </summary>
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] UserParameters parameters)
		{
			parameters.UserID = this.GetInvocationUserID();

			var users = await this.Repository.GetAll(parameters);
			var userDtos = users.Select(u => this.Mapper.Map<UserDto>(u));

			this.Response.AddPaginationHeader(new PaginationHeader
			(
				users.PageNumber,
				users.PageSize,
				users.TotalPages,
				users.TotalCount
			));

			return this.Ok(userDtos);
		}
		#endregion
	}
}