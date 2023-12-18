import { Injectable } from '@angular/core'
import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
  HttpErrorResponse
} from '@angular/common/http'
import { Observable, throwError } from 'rxjs'
import { catchError, map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})

export class HandleErrorHttpInterceptor implements HttpInterceptor {
  intercept (
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      map((event: HttpEvent<any>) => {
        return event
      }),
      catchError((error: any) => {
        if (error instanceof HttpErrorResponse) {
          console.error('HTTP error occurred:', error)
        }
        // Propagate the error
        return throwError(() => error)
      })
    )
  }
}
