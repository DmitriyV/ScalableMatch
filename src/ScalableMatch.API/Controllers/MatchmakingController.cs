using Microsoft.AspNetCore.Mvc;
using ScalableMatch.API.Models;
using ScalableMatch.Application.Common.Exceptions;
using ScalableMatch.Application.Common.Models;
using ScalableMatch.Application.MatchmakingTickets.Start;

namespace ScalableMatch.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MatchmakingController : ControllerBase
    {
        private readonly ILogger<MatchmakingController> _logger;
        private readonly IStartMatchmakingUseCase _startMatchmakingUseCase;

        public MatchmakingController(ILogger<MatchmakingController> logger, IStartMatchmakingUseCase startMatchmakingUseCase)
        {
            _logger = logger;
            _startMatchmakingUseCase = startMatchmakingUseCase;
        }

        [HttpPost("StartMatchmaking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StartMatchmakingResponse>> StartMatchmaking([FromBody] StartMatchmakingRequest request)
        {
            _logger.LogInformation("Start matchmaking for player {0}", request.Player.Id);

            MatchmakingTicketDto ticket;
            try
            {
                ticket = await _startMatchmakingUseCase.QueuePlayerAsync(request.Player, request.GameId);
            }
            catch (ValidationException e)
            {
                _logger.LogWarning(e.Message);

                return BadRequest(e.Message);
            }

            _logger.LogInformation("Ticket {0} for player {1} has been queued", ticket.Id, request.Player.Id);

            return Ok(new StartMatchmakingResponse()
            {
                MatchmakingTicket = ticket
            });
        }

        [HttpPost("StopMatchmaking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult StopMatchmaking([FromBody] StopMatchmakingRequest request)
        {
            return Ok();
        }

        [HttpPost("StartMatchBackfill")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult StartMatchBackfill([FromBody] StartMatchBackfillRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
