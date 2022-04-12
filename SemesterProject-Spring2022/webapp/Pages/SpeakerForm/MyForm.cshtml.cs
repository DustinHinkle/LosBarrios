using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LosBarriosDomain.Models;
using webapp.Data;
using Microsoft.AspNetCore.Mvc.Rendering;



namespace webapp.Pages;
//[Authorize]
public class FormModel : PageModel
{
    private readonly ILogger<FormModel> _logger;

    public FormModel(ILogger<FormModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
    
    public Speaker CreateSpeaker(webapp.Data.ApplicationDbContext.IdentityDbContext _context)
    {
        _context = context;
    }

    [BindProperty]
    [Required]
    [EmailAddress] // an internal validation property for Email addresses
    [StringLength(40, MinimumLength = 3)]// max length set to 40 felt arbitrarily reasonable
    [Display(Name = "E-Mail")]// Name of the Field ... kept getting errors thinking email = e-mail
    public string Email {get; set;}
    [BindProperty]
    [Required]
    [StringLength(40, MinimumLength = 1)]
    [Display(Name = "First Name")]
    public string FirstName {get; set;}
    [BindProperty]
    [Required]
    [StringLength(40, MinimumLength = 1)]
    [Display(Name = "Last Name")]
    public string LastName {get; set;}
    [BindProperty]
    [Required]
    [StringLength(40, MinimumLength = 1)]
    [Display(Name = "Job Title")]
    public string JobTitle {get; set;}
    [BindProperty]
    [Required]
    [StringLength(40, MinimumLength = 1)]
    [Display(Name = "Employer")]
    public string Employer {get; set;}
    [BindProperty]
    [Required]
    [Display(Name = "Address")]
    public string Address {get; set;}
    [BindProperty]
    [Required]
    [Display(Name = "Cell Phone")]
    public string CellPhone {get; set;}
    [BindProperty]
    [Required]
    [Display(Name = "Business Phone")]
    public string BusinessPhone {get; set;}
    [BindProperty]
    [Required]
    [Display(Name = "Demonstration")]
    public string Demonstration {get; set;}
    [BindProperty]
    [Required]
    [Range(0, 10, ErrorMessage = "Please enter valid number")]
    [Display(Name = "Lunch Count")]
    public int LunchCount {get; set;}
    [BindProperty]
    [Required]
    [StringLength(40, MinimumLength = 1)]
    [Display(Name = "Topic Title")]
    public string TopicTitle {get; set;}
    [BindProperty]
    [Required]
    [Display(Name = "Topic Description")]
    public string TopicDes {get; set;}

    public async Task<IActionResult>OnPostAsync(){
        context.Speaker.Add(Speaker);
        context.Speaker.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}