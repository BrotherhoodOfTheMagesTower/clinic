using Clinic.Data.Models;

namespace Clinic.Areas.Identity.Data
{
    public class Address
    {
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public int HouseNumber { get; set; }
        public int? LocalNumber { get; set; }
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
