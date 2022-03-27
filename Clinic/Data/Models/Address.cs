using Clinic.Data.Models;

namespace Clinic.Areas.Identity.Data
{
    public class Address
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string HouseNumber { get; set; }
        public string? LocalNumber { get; set; }
        public ICollection<Patient> Patients { get; set; }
    }
}
