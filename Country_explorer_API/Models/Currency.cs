using System.Text.Json.Serialization;

namespace Country_explorer_API.Models
{
    /// <summary>
    /// Currency class.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// The currency name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// The currency code.
        /// </summary>
        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
    }
}