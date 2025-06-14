namespace DesignPatterns.BRIDGE.EX1;

public class AudioPlayer : MediaPlayer
{
    public AudioPlayer(IMediaEngine engine) : base(engine) { }

    public void AdjustVolume(int level)
    {
        Console.WriteLine($"Adjusting volume to {level}%");
        _engine.SetAudioParameter("volume", level.ToString());
    }

    public void ApplyEqualizer(string preset)
    {
        Console.WriteLine($"Applying equalizer preset: {preset}");
        _engine.SetAudioParameter("equalizer", preset);
    }

    public override void Play()
    {
        Console.WriteLine("AudioPlayer: Playing audio content");
        base.Play();
    }
}