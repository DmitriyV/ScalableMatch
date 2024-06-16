using Microsoft.AspNetCore.Mvc;
using ScalableMatch.API.Models;

namespace ScalableMatch.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MatchmakingController : ControllerBase
    {
        private readonly ILogger<MatchmakingController> _logger;
        private readonly IMatchmakingService _matchmakingService;

        public MatchmakingController(ILogger<MatchmakingController> logger, IMatchmakingService matchmakingService)
        {
            _logger = logger;
            _matchmakingService = matchmakingService;
        }

        [HttpPost("StartMatchmaking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<StartMatchmakingResponse> StartMatchmaking([FromBody] StartMatchmakingRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Player.PlayerId))
                return BadRequest("PlayerId is empty.");

            if(request.Player.LatencyInMs <= 0)
                return BadRequest("Latency cannot be negative or zero.");

            _matchmakingService.StartMatchmaking();

            return Ok(new StartMatchmakingResponse()
            { 
                MatchmakingTicket = new MatchmakingTicket()
                {
                    Player = request.Player,
                    TicketId = "Ticket Id"
                }
            });
        }

        [HttpPost("StopMatchmaking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult StopMatchmaking([FromBody] StopMatchmakingRequest request)
        {
            _matchmakingService.StopMatchmaking();
            return Ok();
        }

        [HttpPost("StartMatchBackfill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult StartMatchBackfill([FromBody] StartMatchBackfillRequest request)
        {
            //todo
            return Ok();
        }
    }
}
