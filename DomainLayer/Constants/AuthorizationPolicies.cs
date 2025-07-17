namespace DomainLayer.Constants;

public class AuthorizationPolicies
{
    // 🔹 Patient-related Policies
    public const string CanViewPatients = "CanViewPatients";
    public const string CanAddPatient = "CanAddPatient";
    public const string CanEditPatient = "CanEditPatient";
    public const string CanDeletePatient = "CanDeletePatient";

    // 🔹 Doctor-related Policies
    public const string CanViewDoctors = "CanViewDoctors";
    public const string CanAddDoctor = "CanAddDoctor";
    public const string CanEditDoctor = "CanEditDoctor";
    public const string CanDeleteDoctor = "CanDeleteDoctor";

    // 🔹 Appointment-related Policies
    public const string CanViewAppointments = "CanViewAppointments";
    public const string CanCreateAppointment = "CanCreateAppointment";
    public const string CanEditAppointment = "CanEditAppointment";
    public const string CanCancelAppointment = "CanCancelAppointment";
    public const string CanRescheduleAppointment = "CanRescheduleAppointment";
    public const string CanCompleteAppointment = "CanCompleteAppointment";
}