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
using LosBarriosDomain;



namespace webapp.Pages;
[Authorize] //need to login to see form page
public class FormUpdateModel : PageModel
{
    private readonly ILogger<FormUpdateModel> _logger;
    private readonly ApplicationDbContext _context;
    private IUnitOfWork _UnitOfWork;
    private readonly UserManager<IdentityUser> _userManager;
    public FormUpdateModel(ILogger<FormUpdateModel> logger,IUnitOfWork UnitOfWork, ApplicationDbContext context, UserManager<IdentityUser> UserManager)
    {
        _logger = logger;
        _context = context;
        _userManager = UserManager;
        _UnitOfWork = UnitOfWork;

        
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
    MySpeakerHelper SpeakerHelper = new MySpeakerHelper();
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
            _UnitOfWork.Speaker.Update(a);
            _UnitOfWork.Complete();  
    //         public void UpdateSpeaker(Speaker entity)
    // {
    //     _context.Set<Speaker>().Update(entity);
    // }

            
            //saves the update in the database
            // _context.Speaker.UpdateRange(a);
            // await _context.SaveChangesAsync();
            //resets verify
            Verify = null;
            return RedirectToPage("/Index");
        }
    public Speaker SelectUserId()
    {
            // gets the signed in user and returns it as result
            IEnumerable<Speaker> listSpeaker = _context.Speaker.ToList();
            var result = listSpeaker.Where(s => s.Email.Equals(Verify)).FirstOrDefault();
            return(result);

            // IEnumerable<Speaker> listSpeaker = _UnitOfWork.Speaker.GetAll();
            // var result = listSpeaker.Where(s => s.Email.Equals(Verify)).FirstOrDefault();

            // IEnumerable<Speaker> listSpeaker = await Repository.GetListAsync();

        
            // IEnumerable<Speaker> SS = await _UnitOfWork.Speaker.GetAll();
            // Speaker = new List<Speaker>(SS)

            
    }
}