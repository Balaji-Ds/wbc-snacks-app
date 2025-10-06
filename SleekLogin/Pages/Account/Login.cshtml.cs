using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SleekLogin.Pages.Account;

public class LoginModel : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public class InputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (string.Equals(Input.Email, "demo@example.com", StringComparison.OrdinalIgnoreCase)
            && Input.Password == "Password123!")
        {
            return RedirectToPage("/Account/Welcome", new { email = Input.Email });
        }

        ModelState.AddModelError(string.Empty, "Invalid email or password. Try demo@example.com / Password123!");
        return Page();
    }
}
