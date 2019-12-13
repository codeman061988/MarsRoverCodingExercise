using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Models.Nasa
{
    /// <summary>
    /// Represents an API response wrapper object, expected when calling a NASA API
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        /// List of photos returned when calling the mars-rover API
        /// </summary>
        public List<Photo> Photos { get; } = null!;

        /// <summary>
        /// In applicable cases, an error object returned from any given NASA API
        /// </summary>
        public ResponseError Error { get; set; } = null!;
    }
}
