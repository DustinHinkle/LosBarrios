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


namespace webapp.Pages;
// [Authorize] //need to login to see form page
public class SessionModel : PageModel
{
    private readonly ILogger<FormModel> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    public SessionModel(ILogger<FormModel> logger, ApplicationDbContext context, UserManager<IdentityUser> UserManager)
    {
        _logger = logger;
        _context = context;
        _userManager = UserManager;
        
    }

    public void OnGet()
    {
    }
    [BindProperty]
    public SpeakerSession session {get; set;}
    public SpeakerSession sessionForSpeaker {get; set;}
    public Speaker SessionSpeaker {get; set;}
    public string Verify;
    

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

            session.SpeakerEmail = userEmail;// identity login is speaker and sessionspeaker email

            SessionSpeaker = SelectUserId(); // the speaker itself
            sessionForSpeaker = SelectSessionSpeakerId();// the Speaker's Session in the database

            session.Podium = helper.ValidatePodium (session.Podium);
            session.Outlet = helper.ValidateOutlet (session.Outlet);
            session.CleanWall = helper.ValidateCleanWall (session.CleanWall);
            session.WhiteBoard = helper.ValidateWhiteBoard (session.WhiteBoard);
            session.DemoTable = helper.ValidateDemoTable (session.DemoTable);
            session.SessionSpeaker = helper.ValidateSpeaker(SessionSpeaker);
            session.SessionCategory = helper.ValidateSessionCategory(session.SessionCategory);
            session.SessionOne = helper.ValidateSessionOne(session.SessionOne);
            session.SessionTwo = helper.ValidateSessionTwo(session.SessionTwo);
            session.SignupDate = DateTime.Today;
            session.SpeakerFullName = ($"{SessionSpeaker.FirstName}" +$" {SessionSpeaker.LastName}");
            


            if(sessionForSpeaker == null)
            {
                _context.SpeakerSessions.Add(session);
                await _context.SaveChangesAsync();
            }else
            {
                sessionForSpeaker.Podium = helper.ValidatePodium (session.Podium);
                sessionForSpeaker.Outlet = helper.ValidateOutlet (session.Outlet);
                sessionForSpeaker.CleanWall = helper.ValidateCleanWall (session.CleanWall);
                sessionForSpeaker.WhiteBoard = helper.ValidateWhiteBoard (session.WhiteBoard);
                sessionForSpeaker.DemoTable = helper.ValidateDemoTable (session.DemoTable);
                sessionForSpeaker.SessionSpeaker = helper.ValidateSpeaker(SessionSpeaker);
                sessionForSpeaker.SessionCategory = helper.ValidateSessionCategory(session.SessionCategory);
                sessionForSpeaker.SessionOne = helper.ValidateSessionOne(session.SessionOne);
                sessionForSpeaker.SessionTwo = helper.ValidateSessionTwo(session.SessionTwo);
                sessionForSpeaker.SignupDate = DateTime.Today;
                sessionForSpeaker.SpeakerFullName = ($"{SessionSpeaker.FirstName}"+ $" {SessionSpeaker.LastName}");


                _context.SpeakerSessions.UpdateRange(sessionForSpeaker);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/Index");
        }
    public Speaker SelectUserId()
    {
            //gets the signed in user and returns it as result
            IEnumerable<Speaker> listSpeaker = _context.Speaker.ToList();
            var result = listSpeaker.Where(s => s.Email.Equals(Verify)).FirstOrDefault();
            return(result);
    }
    public SpeakerSession SelectSessionSpeakerId()
    {
            //gets the session where it matches the signed in user's email
            IEnumerable<SpeakerSession> listSpeakerSession = _context.SpeakerSessions.ToList();
            var result = listSpeakerSession.Where(a => a.SpeakerEmail == Verify).FirstOrDefault();


            return result;
    }
    
}