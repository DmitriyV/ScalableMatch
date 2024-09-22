using Microsoft.Extensions.DependencyInjection;
using ScalableMatch.Application.Common.Validators;
using ScalableMatch.Application.MatchmakingTickets.AssignSession;
using ScalableMatch.Application.MatchmakingTickets.Start;
using ScalableMatch.Application.MatchmakingTickets.Stop;

namespace ScalableMatch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerDtoValidator, PlayerDtoValidator>();
            services.AddScoped<ITicketIdValidator, TicketIdValidator>();

            services.AddSingleton<ILatencyRule, LatencyRule>();
            services.AddSingleton<IMatchCreator, MatchCreator>();

            services.AddScoped<IStartMatchmakingUseCase, StartMatchmakingUseCase>();
            services.AddScoped<IStopMatchmakingUseCase, StopMatchmakingUseCase>();
            services.AddSingleton<IAssignSessionUseCase, AssignSessionUseCase>();

            return services;
        }
    }
}
