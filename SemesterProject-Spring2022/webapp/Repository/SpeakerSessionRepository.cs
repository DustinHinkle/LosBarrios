#nullable disable
using LosBarriosDomain.SpeakerSessionAggregate;
using webapp.Data;
using Microsoft.EntityFrameworkCore;


namespace Repository;

public class SpeakerSessionRepository : GenericRepository<SpeakerSession>, ISpeakerSessionRepository
{
    public SpeakerSessionRepository(ApplicationDbContext context) : base(context)
    {
        
    }
    
    //Data retrieval methods below
    public async Task<SpeakerSession> GetSessionId(int id)
    {
        return await _context.Set<SpeakerSession>().FindAsync(id);
    }
    public async Task<IEnumerable<SpeakerSession>> GetAllSessions()
    {
        return await _context.Set<SpeakerSession>().ToListAsync();
    }
    public void DeleteSpeaker(SpeakerSession entity)
    {
        _context.Set<SpeakerSession>().Remove(entity);
    }
    public void UpdateSpeaker(SpeakerSession entity)
    {
        _context.Set<SpeakerSession>().Update(entity);
    }
}