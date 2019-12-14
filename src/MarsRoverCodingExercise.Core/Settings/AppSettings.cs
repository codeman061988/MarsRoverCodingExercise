using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Settings
{
    /// <summary>
    /// Strongly typed model of appsettings.json
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Mapped Nasa settings from appsettings.json
        /// </summary>
        public NasaServices NasaServices { get; set; } = null!;
    }
}
