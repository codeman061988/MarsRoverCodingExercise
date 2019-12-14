using Flurl.Http;
using Flurl.Http.Configuration;
using MarsRoverCodingExercise.Core.Interfaces;
using MarsRoverCodingExercise.Core.Models.Nasa;
using MarsRoverCodingExercise.Core.Settings;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace MarsRoverCodingExercise.Infrastructure.Clients
{
    /// <inheritdoc />
    public class NasaClient : INasaClient
    {
        private readonly AppSettings _settings;
        private readonly IFlurlClient _flurlClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="NasaClient"/> class
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="flurlClientFactory"></param>
        public NasaClient(IOptions<AppSettings> settings, IFlurlClientFactory flurlClientFactory)
        {
            if (settings == null) { throw new ArgumentNullException(nameof(settings)); }
            if (flurlClientFactory == null) { throw new ArgumentNullException(nameof(flurlClientFactory)); }

            _settings = settings.Value;
            _flurlClient = flurlClientFactory.Get(_settings.NasaServices.Endpoints.BaseUrl);
        }

        /// <inheritdoc />
        public async Task<NasaApiResponse> GetMarsRoverPhotosByDate(string roverName, string dateStr)
        {
            // Decalre new variable, whos value is that of the results of the Flurl Http call
            var response = await _flurlClient
                .Request(_settings.NasaServices.Endpoints.MarsPhotosUri, "rovers", roverName, "photos")
                .SetQueryParams(new
                {
                    earth_date = dateStr,
                    api_key = _settings.NasaServices.ApiKey
                })
                .GetAsync()
                .ReceiveJson<NasaApiResponse>()
                .ConfigureAwait(false);

            return response;
        }

        /// <inheritdoc />
        public async Task<string> DownloadFiles(string source, string dest)
        {
            return await source.DownloadFileAsync(dest).ConfigureAwait(false);
        }

    }
}
