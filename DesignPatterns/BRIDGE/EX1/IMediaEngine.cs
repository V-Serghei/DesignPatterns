namespace DesignPatterns.BRIDGE.EX1;

public interface IMediaEngine
{
    void InitializePlayback();
    void StartPlayback(string content);
    void PausePlayback();
    void StopPlayback();
    void ReleaseResources();
    void SetAudioParameter(string name, string value);
    void SetVideoParameter(string name, string value);
    void SetStreamingParameter(string name, string value);
}