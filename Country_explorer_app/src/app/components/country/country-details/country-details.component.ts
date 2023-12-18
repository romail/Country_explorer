import { Component, OnInit } from '@angular/core'
import { ActivatedRoute } from '@angular/router'
import { CountryService } from '../../../services/country.service'
import { Country } from '../../../interfaces/country.interface'

@Component({
  selector: 'app-country-details',
  templateUrl: './country-details.component.html',
  styleUrls: ['./country-details.component.scss']
})
export class CountryDetailsComponent implements OnInit {
  country: Country | undefined

  constructor (
    private readonly route: ActivatedRoute,
    private readonly countryService: CountryService
  ) { }

  ngOnInit (): void {
    this.loadCountryDetails()
  }

  private loadCountryDetails (): void {
    const alpha3Code = this.route.snapshot.paramMap.get('id')

    if (alpha3Code != null) {
      this.countryService.getCountryDetails(alpha3Code).subscribe({
        next: (data: Country) => {
          this.country = data
          console.log(this.country)
        },
        error: (error) => {
          console.error('Error fetching country details:', error)
        }
      })
    }
  }
}
