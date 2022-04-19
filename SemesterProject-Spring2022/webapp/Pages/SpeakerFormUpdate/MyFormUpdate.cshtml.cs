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
            Verify = userEmail; //makes userEmail accessable   
            a = SelectUserId(); //sets speaker a equal to the signed in user
            
            //Sends new information to vaidation
            a.FirstName = helper.ValidateFirstName(speaker.FirstName);
            a.LastName = helper.ValidateLastName(speaker.LastName);
            a.Email = helper.ValidateEmailAddress(speaker.Email);
            a.Employer = helper.ValidateEmployer(speaker.Employer);
            a.Demonstration = helper.ValidateDemonstration(speaker.Demonstration);
            a.LunchCount = helper.ValidateLunchCount(speaker.LunchCount);
            a.TopicDes = helper.ValidateTopicDes(speaker.TopicDes);
            a.TopicTitle = helper.ValidateTopicTitle(speaker.TopicTitle);
            a.BusinessPhone = helper.ValidateBusinessPhone(speaker.BusinessPhone);
            a.CellPhone = helper.ValidateCellPhone(speaker.CellPhone);
            a.JobTitle = helper.ValidateJobTitle(speaker.JobTitle);
            a.Address = helper.ValidateAddress(speaker.Address);
            a.Email = userEmail;
            
            //saves the update in the database
            _context.Speaker.UpdateRange(a);
            await _context.SaveChangesAsync();
            //resets verify
            Verify = null;
            return RedirectToPage("/Index");
        }
    public Speaker SelectUserId()
    {
            //gets the signed in user and returns it as result
            IEnumerable<Speaker> listSpeaker = _context.Speaker.ToList();
            var result = listSpeaker.Where(s => s.Email.Equals(Verify)).FirstOrDefault();
            return(result);
    }
}