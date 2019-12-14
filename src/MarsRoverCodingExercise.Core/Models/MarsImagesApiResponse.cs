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
        /// Initializes a new instance of the <see cref="MarsImagesApiResponse"/> class
        /// </summary>
        /// <param name="marsImages"></param>
        public MarsImagesApiResponse(List<MarsImage> marsImages)
        {
            MarsImages = marsImages;
        }

        /// <summary>
        /// Represets a collection of mars images
        /// </summary>
        public List<MarsImage> MarsImages { get; private set; } = null!;
    }
}
