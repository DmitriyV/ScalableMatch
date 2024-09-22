using ScalableMatch.Application.MatchmakingTickets.AssignSession;

namespace ScalableMatch.API.AssignSession
{
    public class MatchmakingHostedService(IAssignSessionUseCase assignSessionUseCase) : BackgroundService
    {
        private const int TicketProcessingDelayInMs = 1000; //todo get from IConfiguration

        private readonly IAssignSessionUseCase _assignSessionUseCase = assignSessionUseCase;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _assignSessionUseCase.ProcessMatchmakingQueue(stoppingToken);

                await Task.Delay(TicketProcessingDelayInMs, stoppingToken);
            }
        }
    }
}
