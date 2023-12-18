import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http'
import { catchError, map, Observable, retry, throwError } from 'rxjs'
import { type Country } from '../interfaces/country.interface'
import { CountryViewModel } from '../models/countryViewModel'

@Injectable({
  providedIn: 'root'
})

export class CountryService {
  private readonly baseApiUrl = 'https://localhost:7115/api/Country'
  private readonly maxRetries = 3

  constructor (private readonly http: HttpClient) {}

  getCountries (): Observable<Country[]> {
    return this.http.get<CountryViewModel[]>(this.baseApiUrl).pipe(
      map((countries: CountryViewModel[]) =>
        countries.map((country) => ({
          name: country.name?.common ?? '',
          capital: Array.isArray(country.capital) ? country.capital[0] : country.capital,
          currency: country.currencies != null ? Object.keys(country.currencies)[0] : '',
          language: country.languages != null ? Object.keys(country.languages)[0] : '',
          region: country.region ?? '',
          currencies: country.currencies,
          languages: country.languages,
          cca: country.cca3 ?? country.cca2,
          maps: country.maps,
          flags: country.flags
        } satisfies Country))
      ),
      retry(this.maxRetries),
      catchError(this.handleError)
    )
  }

  getCountryDetails (alpha3Code: string): Observable<Country> {
    const url = `${this.baseApiUrl}/${alpha3Code}`
    return this.http.get<CountryViewModel>(url).pipe(
      map((country: CountryViewModel) => ({
        name: country.name?.common,
        capital: Array.isArray(country.capital) ? country.capital[0] : country.capital,
        currency: country.currencies != null ? Object.keys(country.currencies)[0] : '',
        language: country.languages != null ? Object.keys(country.languages)[0] : '',
        region: country.region ?? '',
        cca: country.cca3 ?? country.cca2,
        maps: country.maps,
        flags: country.flags
      })),
      retry(this.maxRetries),
      catchError((error) => {
        console.error('Error fetching country details:', error)
        return throwError(() => error)
      })
    )
  }

  private readonly handleError = (error: any): Observable<never> => {
    console.error('An error occurred:', error)
    return throwError(() => error)
  }
}
