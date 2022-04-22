using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;

namespace LosBarriosDomain;

    public interface IUnitOfWork : IDisposable
    {
        ISpeakerRepository Speaker { get; }
        ISpeakerSessionRepository SpeakerSession { get; }
        int Complete();
    }
