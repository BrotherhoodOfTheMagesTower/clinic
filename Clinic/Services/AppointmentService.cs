using Clinic.Areas.Identity.Data;
using Clinic.Data;
using Clinic.Data.Models;

namespace Clinic.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _context;

        public AppointmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
        }

        public List<Appointment> GetAllAppointmets()
            => _context.Appointments.ToList();

        public List<Appointment> GetDoctorAppointments(Doctor doctor)
            => _context.Appointments.Where(a => a.Doctor.Id == doctor.Id ).ToList();

        public List<Appointment> GetPatientAppointments(Patient patient)
            => _context.Appointments.Where(a => a.Patient.Id == patient.Id).ToList();
    }
}
