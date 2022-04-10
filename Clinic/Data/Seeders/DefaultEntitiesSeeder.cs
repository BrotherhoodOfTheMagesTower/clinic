using Clinic.Areas.Identity.Data;
using Clinic.Constants;
using Clinic.Data.Models;
using Clinic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data
{
    public static class DefaultEntitiesSeeder
    {
        public static List<Tuple<ApplicationUser, string>> SeedUsers(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            var usersWithParticularRole = new List<Tuple<ApplicationUser, string>> { };

            //Seed 3 Doctors
            if (!context!.Doctors.Any() || context!.Doctors.Count() < 3)
            {
                if(context!.Users.FirstOrDefault(x => x.Email == "doctor@1.com") == null)
                {
                    var doctor = new Doctor
                    {
                        FirstName = "Dominik",
                        LastName = "Kowalski",
                        PermissionNumber = 111111,
                        User = new ApplicationUser
                        {
                            Email = "doctor@1.com",
                            NormalizedEmail = "DOCTOR@1.COM",
                            UserName = "doctor@1.com",
                            NormalizedUserName = "DOCTOR@1.COM",
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString()
                        }
                    };
                    usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(doctor.User, Roles.Doctor));
                    doctor.User.HashPassword();
                    context!.Doctors.Add(doctor);
                }

                if (context!.Users.FirstOrDefault(x => x.Email == "doctor@2.com") == null)
                {
                    var doctor = new Doctor
                    {
                        FirstName = "Dorian",
                        LastName = "Więckowski",
                        PermissionNumber = 222222,
                        User = new ApplicationUser
                        {
                            Email = "doctor@2.com",
                            NormalizedEmail = "DOCTOR@2.COM",
                            UserName = "doctor@2.com",
                            NormalizedUserName = "DOCTOR@2.COM",
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString()
                        }
                    };
                    usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(doctor.User, Roles.Doctor));
                    doctor.User.HashPassword();
                    context!.Doctors.Add(doctor);
                }

                if (context!.Users.FirstOrDefault(x => x.Email == "doctor@3.com") == null)
                {
                    var doctor = new Doctor
                    {
                        FirstName = "Dorota",
                        LastName = "Bzik",
                        PermissionNumber = 333333,
                        User = new ApplicationUser
                        {
                            Email = "doctor@3.com",
                            NormalizedEmail = "DOCTOR@3.COM",
                            UserName = "doctor@3.com",
                            NormalizedUserName = "DOCTOR@3.COM",
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString()
                        }
                    };
                    usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(doctor.User, Roles.Doctor));
                    doctor.User.HashPassword();
                    context!.Doctors.Add(doctor);
                }
            }

            //Seed 1 Registrar
            if (!context.Registrars.Any())
            {
                var registrar = new Registrar
                {
                    FirstName = "Renata",
                    LastName = "Sierzputowska",
                    User = new ApplicationUser
                    {
                        Email = "registrar@registrar.com",
                        NormalizedEmail = "REGISTRAR@REGISTRAR.COM",
                        UserName = "registrar@registrar.com",
                        NormalizedUserName = "REGISTRAR@REGISTRAR.COM",
                        EmailConfirmed = true,
                        SecurityStamp = Guid.NewGuid().ToString()
                    }
                };

                usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(registrar.User, Roles.Registrar)); ;
                registrar.User.HashPassword();
                context!.Registrars.Add(registrar);
            }

            //Seed 2 Lab Technicians
            if (!context.LabTechnicians.Any() || context!.LabTechnicians.Count() < 2)
            {
                if (context!.Users.FirstOrDefault(x => x.Email == "labtechnician@1.com") == null)
                {
                    var labTechnician = new LabTechnician
                    {
                        FirstName = "Teodor",
                        LastName = "Wysoki",
                        User = new ApplicationUser
                        {
                            Email = "labtechnician@1.com",
                            NormalizedEmail = "LABTECHNICIAN@1.COM",
                            UserName = "labtechnician@1.com",
                            NormalizedUserName = "LABTECHNICIAN@1.COM",
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString()
                        }
                    };
                    usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(labTechnician.User, Roles.LabTechnician));
                    labTechnician.User.HashPassword();
                    context!.LabTechnicians.Add(labTechnician);
                }

                if (context!.Users.FirstOrDefault(x => x.Email == "labtechnician@2.com") == null)
                {
                    var labTechnician = new LabTechnician
                    {
                        FirstName = "Teresa",
                        LastName = "Kręciołek",
                        User = new ApplicationUser
                        {
                            Email = "labtechnician@2.com",
                            NormalizedEmail = "LABTECHNICIAN@2.COM",
                            UserName = "labtechnician@2.com",
                            NormalizedUserName = "LABTECHNICIAN@2.COM",
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString()
                        }
                    };
                    usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(labTechnician.User, Roles.LabTechnician));
                    labTechnician.User.HashPassword();
                    context!.LabTechnicians.Add(labTechnician);
                }

            }

            //Seed 2 Lab Managers
            if (!context.LabManagers.Any() || context!.LabTechnicians.Count() < 2)
            {
                if (context!.Users.FirstOrDefault(x => x.Email == "labmanager@1.com") == null)
                {
                    var labManager = new LabManager
                    {
                        FirstName = "Maria",
                        LastName = "Myszkowska",
                        User = new ApplicationUser
                        {
                            Email = "labmanager@1.com",
                            NormalizedEmail = "LABMANAGER@1.COM",
                            UserName = "labmanager@1.com",
                            NormalizedUserName = "LABMANAGER@1.COM",
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString()
                        }
                    };

                    usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(labManager.User, Roles.LabManager));
                    labManager.User.HashPassword();
                    context!.LabManagers.Add(labManager);
                }

                if (context!.Users.FirstOrDefault(x => x.Email == "labmanager@2.com") == null)
                {
                    var labManager = new LabManager
                    {
                        FirstName = "Manuel",
                        LastName = "Mielikowski",
                        User = new ApplicationUser
                        {
                            Email = "labmanager@2.com",
                            NormalizedEmail = "LABMANAGER@2.COM",
                            UserName = "labmanager@2.com",
                            NormalizedUserName = "LABMANAGER@2.COM",
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString()
                        }
                    };

                    usersWithParticularRole.Add(new Tuple<ApplicationUser, string>(labManager.User, Roles.LabManager));
                    labManager.User.HashPassword();
                    context!.LabManagers.Add(labManager);
                }

            }

            context!.SaveChanges();

            return usersWithParticularRole;
        }

        public static async Task AssignRoles(this IServiceProvider serviceProvider, List<Tuple<ApplicationUser, string>> users)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            UserManager<ApplicationUser>? _userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            foreach (var user in users)
            {
                var usr = await _userManager!.FindByEmailAsync(user.Item1.Email);

                if (!await _userManager.IsInRoleAsync(usr, user.Item2))
                    await _userManager.AddToRoleAsync(usr, user.Item2);
            }

            context!.SaveChanges();
        }

        private static void HashPassword(this ApplicationUser user, string psswd = "Password123!")
        {
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user, psswd);
            user.PasswordHash = hashed;
        }

        public static async Task SeedDefaultEntities(this IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();

            //Seed 3 Patients & 2 Addresses (one Patient without Address)
            if (!context!.Patients.Any() || context.Patients.Count() < 3)
            {
                if (!context.Patients.Any(x => x.Id == Guid.Parse("ba6c78a4-9cff-4bb1-acbd-f4c23a063616")))
                {
                    var patient = new Patient
                    {
                        Id = Guid.Parse("ba6c78a4-9cff-4bb1-acbd-f4c23a063616"),
                        FirstName = "Patrycja",
                        LastName = "Konicz",
                        Pesel = "01217802012",
                        BirthDate = new DateTime(1999, 12, 23),
                        PhoneNumber = "625976788",
                        Gender = Enums.Gender.FEMALE,
                        Appointments = null,
                        Address = null
                    };

                    var address = new Address
                    {
                        Id = Guid.Parse("9c755080-ba6b-48f1-854d-1816ad5fa74a"),
                        Street = "Mickiewicza",
                        PostalCode = "42-300",
                        City = "Radom",
                        HouseNumber = "12",
                        LocalNumber = null,
                        Patients = new[] { patient }
                    };
                    patient.Address = address;

                    context.Patients.Add(patient);
                    context.Addresses.Add(address);
                    context.SaveChanges();
                }

                if (!context.Patients.Any(x => x.Id == Guid.Parse("07a59249-4c98-4034-9708-5ae4fd895e31")))
                {
                    var patient = new Patient
                    {
                        Id = Guid.Parse("07a59249-4c98-4034-9708-5ae4fd895e31"),
                        FirstName = "Paulina",
                        LastName = "Kunicka",
                        Pesel = "93317107048",
                        BirthDate = new DateTime(1996, 6, 10),
                        PhoneNumber = "538125238",
                        Gender = Enums.Gender.FEMALE,
                        Appointments = null,
                        Address = null
                    };

                    var address = new Address
                    {
                        Id = Guid.Parse("50c37e41-99f2-4bec-8d85-5eb24ce71431"),
                        Street = "Wolności",
                        PostalCode = "32-930",
                        City = "Szczecin",
                        HouseNumber = "199",
                        LocalNumber = null,
                        Patients = new[] { patient }
                    };
                    patient.Address = address;

                    context.Patients.Add(patient);
                    context.Addresses.Add(address);
                    context.SaveChanges();
                }

                if (!context.Patients.Any(x => x.Id == Guid.Parse("54319b96-4f10-4a47-a880-d85ebe60ac70")))
                {
                    var patient = new Patient
                    {
                        Id = Guid.Parse("54319b96-4f10-4a47-a880-d85ebe60ac70"),
                        FirstName = "Patryk",
                        LastName = "Niedopieralski",
                        Pesel = "76530186943",
                        BirthDate = new DateTime(2002, 3, 27),
                        PhoneNumber = "786578354",
                        Gender = Enums.Gender.MALE,
                        Appointments = null,
                        Address = null
                    };

                    context.Patients.Add(patient);
                    context.SaveChanges();
                }
            }

            //Seed 4 appointments (and 4 examinations for one specific appointment - 2 Lab (Blood & COVID), 2 Physical (Ear & Throat))
            if (!context!.Appointments.Any() || context.Appointments.Count() < 4)
            {
                var doctorService = new DoctorService(context);
                var registrarService = new RegistrarService(context);
                var patientService = new PatientService(context);
                var glossaryService = new GlossaryService(context);
                var labTechnicianService = new LabTechnicianService(context);
                var labManagerService = new LabManagerService(context);

                //for Patrycja Konicz, finished and without examinations
                if (!context.Appointments.Any(x=>x.Id == Guid.Parse("a9d973ac-6683-4c61-bded-410f3841cc1b")))
                {
                    var doc = doctorService.GetAllDoctors().ElementAt(0);
                    var pat = patientService.GetById(Guid.Parse("ba6c78a4-9cff-4bb1-acbd-f4c23a063616"))!;

                    var appointment = new Appointment
                    {
                        Id = Guid.Parse("a9d973ac-6683-4c61-bded-410f3841cc1b"),
                        Description = "This is a default description, which should be added/edited by the appropriate Doctor.",
                        Diagnosis = "She will survive.",
                        Status = AppointmentStatus.FINISHED,
                        RegisteredAt = new DateTime(2022, 1, 12, 8, 20, 57),
                        RegisteredTo = new DateTime(2022, 1, 16, 11, 00, 00),
                        Doctor = doc,
                        Registrar = registrarService.GetAllRegistrars().ElementAt(0),
                        Patient = pat,
                        LaboratoryExaminations = null,
                        PhysicalExaminations = null
                    };
                    context.Appointments.Add(appointment);
                    context.SaveChanges();

                    if(doc.Appointments is null)
                    {
                        doc.Appointments = new List<Appointment>() { appointment };
                    } else doc.Appointments.Add(appointment);

                    if (pat.Appointments is null)
                    {
                        pat.Appointments = new List<Appointment>() { appointment };
                    }
                    else pat.Appointments.Add(appointment);

                    doctorService.Update(doc);
                    patientService.Update(pat);
                }

                //for Patryk Niedopieralski - finished with 4 examinations
                if (!context.Appointments.Any(x => x.Id == Guid.Parse("311f0f18-74d7-47e1-93be-8cb9bb2354f4")))
                {
                    var doc = doctorService.GetAllDoctors().ElementAt(1);
                    var pat = patientService.GetById(Guid.Parse("54319b96-4f10-4a47-a880-d85ebe60ac70"))!;
                    var tech1 = (await labTechnicianService.GetAllLabTechniciansAsync()).ElementAt(0);
                    var tech2 = (await labTechnicianService.GetAllLabTechniciansAsync()).ElementAt(1);
                    var man1 = (await labManagerService.GetAllLabManagersAsync()).ElementAt(0);
                    var man2 = (await labManagerService.GetAllLabManagersAsync()).ElementAt(1);
                    var labBlood = glossaryService.GetByCode(GlossaryCode.LAB_BLOOD);
                    var labCovid = glossaryService.GetByCode(GlossaryCode.LAB_COVID);
                    var phyEar = glossaryService.GetByCode(GlossaryCode.PHY_EAR)!;
                    var phyThroat = glossaryService.GetByCode(GlossaryCode.PHY_THROAT)!;

                    var appointment = new Appointment
                    {
                        Id = Guid.Parse("311f0f18-74d7-47e1-93be-8cb9bb2354f4"),
                        Description = "This is a default description, which should be added/edited by the appropriate Doctor.",
                        Diagnosis = "He will survive.",
                        Status = AppointmentStatus.FINISHED,
                        RegisteredAt = new DateTime(2021, 10, 12, 9, 14, 23),
                        RegisteredTo = new DateTime(2021, 10, 14, 9, 00, 00),
                        Doctor = doc,
                        Registrar = registrarService.GetAllRegistrars().ElementAt(0),
                        Patient = pat,
                        LaboratoryExaminations = null,
                        PhysicalExaminations = null
                    };
                    var labExam_1 = new LaboratoryExamination
                    {
                        Id = Guid.Parse("10634821-b1d0-4dac-b091-22fec1231bc6"),
                        DoctorsNotes = "Please do the examination CAREFULLY!",
                        OrderedAt = new DateTime(2021, 10, 14, 9, 12, 0),
                        Result = "The results were OK.",
                        ExecutedOrCancelledAt = new DateTime(2021, 10, 15, 12, 0, 0),
                        ManagerNotes = "Please focus on the correct transfer of the probe.",
                        ApprovedOrCancelledAt = new DateTime(2021, 10, 15, 14, 30, 0),
                        Status = Enums.ExaminationStatus.EXECUTED,
                        Appointment = appointment,
                        GlossaryDictionary = labBlood,
                        LabTechnician = tech1,
                        LabManager = man1
                    };
                    var labExam_2 = new LaboratoryExamination
                    {
                        Id = Guid.Parse("d8eb4086-5914-469a-93f0-52f0c500eae5"),
                        DoctorsNotes = "Please do the examination CAREFULLY!",
                        OrderedAt = new DateTime(2021, 10, 14, 9, 12, 0),
                        Result = "The results were negative, patient does not have COVID.",
                        ExecutedOrCancelledAt = new DateTime(2021, 10, 15, 13, 0, 0),
                        ManagerNotes = "Please focus on the correct transfer of the probe.",
                        ApprovedOrCancelledAt = new DateTime(2021, 10, 15, 14, 31, 0),
                        Status = Enums.ExaminationStatus.EXECUTED,
                        Appointment = appointment,
                        GlossaryDictionary = labCovid,
                        LabTechnician = tech2,
                        LabManager = man2
                    };
                    var phyExam_1 = new PhysicalExamination
                    {
                        Id = Guid.Parse("d7f7e8dd-a1c1-4b60-9d8d-732d02fb68c2"),
                        Result = "It turns out that this patient has healthy ears.",
                        Appointment = appointment,
                        GlossaryDictionary = phyEar
                    };
                    var phyExam_2 = new PhysicalExamination
                    {
                        Id = Guid.Parse("831ebcba-d0f1-416b-ab21-445500b3d3ae"),
                        Result = "It turns out that this patient has a healthy throat.",
                        Appointment = appointment,
                        GlossaryDictionary = phyThroat
                    };
                    appointment.LaboratoryExaminations = new List<LaboratoryExamination>() { labExam_1, labExam_2 };
                    appointment.PhysicalExaminations = new List<PhysicalExamination>() { phyExam_1, phyExam_2 };

                    context.Appointments.Add(appointment);
                    context.SaveChanges();

                    if (doc.Appointments is null)
                    {
                        doc.Appointments = new List<Appointment>() { appointment };
                    } else doc.Appointments.Add(appointment);

                    if (pat.Appointments is null)
                    {
                        pat.Appointments = new List<Appointment>() { appointment };
                    } else pat.Appointments.Add(appointment);

                    if(tech1.LaboratoryExaminations is null)
                    {
                        tech1.LaboratoryExaminations = new List<LaboratoryExamination>() { labExam_1 };
                    } else tech1.LaboratoryExaminations.Add(labExam_1);

                    if (tech2.LaboratoryExaminations is null)
                    {
                        tech2.LaboratoryExaminations = new List<LaboratoryExamination>() { labExam_2 };
                    } else tech2.LaboratoryExaminations.Add(labExam_2);

                    if (man1.LaboratoryExaminations is null)
                    {
                        man1.LaboratoryExaminations = new List<LaboratoryExamination>() { labExam_1 };
                    } else man1.LaboratoryExaminations.Add(labExam_1);

                    if (man2.LaboratoryExaminations is null)
                    {
                        man2.LaboratoryExaminations = new List<LaboratoryExamination>() { labExam_2 };
                    } else man2.LaboratoryExaminations.Add(labExam_2);

                    if(labBlood!.LaboratoryExaminations is null)
                    {
                        labBlood.LaboratoryExaminations = new List<LaboratoryExamination>() { labExam_1 };
                    } else labBlood.LaboratoryExaminations.Add(labExam_1);

                    if (labCovid!.LaboratoryExaminations is null)
                    {
                        labCovid.LaboratoryExaminations = new List<LaboratoryExamination>() { labExam_2 };
                    } else labCovid.LaboratoryExaminations.Add(labExam_2);

                    if (phyEar!.PhysicalExaminations is null)
                    {
                        phyEar.PhysicalExaminations = new List<PhysicalExamination>() { phyExam_1 };
                    }
                    else phyEar.PhysicalExaminations.Add(phyExam_1);

                    if (phyThroat!.PhysicalExaminations is null)
                    {
                        phyThroat.PhysicalExaminations = new List<PhysicalExamination>() { phyExam_2 };
                    }
                    else phyThroat.PhysicalExaminations.Add(phyExam_2);

                    doctorService.Update(doc);
                    patientService.Update(pat);
                    labTechnicianService.Update(tech1);
                    labTechnicianService.Update(tech2);
                    labManagerService.Update(man1);
                    labManagerService.Update(man2);
                    glossaryService.Update(labBlood);
                    glossaryService.Update(labCovid);
                    glossaryService.Update(phyEar);
                    glossaryService.Update(phyThroat);

                }

                //for Patryk Niedopieralski - booked without examinations
                if (!context.Appointments.Any(x => x.Id == Guid.Parse("53d81e19-e81d-4461-9544-ae47d1579f12")))
                {
                    var doc = doctorService.GetAllDoctors().ElementAt(2);
                    var pat = patientService.GetById(Guid.Parse("54319b96-4f10-4a47-a880-d85ebe60ac70"))!;

                    var appointment = new Appointment
                    {
                        Id = Guid.Parse("53d81e19-e81d-4461-9544-ae47d1579f12"),
                        Description = null,
                        Diagnosis = null,
                        Status = AppointmentStatus.BOOKED,
                        RegisteredAt = new DateTime(2022, 3, 16, 7, 40, 12),
                        RegisteredTo = new DateTime(2023, 11, 19, 12, 00, 00),
                        Doctor = doc,
                        Registrar = registrarService.GetAllRegistrars().ElementAt(0),
                        Patient = pat,
                        LaboratoryExaminations = null,
                        PhysicalExaminations = null
                    };
                    context.Appointments.Add(appointment);
                    context.SaveChanges();

                    if (doc.Appointments is null)
                    {
                        doc.Appointments = new List<Appointment>() { appointment };
                    } else doc.Appointments.Add(appointment);

                    if (pat.Appointments is null)
                    {
                        pat.Appointments = new List<Appointment>() { appointment };
                    } else pat.Appointments.Add(appointment);

                    doctorService.Update(doc);
                    patientService.Update(pat);
                }

                //for Patryk Niedopieralski - booked without examinations (but different Doctor)
                if (!context.Appointments.Any(x => x.Id == Guid.Parse("e4704457-8a9d-4c2a-886b-fc774d608005")))
                {
                    var doc = doctorService.GetAllDoctors().ElementAt(1);
                    var pat = patientService.GetById(Guid.Parse("54319b96-4f10-4a47-a880-d85ebe60ac70"))!;

                    var appointment = new Appointment
                    {
                        Id = Guid.Parse("e4704457-8a9d-4c2a-886b-fc774d608005"),
                        Description = null,
                        Diagnosis = null,
                        Status = AppointmentStatus.BOOKED,
                        RegisteredAt = new DateTime(2022, 3, 20, 9, 22, 19),
                        RegisteredTo = new DateTime(2023, 10, 3, 10, 30, 00),
                        Doctor = doc,
                        Registrar = registrarService.GetAllRegistrars().ElementAt(0),
                        Patient = pat,
                        LaboratoryExaminations = null,
                        PhysicalExaminations = null
                    };
                    context.Appointments.Add(appointment);
                    context.SaveChanges();

                    if (doc.Appointments is null)
                    {
                        doc.Appointments = new List<Appointment>() { appointment };
                    }
                    else doc.Appointments.Add(appointment);

                    if (pat.Appointments is null)
                    {
                        pat.Appointments = new List<Appointment>() { appointment };
                    }
                    else pat.Appointments.Add(appointment);

                    doctorService.Update(doc);
                    patientService.Update(pat);
                }
            }
        }
    }
}
