using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Models.Nasa
{
    /// <summary>
    /// Represents a Response Error from a given NASA API
    /// </summary>
    public class ResponseError
    {
        /// <summary>
        /// The error code
        /// </summary>
        public string? Code { get; set; }

        /// <summary>
        /// A message that briefly describes the error code returneds
        /// </summary>
        public string? Message { get; set; }
    }
}
