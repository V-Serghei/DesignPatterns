using System.Text;

namespace DesignPatterns.VISITOR.ex1;

public class InsuranceReportGenerator: IMedicalRecordVisitor
{
    private readonly StringBuilder _report = new StringBuilder();

    public string Report => _report.ToString();

    public void Visit(LabResult labResult)
    {
        _report.AppendLine($"Lab Result - Patient: {labResult.PatientId}, Test: {labResult.TestName}, Result: {labResult.Result}, Date: {labResult.Date}");
    }

    public void Visit(ExaminationRecord examinationRecord)
    {
        _report.AppendLine($"Examination - Patient: {examinationRecord.PatientId}, Notes: {examinationRecord.DoctorNotes}, Date: {examinationRecord.Date}");
    }

    public void Visit(Prescription prescription)
    {
        _report.AppendLine($"Prescription - Patient: {prescription.PatientId}, Medication: {prescription.Medication}, Dosage: {prescription.Dosage}mg, Valid Until: {prescription.ValidUntil}");
    }
}