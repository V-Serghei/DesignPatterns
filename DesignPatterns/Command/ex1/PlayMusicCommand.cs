namespace DesignPatterns.Command.ex1;

public class PlayMusicCommand: ICommand
{
    private readonly MusicPlayer _musicPlayer;
    private readonly string _track;

    public PlayMusicCommand(MusicPlayer musicPlayer, string track)
    {
        _musicPlayer = musicPlayer;
        _track = track;
    }

    public void Execute()
    {
        _musicPlayer.Play(_track);
    }

    public void Undo()
    {
        _musicPlayer.Stop();
    }

    public string Description => $"Play '{_track}' on {_musicPlayer}";
}