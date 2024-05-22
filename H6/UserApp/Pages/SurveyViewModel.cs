using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserApp.Pages
{
    public class SurveyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private QuestionGroup _questionGroup;
        public QuestionGroup QuestionGroup
        {
            get => _questionGroup;
            set
            {
                _questionGroup = value;
                OnPropertyChanged(nameof(QuestionGroup));
            }
        }

        private AnswerGroup _answerGroup;
        public AnswerGroup AnswerGroup
        {
            get => _answerGroup;
            set
            {
                _answerGroup = value;
                OnPropertyChanged(nameof(AnswerGroup));
            }
        }

        public SurveyViewModel(QuestionGroup questionGroup)
        {
            QuestionGroup = questionGroup;
            InitializeAnswerGroup();
        }

        private void InitializeAnswerGroup()
        {
            AnswerGroup = new AnswerGroup
            {
                Country = QuestionGroup.Country,
                Area = QuestionGroup.Area,
                Answers = new List<Answer>(),
                user = new User() // Initialize with current user or a new user
            };

            foreach (var question in QuestionGroup.Questions)
            {
                AnswerGroup.Answers.Add(new Answer
                {
                    Question = question,
                    Options = new List<Option>()
                });
            }
        }

        public bool ValidateAnswers(out string validationMessage)
        {
            validationMessage = string.Empty;
            foreach (var answer in AnswerGroup.Answers)
            {
                if (answer.Question.Options == null || answer.Question.Options.Count == 0)
                {
                    if (string.IsNullOrWhiteSpace(answer.FreeTextAnswer))
                    {
                        validationMessage = $"Please answer the question: '{answer.Question.PossibleQuestion}'";
                        return false;
                    }
                }
                else if (answer.Question.IsMultiple)
                {
                    if (answer.Options == null || answer.Options.Count == 0)
                    {
                        validationMessage = $"Please select at least one option for the question: '{answer.Question.PossibleQuestion}'";
                        return false;
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(answer.SelectedAnswer))
                    {
                        validationMessage = $"Please select an option for the question: '{answer.Question.PossibleQuestion}'";
                        return false;
                    }
                }
            }
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
