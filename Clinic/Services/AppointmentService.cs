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

        public bool Add(Appointment appointment)
        {
            if (appointment == null) return false;
            var obj = GetAppointmentByDoctorAndTime(appointment.RegisteredTo, appointment.Doctor.Id);
            if (obj != null)
                return false;
            var guid = Guid.NewGuid();
            appointment.Id = guid;
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return true;
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
            if (appointment == null) return;
            _context.Appointments.Update(appointment);
            _context.SaveChanges();
        }

        public List<Appointment> GetAllAppointmets()
        {
            return _context.Appointments
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .ToList();

        }

        public List<Appointment> GetDoctorAppointments(Doctor doctor)
            => _context.Appointments.Where(a => a.Doctor.Id == doctor.Id).ToList();

        public async Task<List<Appointment>> GetDoctorAppointmentsAsync(Doctor doctor)
            => await _context.Appointments
                .Include(p => p.Patient)
                .Include(p => p.Registrar)
                .Where(a => a.Doctor.Id == doctor.Id)
                .ToListAsync();

        public async Task<List<Appointment>> GetDoctorAppointmentsByStatusAsync(Doctor doctor, AppointmentStatus status)
            => await _context.Appointments
                .Include(p => p.Patient)
                .Include(p => p.Registrar)
                .Where(a => a.Doctor.Id == doctor.Id)
                .Where(s => s.Status == status)
                .ToListAsync();

        public List<Appointment> GetPatientAppointments(Patient patient)
            => _context.Appointments.Where(a => a.Patient.Id == patient.Id).ToList();

        public async Task<List<Appointment>> GetPatientAppointmentsAsync(Patient patient)
           => await _context.Appointments
            .Include(d => d.Doctor)
            .Where(p => p.Patient == patient).ToListAsync();

        public List<Appointment> GetAppointmentsByPatternAsync(string pattern)
        {
            List<Appointment>? appointmentList = null;
            string[] words = pattern.Split(' ');
            foreach (var word in words)
            {
                List<Appointment> tmp = _context.Appointments
                    .Include(a => a.Patient)
                    .Include(a => a.Doctor)
                    .Where((a => a.Patient.FirstName.Contains(word) || a.Patient.LastName.Contains(word) || a.Doctor.FirstName.Contains(word) || a.Doctor.LastName.Contains(word))).ToList();
                if (appointmentList == null)
                    appointmentList = tmp;
                else
                    appointmentList.AddRange(tmp);
            }

            return appointmentList;
        }

        public Appointment? GetAppointmentByDoctorAndTime(DateTime dateTime, string doctorId)
        {
            Appointment? appointment = _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.RegisteredTo == dateTime && a.Doctor.Id == doctorId)
                .FirstOrDefault();
            return appointment;
        }

        public List<DateTime> GetAvailableDatesByDoctorAndTime(DateTime dateTime, string doctorId)
        {
            List<DateTime> appointments = _context.Appointments
                .Where(a => a.RegisteredTo.Day == dateTime.Day && a.Doctor.Id == doctorId)
                .Select(d => d.RegisteredTo)
                .ToList();
            return appointments;
        }


        public List<DateTime> GetAvailableHours(DateTime dateTime, string doctorId)
        {
            List<DateTime> avaiableHours = new List<DateTime>();
            DateTime actualHour = dateTime;
            TimeSpan ts = new TimeSpan(8, 0, 0);
            actualHour = actualHour.Date + ts;
            avaiableHours.Add(actualHour);
            while (actualHour.Hour < 16)
            {
                actualHour = actualHour.AddMinutes(15);
                avaiableHours.Add(actualHour);
            }

            List<DateTime> doctorAppointments = GetAvailableDatesByDoctorAndTime(dateTime, doctorId);


            foreach (DateTime doctorAppointment in doctorAppointments)
            {
                foreach (DateTime avaiableHour in avaiableHours)
                { 
                    if (doctorAppointment == avaiableHour)
                    {
                        avaiableHours.Remove(avaiableHour);
                        break;
                    }
                }
            }
            
            return avaiableHours;
        }
    }
}