namespace Tabiyat.Shared.Models
{
    /// <summary>
    /// Specialization types for doctors
    /// </summary>
    public enum Specialization
    {
        Cardiologist = 1,
        Dermatologist = 2,
        Endocrinologist = 3,
        Gastroenterologist = 4,
        GeneralPractitioner = 5,
        Nephrologist = 6,
        Neurologist = 7,
        Oncologist = 8,
        Orthopedist = 9,
        Pulmonologist = 10,
        Rheumatologist = 11,
        Ophthalmologist = 12,
        ENT = 13,
        Psychiatrist = 14,
        Surgeon = 15
    }

    /// <summary>
    /// Medicine timing instructions
    /// </summary>
    public enum MedicineTiming
    {
        BeforeBreakfast = 1,
        AfterBreakfast = 2,
        BeforeLunch = 3,
        AfterLunch = 4,
        BeforeDinner = 5,
        AfterDinner = 6,
        Bedtime = 7,
        AsNeeded = 8,
        OnceDaily = 9,
        TwiceDaily = 10,
        ThriceDaily = 11
    }

    /// <summary>
    /// Appointment status
    /// </summary>
    public enum AppointmentStatus
    {
        Scheduled = 1,
        Completed = 2,
        Cancelled = 3,
        NoShow = 4,
        Rescheduled = 5
    }

    /// <summary>
    /// Existing medical conditions
    /// </summary>
    public enum MedicalCondition
    {
        Diabetes = 1,
        HighBloodPressure = 2,
        Thyroid = 3,
        Obesity = 4,
        AsthmaOrCOPD = 5,
        HeartDisease = 6,
        KidneyDisease = 7,
        LiverDisease = 8,
        Cancer = 9,
        Arthritis = 10,
        Migraine = 11,
        Depression = 12,
        Anxiety = 13,
        Cholesterol = 14,
        Anemia = 15
    }

    /// <summary>
    /// Common surgeries
    /// </summary>
    public enum SurgeryType
    {
        Appendectomy = 1,
        Cholecystectomy = 2,
        Hernia = 3,
        Hysterectomy = 4,
        Prostatectomy = 5,
        Mastectomy = 6,
        Cataract = 7,
        Bypass = 8,
        Angioplasty = 9,
        Knee = 10,
        Hip = 11,
        Spine = 12,
        Thyroid = 13,
        Tonsil = 14,
        Other = 15
    }

    /// <summary>
    /// Report/Document type
    /// </summary>
    public enum ReportType
    {
        BloodTest = 1,
        XRay = 2,
        MRI = 3,
        CTScan = 4,
        Ultrasound = 5,
        ECG = 6,
        EEG = 7,
        BoneDensity = 8,
        MammographyReport = 9,
        EndoscopyReport = 10,
        PathologyReport = 11,
        PrescriptionHistory = 12,
        OtherReport = 13
    }

    /// <summary>
    /// Gender
    /// </summary>
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    /// <summary>
    /// Blood group
    /// </summary>
    public enum BloodGroup
    {
        APositive = 1,
        ANegative = 2,
        BPositive = 3,
        BNegative = 4,
        ABPositive = 5,
        ABNegative = 6,
        OPositive = 7,
        ONegative = 8,
        Unknown = 9
    }
}
