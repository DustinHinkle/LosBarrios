using LosBarriosDomain.SpeakerAggregate;
using Microsoft.Extensions.Logging;


namespace Repository;

public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
{
    public SpeakerRepository(webappDbContext context) : base(context)
    {
        
    }

    public IEnumerable<Speaker> GetSpeakers(int id)
    {
        return _context.Speakers.Where(x => x.SpeakerId == id);
    }

}