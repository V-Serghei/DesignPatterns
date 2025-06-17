namespace DesignPatterns.BRIDGE.EX1;

public class TVPlayer: MediaPlayer
{
    public TVPlayer(IMediaEngine engine) : base(engine)
    {
    }
    
    public void SetChannel(int channelNumber)
    {
        Console.WriteLine($"Setting TV channel to {channelNumber}");
        _engine.SetParameter("channel", channelNumber.ToString());
    }
    
    public void AdjustVolume(int level)
    {
        Console.WriteLine($"Adjusting TV volume to {level}%");
        _engine.SetParameter("volume", level.ToString());
    }
    public override void Play()
    {
        Console.WriteLine("TVPlayer: Playing TV content");
        base.Play();
    }
}