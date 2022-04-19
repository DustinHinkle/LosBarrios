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
[Authorize] //need to login to see form page
public class FormUpdateModel : PageModel
{
    private readonly ILogger<FormUpdateModel> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    public FormUpdateModel(ILogger<FormUpdateModel> logger, ApplicationDbContext context, UserManager<IdentityUser> UserManager)
    {
        _logger = logger;
        _context = context;
        _userManager = UserManager;
        
    }
    // public FormModel(ApplicationDbContext context)
    //     {
    //         _context = context;
    //     }

    public void OnGet()
    {
    }
    [BindProperty]
    public Speaker speaker {get; set;}
    // speaker.Email = _context.Users.
    public Speaker a {get; set;}
    MySpeakerHelper helper = new MySpeakerHelper();
    // speaker.FirstName = helper.ValidateJobTitle
    public string Verify;
    public async Task<IActionResult> OnPostAsync()
        {
            // ApplicationUser applicationUser = await _userManager.GetUserAsync(User);
            // string userEmail = applicationUser?.Email; // will give the user's Email
            // var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            // var userName =  User.FindFirstValue(ClaimTypes.Name) // will give the user's userName

            IdentityUser applicationUser = await _userManager.GetUserAsync(User);
            string userEmail = applicationUser?.Email; // will give the user's Email
            Verify = userEmail;
            a = SelectUserId();
            a = speaker;
            
            speaker.FirstName = helper.ValidateFirstName(speaker.FirstName);
            speaker.LastName = helper.ValidateLastName(speaker.LastName);
            speaker.Email = helper.ValidateEmailAddress(speaker.Email);
            speaker.Employer = helper.ValidateEmployer(speaker.Employer);
            speaker.Demonstration = helper.ValidateDemonstration(speaker.Demonstration);
            speaker.LunchCount = helper.ValidateLunchCount(speaker.LunchCount);
            speaker.TopicDes = helper.ValidateTopicDes(speaker.TopicDes);
            speaker.TopicTitle = helper.ValidateTopicTitle(speaker.TopicTitle);
            speaker.BusinessPhone = helper.ValidateBusinessPhone(speaker.BusinessPhone);
            speaker.CellPhone = helper.ValidateCellPhone(speaker.CellPhone);
            speaker.JobTitle = helper.ValidateJobTitle(speaker.JobTitle);
            speaker.Address = helper.ValidateAddress(speaker.Address);
            speaker.Email = userEmail;
            
            _context.Speaker.UpdateRange(a);
            await _context.SaveChangesAsync();
            Verify = null;
            return RedirectToPage("/Index");
        }
    public Speaker SelectUserId()
    {
            IEnumerable<Speaker> listSpeaker = _context.Speaker.ToList();
            var result = listSpeaker.Where(s => s.Email.Equals(Verify)).FirstOrDefault();
            return(result);
    }
}