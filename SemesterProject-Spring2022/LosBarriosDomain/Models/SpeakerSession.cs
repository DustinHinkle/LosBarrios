
namespace LosBarriosDomain;

public class SpeakerSession 
{

    //TODO
    // Podium	
    [Display(Name = "Podium")]
    public bool Podium { get; set; }
    // Electrical outlet	
    [Display(Name = "Electrical Outlet")]
    public bool Outlet { get; set; }
    // Clean wall for projection	
    [Display(Name = "Clean Wall")]
    public bool CleanWall{ get; set; }
    // White Board	
    [Display(Name = "White Board")]
    public bool WhiteBoard { get; set; }
    // One demonstration table    
    [Display(Name = "Demonstration Table")]
    public bool DemoTable { get; set; } 
}