using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Models.Nasa
{
    /// <summary>
    /// Represents a Rover response DTO object sent back from a given NASA API
    /// </summary>
    public class Rover
    {
        /// <summary>
        /// Rover Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name of the Rover (i.e. Curiosity)
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Rover landing date
        /// </summary>
        [JsonProperty("landing_date")]
        public DateTimeOffset LandingDate { get; set; }

        /// <summary>
        /// Rover Launch date
        /// </summary>
        [JsonProperty("launch_date")]
        public DateTimeOffset LaunchDate { get; set; }

        /// <summary>
        /// Rover operational status
        /// </summary>
        public string Status { get; set; } = string.Empty;

        /// <summary>
        /// Mission MAX sol
        /// </summary>
        [JsonProperty("max_sol")]
        public long MaxSol { get; set; }

        /// <summary>
        /// Mission Max date
        /// </summary>
        [JsonProperty("max_date")]
        public DateTimeOffset MaxDate { get; set; }

        /// <summary>
        /// Total photos taken by the rover
        /// </summary>
        [JsonProperty("total_photos")]
        public long TotalPhotos { get; set; }

        /// <summary>
        /// List of cameras used by the rover
        /// </summary>
        public List<CameraElement> Cameras { get; } = null!;
    }
}
