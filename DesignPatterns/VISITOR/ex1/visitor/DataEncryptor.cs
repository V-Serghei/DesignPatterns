namespace DesignPatterns.VISITOR.ex1;



/// <summary>
/// Представляет собой конкретного Visitor в паттерне Visitor.
/// </summary>
public class DataEncryptor: IMedicalRecordVisitor
{
    private readonly Dictionary<string, string> _encryptedData = new Dictionary<string, string>();

    public Dictionary<string, string> EncryptedData => _encryptedData;

    // Простая симуляция шифрования (в реальности использовать алгоритмы вроде AES)
    private string Encrypt(string data) => $"ENC_{data.Reverse()}";

    public void Visit(LabResult labResult)
    {
        _encryptedData[$"LabResult_{labResult.TestName}_{labResult.Date}"] = Encrypt(labResult.Result);
    }

    public void Visit(ExaminationRecord examinationRecord)
    {
        _encryptedData[$"Exam_{examinationRecord.PatientId}_{examinationRecord.Date}"] = Encrypt(examinationRecord.DoctorNotes);
    }

    public void Visit(Prescription prescription)
    {
        _encryptedData[$"Prescription_{prescription.PatientId}_{prescription.ValidUntil}"] = Encrypt(prescription.Medication);
    }
}