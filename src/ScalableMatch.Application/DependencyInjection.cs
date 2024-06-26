using Microsoft.Extensions.DependencyInjection;
using ScalableMatch.Application.Common.Validators;
using ScalableMatch.Application.MatchmakingTickets.Start;

namespace ScalableMatch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPlayerDtoValidator, PlayerDtoValidator>();
            services.AddScoped<IStartMatchmakingUseCase, StartMatchmakingUseCase>();

            return services;
        }
    }
}
