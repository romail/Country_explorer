import { Injectable } from '@angular/core'
import { HttpErrorResponse } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {
  handle (error: any): void {
    if (error instanceof HttpErrorResponse) {
      // Handle HTTP errors
      this.handleHttpError(error)
    } else if (error instanceof Error) {
      // Handle client-side errors
      this.handleClientError(error)
    } else {
      // Handle other types of errors
      this.handleOtherError(error)
    }
  }

  private handleHttpError (error: HttpErrorResponse): void {
    let errorMessage = 'An error occurred'
    if (error.error instanceof ErrorEvent) {
      // Client-side error
      errorMessage = `Client-side error: ${error.error.message}`
    } else {
      // Server-side error
      errorMessage = `Server-side error: ${error.status} - ${error.error.message}`
    }

    console.error(errorMessage)
    // You might want to show a user-friendly error message or log the error to a remote server
    // Depending on your application's requirements
    // ...
  }

  private handleClientError (error: Error): void {
    const errorMessage = `Client-side error: ${error.message}`
    console.error(errorMessage)
    // Handle client-side errors, possibly show a user-friendly message
    // ...
  }

  private handleOtherError (error: any): void {
    const errorMessage = 'An unexpected error occurred'
    console.error(errorMessage, error)
    // Handle other types of errors, possibly show a generic error message
    // ...
  }
}
