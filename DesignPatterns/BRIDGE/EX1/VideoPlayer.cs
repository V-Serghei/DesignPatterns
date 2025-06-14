namespace DesignPatterns.BRIDGE.EX1;

public class VideoPlayer : MediaPlayer
{
    public VideoPlayer(IMediaEngine engine) : base(engine) { }

    public void AdjustResolution(int width, int height)
    {
        Console.WriteLine($"Setting resolution to {width}x{height}");
        _engine.SetVideoParameter("resolution", $"{width}x{height}");
    }

    public void EnableSubtitles(string language)
    {
        Console.WriteLine($"Enabling {language} subtitles");
        _engine.SetVideoParameter("subtitles", language);
    }

    public override void Play()
    {
        Console.WriteLine("VideoPlayer: Playing video content");
        base.Play();
    }
}