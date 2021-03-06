// components
import { Injectable } from '@angular/core';
import { Router, Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

// services
import { AuthService } from '../-services/auth/auth.service';
import { LikesService } from '../-services/likes/likes.service';
import { AlertifyService } from '../-services/alertify/alertify.service';

// models
import { Like } from '../-models/like';
import { PaginatedResult } from '../-models/paginated-result';
import { LikeContainer, LikeParameters } from '../-services/likes/likes.models';

@Injectable()
export class MatchesResolver implements Resolve<PaginatedResult<Like>>
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
	 * The filter parameters.
	 */
	public readonly filterParameters: LikeParameters =
	{
		container: LikeContainer.Senders,
		includeRequestUser: false
	};

	/**
	 * Creates an instance of the matches resolver.
	 *
	 * @param router The router.
	 * @param authApi The auth service.
	 * @param likesApi The likes service.
	 * @param alertify The alertify service.
	 */
	public constructor
	(
		private readonly router: Router,
		private readonly authApi: AuthService,
		private readonly likesApi: LikesService,
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
	public resolve(route: ActivatedRouteSnapshot): Observable<PaginatedResult<Like>>
	{
		return this.likesApi.getAll(this.authApi.user.id, this.pageNumber, this.pageSize, this.filterParameters).pipe
		(
			catchError
			((error: any) =>
			{
				this.alertify.error('An error occured while retrieving the matches.');
				this.router.navigate(['/home']);

				return of(null);
			})
		);
	}
}