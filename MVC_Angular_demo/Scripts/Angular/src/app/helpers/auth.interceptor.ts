import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandlerFn,
  HttpRequest,
} from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

export function AuthInterceptor(
  req: HttpRequest<unknown>,
  next: HttpHandlerFn
): Observable<HttpEvent<unknown>> {
  console.log(req.url);
  const authToken = localStorage.getItem('authToken');

  // Clone the request and add the Authorization header if the token exists
  if (authToken != null && authToken != "") {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${authToken}`,
      },
    });
  }
  return next(req).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401) {
        // Handle unauthorized request, e.g., redirect to login page
        window.location.href = '/Account/Login';
      }
      return throwError(error);
    })
  );
}
