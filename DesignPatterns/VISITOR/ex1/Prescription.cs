namespace DesignPatterns.VISITOR.ex1;

public class Prescription: IMedicalRecord
{
    public string PatientId { get; }
    public string Medication { get; }
    public int Dosage { get; }
    public DateTime ValidUntil { get; }

    public Prescription(string patientId, string medication, int dosage, DateTime validUntil)
    {
        PatientId = patientId;
        Medication = medication;
        Dosage = dosage;
        ValidUntil = validUntil;
    }

    public void Accept(IMedicalRecordVisitor visitor) => visitor.Visit(this);
}