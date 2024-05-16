namespace WebSite.Components.Managers {
    public interface ISessionService {
        bool GetAuthenticationState();
        string GetArea();
        string GetCountry();
        string GetRole();
    }
}
