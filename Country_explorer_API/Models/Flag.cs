﻿using System.Text.Json.Serialization;

namespace Country_explorer_API.Models
{
    /// <summary>
    /// Flag of a country in different formats: PNG, SVG, ...
    /// </summary>
    public class Flag
    {
        /// <summary>
        /// Url to the PNG flag.
        /// </summary>
        [JsonPropertyName("png")]
        public string Png { get; set; }

        /// <summary>
        /// Url to the SVG flag.
        /// </summary>
        [JsonPropertyName("svg")]
        public string Svg { get; set; }
    }
}