namespace DesignPatterns.Command.ex2;

public class ClientCalcilator
{
    public void Run()
    {
        var calculatorResiver = new CalculatorResiver(10);
        var addCommand = new AddCommand(calculatorResiver, 5);
        //var subtractCommand = new SubtractCommand(calculatorResiver, 3);
        //var multiplyCommand = new MultiplyCommand(calculatorResiver, 2);
        
        
        var calculator = new CalculatorInvoker();
        calculator.SetCommand(addCommand).ExecuteCommand();
        calculator.UndoCommand();
        
    }
}