namespace shared.Services;

public interface ISessionService
{
    AuthSessionDto? CurrentSession { get; }
    void SaveSession(AuthSessionDto session);
    void ClearSession();
    bool IsLoggedIn();
}

public class SessionService: ISessionService
{
    public AuthSessionDto? CurrentSession { get; private set; }
    public void SaveSession(AuthSessionDto session)
    {
        CurrentSession = session;
    }
    public void ClearSession()
    {
        CurrentSession = null;
    }
    public bool IsLoggedIn()
    {
        return CurrentSession != null;
    }
}
