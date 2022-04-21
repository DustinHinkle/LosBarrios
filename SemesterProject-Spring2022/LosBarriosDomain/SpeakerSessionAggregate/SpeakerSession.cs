
#nullable disable
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LosBarriosDomain.SpeakerAggregate;
namespace LosBarriosDomain.SpeakerSessionAggregate;

public class SpeakerSession 
{
    public string SpeakerSessionId {get; set;} //Primary key
    public int SpeakerId {get; set;} //Foreign key
    //TODO
    // Podium	
    public Speaker SessionSpeaker {get; set;}

    public string SessionCategory {get; set;} = string.Empty;

    public bool SessionOne { get; set; } = false;

    public bool SessionTwo { get; set; } = false;

    public DateOnly SignupDate {get; set;}

    // Podium
    public bool Podium { get; set; } = false;
    // Electrical outlet	
    public bool Outlet { get; set; } = false;
    // Clean wall for projection	
    public bool CleanWall{ get; set; } = false;
    // White Board	
    public bool WhiteBoard { get; set; } = false;
    // One demonstration table    
    public bool DemoTable { get; set; } =false;
    
}