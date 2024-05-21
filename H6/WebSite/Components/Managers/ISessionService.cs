using Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace WebSite.Components.Managers {
    public interface ISessionService {
        event Action AuthenticationStateChanged;
        bool GetAuthenticationState();
        bool IsHSEAdmin();
        bool IsAdmin();
        Area GetArea();
        Country GetCountry();
        string GetRole();
        QuestionGroup GetQuestionGroup();
        void ChangeGroup(int countryId, int areaId);
        void MarkUserAsAuthenticated(User user);
        void MarkUserAsLoggedOut();
        User GetUser();
    }
}
