namespace DesignPatterns.BRIDGE.EX1;

public abstract class MediaPlayer
{
    protected IMediaEngine _engine;
    protected string _content;

    public MediaPlayer(IMediaEngine engine)
    {
        _engine = engine;
    }

    public void SetContent(string content)
    {
        _content = content;
        Console.WriteLine($"Content set to: {content}");
    }

    public virtual void Play()
    {
        _engine.InitializePlayback();
        _engine.StartPlayback(_content);
    }

    public virtual void Stop()
    {
        _engine.StopPlayback();
        _engine.ReleaseResources();
    }

    public virtual void Pause()
    {
        _engine.PausePlayback();
    }
}