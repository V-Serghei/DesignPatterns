namespace DesignPatterns.VISITOR.ex1;

public class DataIntegrityChecker: IMedicalRecordVisitor
{
    private readonly List<string> _errors = new List<string>();

    public List<string> Errors => _errors;

    public void Visit(LabResult labResult)
    {
        if (string.IsNullOrEmpty(labResult.Result)) _errors.Add($"LabResult for {labResult.TestName}: Missing result");
        if (labResult.Date == default) _errors.Add($"LabResult for {labResult.TestName}: Missing date");
    }

    public void Visit(ExaminationRecord examinationRecord)
    {
        if (string.IsNullOrEmpty(examinationRecord.DoctorNotes)) _errors.Add($"ExaminationRecord for {examinationRecord.PatientId}: Missing notes");
        if (examinationRecord.Date == default) _errors.Add($"ExaminationRecord for {examinationRecord.PatientId}: Missing date");
    }

    public void Visit(Prescription prescription)
    {
        if (string.IsNullOrEmpty(prescription.Medication)) _errors.Add($"Prescription for {prescription.PatientId}: Missing medication");
        if (prescription.Dosage <= 0) _errors.Add($"Prescription for {prescription.PatientId}: Invalid dosage");
        if (prescription.ValidUntil == default) _errors.Add($"Prescription for {prescription.PatientId}: Missing valid until date");
    }
}