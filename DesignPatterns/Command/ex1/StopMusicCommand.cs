namespace DesignPatterns.Command.ex1;

public class StopMusicCommand: ICommand
{
    private readonly MusicPlayer _musicPlayer;
    private string _lastTrack; // To remember what was playing

    public StopMusicCommand(MusicPlayer musicPlayer)
    {
        _musicPlayer = musicPlayer;
    }

    public void Execute()
    {
        _musicPlayer.Stop();
    }

    public void Undo()
    {
        // This is simplified - in a real implementation we'd need to remember the track
        Console.WriteLine("Cannot undo stop music - track information lost");
    }

    public string Description => $"Stop {_musicPlayer}";
}