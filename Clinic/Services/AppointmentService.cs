using Clinic.Areas.Identity.Data;
using Clinic.Data;
using Clinic.Data.Models;
using Microsoft.EntityFrameworkCore;

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
            _context.SaveChanges();
        }

        public Appointment? GetById(Guid id)
             => _context.Appointments.FirstOrDefault(a => a.Id == id);

        public async Task<Appointment?> GetByIdAsync(Guid id)
          => await _context.Appointments
            .Include(p => p.Patient)
            .Include(p => p.Registrar)
            .Include(p => p.Doctor)
            .Include(p => p.LaboratoryExaminations)
            .Include(p => p.PhysicalExaminations)
            .FirstOrDefaultAsync(a => a.Id == id);

        public void Update(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public List<Appointment> GetAllAppointmets()
            => _context.Appointments.ToList();

        public List<Appointment> GetDoctorAppointments(Doctor doctor)
            => _context.Appointments.Where(a => a.Doctor.Id == doctor.Id).ToList();

        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(Doctor doctor)
            => await _context.Appointments
                .Include(p => p.Patient)
                .Include(p => p.Registrar)
                .Where(a => a.Doctor.Id == doctor.Id)
                .ToListAsync();

        public async Task<List<LaboratoryExamination>> GetLaboratoryExaminationsAsync(Appointment appointment)
            => await _context.LaboratoryExaminations
                .Include(l => l.LabManager)
                .Include(l => l.LabTechnician)
                .Include(g => g.GlossaryDictionary)
                .Include(a => a.Appointment)
                .Where(a => a.Id == appointment.Id)
                .ToListAsync();
        public async Task<List<PhysicalExamination>> GetPhysicalExaminationsAsync(Appointment appointment)
           => await _context.PhysicalExaminations
               .Include(l => l.GlossaryDictionary)
               .Include(a => a.Appointment)
               .Where(a => a.Id == appointment.Id)
               .ToListAsync();

        public List<Appointment> GetPatientAppointments(Patient patient)
            => _context.Appointments.Where(a => a.Patient.Id == patient.Id).ToList();
    }
}