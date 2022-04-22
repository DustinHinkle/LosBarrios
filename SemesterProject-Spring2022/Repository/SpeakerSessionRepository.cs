using LosBarriosDomain.SpeakerSessionAggregate;

namespace Repository;

public class SpeakerSessionRepository : GenericRepository<SpeakerSession>, ISpeakerSessionRepository
{
    public SpeakerSessionRepository(webappDbContext context) : base(context)
    {
        
    }
}