using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Maui.Storage;
using shared;

namespace app;

public sealed class CurrentUserState
{
    private const string SessionKey = "current_user_session";
    private const string UserKey = "current_user_user";

    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter() }
    };

    private AuthSessionDto? _session;
    private UserDto? _user;

    public CurrentUserState()
    {
        LoadFromStorage();
    }

    public AuthSessionDto? Session
    {
        get => _session;
        set
        {
            _session = value;
            Persist();
        }
    }

    public UserDto? User
    {
        get => _user;
        set
        {
            _user = value;
            Persist();
        }
    }

    public void Set(AuthSessionDto session, UserDto user)
    {
        _session = session;
        _user = user;
        Persist();
    }

    public void Clear()
    {
        _session = null;
        _user = null;
        Preferences.Default.Remove(SessionKey);
        Preferences.Default.Remove(UserKey);
    }

    private void LoadFromStorage()
    {
        try
        {
            var sessionJson = Preferences.Default.Get(SessionKey, string.Empty);
            var userJson = Preferences.Default.Get(UserKey, string.Empty);

            if (string.IsNullOrWhiteSpace(sessionJson) || string.IsNullOrWhiteSpace(userJson))
            {
                Clear();
                return;
            }

            _session = JsonSerializer.Deserialize<AuthSessionDto>(sessionJson, JsonOptions);
            _user = JsonSerializer.Deserialize<UserDto>(userJson, JsonOptions);

            if (_session is null || _user is null)
                Clear();
        }
        catch
        {
            Clear();
        }
    }

    private void Persist()
    {
        if (_session is null || _user is null)
        {
            Preferences.Default.Remove(SessionKey);
            Preferences.Default.Remove(UserKey);
            return;
        }

        var sessionJson = JsonSerializer.Serialize(_session, JsonOptions);
        var userJson = JsonSerializer.Serialize(_user, JsonOptions);

        Preferences.Default.Set(SessionKey, sessionJson);
        Preferences.Default.Set(UserKey, userJson);
    }
}
