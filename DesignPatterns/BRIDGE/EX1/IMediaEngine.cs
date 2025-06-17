namespace DesignPatterns.BRIDGE.EX1;

public interface IMediaEngine
{
    void InitializePlayback();
    void StartPlayback(string content);
    void PausePlayback();
    void StopPlayback();
    void ReleaseResources();
    void SetParameter(string name, string value);
}