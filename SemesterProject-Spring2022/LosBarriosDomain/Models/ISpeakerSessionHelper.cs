namespace LosBarriosDomain.Models;

public interface ISpeakerSessionHelper 
{
    public bool GetPodium (bool Podium);
}

public class MySpeakerSessionHelper : ISpeakerSessionHelper
{
    public bool GetPodium (bool Podium)
    {
        return Podium;
    }
}