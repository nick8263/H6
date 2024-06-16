using Models;
using ApiAccess;

namespace WebSite.Components {
    public class APIConnector : IData {
        private static HomeAccess HomeAccess = new HomeAccess();
        private static UserAccess UserAccess = new UserAccess();

        public async Task AddArea(Area area, string token) {
            await HomeAccess.CreateArea(area, token);
        }

        public async Task AddCountry(Country country, string token) {
            await HomeAccess.CreateCountry(country, token);
        }

        public async Task AddQuestion(Question question, string token) {
            await HomeAccess.CreateQuestion(question, token);
        }

        public async Task AddRole(RoleModel role, string token) {
            await HomeAccess.CreateRole(role, token);
        }

        public async Task AddUser(User user, string token) {
            await UserAccess.CreateUser(user, token);
        }

        public async Task DeleteAnswer(int answerGroupId, string token) {
            await HomeAccess.DeleteAnswerGroup(answerGroupId, token);
        }

        public async Task DeleteArea(int areaId, string token) {
            await HomeAccess.DeleteArea(areaId, token);
        }

        public async Task DeleteCountry(int countryId, string token) {
            await HomeAccess.DeleteCountry(countryId, token);
        }

        public async Task DeleteQuestion(int questionId, string token) {
            await HomeAccess.DeleteQuestion(questionId, token);
        }

        public async Task DeleteRole(int roleId, string token) {
            await HomeAccess.DeleteRole(roleId, token);
        }

        public async Task DeleteUser(int userId, string token) {
            await UserAccess.DeleteUser(userId, token);
        }

        public async Task EditQuestion(Question editedQuestion, string token) {
            await HomeAccess.UpdateQuestion(editedQuestion, token);
        }

        public async Task<List<AnswerGroup>> GetAnswerGroup(int areaId, int countryId, string token) {
            var result = await HomeAccess.ReadAnswerGroup(new GroupAccessModel { AreaId = areaId, CountryId = countryId }, token);
            return result.Item1;
        }

        public async Task<Area> GetArea(int id, string token) {
            var result = await HomeAccess.ReadArea(id, token);
            return result.Item1;
        }

        public async Task<List<Area>> GetAreas(string token) {
            var result = await HomeAccess.ReadAllAreas(token);
            return result.Item1;
        }

        public async Task<List<Country>> GetCountries(string token) {
            var result = await HomeAccess.ReadAllCountries(token);
            return result.Item1;
        }

        public async Task<Country> GetCountry(int id, string token) {
            var result = await HomeAccess.ReadCountry(id, token);
            return result.Item1;
        }

        public async Task<Question> GetQuestion(int id, string token) {
            var result = await HomeAccess.ReadQuestion(id, token);
            return result.Item1;
        }

        public async Task<QuestionGroup> GetQuestionGroup(int areaId, int countryId, string token) {
            var result = await HomeAccess.ReadQuestionGroup(new GroupAccessModel { AreaId = areaId, CountryId = countryId }, token);
            return result.Item1;
        }

        public async Task<QuestionGroup> GetQuestionGroups(int areaId, int countryId, string token) {
            var result = await HomeAccess.ReadQuestionGroup(new GroupAccessModel { AreaId = areaId, CountryId = countryId }, token);
            return result.Item1;
        }

        public async Task<List<Question>> GetQuestions(string token) {
            var result = await HomeAccess.ReadAllQuestions(token);
            return result.Item1;
        }

        public async Task<List<RoleModel>> GetRoles(string token) {
            var result = await HomeAccess.ReadAllRoles(token);
            return result.Item1;
        }

        public async Task<TokenUser> GetUser(string username, string password) {
            LoginModel loginModel = new LoginModel { Password = password, UserName = username };
            var result = await UserAccess.Login(loginModel);
            return result.Item1;
        }

        public async Task<User> GetUser(int id, string token) {
            var result = await UserAccess.ReadUser(id, token);
            return result.Item1;
        }

        public async Task<List<User>> GetUsers(string token) {
            var result = await UserAccess.ReadAllUser(token);
            return result.Item1;
        }

        public async Task UpdateQuestionGroup(QuestionGroup questionGroup, string token) {
            await HomeAccess.UpdateQuestionGroup(questionGroup, token);
        }

        public async Task UpdateUser(TokenUser updatedUser) {
            await UserAccess.UpdateUser(updatedUser);
        }
    }

}