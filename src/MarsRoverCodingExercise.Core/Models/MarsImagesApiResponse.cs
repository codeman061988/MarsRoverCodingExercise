using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Models
{
    /// <summary>
    /// DTO which represents a response object from the MarsImages API
    /// </summary>
    public class MarsImagesApiResponse
    {
        /// <summary>
        /// Represets a collection of mars images
        /// </summary>
        public List<MarsImage> MarsImages { get; } = null!;
    }
}
