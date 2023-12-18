using System.Text.Json.Serialization;

namespace Country_explorer_API.Models
{
    public class CountryDetailViewModel
    {
        /// <summary>
        /// Country name
        /// </summary>
        [JsonPropertyName("name")]
        public CountryName Name { get; set; }

        /// <summary>
        /// Top Level Domain of the country.
        /// </summary>
        [JsonPropertyName("tld")]
        public List<string> Tld { get; set; }

        /// <summary>
        /// The alpha-2 code of the country.
        /// </summary>
        [JsonPropertyName("cca2")]
        public string Cca2 { get; set; }

        /// <summary>
        /// ISO 3166-1 numeric : https://en.wikipedia.org/wiki/ISO_3166-1_numeric
        /// </summary>
        [JsonPropertyName("ccn3")]
        public string Ccn3 { get; set; }

        /// <summary>
        /// The alpha-3 code of the country.
        /// </summary>
        [JsonPropertyName("cca3")]
        public string Cca3 { get; set; }

        /// <summary>
        /// International Olympic Committee Code.
        /// </summary>
        [JsonPropertyName("cioc")]
        public string Cioc { get; set; }

        /// <summary>
        /// Is the country independent?
        /// </summary>
        [JsonPropertyName("independent")]
        public bool Independent { get; set; }

        /// <summary>
        /// Status of the country. check out the https://restcountries.com/ for more info.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Is the country member of the United Nations ?
        /// </summary>
        [JsonPropertyName("unMember")]
        public bool UnMember { get; set; }

        /// <summary>
        /// Currencies used in the country.
        /// The dictionary is the currency code, the value is a Currency
        /// object: {name: string, symbol: string}.
        /// </summary>
        [JsonPropertyName("currencies")]
        public Dictionary<string, Currency> Currencies { get; set; }

        /// <summary>
        /// International direct dialing.
        /// </summary>
        [JsonPropertyName("idd")]
        public Idd Idd { get; set; }

        /// <summary>
        /// Capital(s) of the country.
        /// </summary>
        [JsonPropertyName("capital")]
        public List<string> Capital { get; set; }

        /// <summary>
        /// Alternative spellings of the country.
        /// </summary>
        [JsonPropertyName("altSpellings")]
        public List<string> AltSpellings { get; set; }

        /// <summary>
        /// Region of the country (eg. Africa, Americas, Asia, Europe, Oceania, Antarctic).
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// The subregion of the country(eg. Western Africa, Western Europe, ...)
        /// <remarks>Can be null.</remarks>
        /// </summary>
        [JsonPropertyName("subregion")]
        public string Subregion { get; set; }

        /// <summary>
        /// Languages spoken in the country.
        /// The key of the dictionary is the language code, the value is a
        /// the language name in english.
        /// </summary>
        [JsonPropertyName("languages")]
        public Languages Languages { get; set; }

        [JsonPropertyName("translations")]
        public Translation Translations { get; set; }

        /// <summary>
        /// Gps coordinates of the country in the format: [latitude, longitude].
        /// </summary>
        [JsonPropertyName("latlng")]
        public List<double> Latlng { get; set; }

        /// <summary>
        /// Is the country landlocked?
        /// </summary>
        [JsonPropertyName("landlocked")]
        public bool Landlocked { get; set; }

        /// <summary>
        /// Neighboring countries.
        /// </summary>
        [JsonPropertyName("borders")]
        public List<string> Borders { get; set; }

        /// <summary>
        /// The area of the country in square kilometers.
        /// </summary>
        [JsonPropertyName("area")]
        public double? Area { get; set; }

        /// <summary>
        /// Demonym.
        /// </summary>
        [JsonPropertyName("demonyms")]
        public Demonyms Demonyms { get; set; }

        /// <summary>
        /// Unicode flag.
        /// </summary>
        [JsonPropertyName("flag")]
        public string UnicodeFlag { get; set; }

        /// <summary>
        /// Google maps or OpenStreetMap link.
        /// </summary>
        [JsonPropertyName("maps")]
        public Maps Maps { get; set; }

        /// <summary>
        /// FIFA code.
        /// </summary>
        [JsonPropertyName("fifa")]
        public string Fifa { get; set; }

        /// <summary>
        /// Car information.
        /// </summary>
        [JsonPropertyName("car")]
        public Car Car { get; set; }

        /// <summary>
        /// List of timezones.
        /// </summary>
        [JsonPropertyName("timezones")]
        public List<string> Timezones { get; set; }

        /// <summary>
        /// Continent of the country. Only one continent is possible.
        /// The data source taken from https://restcountries.com/ return a list of
        /// one continent. That's why it's an array.
        /// </summary>
        [JsonPropertyName("continents")]
        public List<string> Continents { get; set; }

        /// <summary>
        /// Flag(Url) of the country in png and svg format.
        /// </summary>
        [JsonPropertyName("flags")]
        public Flag Flags { get; set; }

        [JsonPropertyName("coatOfArms")]
        public CoatOfArms CoatOfArms { get; set; }

        /// <summary>
        /// The week start by which day ? (eg. Sunday, Monday, ...)
        /// </summary>
        [JsonPropertyName("startOfWeek")]
        public string StartOfWeek { get; set; }

        /// <summary>
        /// Capital details. (eg. latitude, longitude, ...)
        /// </summary>
        [JsonPropertyName("capitalInfo")]
        public CapitalInformation CapitalInfo { get; set; }
    }


    public class Languages
    {
        public Dictionary<string, string> Values { get; set; }
    }

    public class CoatOfArms
    {
        public string Png { get; set; }
        public string Svg { get; set; }
    }
}
