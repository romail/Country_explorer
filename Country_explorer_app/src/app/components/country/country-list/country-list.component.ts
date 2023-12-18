import { Component, type OnInit } from '@angular/core'
import { Country } from '../../../interfaces/country.interface'
import { CountryService } from '../../../services/country.service'
import { Router } from '@angular/router'

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrls: ['./country-list.component.scss']
})

export class CountryListComponent implements OnInit {
  countries: Country[] = []

  constructor (private readonly countryService: CountryService, private readonly router: Router) {}

  ngOnInit (): void {
    this.countryService.getCountries().subscribe((data: Country[]) => {
      this.countries = data
    })
  }

  async navigateToDetails (alpha3Code: string): Promise<void> {
    try {
      await this.router.navigate(['/countries', alpha3Code])
    } catch (error) {
      console.error('Error navigating to country details:', error)
      // Handle the error as needed
    }
  }
}
