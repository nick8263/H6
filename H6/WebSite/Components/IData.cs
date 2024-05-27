using Models;

namespace WebSite.Components {
    public interface IData {
        List<AnswerGroup> GetAnswerGroup(int areaId, int countryId);
        List<RoleModel> GetRoles();
        void DeleteRole(int roleId);
        void AddRole(RoleModel role);
        List<Area> GetAreas();
        List<Country> GetCountries();
        Question GetQuestion(int id);
        Area GetArea(int id);
        Country GetCountry(int id);
        QuestionGroup GetQuestionGroup(int areaId, int countryId);
        List<Question> GetQuestions();        
        User GetUser(string username, string password);
        User GetUser(int id);
        List<User> GetUsers();
        void AddQuestion(Question question);
        void EditQuestion(Question editedQuestion);
        void DeleteQuestion(int questionId);
        void AddUser(User user);
        void AddArea(Area area);
        void DeleteArea(int areaId);
        void AddCountry(Country country);
        void DeleteCountry(int countryId);
        void UpdateUser(User updatedUser);
        void DeleteUser(int userId);
    }
}
