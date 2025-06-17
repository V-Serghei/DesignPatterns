using DesignPatterns.VISITOR.ex1;

namespace DesignPatterns.Client.VISITOR;

public class VisitorClient
{
    public void Run()
    {
        var recordSystem = new PatientRecordSystem();

        // Добавление записей
        recordSystem.AddRecord(new LabResult("P001", "Blood Test", "Normal", new DateTime(2025, 6, 17)));
        recordSystem.AddRecord(new ExaminationRecord("P001", "Patient stable", new DateTime(2025, 6, 16)));
        recordSystem.AddRecord(new Prescription("P001", "Paracetamol", 500, new DateTime(2025, 6, 24)));

        // Применение посетителей
        var checker = new DataIntegrityChecker();
        recordSystem.Accept(checker);
        Console.WriteLine("\nData Integrity Check:");
        if (checker.Errors.Count == 0)
        {
            Console.WriteLine("All records are valid.");
        }
        else
        {
            foreach (var error in checker.Errors)
            {
                Console.WriteLine($"Error: {error}");
            }
        }

        var reportGenerator = new InsuranceReportGenerator();
        recordSystem.Accept(reportGenerator);
        Console.WriteLine("\nInsurance Report:");
        Console.WriteLine(reportGenerator.Report);

        var encryptor = new DataEncryptor();
        recordSystem.Accept(encryptor);
        Console.WriteLine("\nEncrypted Data:");
        foreach (var entry in encryptor.EncryptedData)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
}