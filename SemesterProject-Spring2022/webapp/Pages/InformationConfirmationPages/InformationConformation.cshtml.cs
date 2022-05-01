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
using webapp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;



namespace webapp.Pages;

[Authorize]
public class InformationConfirmationModel : PageModel
{
    private readonly ILogger<InformationConfirmationModel> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    public InformationConfirmationModel(ILogger<InformationConfirmationModel> logger, ApplicationDbContext context, UserManager<IdentityUser> UserManager)
    {
        _logger = logger;
        _context = context;
        _userManager = UserManager;
        
    }

    [BindProperty]
    public Speaker speaker {get; set;}
    public static string Verify;
    public async Task OnGetAsync()
    {
        //gets the signed in user's email
        IdentityUser applicationUser = await _userManager.GetUserAsync(User);
        string userEmail = applicationUser?.Email; // will give the user's Email
        Verify = userEmail;
        speaker = CheckEmailInformation();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        IdentityUser applicationUser = await _userManager.GetUserAsync(User);
        Verify = null;
        return RedirectToPage("/Index");
    }
    public Speaker CheckEmailInformation()
    {
        IEnumerable<Speaker> listSpeaker = _context.Speaker.ToList();
        var result = listSpeaker.Where(s => s.Email.Equals(Verify)).FirstOrDefault();
        return(result);
    }
}