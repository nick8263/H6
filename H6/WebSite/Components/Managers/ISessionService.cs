using Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace WebSite.Components.Managers {
    public interface ISessionService {

        public int a { get; set; }

        event Action AuthenticationStateChanged;
        bool GetAuthenticationState();
        bool IsHSEAdmin();
        bool IsAdmin();
        Area GetArea();
        Country GetCountry();
        string GetRole();
        QuestionGroup GetQuestionGroup();
        void ChangeGroup(QuestionGroup questionGroup);
        void MarkUserAsAuthenticated(User user, QuestionGroup questionGroup, string Token);
        void MarkUserAsLoggedOut();
        User GetUser();
        String GetToken();
    }
}
