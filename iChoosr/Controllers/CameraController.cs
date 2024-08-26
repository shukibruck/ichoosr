using iChoosr.Application.Abstract;
using iChoosr.Application.CameraHandler;
using Microsoft.AspNetCore.Mvc;

namespace iChoosr.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CameraController : ControllerBase
    {
        private readonly IQuery<GetCameraClassifierQueryResult> _query;

        public CameraController(IQuery<GetCameraClassifierQueryResult> query)
        {
            _query = query;
        }

        [HttpGet]
        public IResult Get()
        {
            var result = _query.Handle();

            return result.IsFailure
                ? Results.BadRequest(result.Error)
                : Results.Ok(result);
        }
    }
}