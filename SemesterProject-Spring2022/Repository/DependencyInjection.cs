using LosBarriosDomain;
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;
using Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



namespace Repository;

public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<ISpeakerRepository, SpeakerRepository>();
            services.AddTransient<ISpeakerSessionRepository, SpeakerSessionRepository>();

            return services;
        }
       
    }