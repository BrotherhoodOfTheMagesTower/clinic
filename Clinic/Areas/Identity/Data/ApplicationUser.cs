using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "The E-mail field is required")]
        [EmailAddress(ErrorMessage = "E-Mail adress is not valid.")]
        public override string Email { get => base.Email; set => base.Email = value; }
    }
}
