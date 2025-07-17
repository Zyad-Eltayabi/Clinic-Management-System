using DomainLayer.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Persistence.Configurations;

public class RoleClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
    public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
    {
        var Roleclaims = new Dictionary<string, List<string>>();

        Roleclaims.Add(Roles.SuperAdmin, new List<string>
        {
            // 🔹 Patient-related Claims
            ClaimConstants.AddPatient,
            ClaimConstants.EditPatient,
            ClaimConstants.DeletePatient,
            ClaimConstants.ViewPatients,

            // 🔹 Doctor-related Claims
            ClaimConstants.ViewDoctors,
            ClaimConstants.AddDoctor,
            ClaimConstants.EditDoctor,
            ClaimConstants.DeleteDoctor,

            // 🔹 Appointment-related Claims
            ClaimConstants.ViewAppointments,
            ClaimConstants.CreateAppointment,
            ClaimConstants.EditAppointment,
            ClaimConstants.CancelAppointment,
            ClaimConstants.CompleteAppointment
        });

        Roleclaims.Add(Roles.ClinicManager, new List<string>
        {
            // 🔹 Patient-related Claims
            ClaimConstants.AddPatient,
            ClaimConstants.EditPatient,
            ClaimConstants.DeletePatient,
            ClaimConstants.ViewPatients,

            // 🔹 Doctor-related Claims
            ClaimConstants.ViewDoctors,
            ClaimConstants.AddDoctor,
            ClaimConstants.EditDoctor,
            ClaimConstants.DeleteDoctor,

            // 🔹 Appointment-related Claims
            ClaimConstants.ViewAppointments,
            ClaimConstants.CreateAppointment,
            ClaimConstants.EditAppointment,
            ClaimConstants.CancelAppointment,
            ClaimConstants.CompleteAppointment
        });

        Roleclaims.Add(Roles.Receptionist, new List<string>
        {
            // 🔹 Patient-related Claims
            ClaimConstants.AddPatient,
            ClaimConstants.EditPatient,
            ClaimConstants.ViewPatients,

            // 🔹 Doctor-related Claims
            ClaimConstants.ViewDoctors,

            // 🔹 Appointment-related Claims
            ClaimConstants.ViewAppointments,
            ClaimConstants.CreateAppointment,
            ClaimConstants.EditAppointment,
            ClaimConstants.CancelAppointment,
            ClaimConstants.CompleteAppointment
        });

        Roleclaims.Add(Roles.MedicalAdmin, new List<string>
        {
            // 🔹 Patient-related Claims
            ClaimConstants.AddPatient,
            ClaimConstants.EditPatient,
            ClaimConstants.ViewPatients,

            // 🔹 Doctor-related Claims
            ClaimConstants.ViewDoctors,

            // 🔹 Appointment-related Claims
            ClaimConstants.ViewAppointments
        });
    }
}