# Tabiyat - Patient Health Dashboard Setup Guide

## Project Overview

**Tabiyat** (Health in Urdu/Arabic) is a complete healthcare management system that enables:
- Patients to manage their health records and book appointments
- Doctors to manage appointments and write prescriptions
- Comprehensive health score calculation based on patient data
- Medical report and scan management

## Prerequisites

- .NET 8 SDK or later
- SQL Server 2019+ or SQL Server LocalDB
- Visual Studio 2022 / VS Code
- Git

## Project Structure

```
Tabiyat/
├── Tabiyat.Shared/           # Shared Models & DTOs (Class Library)
│   ├── Models/               # Domain entities
│   └── DTOs/                 # Data Transfer Objects
├── Tabiyat.Api/              # ASP.NET Core Web API
│   ├── Data/                 # DbContext & EF Core
│   ├── Services/             # Business logic services
│   ├── Controllers/          # API endpoints
│   ├── Migrations/           # Database migrations
│   ├── appsettings.json      # Configuration
│   └── Program.cs            # Dependency injection setup
└── Tabiyat.Client/           # Blazor WebAssembly Client
    ├── Components/           # Blazor components
    ├── Pages/                # Page components
    ├── Services/             # HTTP client services
    └── Program.cs            # Client setup
```

## Getting Started

### Step 1: Clone the Repository

```bash
git clone https://github.com/pbnaresh-dotnet/Tabiyat.git
cd Tabiyat
```

### Step 2: Create Project Structure

If you haven't created the projects yet:

```bash
# Create the solution
dotnet new globaljson --sdk-version 8.0.0 --roll-forward latestMinor
dotnet new sln -n Tabiyat

# Create projects
dotnet new classlib -n Tabiyat.Shared -o Tabiyat.Shared
dotnet new webapi -n Tabiyat.Api -o Tabiyat.Api
dotnet new blazorwasm -n Tabiyat.Client -o Tabiyat.Client

# Add projects to solution
dotnet sln add Tabiyat.Shared/Tabiyat.Shared.csproj
dotnet sln add Tabiyat.Api/Tabiyat.Api.csproj
dotnet sln add Tabiyat.Client/Tabiyat.Client.csproj
```

### Step 3: Add NuGet Dependencies

**Tabiyat.Shared** (no special dependencies needed)

**Tabiyat.Api:**
```bash
cd Tabiyat.Api

# EF Core packages
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.0

# Reference Shared project
dotnet add reference ../Tabiyat.Shared/Tabiyat.Shared.csproj

cd ..
```

**Tabiyat.Client:**
```bash
cd Tabiyat.Client

# Reference Shared project
dotnet add reference ../Tabiyat.Shared/Tabiyat.Shared.csproj

cd ..
```

### Step 4: Configure Database Connection

Edit `Tabiyat.Api/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TabiyatDb;Trusted_Connection=true;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

For SQL Server (Windows Authentication):
```json
"DefaultConnection": "Server=YOUR_SERVER_NAME;Database=TabiyatDb;Integrated Security=true;MultipleActiveResultSets=true"
```

For SQL Server (SQL Authentication):
```json
"DefaultConnection": "Server=YOUR_SERVER;Initial Catalog=TabiyatDb;User Id=sa;Password=YOUR_PASSWORD;MultipleActiveResultSets=true"
```

### Step 5: Set Up Entity Framework Core

**Create Initial Migration:**

```bash
cd Tabiyat.Api

# Create migration
dotnet ef migrations add InitialCreate --project . --startup-project .

# Apply migration to database
dotnet ef database update

cd ..
```

### Step 6: Configure Dependency Injection (Program.cs)

Edit `Tabiyat.Api/Program.cs`:

```csharp
using Tabiyat.Api.Data;
using Tabiyat.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplicationBuilder.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Services
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<ITestReportService, TestReportService>();
builder.Services.AddScoped<IScanService, ScanService>();

// Add controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add CORS if needed
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("https://localhost:7000")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowBlazor");
app.UseAuthorization();
app.MapControllers();

app.Run();
```

### Step 7: Run the Application

**Terminal 1 - Start API:**
```bash
cd Tabiyat.Api
dotnet run
```
API will be available at: `https://localhost:5001`

**Terminal 2 - Start Blazor Client:**
```bash
cd Tabiyat.Client
dotnet run
```
Client will be available at: `https://localhost:7000`

## Database Models Overview

### Patient Model
- Full registration details (Name, Email, Phone, DOB)
- Height, Weight, BMI calculation
- Blood Group, Gender
- Emergency contact information
- Medical conditions list
- Surgery history
- Health score calculation

### Doctor Model
- Specialization (15 types)
- License/Registration number
- Medical school & experience
- Hospital/Clinic information
- Rating system

### Appointment Model
- Date/Time scheduling
- Status tracking (Scheduled, Completed, Cancelled, NoShow, Rescheduled)
- Patient symptoms & reason
- Doctor notes
- Prescription link
- Tests link

### Prescription Model
- Multiple medicines with:
  - Timing instructions (Before/After Breakfast, Lunch, Dinner, Bedtime)
  - Duration in days
  - Frequency per day
  - Special instructions
- Dietary recommendations
- Lifestyle recommendations
- Follow-up recommendations

### Test Model
- Test recommendations by doctor
- Multiple test types (Blood, X-Ray, MRI, CT, Ultrasound, ECG, etc.)
- Priority levels
- Recommended lab/center
- Completion tracking

### TestReport Model
- Patient report uploads
- File storage with size tracking
- MIME type
- Reference and actual values
- Lab information
- Doctor remarks
- Status tracking (Pending, Normal, Abnormal)

### Scan Model
- Old medical scans/reports upload
- Used for health score calculation
- Medical center information
- Doctor remarks
- Toggle for health score inclusion

## Health Score Calculation

The health score (0-100) is calculated based on:

1. **BMI Factor** (Weight / Height²)
   - Normal (18.5-24.9): 0 points
   - Underweight (<18.5): -10 points
   - Overweight (25-29.9): -10 points
   - Obese (30-35): -20 points
   - Severely Obese (>35): -30 points

2. **Medical Conditions**
   - Each active condition: -5 points
   - Examples: Diabetes, BP, Thyroid, Obesity, etc.

3. **Age Factor**
   - Age 50-60: -5 points
   - Age 60+: -10 points

4. **Test Results**
   - Abnormal results: -5 to -10 points each

### Score Ranges
- **80-100**: Excellent (Green)
- **60-79**: Good (Light Green)
- **40-59**: Fair (Yellow)
- **20-39**: Poor (Orange)
- **0-19**: Critical (Red)

## API Endpoints Reference

### Patients
```
POST   /api/patients                      - Register new patient
GET    /api/patients                      - Get all patients
GET    /api/patients/{id}                 - Get patient details
PUT    /api/patients/{id}                 - Update patient
DELETE /api/patients/{id}                 - Delete patient
GET    /api/patients/{id}/health-score    - Get health score
GET    /api/patients/{id}/conditions      - Get medical conditions
POST   /api/patients/{id}/conditions      - Add medical condition
DELETE /api/patients/{id}/conditions/{cid} - Remove condition
```

### Doctors
```
POST   /api/doctors                              - Register doctor
GET    /api/doctors                              - Get all doctors
GET    /api/doctors/{id}                         - Get doctor details
PUT    /api/doctors/{id}                         - Update doctor
DELETE /api/doctors/{id}                         - Delete doctor
GET    /api/doctors/specialization/{spec}       - Get by specialization
```

### Appointments
```
POST   /api/appointments                         - Book appointment
GET    /api/appointments                         - Get all appointments
GET    /api/appointments/{id}                    - Get appointment details
GET    /api/appointments/patient/{patientId}    - Get patient appointments
GET    /api/appointments/doctor/{doctorId}      - Get doctor appointments
PUT    /api/appointments/{id}                    - Update appointment
DELETE /api/appointments/{id}                    - Cancel appointment
PUT    /api/appointments/{id}/complete          - Mark as completed
PUT    /api/appointments/{id}/reschedule        - Reschedule appointment
```

### Prescriptions
```
POST   /api/prescriptions                        - Create prescription
GET    /api/prescriptions/{id}                   - Get prescription
GET    /api/prescriptions/patient/{patientId}   - Get patient prescriptions
GET    /api/prescriptions/appointment/{appId}   - Get appointment prescription
PUT    /api/prescriptions/{id}                   - Update prescription
DELETE /api/prescriptions/{id}                   - Delete prescription
POST   /api/prescriptions/{id}/medicines        - Add medicine
DELETE /api/prescriptions/{id}/medicines/{mid}  - Remove medicine
```

### Tests
```
POST   /api/tests                                - Add test
GET    /api/tests/{id}                           - Get test
GET    /api/tests/appointment/{appId}           - Get appointment tests
GET    /api/tests/patient/{patientId}           - Get patient tests
PUT    /api/tests/{id}                           - Update test
PUT    /api/tests/{id}/complete                 - Mark as completed
DELETE /api/tests/{id}                           - Delete test
```

### Reports
```
POST   /api/reports                              - Upload report
GET    /api/reports/{id}                         - Get report
GET    /api/reports/patient/{patientId}         - Get patient reports
GET    /api/reports/appointment/{appId}         - Get appointment reports
PUT    /api/reports/{id}                         - Update report
DELETE /api/reports/{id}                         - Delete report
POST   /api/reports/{id}/remarks                - Add doctor remarks
```

### Scans
```
POST   /api/scans                                - Upload scan
GET    /api/scans/{id}                           - Get scan
GET    /api/scans/patient/{patientId}           - Get patient scans
PUT    /api/scans/{id}                           - Update scan
PUT    /api/scans/{id}/health-score-toggle      - Toggle health score inclusion
DELETE /api/scans/{id}                           - Delete scan
```

## Service Implementation Guide

All service interfaces are defined. Implement the following services:

1. **DoctorService** - Similar to PatientService
2. **AppointmentService** - Handles appointment CRUD and status management
3. **PrescriptionService** - Manages prescriptions and medicines
4. **TestService** - Manages test recommendations
5. **TestReportService** - Handles report uploads and management
6. **ScanService** - Manages old scan uploads

Each service should:
- ✅ Implement the corresponding interface
- ✅ Add logging for tracking
- ✅ Include error handling
- ✅ Validate business logic
- ✅ Use dependency injection for DbContext

## Testing with Swagger

When API is running, visit: `https://localhost:5001/swagger`

All endpoints are documented and can be tested directly.

## Next Steps

1. ✅ Implement remaining services (Doctor, Appointment, Prescription, Test, Report, Scan)
2. ✅ Create API controllers for each service
3. ✅ Build Blazor components for patient dashboard
4. ✅ Add authentication/authorization
5. ✅ Implement file upload functionality for scans/reports
6. ✅ Add advanced filtering and search
7. ✅ Implement notifications/reminders
8. ✅ Add multi-language support

## Troubleshooting

### Database Connection Issues
```bash
# Check LocalDB instances
sqllocaldb info

# Stop and delete LocalDB
sqllocaldb stop mssqllocaldb
sqllocaldb delete mssqllocaldb

# Create new instance
sqllocaldb create mssqllocaldb
```

### Migration Issues
```bash
# Remove last migration
dotnet ef migrations remove --project . --startup-project .

# Reset database
dotnet ef database drop --force
dotnet ef database update
```

### CORS Issues
Ensure CORS is configured in Program.cs and the client URL matches.

## Support

For issues or questions, please create an issue on GitHub.

## License

MIT License - See LICENSE file for details
