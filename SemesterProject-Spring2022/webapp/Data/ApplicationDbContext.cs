#nullable disable
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LosBarriosDomain.Models;
namespace webapp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Speaker> Speaker {get; set;} 
    public DbSet<Employer> Employers {get; set;}
    public DbSet<SpeakerSession> SpeakerSessions {get;set;}

}
