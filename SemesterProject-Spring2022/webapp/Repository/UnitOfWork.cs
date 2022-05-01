using LosBarriosDomain;
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;
using webapp.Data;

namespace Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public ISpeakerRepository Speaker { get; }
    public ISpeakerSessionRepository SpeakerSession { get; }
    public ISpeakerHelper SpeakerHelper{get; }
    public ISpeakerSessionHelper SessionHelper {get; }

    public UnitOfWork(ApplicationDbContext webappDbContext, ISpeakerRepository speakerRepository, 
                      ISpeakerSessionRepository sessionRepository, ISpeakerHelper speakerHelper, 
                      ISpeakerSessionHelper sessionHelper) 
        {
            this._context = webappDbContext;
            this.Speaker = speakerRepository;
            this.SpeakerSession = sessionRepository;
            this.SpeakerHelper = speakerHelper;
            this.SessionHelper = sessionHelper;
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
