using System.Collections.Generic;
using System.Threading.Tasks;
using LosBarriosDomain.SpeakerSessionAggregate;
using Microsoft.EntityFrameworkCore;


namespace Repository;

public class SpeakerSessionRepository : GenericRepository<SpeakerSession>, ISpeakerSessionRepository
{
    public SpeakerSessionRepository(webappDbContext context) : base(context)
    {
        
    }
}