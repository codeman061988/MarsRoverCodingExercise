using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Models.Nasa
{
    /// <summary>
    /// Represents a Photo response DTO object sent back from a given NASA API
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// Photo Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Mission SOL
        /// </summary>
        public long Sol { get; set; }

        /// <summary>
        /// Camera used to take photos
        /// </summary>
        public PhotoCamera Camera { get; set; } = null!;

        /// <summary>
        /// Web image source
        /// </summary>
        [JsonProperty("img_src")]
        public Uri ImgSrc { get; set; } = null!;

        /// <summary>
        /// Equivalent earth date
        /// </summary>
        [JsonProperty("earth_date")]
        public DateTimeOffset EarthDate { get; set; }

        /// <summary>
        /// Rover responsible for taking the photos 
        /// </summary>
        public Rover Rover { get; set; } = null!;
    }

}
