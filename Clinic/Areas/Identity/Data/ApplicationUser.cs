using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [StringLength(255, ErrorMessage = "The first name field should have maximum 255 characters")]
        public string? FirstName { get; set; }

        [StringLength(255, ErrorMessage = "The first name field should have maximum 255 characters")]
        public string? LastName { get; set; }

        public bool IsActive { get; set; }
    }
}
