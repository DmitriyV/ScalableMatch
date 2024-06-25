using Microsoft.Extensions.DependencyInjection;
using ScalableMatch.Application.MatchmakingTickets.Start;

namespace ScalableMatch.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IStartMatchmakingUseCase, StartMatchmakingUseCase>();

            return services;
        }
    }
}
