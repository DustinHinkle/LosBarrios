#nullable disable
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain;
using Microsoft.Extensions.Logging;
using webapp.Data;

namespace Repository;

public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
{
    public SpeakerRepository(ApplicationDbContext context) : base(context)
    {
        
    }

    public IEnumerable<Speaker> GetSpeakers(int? id)
    {
        return _context.Speaker.Where(x => x.SpeakerId == id);
    }
}