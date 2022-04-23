using LosBarriosDomain.SpeakerSessionAggregate;

namespace Repository;

public class SpeakerSessionRepository : GenericRepository<SpeakerSession>, ISpeakerSessionRepository
{
    public SpeakerSessionRepository(webappDbContext context) : base(context)
    {
        
    }

    public IEnumerable<SpeakerSession> GetSpeakerSessions(int id)
    {
        return _context.SpeakerSessions.Where(x => x.SpeakerSessionId == id);
    }
}