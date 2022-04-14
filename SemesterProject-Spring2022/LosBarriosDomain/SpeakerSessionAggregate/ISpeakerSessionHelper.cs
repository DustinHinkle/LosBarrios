namespace LosBarriosDomain.SpeakerSessionAggregate;

public interface ISpeakerSessionHelper 
{
    public bool GetPodium (bool Podium);
    public bool GetOutlet (bool Outlet);
    public bool GetCleanWall (bool CleanWall);
    public bool GetWhiteBoard (bool WhiteBoard);
    public bool GetDemoTable (bool DemoTable);
    



}

public class MySpeakerSessionHelper : ISpeakerSessionHelper
{
    public bool GetPodium (bool Podium)
    {
        return Podium;
        
    }
    
    public bool GetCleanWall (bool CleanWall)
     {
        return CleanWall;
     }

    public bool GetWhiteBoard (bool WhiteBoard)
     {
         return WhiteBoard;
     }

    public bool GetDemoTable (bool DemoTable)
     {
         return DemoTable;
     }
     
    public bool GetOutlet (bool Outlet)
     {
         return Outlet;
     }
     

}