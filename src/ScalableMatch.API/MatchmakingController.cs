using Microsoft.AspNetCore.Mvc;
using ScalableMatch.API.StartMatchmaking;
using ScalableMatch.API.StopMatchmaking;
using ScalableMatch.Application.Common.Exceptions;
using ScalableMatch.Application.MatchmakingTickets;
using ScalableMatch.Application.MatchmakingTickets.Start;
using ScalableMatch.Application.MatchmakingTickets.Stop;

namespace ScalableMatch.API
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MatchmakingController(ILogger<MatchmakingController> logger, IStartMatchmakingUseCase startMatchmakingUseCase, IStopMatchmakingUseCase stopMatchmakingUseCase) : ControllerBase
    {
        private readonly ILogger<MatchmakingController> _logger = logger;
        private readonly IStartMatchmakingUseCase _startMatchmakingUseCase = startMatchmakingUseCase;
        private readonly IStopMatchmakingUseCase _stopMatchmakingUseCase = stopMatchmakingUseCase;

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

            return Ok(new StartMatchmakingResponse(ticket));
        }

        [HttpPost("StopMatchmaking")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> StopMatchmakingAsync([FromBody] StopMatchmakingRequest request)
        {
            _logger.LogInformation("Stop matchmaking for ticket {0}", request.TicketId);

            try
            {
                await _stopMatchmakingUseCase.DequeuePlayerAsync(request.TicketId);
            }
            catch (ValidationException e)
            {
                _logger.LogWarning(e.Message);
                return BadRequest(e.Message);
            }

            _logger.LogInformation("Ticket {0} has been dequeued", request.TicketId);

            return Ok(request.TicketId);
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
