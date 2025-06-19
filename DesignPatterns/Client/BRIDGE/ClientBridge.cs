using DesignPatterns.BRIDGE.EX1;

namespace DesignPatterns.Client.BRIDGE;

public class ClientBridge
{
    public void Run()
    {
        Console.WriteLine("Cross-Platform Media Player Demo");
        Console.WriteLine("-------------------------------");

        // Create different combinations of players and platform engines
            
        // Audio player on Windows
        MediaPlayer windowsAudioPlayer = new AudioPlayer(new WindowsMediaEngine());
        windowsAudioPlayer.SetContent("music.mp3");
        windowsAudioPlayer.Play();
        windowsAudioPlayer.Stop();
            
        Console.WriteLine();
            
        // Video player on macOS
        MediaPlayer macVideoPlayer = new VideoPlayer(new MacOSMediaEngine());
        macVideoPlayer.SetContent("movie.mp4");
        macVideoPlayer.Play();
        ((VideoPlayer)macVideoPlayer).AdjustResolution(1920, 1080);
        macVideoPlayer.Stop();
            
        Console.WriteLine();
            
        // Streaming player on Linux
        MediaPlayer linuxStreamPlayer = new StreamingPlayer(new LinuxMediaEngine());
        linuxStreamPlayer.SetContent("https://stream.example.com/live");
        linuxStreamPlayer.Play();
        ((StreamingPlayer)linuxStreamPlayer).BufferContent(30);
        linuxStreamPlayer.Stop();
            
        Console.WriteLine();
            
        // Adding a new combination is easy - Video player on Linux
        MediaPlayer linuxVideoPlayer = new VideoPlayer(new LinuxMediaEngine());
        linuxVideoPlayer.SetContent("documentary.mkv");
        linuxVideoPlayer.Play();
    }
}