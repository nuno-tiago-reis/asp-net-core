// components
import { Injectable } from '@angular/core';
import
{
	HttpEvent,
	HttpHandler,
	HttpRequest,
	HttpResponse,
	HttpErrorResponse,
	HttpInterceptor,
	HTTP_INTERCEPTORS
}
from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable
(({
	providedIn: 'root'
}) as any)

export class KindlyHttpInterceptor implements HttpInterceptor
{
	/**
	 * Creates an instance of the kindly http interceptor.
	 */
	public constructor()
	{
		// Nothing to do here.
	}

	public intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>
	{
		return next.handle(request).pipe
		(
			tap((event: HttpEvent<any>) =>
			{
				if (event instanceof HttpResponse)
				{
					console.log(event.status + `: ${event.url} successfull`);
				}

				return event;
			}),

			catchError(error =>
			{
				if (error instanceof HttpErrorResponse)
				{
					// Application errors are custom errors
					const applicationError = error.headers.get('Application-Error');

					if (applicationError)
					{
						console.error(`An application error occurred: ${applicationError}`);
						return throwError(applicationError);
					}

					// Model errors are ASP.NET model validation errors
					const serverError = error.error;

					if (serverError && typeof serverError === 'object')
					{
						let modelErrors = '\n';

						for (const key in serverError)
						{
							if (serverError.hasOwnProperty(key))
							{
								if (!serverError[key])
								{
									continue;
								}

								modelErrors += serverError[key] + '\n';
							}
						}

						if (modelErrors !== '\n')
						{
							console.error(`A model error occurred: ${modelErrors}`);
							return throwError(modelErrors);
						}
						else
						{
							console.error(`A server error occurred: ${serverError}`);
							return throwError(serverError);
						}

					}

					// A client-side or network error occurred. Handle it accordingly.
					console.error(`An internal server error occured: ${error.message}`);
					console.error(error.error);
					return throwError(`Something bad happened; please try again later.`);
				}
				else
				{
					// The backend returned an unsuccessful response code.
					// The response body may contain clues as to what went wrong,
					console.error(`A backend error occurred: ${error.message}`);
					console.error(error.error);
					return throwError(`Something bad happened; please try again later.`);
				}
			})
		);
	}
}

export const serviceInterceptorProvider =
{
	provide: HTTP_INTERCEPTORS,
	useClass: KindlyHttpInterceptor,
	multi: true
};