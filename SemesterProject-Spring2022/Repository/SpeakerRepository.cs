using System.Collections.Generic;
using System.Threading.Tasks;
using LosBarriosDomain.SpeakerAggregate;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class SpeakerRepository : GenericRepository<Speaker>, ISpeakerRepository
{
    public SpeakerRepository(webappDbContext context) : base(context)
    {
        
    }
}