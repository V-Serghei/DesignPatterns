namespace DesignPatterns.VISITOR.ex1;


/// <summary>
/// Представляет собой Visitor в паттерне Visitor.
/// </summary>
public interface IMedicalRecordVisitor
{
    void Visit(LabResult labResult);
    void Visit(ExaminationRecord examinationRecord);
    void Visit(Prescription prescription);
}