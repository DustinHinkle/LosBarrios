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
public class InformationModel : PageModel
{
    private readonly ILogger<InformationModel> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
        
    [BindProperty]
    public Speaker speaker {get; set;}
    // speaker.Email = _context.Users.
    public Speaker a {get; set;}
    MySpeakerHelper helper = new MySpeakerHelper();
    // speaker.FirstName = helper.ValidateJobTitle
    public string Verify;
    public bool x;

    public InformationModel(ILogger<InformationModel> logger, ApplicationDbContext context, UserManager<IdentityUser> UserManager, SignInManager<IdentityUser> SignInManager)
    {
        _logger = logger;
        _context = context;
        _userManager = UserManager;
        _signInManager = SignInManager;
        
    }
    public async Task OnGet()
    {
        IdentityUser applicationUser = await _userManager.GetUserAsync(User);
        string userEmail = applicationUser?.Email; // will give the user's Email
        Verify = userEmail;
        a = SelectUserId();
    }
    public async Task<IActionResult> OnPostAsync()
    {
        //gets the Identity user and sets their database entry to test
        IdentityUser applicationUser = await _userManager.GetUserAsync(User);
        string userEmail = applicationUser?.Email; // will give the user's Email
        var test = _context.Speaker.Where(s => s.Email == userEmail).FirstOrDefault();
        if(test != null)
        {
            Console.WriteLine("Update");
            await UpdateSpeakerAsync();
            return RedirectToPage("/Index");
        }else{
            Console.WriteLine("New Speaker");
            await AddNewSpeaker();
            return RedirectToPage("/Index");
        }
    }

    public async Task AddNewSpeaker(){
        IdentityUser applicationUser = await _userManager.GetUserAsync(User);
        string userEmail = applicationUser?.Email; // will give the user's Email
        Verify = userEmail; //makes userEmail accessable  
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
        speaker.Email = Verify;
        _context.Speaker.Add(speaker);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateSpeakerAsync(){
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
    }
    public Speaker SelectUserId()
    {
            //gets the signed in user and returns it as result
            IEnumerable<Speaker> listSpeaker = _context.Speaker.ToList();
            var result = listSpeaker.Where(s => s.Email.Equals(Verify)).FirstOrDefault();
            return(result);
    }
}