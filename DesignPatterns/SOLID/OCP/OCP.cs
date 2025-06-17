namespace DesignPatterns.SOLID.OCP;

public class OCP
{
    /// <summary>
    /// Плохой пример принципа открытости/закрытости (OCP).
    /// Так как для добавления новой операции надо изменяиь уже существующий класс Calculator,
    /// </summary>
    class Calculator
    {
        private int A { get; set; }
        private int B { get; set; }
        public Calculator(int a, int b)
        {
            A = a;
            B = b;
        }
        
        public void SetValues(int a, int b)
        {
            A = a;
            B = b;
        }

        public int Add()
        {
            return A + B;
        }
        public int Subtract()
        {
            return A - B;
        }
        public int Multiply()
        {
            return A * B;
        }
        public int Divide()
        {
            if (B == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return A / B;
        }

    }

    /// <summary>
    /// Настоящий пример принципа открытости/закрытости (OCP).
    /// Демонстрирует как можно добавлять новые операции без изменения существующего кода.
    /// </summary>
    class CalculatorReal
    {
        private int A { get; set; }
        private int B { get; set; }
        public CalculatorReal(int a, int b)
        {
            A = a;
            B = b;
        }
        
        public void SetValues(int a, int b)
        {
            A = a;
            B = b;
        }
        
        public int Calculate(IOperation operation)
        {
            return operation.Execute(A,B);
        }
        
    }
    
    interface IOperation
    {
        int Execute(int a, int b);
    }
    
    class AddOperation : IOperation
    {
        public int Execute(int a, int b) => a + b;
    }
    class SubtractOperation : IOperation
    {
        public int Execute(int a, int b) => a - b;
    }
    class MultiplyOperation : IOperation
    {
        public int Execute(int a, int b) => a * b;
    }
    class DivideOperation : IOperation
    {
        public int Execute(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }
    }
    class ModuloOperation : IOperation
    {
        public int Execute(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a % b;
        }
    }
}