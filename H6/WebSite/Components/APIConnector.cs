using Models;
using ApiAccess;

namespace WebSite.Components {
    public class APIConnector : IData {
        private static HomeAccess HomeAccess = new HomeAccess();
        private static UserAccess UserAccess = new UserAccess();

        public async Task AddArea(Area area) {
            await HomeAccess.CreateArea(area);
        }

        public async Task AddCountry(Country country) {
            await HomeAccess.CreateCountry(country);
        }

        public async Task AddQuestion(Question question) {
            await HomeAccess.CreateQuestion(question);
        }

        public async Task AddRole(RoleModel role) {
            await HomeAccess.CreateRole(role);
        }

        public async Task AddUser(User user) {
            await UserAccess.CreateUser(user);
        }

        public async Task DeleteArea(int areaId) {
            await HomeAccess.DeleteArea(areaId);
        }

        public async Task DeleteCountry(int countryId) {
            await HomeAccess.DeleteCountry(countryId);
        }

        public async Task DeleteQuestion(int questionId) {
            await HomeAccess.DeleteQuestion(questionId);
        }

        public async Task DeleteRole(int roleId) {
            await HomeAccess.DeleteRole(roleId);
        }

        public async Task DeleteUser(int userId) {
            await UserAccess.DeleteUser(userId);
        }

        public async Task EditQuestion(Question editedQuestion) {
            await HomeAccess.UpdateQuestion(editedQuestion);
        }

        public async Task<List<AnswerGroup>> GetAnswerGroup(int areaId, int countryId) {
            var result = await HomeAccess.ReadAnswerGroup(new GroupAccessModel { AreaId = areaId, CountryId = countryId });
            return result.Item1;
        }

        public async Task<Area> GetArea(int id) {
            var result = await HomeAccess.ReadArea(id);
            return result.Item1;
        }

        public async Task<List<Area>> GetAreas() {
            var result = await HomeAccess.ReadAllAreas();
            return result.Item1;
        }

        public async Task<List<Country>> GetCountries() {
            var result = await HomeAccess.ReadAllCountries();
            return result.Item1;
        }

        public async Task<Country> GetCountry(int id) {
            var result = await HomeAccess.ReadCountry(id);
            return result.Item1;
        }

        public async Task<Question> GetQuestion(int id) {
            var result = await HomeAccess.ReadQuestion(id);
            return result.Item1;
        }

        public async Task<QuestionGroup> GetQuestionGroup(int areaId, int countryId) {
            var result = await HomeAccess.ReadQuestionGroup(new GroupAccessModel { AreaId = areaId, CountryId = countryId });
            return result.Item1;
        }

        public async Task<List<Question>> GetQuestions() {
            var result = await HomeAccess.ReadAllQuestions();
            return result.Item1;
        }

        public async Task<List<RoleModel>> GetRoles() {
            var result = await HomeAccess.ReadAllRoles();
            return result.Item1;
        }

        public async Task<TokenUser> GetUser(string username, string password) {
            LoginModel loginModel = new LoginModel { Password = password, UserName = username };
            var result = await UserAccess.Login(loginModel);
            return result.Item1;
        }

        public async Task<User> GetUser(int id) {
            var result = await UserAccess.ReadUser(id);
            return result.Item1;
        }

        public async Task<List<User>> GetUsers() {
            var result = await UserAccess.ReadAllUser();
            return result.Item1;
        }

        public async Task UpdateUser(TokenUser updatedUser) {
            await UserAccess.UpdateUser(updatedUser);
        }
    }

}