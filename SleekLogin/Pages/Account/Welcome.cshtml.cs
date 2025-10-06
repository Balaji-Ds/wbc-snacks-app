using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SleekLogin.Pages.Account;

public class WelcomeModel : PageModel
{
    [FromQuery(Name = "email")]
    public string? Email { get; set; }

    public string EmailDisplayed => string.IsNullOrWhiteSpace(Email) ? "Guest" : Email!;

    public void OnGet()
    {
    }
}
