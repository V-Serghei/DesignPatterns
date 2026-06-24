namespace DesignPatterns.BRIDGE.ex2;

public abstract class NumberTypeImp
{
    public abstract string Add(string a, string b);
    public abstract string Subtract(string a, string b);
    public abstract string Multiply(string a, string b);
}

public class StandardNumberImp : NumberTypeImp
{
    public override string Add(string a, string b) =>
        (double.Parse(a) + double.Parse(b)).ToString();

    public override string Subtract(string a, string b) =>
        (double.Parse(a) - double.Parse(b)).ToString();

    public override string Multiply(string a, string b) =>
        (double.Parse(a) * double.Parse(b)).ToString();
}

public class ComplexNumberImp : NumberTypeImp
{
    public override string Add(string a, string b)
    {
        var (ar, ai) = Parse(a);
        var (br, bi) = Parse(b);
        return $"{ar + br}+{ai + bi}i";
    }

    public override string Subtract(string a, string b)
    {
        var (ar, ai) = Parse(a);
        var (br, bi) = Parse(b);
        return $"{ar - br}+{ai - bi}i";
    }

    public override string Multiply(string a, string b)
    {
        var (ar, ai) = Parse(a);
        var (br, bi) = Parse(b);
        return $"{ar * br - ai * bi}+{ar * bi + ai * br}i";
    }

    private static (double real, double imag) Parse(string s)
    {
        var parts = s.Split('+');
        return (double.Parse(parts[0]), double.Parse(parts[1].TrimEnd('i')));
    }
}

public class FractionImp : NumberTypeImp
{
    public override string Add(string a, string b)
    {
        var (n1, d1) = Parse(a);
        var (n2, d2) = Parse(b);
        return Simplify(n1 * d2 + n2 * d1, d1 * d2);
    }

    public override string Subtract(string a, string b)
    {
        var (n1, d1) = Parse(a);
        var (n2, d2) = Parse(b);
        return Simplify(n1 * d2 - n2 * d1, d1 * d2);
    }

    public override string Multiply(string a, string b)
    {
        var (n1, d1) = Parse(a);
        var (n2, d2) = Parse(b);
        return Simplify(n1 * n2, d1 * d2);
    }

    private static (int num, int den) Parse(string s)
    {
        var p = s.Split('/');
        return (int.Parse(p[0]), int.Parse(p[1]));
    }

    private static string Simplify(int num, int den)
    {
        int g = Gcd(Math.Abs(num), Math.Abs(den));
        return $"{num / g}/{den / g}";
    }

    private static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
}

public abstract class Calculator
{
    protected readonly NumberTypeImp _imp;

    protected Calculator(NumberTypeImp imp) => _imp = imp;

    public virtual string Add(string a, string b) => _imp.Add(a, b);
    public virtual string Subtract(string a, string b) => _imp.Subtract(a, b);
    public virtual string Multiply(string a, string b) => _imp.Multiply(a, b);
}

public class BasicCalculator : Calculator
{
    public BasicCalculator(NumberTypeImp imp) : base(imp) { }
}

public class AdvancedCalculator : Calculator
{
    public AdvancedCalculator(NumberTypeImp imp) : base(imp) { }

    public string Power(string baseVal, int exponent)
    {
        string result = baseVal;
        for (int i = 1; i < exponent; i++)
            result = _imp.Multiply(result, baseVal);
        return result;
    }
}
