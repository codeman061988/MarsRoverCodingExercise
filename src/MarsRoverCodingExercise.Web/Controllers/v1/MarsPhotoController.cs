using MarsRoverCodingExercise.Core.Interfaces;
using MarsRoverCodingExercise.Core.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MarsRoverCodingExercise.Web.Controllers.v1
{
    /// <summary>
    /// Represents a RESTful service for Mars Photos
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v1/mars-photos")]
    public class MarsPhotoController : ControllerBase
    {
        private readonly IMarsPhotoService _marsPhotoService;
        private readonly IWebHostEnvironment _env;

        /// <summary>
        /// Initializes a new instance of the <see cref="MarsPhotoController"/> class
        /// </summary>
        /// <param name="marsPhotoService"></param>
        /// <param name="env"></param>
        public MarsPhotoController(IMarsPhotoService marsPhotoService, IWebHostEnvironment env)
        {
            _marsPhotoService = marsPhotoService;
            _env = env;
        }

        /// <summary>
        /// Gets image for a specified rover, retriving them per the dates specified in dates.txt, storing them locally
        /// and providing accessible output paths to retireve them in a web browser
        /// </summary>
        /// <param name="roverName"></param>
        /// <returns></returns>
        [HttpGet("{roverName}")]
        [ProducesResponseType(typeof(MarsImagesApiResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get(string roverName)
        {
            try
            {
                // Get the response from our service
                var serviceResponse = 
                    await _marsPhotoService.GetMarsImagesByRoverName(roverName, _env.WebRootPath).ConfigureAwait(false);

                return Ok(serviceResponse);
            }
            catch (Exception)
            {
                return StatusCode(500);
                throw;
            }
        }
    }
}
