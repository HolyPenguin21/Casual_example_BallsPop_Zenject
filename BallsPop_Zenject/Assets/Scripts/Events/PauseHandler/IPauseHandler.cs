public interface IPauseHandler
{
    delegate void OnGamePause();
    delegate void OnGameResume();

    public void Add_PauseListener(OnGamePause method);
    public void Invoke_Pause();
    public void Add_ResumeListener(OnGameResume method);
    public void Invoke_Resume();
}
