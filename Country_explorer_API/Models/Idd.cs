﻿using System.Text.Json.Serialization;

namespace Country_explorer_API.Models
{
    /// <summary>
    /// International Direct Dialing.
    /// </summary>
    public class Idd
    {
        /// <summary>
        /// Eg. The call prefix for Togo is +228.
        /// The root is +2
        /// </summary>
        [JsonPropertyName("root")]
        public string Root { get; set; }

        /// <summary>
        /// Eg. The call prefix for Togo is +228.
        /// The suffixes are [28].
        /// </summary>
        [JsonPropertyName("suffixes")]
        public string[] Suffixes { get; set; }
    }
}