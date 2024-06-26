using Microsoft.Extensions.DependencyInjection;
using ScalableMatch.Application.Common.Interfaces;
using ScalableMatch.Infrastructure.Data;

namespace ScalableMatch.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ITicketRepository, FakeTicketRepository>(); //replace FakeTicketRepository with TicketRepository when it's implemented

            return services;
        }
    }
}