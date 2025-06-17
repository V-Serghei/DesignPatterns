namespace DesignPatterns.VISITOR.ex1;

public interface IMedicalRecord
{
    void Accept(IMedicalRecordVisitor visitor);
}