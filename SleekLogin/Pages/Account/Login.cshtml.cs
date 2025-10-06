using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SleekLogin.Pages.Account;

public class LoginModel : PageModel
{
    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [BindProperty]
    public bool RememberMe { get; set; }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var isValid = string.Equals(Email, "demo@example.com", StringComparison.OrdinalIgnoreCase)
                      && Password == "Password123!";

        if (!isValid)
        {
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return Page();
        }

        TempData["LoginMessage"] = $"Welcome back, {Email}!";
        return RedirectToPage("/Index");
    }
}
