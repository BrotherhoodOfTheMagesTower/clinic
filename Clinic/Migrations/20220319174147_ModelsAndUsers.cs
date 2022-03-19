using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Migrations
{
    public partial class ModelsAndUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PermissionNumber",
                table: "AspNetUsers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GlossaryDictionaries",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlossaryDictionaries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pesel = table.Column<long>(type: "bigint", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    HouseNumber = table.Column<int>(type: "int", nullable: false),
                    LocalNumber = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RegistrarId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_RegistrarId",
                        column: x => x.RegistrarId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryExaminations",
                columns: table => new
                {
                    LaboratoryExaminationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorsNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlossaryDictionaryId = table.Column<int>(type: "int", nullable: false),
                    LabTechnicianId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LabManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryExaminations", x => x.LaboratoryExaminationId);
                    table.ForeignKey(
                        name: "FK_LaboratoryExaminations_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryExaminations_AspNetUsers_LabManagerId",
                        column: x => x.LabManagerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryExaminations_AspNetUsers_LabTechnicianId",
                        column: x => x.LabTechnicianId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryExaminations_GlossaryDictionaries_GlossaryDictionaryId",
                        column: x => x.GlossaryDictionaryId,
                        principalTable: "GlossaryDictionaries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalExaminations",
                columns: table => new
                {
                    PhysicalExaminationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GlossaryDictionaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalExaminations", x => x.PhysicalExaminationId);
                    table.ForeignKey(
                        name: "FK_PhysicalExaminations_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicalExaminations_GlossaryDictionaries_GlossaryDictionaryId",
                        column: x => x.GlossaryDictionaryId,
                        principalTable: "GlossaryDictionaries",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RegistrarId",
                table: "Appointments",
                column: "RegistrarId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryExaminations_AppointmentId",
                table: "LaboratoryExaminations",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryExaminations_GlossaryDictionaryId",
                table: "LaboratoryExaminations",
                column: "GlossaryDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryExaminations_LabManagerId",
                table: "LaboratoryExaminations",
                column: "LabManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryExaminations_LabTechnicianId",
                table: "LaboratoryExaminations",
                column: "LabTechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExaminations_AppointmentId",
                table: "PhysicalExaminations",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalExaminations_GlossaryDictionaryId",
                table: "PhysicalExaminations",
                column: "GlossaryDictionaryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "LaboratoryExaminations");

            migrationBuilder.DropTable(
                name: "PhysicalExaminations");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "GlossaryDictionaries");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PermissionNumber",
                table: "AspNetUsers");
        }
    }
}
