﻿using System.Text.Json.Serialization;

namespace Country_explorer_API.Models
{
    /// <summary>
    /// Postal code class.
    /// </summary>
    public class PostalCode
    {
        /// <summary>
        /// The postal code format.
        /// </summary>
        [JsonPropertyName("format")]
        public string Format { get; set; }

        /// <summary>
        /// Regex pattern for the postal code.
        /// </summary>
        [JsonPropertyName("regex")]
        public string Regex { get; set; }
    }
}