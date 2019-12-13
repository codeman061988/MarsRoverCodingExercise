using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Models.Nasa
{
    /// <summary>
    /// Represents a Camera Element response DTO object sent back from a given NASA API
    /// </summary>
    public class CameraElement
    {
        /// <summary>
        /// Name of the Camera Element
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Full Name of the camera element
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; } = string.Empty;
    }
}
