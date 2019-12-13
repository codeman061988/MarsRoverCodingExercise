using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRoverCodingExercise.Core.Settings
{
    /// <summary>
    /// Strongly typed model of NASA settings from appsettings.json
    /// </summary>
    public class Nasa
    {
        /// <summary>
        /// Account email, by which API key was registered
        /// </summary>
        public string AccountEmail { get; set; } = string.Empty;

        /// <summary>
        /// Account Id, as a result of account registration
        /// </summary>
        public string AccountId { get; set; } = string.Empty;

        /// <summary>
        /// API key, by which NASA API calls are made
        /// </summary>
        public string ApiKey { get; set; } = string.Empty;

        /// <summary>
        /// API Endpoints
        /// </summary>
        public NasaApiEndpoints Endpoints { get; set; } = null!;
    }
}
