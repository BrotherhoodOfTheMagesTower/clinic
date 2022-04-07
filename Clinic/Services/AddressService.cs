using Clinic.Areas.Identity.Data;
using Clinic.Data;

namespace Clinic.Services
{
    public class AddressService
    {
        private readonly ApplicationDbContext _context;

        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }
        public Address GetById(Guid id)
        {
            return _context.Addresses.FirstOrDefault(p => p.Id == id);
        }

        public List<Address> GetAllAddresses()
            => _context.Addresses.ToList();

        public void Update(Address address)
        {
            _context.Addresses.Update(address);
            _context.SaveChanges();
        }
    }
}
