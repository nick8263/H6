using Models;

namespace WebSite.Components {
    public interface IData {
        Task<List<AnswerGroup>> GetAnswerGroup(int areaId, int countryId);

        Task<List<RoleModel>> GetRoles();
        Task DeleteRole(int roleId);
        Task AddRole(RoleModel role);

        Task<Question> GetQuestion(int id);
        Task<QuestionGroup> GetQuestionGroup(int areaId, int countryId);
        Task<List<Question>> GetQuestions();
        Task AddQuestion(Question question);
        Task EditQuestion(Question editedQuestion);
        Task DeleteQuestion(int questionId);

        Task AddArea(Area area);
        Task DeleteArea(int areaId);
        Task<Area> GetArea(int id);
        Task<List<Area>> GetAreas();

        Task AddCountry(Country country);
        Task DeleteCountry(int countryId);
        Task<Country> GetCountry(int id);
        Task<List<Country>> GetCountries();

        Task AddUser(User user);
        Task DeleteUser(int userId);
        Task UpdateUser(TokenUser updatedUser);
        Task<TokenUser> GetUser(string username, string password);
        Task<User> GetUser(int id);
        Task<List<User>> GetUsers();
    }

}
