﻿using System.Text.Json.Serialization;

namespace Country_explorer_API.Models
{
    /// <summary>
    /// Car information.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Signs that can be found on the vehicle.
        /// </summary>
        [JsonPropertyName("signs")]
        public string[] Signs { get; set; }

        /// <summary>
        /// The name of the side of the road that traffic drives on: left or right.
        /// </summary>
        [JsonPropertyName("side")]
        public string Side { get; set; }
    }
}
