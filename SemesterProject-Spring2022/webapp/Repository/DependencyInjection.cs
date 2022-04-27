using LosBarriosDomain;
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;



namespace Repository;

public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddTransient<ISpeakerRepository, SpeakerRepository>();
            services.AddTransient<ISpeakerSessionRepository, SpeakerSessionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            

            return services;
        }
       
    }