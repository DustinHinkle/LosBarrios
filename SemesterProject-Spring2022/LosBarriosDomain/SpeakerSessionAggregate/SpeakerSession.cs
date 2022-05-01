
#nullable disable
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
<<<<<<< HEAD
using LosBarriosDomain.SpeakerAggregate;
=======
>>>>>>> 08393dc128b8d467e97f8b99e5fbc1bef524ed7a
namespace LosBarriosDomain.SpeakerSessionAggregate;
using LosBarriosDomain.SpeakerAggregate;

public class SpeakerSession 
{
    public int SpeakerSessionId {get; set;} //Primary key
<<<<<<< HEAD
=======
    public int SpeakerId {get; set;} //Foreign key
    public List<Speaker> Speakers {get; set;} //Navigation property
>>>>>>> 08393dc128b8d467e97f8b99e5fbc1bef524ed7a
    //TODO
    // Podium	
    public Speaker SessionSpeaker {get; set;}

    // DO NOT TOUCH THE ABOVE
    public string SpeakerFullName {get; set;}  = string.Empty;
    public string SpeakerEmail {get; set;}  = string.Empty;

    public string SessionCategory {get; set;} = string.Empty;

    public bool SessionOne { get; set; } = false;

    public bool SessionTwo { get; set; } = false;

    public DateTime SignupDate {get; set;}

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