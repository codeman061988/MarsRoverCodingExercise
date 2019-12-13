using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Models.Nasa
{
    /// <summary>
    /// Represents a Photo Camera response DTO object sent back from a given NASA API
    /// </summary>
    public class PhotoCamera
    {
        /// <summary>
        /// Photo Camera Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Name of the Photo Camera (i.e. FHAZ)
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Associated Rover ID
        /// </summary>
        [JsonProperty("rover_id")]
        public long RoverId { get; set; }

        /// <summary>
        /// Full Name of the Photo Camera (i.e. Front Hazard Avoidance Camera)
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; } = string.Empty;
    }
}
