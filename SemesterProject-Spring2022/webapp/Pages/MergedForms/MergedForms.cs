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
using Repository;
using LosBarriosDomain;

namespace webapp.Pages;
[Authorize] //need to login to see form page
public class InformationModel : PageModel
{
    private readonly ILogger<InformationModel> _logger;
    private readonly ApplicationDbContext _context;
    private IUnitOfWork _UnitOfWork;

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
        
    [BindProperty]
    public Speaker speaker {get; set;}
    // speaker.Email = _context.Users.
    public Speaker a {get; set;}
    MySpeakerHelper helper = new MySpeakerHelper();
    // speaker.FirstName = helper.ValidateJobTitle
    public string Verify;

    public InformationModel(ILogger<InformationModel> logger,IUnitOfWork UnitOfWork, ApplicationDbContext context, UserManager<IdentityUser> UserManager, SignInManager<IdentityUser> SignInManager)
    {
        _logger = logger;
        _context = context;
        _userManager = UserManager;
        _UnitOfWork = UnitOfWork;
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
        speaker.FirstName = _UnitOfWork.SpeakerHelper.ValidateFirstName(speaker.FirstName);
        speaker.LastName = _UnitOfWork.SpeakerHelper.ValidateLastName(speaker.LastName);
        speaker.Email = _UnitOfWork.SpeakerHelper.ValidateEmailAddress(speaker.Email);
        speaker.Employer = _UnitOfWork.SpeakerHelper.ValidateEmployer(speaker.Employer);
        speaker.Demonstration = _UnitOfWork.SpeakerHelper.ValidateDemonstration(speaker.Demonstration);
        speaker.LunchCount = _UnitOfWork.SpeakerHelper.ValidateLunchCount(speaker.LunchCount);
        speaker.TopicDes = _UnitOfWork.SpeakerHelper.ValidateTopicDes(speaker.TopicDes);
        speaker.TopicTitle = _UnitOfWork.SpeakerHelper.ValidateTopicTitle(speaker.TopicTitle);
        speaker.BusinessPhone = _UnitOfWork.SpeakerHelper.ValidateBusinessPhone(speaker.BusinessPhone);
        speaker.CellPhone = _UnitOfWork.SpeakerHelper.ValidateCellPhone(speaker.CellPhone);
        speaker.JobTitle = _UnitOfWork.SpeakerHelper.ValidateJobTitle(speaker.JobTitle);
        speaker.Address = _UnitOfWork.SpeakerHelper.ValidateAddress(speaker.Address);
        speaker.Email = Verify;
        // _context.Speaker.Add(speaker);
        // await _context.SaveChangesAsync();
        await _UnitOfWork.Speaker.Add(speaker); 
        _UnitOfWork.Complete();  
    }
    public async Task UpdateSpeakerAsync(){
        IdentityUser applicationUser = await _userManager.GetUserAsync(User);
        string userEmail = applicationUser?.Email; // will give the user's Email
        Verify = userEmail; //makes userEmail accessable   
        a = SelectUserId(); //sets speaker a equal to the signed in user
        //Sends new information to vaidation
        a.FirstName = _UnitOfWork.SpeakerHelper.ValidateFirstName(speaker.FirstName);
        a.LastName = _UnitOfWork.SpeakerHelper.ValidateLastName(speaker.LastName);
        a.Email = _UnitOfWork.SpeakerHelper.ValidateEmailAddress(speaker.Email);
        a.Employer = _UnitOfWork.SpeakerHelper.ValidateEmployer(speaker.Employer);
        a.Demonstration = _UnitOfWork.SpeakerHelper.ValidateDemonstration(speaker.Demonstration);
        a.LunchCount = _UnitOfWork.SpeakerHelper.ValidateLunchCount(speaker.LunchCount);
        a.TopicDes = _UnitOfWork.SpeakerHelper.ValidateTopicDes(speaker.TopicDes);
        a.TopicTitle = _UnitOfWork.SpeakerHelper.ValidateTopicTitle(speaker.TopicTitle);
        a.BusinessPhone = _UnitOfWork.SpeakerHelper.ValidateBusinessPhone(speaker.BusinessPhone);
        a.CellPhone = _UnitOfWork.SpeakerHelper.ValidateCellPhone(speaker.CellPhone);
        a.JobTitle = _UnitOfWork.SpeakerHelper.ValidateJobTitle(speaker.JobTitle);
        a.Address = _UnitOfWork.SpeakerHelper.ValidateAddress(speaker.Address);
        a.Email = userEmail;
        
        //saves the update in the database
        // _context.Speaker.UpdateRange(a);
        // await _context.SaveChangesAsync();
        _UnitOfWork.Speaker.Update(a);
        _UnitOfWork.Complete();  
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