using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Models
{
    /// <summary>
    /// DTO which represets a Mars Image
    /// </summary>
    public class MarsImage
    {
        /// <summary>
        /// The date which the image was captured
        /// </summary>
        public string Date { get; set; } = string.Empty;

        /// <summary>
        /// The local (app) URL, which represents where the image is stored locally
        /// </summary>
        public Uri LocalUrl { get; set; } = null!;
    }
}
