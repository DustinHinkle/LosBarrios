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



namespace webapp.Pages;
//[Authorize]
public class FormModel : PageModel
{
    private readonly ILogger<FormModel> _logger;
    private readonly ApplicationDbContext _context;
    public FormModel(ILogger<FormModel> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
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

    MySpeakerHelper helper = new MySpeakerHelper();
    // speaker.FirstName = helper.ValidateJobTitle
    public bool x = true;
    public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            while(x == true)
            {
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
                x = false;
            }
            

            _context.Speaker.Add(speaker);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }






    // public Speaker CreateSpeaker(webapp.Data.ApplicationDbContext.IdentityDbContext _context)
    // {
    //     _context = context;
    // }

    // [BindProperty]
    // [Required]
    // [EmailAddress] // an internal validation property for Email addresses
    // [StringLength(40, MinimumLength = 3)]// max length set to 40 felt arbitrarily reasonable
    // [Display(Name = "E-Mail")]// Name of the Field ... kept getting errors thinking email = e-mail
    // public string Email {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "First Name")]
    // public string FirstName {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Last Name")]
    // public string LastName {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Job Title")]
    // public string JobTitle {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Employer")]
    // public string Employer {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Address")]
    // public string Address {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Cell Phone")]
    // public string CellPhone {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Business Phone")]
    // public string BusinessPhone {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Demonstration")]
    // public string Demonstration {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Lunch Count")]
    // public int LunchCount {get; set;}

    // [BindProperty]
    // [Required]
    // [Display(Name = "Topic Title")]
    // public string TopicTitle {get; set;}

    // [BindProperty]
    // [Display(Name = "Topic Description")]
    // public string TopicDes {get; set;}

    // public async Task<IActionResult>OnPostAsync(){
    //     context.Speaker.Add(Speaker);
    //     context.Speaker.SaveChangesAsync();

    //     return RedirectToPage("./Index");
    // }


    
    // public async Task<IActionResult> OnPostAsync()
    //     {
    //         if (!ModelState.IsValid)
    //         {
    //             return Page();
    //         }

    //         // _context.Speaker.Add(speaker);
    //         // await _context.SaveChangesAsync();

    //         return RedirectToPage("./Index");
    //     }
}