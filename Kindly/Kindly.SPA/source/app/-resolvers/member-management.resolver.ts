// components
import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

// services
import { UsersService } from '../-services/users/users.service';
import { AlertifyService } from '../-services/alertify/alertify.service';

// models
import { User } from '../-models/user';
import { PaginatedResult } from '../-models/paginated-result';

@Injectable()
export class MemberManagementResolver implements Resolve<PaginatedResult<User>>
{
	/**
	 * The page number.
	 */
	public readonly pageNumber = 1;

	/**
	 * The page size.
	 */
	public readonly pageSize = 18;

	/**
	 * Creates an instance of the member list resolver.
	 *
	 * @param router The router.
	 * @param usersApi The users service.
	 * @param alertify The alertify service.
	 */
	public constructor
	(
		private readonly router: Router,
		private readonly usersApi: UsersService,
		private readonly alertify: AlertifyService
	)
	{
		// Nothing to do here.
	}

	/**
	 * Resolves a route.
	 *
	 * @param route the route.
	 */
	public resolve(route: ActivatedRouteSnapshot): Observable<PaginatedResult<User>>
	{
		return this.usersApi.getAllWithRoles(this.pageNumber, this.pageSize).pipe
		(
			catchError
			((error: any) =>
			{
				this.alertify.error('An error occured while retrieving the members.');
				this.router.navigate(['/home']);

				return of(null);
			})
		);
	}
}