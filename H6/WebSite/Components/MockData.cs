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
        private static List<TokenUser> _tokens = new List<TokenUser>();
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
                Name = "Admin"
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
            _tokens.Add(new TokenUser { Token = "Token1", User = user });

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
                Name = "HSE"
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
            _tokens.Add(new TokenUser { Token = "Token2", User = user });

            role = new RoleModel {
                Id = 3,
                Name = "Regular"
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
            _tokens.Add(new TokenUser { Token = "Token3", User = user });

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

            answers = new List<Answer>();

            answerGroup = new AnswerGroup {
                Id = 3,
                Area = area,
                Country = country,
                user = user,
                Answers = new List<Answer>()
            };

            answer = new Answer {
                Id = 6,
                Question = _questions[0],
                FreeTextAnswer = null,
                SelectedAnswer = _questions[0].Options[2].PossibleOption,
                AnswerGroups = new List<AnswerGroup>()
            };
            answer.AnswerGroups.Add(answerGroup);
            answers.Add(answer);
            answerGroup.Answers.Add(answer);

            answer = new Answer {
                Id = 7,
                Question = _questions[1],
                FreeTextAnswer = "23",
                SelectedAnswer = null,
                AnswerGroups = new List<AnswerGroup>()
            };

            answer.AnswerGroups.Add(answerGroup);
            answers.Add(answer);
            answerGroup.Answers.Add(answer);

            answer = new Answer {
                Id = 8,
                Question = _questions[0],
                FreeTextAnswer = null,
                SelectedAnswer = _questions[0].Options[1].PossibleOption,
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

        public async Task<List<AnswerGroup>> GetAnswerGroup(int areaId, int countryId, string token) {
            return await Task.Run(() => _answerGroups.Where(a => a.Area.Id == areaId && a.Country.Id == countryId).ToList());
        }

        public async Task<List<RoleModel>> GetRoles(string token) {
            return await Task.FromResult(_roles);
        }

        public async Task DeleteRole(int roleId, string token) {
            await Task.Run(() => {
                var roleToRemove = _roles.FirstOrDefault(r => r.Id == roleId);
                if (roleToRemove != null) {
                    _roles.Remove(roleToRemove);
                }
            });
        }

        public async Task AddRole(RoleModel role, string token) {
            await Task.Run(() => {
                role.Id = _roles.Any() ? _roles.Max(r => r.Id) + 1 : 1;
                _roles.Add(role);
            });
        }

        public async Task<List<Area>> GetAreas(string token) {
            return await Task.FromResult(_areas);
        }

        public async Task<List<Country>> GetCountries(string token) {
            return await Task.FromResult(_countries);
        }

        public async Task<Question> GetQuestion(int id, string token) {
            return await Task.Run(() => _questions.FirstOrDefault(q => q.Id == id));
        }

        public async Task<Area> GetArea(int id, string token) {
            return await Task.Run(() => _areas.FirstOrDefault(a => a.Id == id));
        }

        public async Task<Country> GetCountry(int id, string token) {
            return await Task.Run(() => _countries.FirstOrDefault(c => c.Id == id));
        }

        public async Task<QuestionGroup> GetQuestionGroup(int areaId, int countryId, string token) {
            return await Task.Run(() => _groups.FirstOrDefault(g => g.Area.Id == areaId && g.Country.Id == countryId));
        }

        public async Task<List<Question>> GetQuestions(string token) {
            return await Task.FromResult(_questions);
        }

        public async Task<List<Question>> GetQuestionsForID(int id, string token) {
            return await Task.Run(() => _groups.FirstOrDefault(g => g.Id == id)?.Questions);
        }

        public async Task<TokenUser> GetUser(string username, string password) {
            return await Task.Run(() => _tokens.FirstOrDefault(u => u.User.UserName == username && u.User.Password == password));
        }

        public async Task<User> GetUser(int id, string token) {
            return await Task.Run(() => _users.FirstOrDefault(u => u.Id == id));
        }

        public async Task<List<User>> GetUsers(string token) {
            return await Task.FromResult(_users);
        }

        public async Task AddQuestion(Question question, string token) {
            await Task.Run(() => {
                // Assign a unique Id to the new question
                question.Id = _questions.Any() ? _questions.Max(q => q.Id) + 1 : 1;
                _questions.Add(question);
            });
        }

        public async Task EditQuestion(Question editedQuestion, string token) {
            await Task.Run(() => {
                var existingQuestion = _questions.FirstOrDefault(q => q.Id == editedQuestion.Id);
                if (existingQuestion != null) {
                    existingQuestion.PossibleQuestion = editedQuestion.PossibleQuestion;
                    existingQuestion.Options = editedQuestion.Options;
                }
            });
        }

        public async Task DeleteQuestion(int questionId, string token) {
            await Task.Run(() => {
                var questionToRemove = _questions.FirstOrDefault(q => q.Id == questionId);
                if (questionToRemove != null) {
                    _questions.Remove(questionToRemove);
                }
            });
        }

        public async Task AddUser(User user, string token) {
            await Task.Run(() => {
                user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;
                _users.Add(user);
            });
        }

        public async Task AddArea(Area area, string token) {
            await Task.Run(() => {
                area.Id = _areas.Any() ? _areas.Max(a => a.Id) + 1 : 1;
                _areas.Add(area);
            });
        }

        public async Task DeleteArea(int areaId, string token) {
            await Task.Run(() => {
                var areaToDelete = _areas.FirstOrDefault(a => a.Id == areaId);
                if (areaToDelete != null) {
                    _areas.Remove(areaToDelete);
                }
            });
        }

        public async Task AddCountry(Country country, string token) {
            await Task.Run(() => {
                country.Id = _countries.Any() ? _countries.Max(c => c.Id) + 1 : 1;
                _countries.Add(country);
            });
        }

        public async Task DeleteCountry(int countryId, string token) {
            await Task.Run(() => {
                var countryToDelete = _countries.FirstOrDefault(c => c.Id == countryId);
                if (countryToDelete != null) {
                    _countries.Remove(countryToDelete);
                }
            });
        }

        public async Task UpdateUser(TokenUser updatedUser) {
            await Task.Run(() => {
                var existingUser = _users.FirstOrDefault(u => u.Id == updatedUser.User.Id);
                if (existingUser != null) {
                    existingUser.Area = updatedUser.User.Area;
                    existingUser.UserName = updatedUser.User.UserName;
                    existingUser.Role = updatedUser.User.Role;
                    existingUser.Country = updatedUser.User.Country;
                    existingUser.Password = updatedUser.User.Password;
                }
            });
        }

        public async Task DeleteUser(int userId, string token) {
            await Task.Run(() => {
                var userToRemove = _users.FirstOrDefault(u => u.Id == userId);
                if (userToRemove != null) {
                    _users.Remove(userToRemove);
                }
            });
        }

        public async Task<QuestionGroup> GetQuestionGroups(int areaId, int countryId, string token) {
            return await Task.Run(() => _groups.FirstOrDefault(g => g.Area.Id == areaId && g.Country.Id == countryId));
        }

        public async Task UpdateQuestionGroup(QuestionGroup questionGroup, string token) {
            await Task.Run(() => {
                var existingGroup = _groups.FirstOrDefault(g => g.Id == questionGroup.Id);
                if (existingGroup != null) {
                    existingGroup = questionGroup;
                }
            });
        }

        public Task DeleteAnswer(int answerId, string token) {
            throw new NotImplementedException();
        }
    }
}
