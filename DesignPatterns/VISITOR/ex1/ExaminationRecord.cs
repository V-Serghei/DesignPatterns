namespace DesignPatterns.VISITOR.ex1;


/// <summary>
/// Представляет собой Element в паттерне Visitor.
/// </summary>
public class ExaminationRecord: IMedicalRecord
{
    public string PatientId { get; }
    public string DoctorNotes { get; }
    public DateTime Date { get; }

    public ExaminationRecord(string patientId, string doctorNotes, DateTime date)
    {
        PatientId = patientId;
        DoctorNotes = doctorNotes;
        Date = date;
    }

    public void Accept(IMedicalRecordVisitor visitor) => visitor.Visit(this);
    
}