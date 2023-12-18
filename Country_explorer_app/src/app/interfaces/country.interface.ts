import { Currency } from './currency.interface'
import { Flag } from './flag.interface'
import { Maps } from './maps.interface'

export interface Country {
  currencies?: Record<string, Currency>
  languages?: Record<string, string>
  name: string
  capital?: string
  currency: string
  language: string
  region: string
  cca: string
  maps: Maps
  flags: Flag
}
