using MarsRoverCodingExercise.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCodingExercise.Core.Interfaces
{
    /// <summary>
    /// Provides presenation logic for the Mars Photo component
    /// </summary>
    public interface IMarsPhotoService
    {
        /// <summary>
        /// Retrieves a collection of mars photos, per rover name
        /// </summary>
        /// <param name="roverName"></param>
        /// <returns></returns>
        Task<MarsImagesApiResponse> GetMarsImagesByRoverName(string roverName, string webRootPath);
    }
}
