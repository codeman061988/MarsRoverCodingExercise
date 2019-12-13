using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Settings
{
    /// <summary>
    /// Strongly typed model of Nasa > Endpoints settings from appsettings.json
    /// </summary>
    public class NasaApiEndpoints
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string MarsPhotosUri { get; set; } = string.Empty;
    }
}
