namespace DesignPatterns.Command.ex1;

public class MusicPlayer
{
    private bool _isPlaying;
    private string _currentTrack;
    private int _volume;

    public MusicPlayer()
    {
        _isPlaying = false;
        _currentTrack = null;
        _volume = 50;
    }

    public void Play(string track)
    {
        _currentTrack = track;
        _isPlaying = true;
        Console.WriteLine($"Music player started playing: {track} at volume {_volume}%");
    }

    public void Stop()
    {
        if (_isPlaying)
        {
            _isPlaying = false;
            Console.WriteLine($"Music player stopped playing: {_currentTrack}");
        }
    }

    public void SetVolume(int volume)
    {
        _volume = Math.Clamp(volume, 0, 100);
        Console.WriteLine($"Music player volume set to {_volume}%");
    }

    public override string ToString() => "Music Player";
}