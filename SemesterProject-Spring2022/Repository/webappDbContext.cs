#nullable disable
using LosBarriosDomain;
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class webappDbContext : DbContext
{
    public webappDbContext (DbContextOptions<webappDbContext> options) 
        : base(options){}
    public DbSet<Speaker> Speakers {get; set;}
    public DbSet<SpeakerSession> SpeakerSessions {get; set;}

}

