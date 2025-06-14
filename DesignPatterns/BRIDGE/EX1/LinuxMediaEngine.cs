namespace DesignPatterns.BRIDGE.EX1;

public class LinuxMediaEngine : IMediaEngine
{
    public void InitializePlayback()
    {
        Console.WriteLine("Linux Media Engine: Initializing GStreamer framework");
    }

    public void StartPlayback(string content)
    {
        Console.WriteLine($"Linux Media Engine: Starting playback of {content} using open-source codecs");
    }

    public void PausePlayback()
    {
        Console.WriteLine("Linux Media Engine: Pausing playback");
    }

    public void StopPlayback()
    {
        Console.WriteLine("Linux Media Engine: Stopping playback");
    }

    public void ReleaseResources()
    {
        Console.WriteLine("Linux Media Engine: Releasing ALSA and V4L resources");
    }

    public void SetAudioParameter(string name, string value)
    {
        Console.WriteLine($"Linux Media Engine: Setting audio parameter {name} to {value}");
    }

    public void SetVideoParameter(string name, string value)
    {
        Console.WriteLine($"Linux Media Engine: Setting video parameter {name} to {value}");
    }

    public void SetStreamingParameter(string name, string value)
    {
        Console.WriteLine($"Linux Media Engine: Setting streaming parameter {name} to {value}");
    }
}