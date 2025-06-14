namespace DesignPatterns.BRIDGE.EX1;

public class WindowsMediaEngine : IMediaEngine
{
    public void InitializePlayback()
    {
        Console.WriteLine("Windows Media Engine: Initializing DirectShow and Media Foundation APIs");
    }

    public void StartPlayback(string content)
    {
        Console.WriteLine($"Windows Media Engine: Starting playback of {content} using Windows codecs");
    }

    public void PausePlayback()
    {
        Console.WriteLine("Windows Media Engine: Pausing playback");
    }

    public void StopPlayback()
    {
        Console.WriteLine("Windows Media Engine: Stopping playback");
    }

    public void ReleaseResources()
    {
        Console.WriteLine("Windows Media Engine: Releasing DirectX resources");
    }

    public void SetAudioParameter(string name, string value)
    {
        Console.WriteLine($"Windows Media Engine: Setting audio parameter {name} to {value}");
    }

    public void SetVideoParameter(string name, string value)
    {
        Console.WriteLine($"Windows Media Engine: Setting video parameter {name} to {value}");
    }

    public void SetStreamingParameter(string name, string value)
    {
        Console.WriteLine($"Windows Media Engine: Setting streaming parameter {name} to {value}");
    }
}