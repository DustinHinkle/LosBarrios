using LosBarriosDomain;
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;

namespace Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly webappDbContext _context;
    public ISpeakerRepository Speaker { get; }
    public ISpeakerSessionRepository SpeakerSession { get; }

    public UnitOfWork(webappDbContext webappDbContext, ISpeakerRepository speakerRepository, ISpeakerSessionRepository sessionRepository) 
        {
            this._context = webappDbContext;
            this.Speaker = speakerRepository;
            this.SpeakerSession = sessionRepository;
        }
    public int Complete()
    {
        return _context.SaveChanges();
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _context.Dispose();
        }
     }
}
