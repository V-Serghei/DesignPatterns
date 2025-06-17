namespace DesignPatterns.BRIDGE.EX1;

public class MacOSMediaEngine : IMediaEngine
{
    public void InitializePlayback()
    {
        Console.WriteLine("macOS Media Engine: Initializing AVFoundation framework");
    }

    public void StartPlayback(string content)
    {
        Console.WriteLine($"macOS Media Engine: Starting playback of {content} using Apple codecs");
    }

    public void PausePlayback()
    {
        Console.WriteLine("macOS Media Engine: Pausing playback");
    }

    public void StopPlayback()
    {
        Console.WriteLine("macOS Media Engine: Stopping playback");
    }

    public void ReleaseResources()
    {
        Console.WriteLine("macOS Media Engine: Releasing Core Audio resources");
    }

    public void SetParameter(string name, string value)
    {
        Console.WriteLine($"macOS Media Engine: Setting audio parameter {name} to {value}");
    }
}