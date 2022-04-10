
#nullable disable
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LosBarriosDomain.Models;

public class SpeakerSession 
{
    public string SpeakerSessionId {get; set;} //Primary key
    public int SpeakerId {get; set;} //Foreign key
    //TODO
    // Podium	
    [Display(Name = "Podium")]
    public bool Podium { get; set; } = false;
    // Electrical outlet	
    [Display(Name = "Electrical Outlet")]
    public bool Outlet { get; set; } = false;
    // Clean wall for projection	
    [Display(Name = "Clean Wall")]
    public bool CleanWall{ get; set; } = false;
    // White Board	
    [Display(Name = "White Board")]
    public bool WhiteBoard { get; set; } = false;
    // One demonstration table    
    [Display(Name ="Demonstration Table")]
    public bool DemoTable { get; set; } =false;
    
}