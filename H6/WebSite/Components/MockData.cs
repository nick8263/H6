using global::Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebSite.Components {
    public class MockData {
        private static MockData _instance;
        private List<Question> _questions;
        private List<QuestionGroup> _groups = new List<QuestionGroup>();
        private QuestionGroup _group;
        
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
            _group = new QuestionGroup() {
                Id = 1,
                Questions = _questions,
                Area = new Area { Id = 1, PossibleArea = "Test Area"},
                Country = new Country { Id = 1, PossibleCountry = "Test Country"}
            };
            _groups.Add(_group);
        }

        public static MockData Instance {
            get {
                if (_instance == null) {
                    _instance = new MockData();
                }
                return _instance;
            }
        }

        public List<Question> GetQuestions() {
            return _questions;
        }

        public List<Question> GetQuestionsForID(int id) {
            return _groups.FirstOrDefault(g => g.Id == id).Questions;
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
    }
}
