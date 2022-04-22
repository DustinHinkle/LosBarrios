using LosBarriosDomain.SpeakerAggregate;


namespace Repository;

public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
{
    public SpeakerRepository(webappDbContext context) : base(context)
    {
        
    }
}