namespace DesignPatterns.VISITOR.ex1;

public class LabResult: IMedicalRecord
{
    public string PatientId { get; }
    public string TestName { get; }
    public string Result { get; }
    public DateTime Date { get; }

    public LabResult(string patientId, string testName, string result, DateTime date)
    {
        PatientId = patientId;
        TestName = testName;
        Result = result;
        Date = date;
    }

    public void Accept(IMedicalRecordVisitor visitor) => visitor.Visit(this);
}