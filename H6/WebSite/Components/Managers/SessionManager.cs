using Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;

namespace WebSite.Components.Managers {
    public class SessionManager : ISessionService {
        private static SessionManager _instance;
        private static bool isAuthenticated = false;
        private static bool isHSEAdmin = false;
        private static bool isAdmin = false;
        private static User loggenInUser;  
        private static QuestionGroup QuestionGroup;
        private static string Token;

        public event Action AuthenticationStateChanged;

        private void NotifyStateChanged() => AuthenticationStateChanged?.Invoke();

        public static SessionManager Instance {
            get {
                if (_instance == null) {
                    _instance = new SessionManager();
                }
                return _instance;
            }
        }

        public void ChangeGroup(QuestionGroup questionGroup) {
            QuestionGroup = questionGroup;
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
            return loggenInUser.Role.Name;
        }

        public User GetUser() {
            return loggenInUser;
        }

        public string GetToken() { 
            return Token;
        }

        public void MarkUserAsAuthenticated(User user, QuestionGroup questionGroup, string token) {
            User temp = user;   
            if (temp != null) {
                loggenInUser = user;
                isAuthenticated = true;
                isAdmin = user.Role.Name == "admin";
                isHSEAdmin = user.Role.Name == "hse";
                QuestionGroup = questionGroup;
                Token = token;
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
