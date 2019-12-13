using Microsoft.AspNetCore.Mvc;

namespace MarsRoverCodingExercise.Web.Controllers.v1
{
    /// <summary>
    /// Represents a RESTful service for Mars Photos
    /// </summary>
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{api-version:apiVersion}/mars-photos")]
    public class MarsPhotoController : ControllerBase
    {

    }
}
