#nullable disable
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LosBarriosDomain.SpeakerSessionAggregate;
using LosBarriosDomain.SpeakerAggregate;

namespace webapp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Speaker> Speakers {get; set;}
    public DbSet<SpeakerSession> SpeakerSessions {get; set;}


}
