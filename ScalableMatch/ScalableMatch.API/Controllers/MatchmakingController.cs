using Microsoft.AspNetCore.Mvc;
using ScalableMatch.API.Models;

namespace ScalableMatch.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MatchmakingController : ControllerBase
    {
        private readonly ILogger<MatchmakingController> _logger;

        public MatchmakingController(ILogger<MatchmakingController> logger)
        {
            _logger = logger;
        }

        [HttpPost("StartMatchmaking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult StartMatchmaking([FromBody] StartMatchmakingRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Player.PlayerId))
                return BadRequest("PlayerId is empty.");

            if(request.Player.LatencyInMs <= 0)
                return BadRequest("Latency cannot be negative or zero.");

            return Ok();
        }

        [HttpPost("StopMatchmaking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult StopMatchmaking([FromBody] StartMatchmakingRequest request)
        {
            return Ok();
        }

        [HttpPost("StartMatchBackfill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult StartMatchBackfill([FromBody] StartMatchmakingRequest request)
        {
            return Ok();
        }
    }
}
