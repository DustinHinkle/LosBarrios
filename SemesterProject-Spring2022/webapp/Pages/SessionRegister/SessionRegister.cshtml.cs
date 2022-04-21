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
    

    MySpeakerHelper helper = new MySpeakerHelper();
    public async Task<IActionResult> OnPostAsync()
        {

            IdentityUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            // speaker.FirstName = helper.ValidateFirstName(speaker.FirstName);
            // speaker.LastName = helper.ValidateLastName(speaker.LastName);
            // speaker.Email = helper.ValidateEmailAddress(speaker.Email);
            // speaker.Employer = helper.ValidateEmployer(speaker.Employer);
            // speaker.Demonstration = helper.ValidateDemonstration(speaker.Demonstration);
            // speaker.LunchCount = helper.ValidateLunchCount(speaker.LunchCount);
            // speaker.TopicDes = helper.ValidateTopicDes(speaker.TopicDes);
            // speaker.TopicTitle = helper.ValidateTopicTitle(speaker.TopicTitle);
            // speaker.BusinessPhone = helper.ValidateBusinessPhone(speaker.BusinessPhone);
            // speaker.CellPhone = helper.ValidateCellPhone(speaker.CellPhone);
            // speaker.JobTitle = helper.ValidateJobTitle(speaker.JobTitle);
            // speaker.Address = helper.ValidateAddress(speaker.Address);
            // speaker.Email = userEmail;
            
                
            
            
            _context.SpeakerSessions.Add(session);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    
}