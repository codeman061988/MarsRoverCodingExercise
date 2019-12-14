using MarsRoverCodingExercise.Core.Models.Nasa;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCodingExercise.Core.Interfaces
{
    /// <summary>
    /// Provides methods through which NASA APIs are accessed and data is retrieved
    /// </summary>
    public interface INasaClient
    {
        /// <summary>
        /// Retrieves photos from a given mars rover by the rover name and date passed in
        /// </summary>
        /// <param name="roverName"></param>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        Task<NasaApiResponse> GetMarsRoverPhotosByDate(string roverName, string dateStr);

        /// <summary>
        /// Downloads a file from the given source, to the given destination
        /// </summary>
        /// <param name="source"></param>
        /// <param name="dest"></param>
        /// <returns></returns>
        Task<string> DownloadFiles(string source, string dest);
    }
}
