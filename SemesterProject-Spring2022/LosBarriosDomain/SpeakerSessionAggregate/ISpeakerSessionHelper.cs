using LosBarriosDomain.SpeakerAggregate;
namespace LosBarriosDomain.SpeakerSessionAggregate;

public interface ISpeakerSessionHelper 
{
    public bool ValidatePodium (bool Podium);
    public bool ValidateOutlet (bool Outlet);
    public bool ValidateCleanWall (bool CleanWall);
    public bool ValidateWhiteBoard (bool WhiteBoard);
    public bool ValidateDemoTable (bool DemoTable);
    public Speaker ValidateSpeaker(Speaker SessionSpeaker);
    public string ValidateSessionCategory(string SessionCategory);
    public bool ValidateSessionOne(bool SessionOne);
    public bool ValidateSessionTwo(bool SessionTwo);



}

public class MySpeakerSessionHelper : ISpeakerSessionHelper
{
    public bool ValidatePodium (bool Podium)
    {
        return Podium;
        
    }
    
    public bool ValidateCleanWall (bool CleanWall)
    {
    return CleanWall;
    }

    public bool ValidateWhiteBoard (bool WhiteBoard)
    {
        return WhiteBoard;
    }

    public bool ValidateDemoTable (bool DemoTable)
    {
        return DemoTable;
    }
     
    public bool ValidateOutlet (bool Outlet)
    {
        return Outlet;
    }
     
    public Speaker ValidateSpeaker(Speaker SessionSpeaker)
    {
        return SessionSpeaker;
    }
    public string ValidateSessionCategory(string SessionCategory)
    {
        return SessionCategory;
    }
    public bool ValidateSessionOne(bool SessionOne)
    {
        return SessionOne;
    }
    public bool ValidateSessionTwo(bool SessionTwo)
    {
        return SessionTwo;
    }

}