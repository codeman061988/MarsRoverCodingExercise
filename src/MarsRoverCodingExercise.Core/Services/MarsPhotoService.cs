﻿using MarsRoverCodingExercise.Core.Interfaces;
using MarsRoverCodingExercise.Core.Models;
using System;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCodingExercise.Core.Services
{
    /// <inheritdoc />
    public class MarsPhotoService : IMarsPhotoService
    {
        private readonly INasaClient _nasaClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarsPhotoService"/> class
        /// </summary>
        /// <param name="nasaClient"></param>
        /// <param name="env"></param>
        public MarsPhotoService(INasaClient nasaClient)
        {
            _nasaClient = nasaClient;
        }

        /// <inheritdoc />
        public async Task<MarsImagesApiResponse> GetMarsImagesByRoverName(string roverName, string webRootPath)
        {
            if (webRootPath == null) { throw new ArgumentNullException(nameof(webRootPath)); }

            // The first thing we want to do is read the required dates from out static dates.txt file.
            var txtPath = Path.Combine(webRootPath, "dates.txt");
            string[] dates = File.ReadAllLines(txtPath, Encoding.UTF8);

            var marsImages = new List<MarsImage>();


            // Loop through each raw date read from file 
            foreach (string strDate in dates)
            {
                string nasaApiDateFormat = "yyyy-M-d";
                string formattedDate = string.Empty;

                // Format date so that it is accepable to NASA APIs
                switch (strDate)
                {
                    case "02/27/17":
                        formattedDate =
                            DateTime.ParseExact("02/27/17", "MM/dd/yy", CultureInfo.InvariantCulture)
                            .ToString(nasaApiDateFormat, CultureInfo.InvariantCulture);
                        break;
                    case "June 2, 2018":
                        formattedDate =
                            DateTime.ParseExact("June 2, 2018", "MMMM d, yyyy", CultureInfo.InvariantCulture)
                            .ToString(nasaApiDateFormat, CultureInfo.InvariantCulture);
                        break;
                    case "Jul-13-2016":
                        formattedDate =
                            DateTime.ParseExact("Jul-13-2016", "MMM-dd-yyyy", CultureInfo.InvariantCulture)
                            .ToString(nasaApiDateFormat, CultureInfo.InvariantCulture);
                        break;
                    case "April 31, 2018":

                        // We'll just move this one back a day ;)
                        formattedDate =
                            DateTime.ParseExact("April 30, 2018", "MMMM dd, yyyy", CultureInfo.InvariantCulture)
                            .ToString(nasaApiDateFormat, CultureInfo.InvariantCulture);
                        break;
                }

                var downloadImagesResult =
                    await DownloadImages(roverName, formattedDate, webRootPath).ConfigureAwait(false);

                foreach (var url in downloadImagesResult)
                {
                    marsImages.Add(new MarsImage
                    {
                        Date = formattedDate,
                        LocalUrl = url
                    });
                }
            }

            var result = new MarsImagesApiResponse(marsImages);

            return result;
        }

        /// <summary>
        /// Using given params, downloads images by both rover name and date, storing them in a local folder
        /// and returning the paths
        /// </summary>
        /// <param name="roverName"></param>
        /// <param name="formattedDate"></param>
        /// <param name="webRootPath"></param>
        private async Task<List<string>> DownloadImages(string roverName, string formattedDate, string webRootPath)
        {
            // Get distination path
            var destUri = $"/images/{roverName}/{formattedDate}/";
            var destPath = $"{webRootPath.Replace("\\", "/", StringComparison.InvariantCulture)}{destUri}";

            // Create date-based folder for images
            Directory.CreateDirectory(destPath);

            // Get response object from API
            var apiResponse =
                await _nasaClient.GetMarsRoverPhotosByDate(roverName, formattedDate).ConfigureAwait(false);

            // Looking through the response object, build a collection of image URLs
            var imageUrls = apiResponse.Photos.Select(src => src.ImgSrc).ToList();

            List<string> outputUrls = new List<string>();

            // Loop through images
            foreach (var url in imageUrls)
            {

                // Download image from NASA server and store in local folder
                var result =
                    await _nasaClient.DownloadFiles(url.OriginalString, destPath).ConfigureAwait(false);

                // Extract Image name with extension from result hard disk path
                var imageName =
                    Path.GetFileName(result
                    .Replace("/", "\\", StringComparison.InvariantCulture)
                    .Replace("//", "/", StringComparison.InvariantCulture));

                var outputUri = $"{destUri}{imageName}";

                outputUrls.Add(outputUri);
            }
            return outputUrls;
        }
    }
}
