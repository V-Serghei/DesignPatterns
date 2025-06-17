namespace DesignPatterns.VISITOR.ex1;

public class PatientRecordSystem
{
    private readonly List<IMedicalRecord> _records = new List<IMedicalRecord>();

    public void AddRecord(IMedicalRecord record) => _records.Add(record);

    public void Accept(IMedicalRecordVisitor visitor)
    {
        foreach (var record in _records)
        {
            record.Accept(visitor);
        }
    }
}