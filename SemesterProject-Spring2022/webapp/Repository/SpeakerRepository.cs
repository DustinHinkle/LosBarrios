#nullable disable
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain;
using Microsoft.Extensions.Logging;
using webapp.Data;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
{
    public SpeakerRepository(ApplicationDbContext context) : base(context)
    {
        
    }
    // public IEnumerable<Speaker> GetSpeakerId(int? id)
    // {
    //     return _context.Speaker.Where(x => x.SpeakerId == id);
    // }

    //Data retrieval methods below
    public async Task<Speaker> GetSpeakerId(int id)
    {
        return await _context.Set<Speaker>().FindAsync(id);
    }
    public async Task<IEnumerable<Speaker>> GetAllSpeakers()
    {
        return await _context.Set<Speaker>().ToListAsync();
    }
    public void DeleteSpeaker(Speaker entity)
    {
        _context.Set<Speaker>().Remove(entity);
    }
    public void UpdateSpeaker(Speaker entity)
    {
        _context.Set<Speaker>().Update(entity);
    }

}
