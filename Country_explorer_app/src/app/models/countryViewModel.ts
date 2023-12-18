import { CapitalInformation } from '../interfaces/capitalInformation.interface'
import { Car } from '../interfaces/car.interface'
import { CountryName } from '../interfaces/countryName.interface'
import { Currency } from '../interfaces/currency.interface'
import { Demonyms } from '../interfaces/demonyms.interface'
import { Flag } from '../interfaces/flag.interface'
import { Idd } from '../interfaces/idd.interface'
import { Maps } from '../interfaces/maps.interface'
import { PostalCode } from '../interfaces/postalCode.interface'
import { Translation } from '../interfaces/translation.interface'

export class CountryViewModel {
  name!: CountryName
  tld?: string[]
  cca2!: string
  ccn3?: string
  cca3!: string
  cioc!: string
  independent?: boolean
  status?: string
  unMember: boolean = false
  currencies?: Record<string, Currency>
  idd!: Idd
  capital?: string[]
  altSpellings: string[] = []
  region!: string
  subregion?: string
  languages?: Record<string, string>
  translations!: Record<string, Translation>
  private readonly latlng: number[] = []
  landlocked: boolean = false
  borders: string[] = []
  area?: number
  demonyms?: Demonyms
  unicodeFlag!: string
  maps!: Maps
  fifa?: string
  car?: Car
  timezones: string[] = []
  continents: string[] = []
  flags!: Flag
  startOfWeek!: string
  capitalInfo!: CapitalInformation
  postalCode?: PostalCode
}
