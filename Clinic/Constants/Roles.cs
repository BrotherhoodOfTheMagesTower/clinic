namespace Clinic.Constants
{
    public static class Roles
    {
        // Roles
        public const string Administrator = "Administrator";
        public const string Doctor = "Doctor";
        public const string Registrar = "Registrar";
        public const string LabTechnician = "Lab Technician";
        public const string LabManager = "Lab Manager";

        // Policies
        public const string RequireAdmin = "RequireAdmin";
        public const string RequireDoctor = "RequireDoctor";
        public const string RequireRegistrar = "RequireRegistrar";
        public const string RequireLabTechnician = "RequireLabTechnician";
        public const string RequireLabManager = "RequireLabManager";
    }
}
