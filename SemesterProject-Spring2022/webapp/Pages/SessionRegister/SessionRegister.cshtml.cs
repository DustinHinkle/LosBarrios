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
    

    MySpeakerSessionHelper helper = new MySpeakerSessionHelper();
    public async Task<IActionResult> OnPostAsync()
        {

            IdentityUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email
            if (!ModelState.IsValid)
            {
                return Page();
            }
        
            
            session.Podium = helper.ValidatePodium (session.Podium);
            session.Outlet = helper.ValidateOutlet (session.Outlet);
            session.CleanWall = helper.ValidateCleanWall (session.CleanWall);
            session.WhiteBoard = helper.ValidateWhiteBoard (session.WhiteBoard);
            session.DemoTable = helper.ValidateDemoTable (session.DemoTable);
            session.SessionSpeaker = helper.ValidateSpeaker(session.SessionSpeaker);
            session.SessionCategory = helper.ValidateSessionCategory(session.SessionCategory);
            session.SessionOne = helper.ValidateSessionOne(session.SessionOne);
            session.SessionTwo = helper.ValidateSessionTwo(session.SessionTwo);
            session.SignupDate = DateTime.Today;
            // speaker.Email = userEmail;
            
                
            
            
            _context.SpeakerSessions.Add(session);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    
}