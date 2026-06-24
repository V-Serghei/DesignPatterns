using DesignPatterns.BRIDGE.EX1;
using DesignPatterns.BRIDGE.ex2;

namespace DesignPatterns.Client.BRIDGE;

public class ClientBridge
{
    public void Run()
    {
        RunEx1();
        Console.WriteLine();
        RunEx2();
    }

    private static void RunEx1()
    {
        Console.WriteLine("=== Ex1: Cross-Platform Media Player ===");

        MediaPlayer windowsAudio = new AudioPlayer(new WindowsMediaEngine());
        windowsAudio.SetContent("music.mp3");
        windowsAudio.Play();
        windowsAudio.Stop();

        Console.WriteLine();

        MediaPlayer macVideo = new VideoPlayer(new MacOSMediaEngine());
        macVideo.SetContent("movie.mp4");
        macVideo.Play();
        ((VideoPlayer)macVideo).AdjustResolution(1920, 1080);
        macVideo.Stop();

        Console.WriteLine();

        MediaPlayer linuxStream = new StreamingPlayer(new LinuxMediaEngine());
        linuxStream.SetContent("https://stream.example.com/live");
        linuxStream.Play();
        ((StreamingPlayer)linuxStream).BufferContent(30);
        linuxStream.Stop();
    }

    private static void RunEx2()
    {
        Console.WriteLine("=== Ex2: Calculator Bridge (number types × operations) ===");

        var standard = new BasicCalculator(new StandardNumberImp());
        Console.WriteLine($"Standard  5+3={standard.Add("5", "3")}  5-3={standard.Subtract("5", "3")}  5*3={standard.Multiply("5", "3")}");

        var complex = new BasicCalculator(new ComplexNumberImp());
        Console.WriteLine($"Complex   (3+4i)+(1+2i) = {complex.Add("3+4i", "1+2i")}");
        Console.WriteLine($"Complex   (3+4i)*(1+2i) = {complex.Multiply("3+4i", "1+2i")}");

        var fraction = new BasicCalculator(new FractionImp());
        Console.WriteLine($"Fraction  1/2 + 1/3 = {fraction.Add("1/2", "1/3")}");
        Console.WriteLine($"Fraction  1/2 * 1/3 = {fraction.Multiply("1/2", "1/3")}");

        var advanced = new AdvancedCalculator(new StandardNumberImp());
        Console.WriteLine($"Advanced  2^10 = {advanced.Power("2", 10)}");
    }
}
