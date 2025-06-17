namespace DesignPatterns.ADAPTER.ex2;

public class AnalogThermometer
{
    public int ReadMercuryLevel()
    {
        // Симуляция чтения уровня ртути (в условных единицах)
        Random rand = new Random();
        return rand.Next(0, 100); // Значения от 0 до 100
    }

    public string CheckMechanicalCondition()
    {
        return "Mechanical check: " + (new Random().NextDouble() > 0.9 ? "Working" : "Needs maintenance");
    }
}