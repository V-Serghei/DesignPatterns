namespace DesignPatterns;

// Implementor: Defines the interface for number type operations
public abstract class NumberTypeImp
{
    public abstract string Add(string a, string b);
    public abstract string Subtract(string a, string b);
    public abstract string Multiply(string a, string b);
}

// Concrete Implementors: Handle specific number types
public class StandardNumberImp : NumberTypeImp
{
    public override string Add(string a, string b)
    {
        double result = double.Parse(a) + double.Parse(b);
        return result.ToString();
    }

    public override string Subtract(string a, string b)
    {
        double result = double.Parse(a) - double.Parse(b);
        return result.ToString();
    }

    public override string Multiply(string a, string b)
    {
        double result = double.Parse(a) * double.Parse(b);
        return result.ToString();
    }
}

public class ComplexNumberImp : NumberTypeImp
{
    // Simplified complex number: a + bi, stored as (real, imaginary)
    public override string Add(string a, string b)
    {
        var partsA = ParseComplex(a);
        var partsB = ParseComplex(b);
        double real = partsA.Item1 + partsB.Item1;
        double imaginary = partsA.Item2 + partsB.Item2;
        return $"{real}+{imaginary}i";
    }

    public override string Subtract(string a, string b)
    {
        var partsA = ParseComplex(a);
        var partsB = ParseComplex(b);
        double real = partsA.Item1 - partsB.Item1;
        double imaginary = partsA.Item2 - partsB.Item2;
        return $"{real}+{imaginary}i";
    }

    public override string Multiply(string a, string b)
    {
        var partsA = ParseComplex(a);
        var partsB = ParseComplex(b);
        double real = partsA.Item1 * partsB.Item1 - partsA.Item2 * partsB.Item2;
        double imaginary = partsA.Item1 * partsB.Item2 + partsA.Item2 * partsB.Item1;
        return $"{real}+{imaginary}i";
    }

    private (double, double) ParseComplex(string s)
    {
        // Assume format "real+imagi" (e.g., "3+4i")
        string[] parts = s.Split('+');
        double real = double.Parse(parts[0]);
        double imaginary = double.Parse(parts[1].TrimEnd('i'));
        return (real, imaginary);
    }
}

public class FractionImp : NumberTypeImp
{
    // Simplified fraction: numerator/denominator
    public override string Add(string a, string b)
    {
        var fracA = ParseFraction(a);
        var fracB = ParseFraction(b);
        int num = fracA.Item1 * fracB.Item2 + fracB.Item1 * fracA.Item2;
        int den = fracA.Item2 * fracB.Item2;
        return SimplifyFraction(num, den);
    }

    public override string Subtract(string a, string b)
    {
        var fracA = ParseFraction(a);
        var fracB = ParseFraction(b);
        int num = fracA.Item1 * fracB.Item2 - fracB.Item1 * fracA.Item2;
        int den = fracA.Item2 * fracB.Item2;
        return SimplifyFraction(num, den);
    }

    public override string Multiply(string a, string b)
    {
        var fracA = ParseFraction(a);
        var fracB = ParseFraction(b);
        int num = fracA.Item1 * fracB.Item1;
        int den = fracA.Item2 * fracB.Item2;
        return SimplifyFraction(num, den);
    }

    private (int, int) ParseFraction(string s)
    {
        // Assume format "num/den" (e.g., "3/4")
        string[] parts = s.Split('/');
        int num = int.Parse(parts[0]);
        int den = int.Parse(parts[1]);
        return (num, den);
    }

    private string SimplifyFraction(int num, int den)
    {
        int gcd = GCD(Math.Abs(num), Math.Abs(den));
        num /= gcd;
        den /= gcd;
        return $"{num}/{den}";
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

// Abstraction: Calculator operations
public abstract class Calculator
{
    protected NumberTypeImp _imp;

    protected Calculator(NumberTypeImp imp)
    {
        _imp = imp;
    }

    public virtual string PerformAddition(string a, string b)
    {
        return _imp.Add(a, b);
    }

    public virtual string PerformSubtraction(string a, string b)
    {
        return _imp.Subtract(a, b);
    }

    public virtual string PerformMultiplication(string a, string b)
    {
        return _imp.Multiply(a, b);
    }
    
}

// Refined Abstraction: Basic calculator for standard operations
public class BasicCalculator : Calculator
{
    public BasicCalculator(NumberTypeImp imp) : base(imp)
    {
    }
    
    
}

public class AdvancedCalculator : Calculator
{
    public AdvancedCalculator(NumberTypeImp imp) : base(imp)
    {
    }

    public string PerformPower(string baseValue, int exponent)
    {
        string result = baseValue;
        for (int i = 1; i < exponent; i++)
        {
            result = _imp.Multiply(result, baseValue);
        }
        return result;
    }
    
}

// Example usage
public class Program1
{
    public static void Main1()
    {
        // Standard number calculator
        NumberTypeImp standardImp = new StandardNumberImp();
        Calculator standardCalc = new BasicCalculator(standardImp);
        Console.WriteLine("Standard Numbers:");
        Console.WriteLine($"Add: {standardCalc.PerformAddition("5", "3")}"); // 8
        Console.WriteLine($"Subtract: {standardCalc.PerformSubtraction("5", "3")}"); // 2
        Console.WriteLine($"Multiply: {standardCalc.PerformMultiplication("5", "3")}"); // 15

        // Complex number calculator
        NumberTypeImp complexImp = new ComplexNumberImp();
        Calculator complexCalc = new BasicCalculator(complexImp);
        Console.WriteLine("\nComplex Numbers:");
        Console.WriteLine($"Add: {complexCalc.PerformAddition("3+4i", "1+2i")}"); // 4+6i
        Console.WriteLine($"Subtract: {complexCalc.PerformSubtraction("3+4i", "1+2i")}"); // 2+2i
        Console.WriteLine($"Multiply: {complexCalc.PerformMultiplication("3+4i", "1+2i")}"); // -5+10i

        // Fraction calculator
        NumberTypeImp fractionImp = new FractionImp();
        Calculator fractionCalc = new BasicCalculator(fractionImp);
        Console.WriteLine("\nFractions:");
        Console.WriteLine($"Add: {fractionCalc.PerformAddition("1/2", "1/3")}"); // 5/6
        Console.WriteLine($"Subtract: {fractionCalc.PerformSubtraction("1/2", "1/3")}"); // 1/6
        Console.WriteLine($"Multiply: {fractionCalc.PerformMultiplication("1/2", "1/3")}"); // 1/6
    }
}