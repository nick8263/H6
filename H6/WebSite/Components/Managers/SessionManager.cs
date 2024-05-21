using Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;

namespace WebSite.Components.Managers {
    public class SessionManager : ISessionService {
        private static bool isAuthenticated = false;
        private static bool isHSEAdmin = false;
        private static bool isAdmin = false;
        private static User loggenInUser;  
        private static QuestionGroup QuestionGroup;

        [Inject]
        MockData MockData { get; set; }

        public event Action AuthenticationStateChanged;

        private void NotifyStateChanged() => AuthenticationStateChanged?.Invoke();

        public void ChangeGroup(int countryId, int areaId) {
            QuestionGroup = MockData.GetQuestionGroup(areaId, countryId);
        }

        public Area GetArea() {
            return loggenInUser.Area;
        }

        public bool IsAdmin() {
            return isAdmin;
        }

        public bool IsHSEAdmin() {
            return isHSEAdmin;
        }

        public bool GetAuthenticationState() {
            return isAuthenticated;
        }

        public Country GetCountry() {
            return loggenInUser.Country;
        }

        public string GetRole() {
            return loggenInUser.Role;
        }

        public User GetUser() {
            return loggenInUser;
        }

        public void MarkUserAsAuthenticated(User user) {
            User temp = user;   
            if (temp != null) {
                loggenInUser = user;
                isAuthenticated = true;
                isAdmin = user.Role == "admin";
                isHSEAdmin = user.Role == "hse";
            }
            NotifyStateChanged();
        }

        public void MarkUserAsLoggedOut() {
            loggenInUser = null;
            QuestionGroup = new QuestionGroup();
            isAuthenticated = false;
            isHSEAdmin=false;
            isAdmin = false;
            NotifyStateChanged();
        }

        public QuestionGroup GetQuestionGroup() {
            return QuestionGroup;
        }

    }
}
