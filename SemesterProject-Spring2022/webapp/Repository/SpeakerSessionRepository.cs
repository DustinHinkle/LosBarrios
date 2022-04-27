using LosBarriosDomain.SpeakerSessionAggregate;
using webapp.Data;

namespace Repository;

public class SpeakerSessionRepository : GenericRepository<SpeakerSession>, ISpeakerSessionRepository
{
    public SpeakerSessionRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public IEnumerable<SpeakerSession> GetSpeakerSessions(int id)
    {
        return _context.SpeakerSessions.Where(x => x.SpeakerSessionId == id);
    }
}