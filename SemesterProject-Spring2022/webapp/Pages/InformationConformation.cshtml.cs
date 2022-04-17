using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;



namespace webapp.Pages;

public class InformationConfirmationModel : PageModel
{
    private readonly ILogger<InformationConfirmationModel> _logger;

    public InformationConfirmationModel(ILogger<InformationConfirmationModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        
    }
}