namespace DesignPatterns.BRIDGE.EX1;

public class StreamingPlayer : MediaPlayer
{
    public StreamingPlayer(IMediaEngine engine) : base(engine) { }

    public void BufferContent(int seconds)
    {
        Console.WriteLine($"Buffering {seconds} seconds of content");
        _engine.SetStreamingParameter("buffer", seconds.ToString());
    }

    public void SetBandwidthLimit(int kbps)
    {
        Console.WriteLine($"Setting bandwidth limit to {kbps} Kbps");
        _engine.SetStreamingParameter("bandwidth", kbps.ToString());
    }

    public override void Play()
    {
        Console.WriteLine("StreamingPlayer: Playing streaming content");
        base.Play();
    }
}