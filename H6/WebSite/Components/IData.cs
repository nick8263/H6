using Models;

namespace WebSite.Components {
    public interface IData {
        Task<List<AnswerGroup>> GetAnswerGroup(int areaId, int countryId, string token);

        Task<QuestionGroup> GetQuestionGroups(int areaId, int countryId, string token);
        Task UpdateQuestionGroup(QuestionGroup questionGroup, string token);

        Task<List<RoleModel>> GetRoles(string token);
        Task DeleteRole(int roleId, string token);
        Task AddRole(RoleModel role, string token);

        Task<Question> GetQuestion(int id, string token);
        Task<QuestionGroup> GetQuestionGroup(int areaId, int countryId, string token);
        Task<List<Question>> GetQuestions(string token);
        Task AddQuestion(Question question, string token);
        Task EditQuestion(Question editedQuestion, string token);
        Task DeleteQuestion(int questionId, string token);

        Task AddArea(Area area, string token);
        Task DeleteArea(int areaId, string token);
        Task<Area> GetArea(int id, string token);
        Task<List<Area>> GetAreas(string token);

        Task AddCountry(Country country, string token);
        Task DeleteCountry(int countryId, string token);
        Task<Country> GetCountry(int id, string token);
        Task<List<Country>> GetCountries(string token);

        Task AddUser(User user, string token);
        Task DeleteUser(int userId, string token);
        Task UpdateUser(TokenUser updatedUser);
        Task<TokenUser> GetUser(string username, string password);
        Task<User> GetUser(int id, string token);
        Task<List<User>> GetUsers(string token);
    }

}
