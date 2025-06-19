namespace DesignPatterns.SOLID.SRP;

public class SingleResponsibilityPrinciple
{
    //Принцип единственной обязанности
    // Каждый компонент должен иметь одну и только одну причину для изменения.
    
    
    // Плохой пример:

    public class Calculator
    {
        public int a { get; set; }
        public int b { get; set; }
        public string Operation { get; set; }

        public int Calculate()
        {
            //
            return int .Parse(Operation) switch
            {
                1 => a + b, // Сложение
                2 => a - b, // Вычитание
                3 => a * b, // Умножение
                4 => a / b, // Деление
                _ => throw new InvalidOperationException("Неизвестная операция")
            };
        }
        public void SaveToFile(string filePath)
        {
            // Сохранение результата в файл
        }
        public void Log(string message)
        {
            // Логирование операции
        }
        public void Clear()
        {
            // Очистка данных
            a = 0;
            b = 0;
            Operation = string.Empty;
        }
        public void PrintResult()
        {
            // Печать результата
            Console.WriteLine($"Результат: {Calculate()}");
        }
        public void History()
        {
            // История операций
            Console.WriteLine("История операций:");
            // Вывод истории
        }
        
    }
    // Хороший пример:
    
    public class NumModel
    {
        public int a { get; set; }
        public int b { get; set; }
        public string Operation { get; set; }
    }
    
    public class Calculator1
    {
        private NumModel _numModel;
        public Calculator1(NumModel numModel)
        {
            _numModel = numModel;
        }
        public int Calculate()
        {
            return (_numModel.Operation) switch
            {
                "1" => _numModel.a + _numModel.b,
                _ => throw new InvalidOperationException("Неизвестная операция")
            };
        }
    }
    
    public interface ICalculator
    {
        int Calculate();
    }
    public interface IFileSaver
    {
        void SaveToFile(string filePath, string content);
    }
    
    public class FileSaver: IFileSaver
    {
        public void SaveToFile(string filePath, string content)
        {
            // Сохранение результата в файл
            System.IO.File.WriteAllText(filePath, content);
        }
    }
    public class Logger
    {
        public void Log(string message)
        {
            // Логирование операции
            Console.WriteLine($"Log: {message}");
        }
    }
    public class Printer
    {
        public void PrintResult(int result)
        {
            // Печать результата
            Console.WriteLine($"Результат: {result}");
        }
    }
    public class History
    {
        public void ShowHistory()
        {
            // История операций
            Console.WriteLine("История операций:");
            // Вывод истории
        }
    }
    public class CalculatorWithSRP
    {
        private readonly Calculator1 _calculator;
        private readonly FileSaver _fileSaver;
        private readonly Logger _logger;
        private readonly Printer _printer;
        private readonly History _history;

        public CalculatorWithSRP(NumModel numModel)
        {
            _calculator = new Calculator1(numModel);
            _fileSaver = new FileSaver();
            _logger = new Logger();
            _printer = new Printer();
            _history = new History();
        }

        public void CalculateAndPrint()
        {
            int result = _calculator.Calculate();
            _printer.PrintResult(result);
            _logger.Log($"Calculated result: {result}");
        }

        public void SaveResult(string filePath, int result)
        {
            _fileSaver.SaveToFile(filePath, result.ToString());
            _logger.Log($"Saved result to {filePath}");
        }

        public void ShowHistory()
        {
            _history.ShowHistory();
        }
    }
    
    
}