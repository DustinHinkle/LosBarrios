#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LosBarriosDomain.SpeakerAggregate;
using LosBarriosDomain.SpeakerSessionAggregate;
using webapp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Repository;
using LosBarriosDomain;


namespace webapp.Pages;
[Authorize] //need to login to see form page
public class SessionModel : PageModel
{
    private readonly ILogger<SessionModel> _logger;
    private readonly ApplicationDbContext _context;
    private IUnitOfWork _UnitOfWork;

    private readonly UserManager<IdentityUser> _userManager;
    public SessionModel(ILogger<SessionModel> logger,IUnitOfWork UnitOfWork, ApplicationDbContext context, UserManager<IdentityUser> UserManager)
    {
        _logger = logger;
        _context = context;
        _UnitOfWork = UnitOfWork;
        _userManager = UserManager;
        
    }
    [BindProperty]
    public SpeakerSession session {get; set;}
    public SpeakerSession sessionForSpeaker {get; set;}
    public Speaker SessionSpeaker {get; set;}
    public string Verify;

    public async Task OnGet()
    {
        IdentityUser applicationUser =  await _userManager.GetUserAsync(User);
        string userEmail = applicationUser?.Email; // will give the user's Email
        var test = _context.Speaker.Where(s => s.Email == userEmail).FirstOrDefault();
    }
    
    

    MySpeakerSessionHelper helper = new MySpeakerSessionHelper();
    public async Task<IActionResult> OnPostAsync()
    {
        
        
        IdentityUser applicationUser = await _userManager.GetUserAsync(User);
        string userEmail = applicationUser?.Email; // will give the user's Email
        if (!ModelState.IsValid)
        {
            return Page();
        }
        Verify = userEmail;
        SessionSpeaker = SelectUserId();

        session.SpeakerEmail = userEmail;// identity login is speaker and sessionspeaker email

        
        sessionForSpeaker = SelectSessionSpeakerId();// the Speaker's Session in the database

        session.Podium = _UnitOfWork.SessionHelper.ValidatePodium (session.Podium);
        session.Outlet = _UnitOfWork.SessionHelper.ValidateOutlet (session.Outlet);
        session.CleanWall = _UnitOfWork.SessionHelper.ValidateCleanWall (session.CleanWall);
        session.WhiteBoard = _UnitOfWork.SessionHelper.ValidateWhiteBoard (session.WhiteBoard);
        session.DemoTable = _UnitOfWork.SessionHelper.ValidateDemoTable (session.DemoTable);
        session.SessionSpeaker = _UnitOfWork.SessionHelper.ValidateSpeaker(SessionSpeaker);
        session.SessionCategory = _UnitOfWork.SessionHelper.ValidateSessionCategory(session.SessionCategory);
        session.SessionOne = _UnitOfWork.SessionHelper.ValidateSessionOne(session.SessionOne);
        session.SessionTwo = _UnitOfWork.SessionHelper.ValidateSessionTwo(session.SessionTwo);
        session.SignupDate = DateTime.Today;
        session.SpeakerFullName = ($"{SessionSpeaker.FirstName}" + $" {SessionSpeaker.LastName}");

        // speaker.FirstName = _UnitOfWork.SpeakerHelper.ValidateFirstName(speaker.FirstName);

        


        if(sessionForSpeaker == null)
        {
            // _context.SpeakerSessions.Add(session);
            // await _context.SaveChangesAsync();
            await _UnitOfWork.SpeakerSession.Add(session);
            _UnitOfWork.Complete();  
        }else
        {
            sessionForSpeaker.Podium = _UnitOfWork.SessionHelper.ValidatePodium (session.Podium);
            sessionForSpeaker.Outlet = _UnitOfWork.SessionHelper.ValidateOutlet (session.Outlet);
            sessionForSpeaker.CleanWall = _UnitOfWork.SessionHelper.ValidateCleanWall (session.CleanWall);
            sessionForSpeaker.WhiteBoard = _UnitOfWork.SessionHelper.ValidateWhiteBoard (session.WhiteBoard);
            sessionForSpeaker.DemoTable = _UnitOfWork.SessionHelper.ValidateDemoTable (session.DemoTable);
            sessionForSpeaker.SessionSpeaker = _UnitOfWork.SessionHelper.ValidateSpeaker(SessionSpeaker);
            sessionForSpeaker.SessionCategory = _UnitOfWork.SessionHelper.ValidateSessionCategory(session.SessionCategory);
            sessionForSpeaker.SessionOne = _UnitOfWork.SessionHelper.ValidateSessionOne(session.SessionOne);
            sessionForSpeaker.SessionTwo = _UnitOfWork.SessionHelper.ValidateSessionTwo(session.SessionTwo);
            sessionForSpeaker.SignupDate = DateTime.Today;
            sessionForSpeaker.SpeakerFullName = ($"{SessionSpeaker.FirstName}"+ $" {SessionSpeaker.LastName}");


            // _context.SpeakerSessions.UpdateRange(sessionForSpeaker);
            _UnitOfWork.SpeakerSession.Update(sessionForSpeaker);
            // await _context.SaveChangesAsync();
            _UnitOfWork.Complete();  

        }
        return RedirectToPage("/Index");
    }
    public Speaker SelectUserId()
    {
            
        //gets the signed in user and returns it as result
        IEnumerable<Speaker> listSpeaker = _context.Speaker.ToList();
        var result = listSpeaker.Where(s => s.Email == Verify).FirstOrDefault();
        return(result);
    }
    public SpeakerSession SelectSessionSpeakerId()
    {
        //gets the session where it matches the signed in user's email
        IEnumerable<SpeakerSession> listSpeakerSession = _context.SpeakerSessions.ToList();
        var result = listSpeakerSession.Where(a => a.SpeakerEmail == Verify).FirstOrDefault();
        // Console.WriteLine("This function has been called Select Session Speaker ID");

        return result;
    }
    
}