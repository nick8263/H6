using global::Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using WebSite.Components.Pages;

namespace WebSite.Components {
    public class MockData : IData {
        private static MockData _instance;
        private static List<Question> _questions;
        private static List<QuestionGroup> _groups = new List<QuestionGroup>();
        private static List<User> _users = new List<User>();
        private static List<Area> _areas = new List<Area>();
        private static List<Country> _countries = new List<Country>();
        private static List<RoleModel> _roles = new List<RoleModel>();
        private static QuestionGroup _group;
        private static List<AnswerGroup> _answerGroups = new List<AnswerGroup>();
        
        public MockData() {
            // Initialize mock data
            _questions = new List<Question> {
            new Question {
                Id = 1,
                PossibleQuestion = "What is your favorite color?",
                Options = new List<Option>
                {
                    new Option { Id = 1, PossibleOption = "Red" },
                    new Option { Id = 2, PossibleOption = "Blue" },
                    new Option { Id = 3, PossibleOption = "Green" }
                }
            },
            new Question {
                Id = 2,
                PossibleQuestion = "How old are you?",
                Options = null // No predefined options for this question
            }
            };
            Area area = new Area { Id = 1, PossibleArea = "Test Area" };
            _areas.Add(area);
            Country country = new Country { Id = 1, PossibleCountry = "Test Country" };
            _countries.Add(country);
            _group = new QuestionGroup() {
                Id = 1,
                Questions = _questions,
                Area = area,
                Country = country
            };
            _groups.Add(_group);
            RoleModel role = new RoleModel {
                Id = 1,
                Name = "admin"
            };
            _roles.Add(role);
            User user = new User {
                Area = area,
                Country = country,
                Id = 1,
                Password = "admin",
                Role = role,
                UserName = "admin"
            };
            _users.Add(user);

            List<Answer> answers = new List<Answer>();

            AnswerGroup answerGroup = new AnswerGroup {
                Id = 1,
                Area = area,
                Country = country,
                user = user,
                Answers = new List<Answer>()               
            };

            Answer answer = new Answer {
                Id = 1,
                Question = _questions[0],
                FreeTextAnswer = null,
                SelectedAnswer = _questions[0].Options[0].PossibleOption,      
                AnswerGroups = new List<AnswerGroup>()
            };            
            answer.AnswerGroups.Add(answerGroup);
            answers.Add(answer);
            answerGroup.Answers.Add(answer);

            answer = new Answer {
                Id = 2,
                Question = _questions[1],
                FreeTextAnswer = "27",
                SelectedAnswer = null,
                AnswerGroups = new List<AnswerGroup>()
            };

            answer.AnswerGroups.Add(answerGroup);
            answers.Add(answer);
            answerGroup.Answers.Add(answer);
            _answerGroups.Add(answerGroup);


            area = new Area { Id = 2, PossibleArea = "Test Area 2" };
            _areas.Add(area);
            country = new Country { Id = 2, PossibleCountry = "Test Country 2" };
            _countries.Add(country);
            role = new RoleModel {
                Id = 2,
                Name = "hse"
            };
            _roles.Add(role);
            user = new User {
                Area = area,
                Country = country,
                Id = 2,
                Password = "hse",
                Role = role,
                UserName = "hse"
            };
            _users.Add(user);

            role = new RoleModel {
                Id = 3,
                Name = "regular"
            };
            _roles.Add(role);
            user = new User {
                Area = area,
                Country = country,
                Id = 3,
                Password = "regular",
                Role = role,
                UserName = "regular"
            };
            _users.Add(user);

            List<Question> temp = new List<Question> {
            new Question {
                Id = 3,
                PossibleQuestion = "What is your favorite color?",
                Options = new List<Option>
                {
                    new Option { Id = 4, PossibleOption = "Purple" },
                    new Option { Id = 5, PossibleOption = "White" },
                    new Option { Id = 6, PossibleOption = "Black" }
                }
            },
            new Question {
                Id = 4,
                PossibleQuestion = "How old are you now?",
                Options = null // No predefined options for this question
            }
            };
            foreach (Question question in temp) {
                _questions.Add(question);
            }
            _group = new QuestionGroup() {
                Id = 2,
                Questions = temp,
                Area = area,
                Country = country
            };
            _groups.Add(_group);

            answers = new List<Answer>();

            answerGroup = new AnswerGroup {
                Id = 2,
                Area = area,
                Country = country,
                user = user,
                Answers = new List<Answer>()
            };

            answer = new Answer {
                Id = 3,
                Question = _questions[0],
                FreeTextAnswer = null,
                SelectedAnswer = _questions[0].Options[0].PossibleOption,
                AnswerGroups = new List<AnswerGroup>()
            };
            answer.AnswerGroups.Add(answerGroup);
            answers.Add(answer);
            answerGroup.Answers.Add(answer);

            answer = new Answer {
                Id = 4,
                Question = _questions[1],
                FreeTextAnswer = "27",
                SelectedAnswer = null,
                AnswerGroups = new List<AnswerGroup>()
            };

            answer.AnswerGroups.Add(answerGroup);
            answers.Add(answer);
            answerGroup.Answers.Add(answer);

            answer = new Answer {
                Id = 5,
                Question = _questions[0],
                FreeTextAnswer = null,
                SelectedAnswer = _questions[0].Options[2].PossibleOption,
                AnswerGroups = new List<AnswerGroup>()
            };

            answer.AnswerGroups.Add(answerGroup);
            answers.Add(answer);
            answerGroup.Answers.Add(answer);
            _answerGroups.Add(answerGroup);

        }

        public static MockData Instance {
            get {
                if (_instance == null) {
                    _instance = new MockData();
                }
                return _instance;
            }
        }

        public AnswerGroup GetAnswerGroup(int areaId, int countryId) {
            return _answerGroups.FirstOrDefault(a => a.Area.Id == areaId && a.Country.Id == countryId);
        }

        public List<RoleModel> GetRoles() { 
            return _roles; 
        }

        public void DeleteRole(int roleId) {
            var roleToRemove = _roles.FirstOrDefault(r => r.Id == roleId);
            if (roleToRemove != null) {
                _roles.Remove(roleToRemove);
            }
        }

        public void AddRole(RoleModel role) {
            role.Id = _roles.Any() ? _roles.Max(r => r.Id) + 1 : 1;
            _roles.Add(role);
        }

        public List<Area> GetAreas() {
            return _areas;
        }

        public List<Country> GetCountries() {
            return _countries;
        }

        public Question GetQuestion(int id) {
            return _questions.FirstOrDefault(q => q.Id == id);
        }

        public Area GetArea(int id) {
            return _areas.FirstOrDefault(a => a.Id == id);
        }

        public Country GetCountry(int id) {
            return _countries.FirstOrDefault(c => c.Id == id);
        }

        public QuestionGroup GetQuestionGroup(int areaId, int countryId) {
            return _groups.FirstOrDefault(g => g.Area.Id == areaId && g.Country.Id == countryId);
        }

        public List<Question> GetQuestions() {
            return _questions;
        }

        public List<Question> GetQuestionsForID(int id) {
            return _groups.FirstOrDefault(g => g.Id == id).Questions;
        }

        public User GetUser(string username, string password) {
            return _users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        }

        public User GetUser(int id) {
            return _users.FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetUsers() {
            return _users;
        }

        public void AddQuestion(Question question) {
            // Assign a unique Id to the new question
            question.Id = _questions.Any() ? _questions.Max(q => q.Id) + 1 : 1;
            _questions.Add(question);
        }

        public void EditQuestion(Question editedQuestion) {
            var existingQuestion = _questions.FirstOrDefault(q => q.Id == editedQuestion.Id);
            if (existingQuestion != null) {
                existingQuestion.PossibleQuestion = editedQuestion.PossibleQuestion;
                existingQuestion.Options = editedQuestion.Options;
            }
        }

        public void DeleteQuestion(int questionId) {
            var questionToRemove = _questions.FirstOrDefault(q => q.Id == questionId);
            if (questionToRemove != null) {
                _questions.Remove(questionToRemove);
            }
        }

        public void AddUser(User user) {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
        }

        public void AddArea(Area area) {
            area.Id = _areas.Any() ? _areas.Max(a => a.Id) + 1 : 1;
            _areas.Add(area);
        }

        public void DeleteArea(int areaId) {
            var areaToDelete = _areas.FirstOrDefault(a => a.Id == areaId);
            if (areaToDelete != null) {
                _areas.Remove(areaToDelete);
            }
        }

        public void AddCountry(Country country) {
            country.Id = _countries.Any() ? _countries.Max(c => c.Id) + 1 : 1;
            _countries.Add(country);
        }

        public void DeleteCountry(int countryId) {
            var countryToDelete = _countries.FirstOrDefault(c => c.Id == countryId);
            if (countryToDelete != null) {
                _countries.Remove(countryToDelete);
            }
        }

        public void UpdateUser(User updatedUser) {
            var existingUser = _users.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (existingUser != null) {
                existingUser.Area = updatedUser.Area;
                existingUser.UserName = updatedUser.UserName;
                existingUser.Role = updatedUser.Role;
                existingUser.Country = updatedUser.Country;
                existingUser.Password = updatedUser.Password;
            }
        }

        public void DeleteUser(int userId) {
            var UserToRemove = _users.FirstOrDefault(u => u.Id == userId);
            if (UserToRemove != null) {
                _users.Remove(UserToRemove);
            }
        }
    }
}
