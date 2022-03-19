
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinic.Areas.Identity.Data
{
    public class Administrator
    {
        [ForeignKey(nameof(User))]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }
    }
}
