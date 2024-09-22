using Microsoft.Extensions.DependencyInjection;
using ScalableMatch.Application.GameSession;
using ScalableMatch.Application.MatchmakingTickets;
using ScalableMatch.Infrastructure.GameSessionRepository;
using ScalableMatch.Infrastructure.TicketRepository;

namespace ScalableMatch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ITicketRepository, FakeTicketRepository>(); //replace fake repository with TicketRepository when it's implemented
            services.AddTransient<IGameSessionRepository, FakeGameSessionRepository>(); //replace fake repository with GameSessionRepository when it's implemented

            return services;
        }
    }
}