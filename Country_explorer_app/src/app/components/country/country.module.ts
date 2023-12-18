import { NgModule } from '@angular/core'
import { CommonModule } from '@angular/common'
import { RouterModule, Routes } from '@angular/router'
import { MatCardModule } from '@angular/material/card'
import { MatIconModule } from '@angular/material/icon'
import { CountryDetailsComponent } from '../country/country-details/country-details.component'
import { CountryListComponent } from '../country/country-list/country-list.component'

const routes: Routes = [
  { path: '', component: CountryListComponent },
  { path: ':id', component: CountryDetailsComponent }
]

@NgModule({
  declarations: [
    CountryListComponent,
    CountryDetailsComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatIconModule,
    RouterModule.forChild(routes)
  ]
})
export class CountryModule { }
