using Models;
using ApiAccess;

namespace WebSite.Components {
    public class APIConnector : IData {
        private static HomeAccess HomeAccess = new HomeAccess();
        private static UserAccess UserAccess = new UserAccess();

        public void AddArea(Area area) {
            HomeAccess.CreateArea(area);
        }

        public void AddCountry(Country country) {
            HomeAccess.CreateCountry(country);
        }

        public void AddQuestion(Question question) {
            HomeAccess.CreateQuestion(question);
        }

        public void AddRole(RoleModel role) {
            HomeAccess.CreateRole(role);
        }

        public void AddUser(User user) {
                UserAccess.CreateUser(user);
        }

        public void DeleteArea(int areaId) {
            HomeAccess.DeleteArea(areaId);
        }

        public void DeleteCountry(int countryId) {
            HomeAccess.DeleteCountry(countryId);
        }

        public void DeleteQuestion(int questionId) {
            HomeAccess.DeleteQuestion(questionId);
        }

        public void DeleteRole(int roleId) {
            HomeAccess.DeleteRole(roleId);
        }

        public void DeleteUser(int userId) {
            UserAccess.DeleteUser(userId);
        }

        public void EditQuestion(Question editedQuestion) {
            HomeAccess.UpdateQuestion(editedQuestion);
        }

        public List<AnswerGroup> GetAnswerGroup(int areaId, int countryId) {
            return HomeAccess.ReadAnswerGroup(areaId, countryId).Result.Item1;
        }

        public Area GetArea(int id) {
            return HomeAccess.ReadArea(id).Result.Item1;
        }

        public List<Area> GetAreas() {
            return HomeAccess.ReadAllAreas().Result.Item1;
        }

        public List<Country> GetCountries() {
            return HomeAccess.ReadAllCountries().Result.Item1;
        }

        public Country GetCountry(int id) {
            return HomeAccess.ReadCountry(id).Result.Item1;
        }

        public Question GetQuestion(int id) {
            return HomeAccess.ReadQuestion(id).Result.Item1;
        }

        public QuestionGroup GetQuestionGroup(int areaId, int countryId) {
            return HomeAccess.ReadQuestionGroup(areaId, countryId).Result.Item1;
        }

        public List<Question> GetQuestions() {
            return HomeAccess.ReadAllQuestions().Result.Item1;
        }

        public List<RoleModel> GetRoles() {
            return HomeAccess.ReadAllRoles().Result.Item1;
        }

        public User GetUser(string username, string password) {
            LoginModel loginModel = new LoginModel { Password = password, UserName = username};
            return UserAccess.Login(loginModel).Result.Item1;
        }

        public User GetUser(int id) {
            return UserAccess.ReadUser(id).Result.Item1;
        }

        public List<User> GetUsers() {
            return UserAccess.ReadAllUser().Result.Item1;
        }

        public void UpdateUser(User updatedUser) {
            UserAccess.UpdateUser(updatedUser);
        }
    }
}