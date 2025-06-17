namespace DesignPatterns.VISITOR.ex1;

public interface IMedicalRecordVisitor
{
    void Visit(LabResult labResult);
    void Visit(ExaminationRecord examinationRecord);
    void Visit(Prescription prescription);
}