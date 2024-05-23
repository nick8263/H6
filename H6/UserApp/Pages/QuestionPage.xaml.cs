namespace UserApp.Pages;

using Models;
public partial class QuestionPage : ContentPage
{
    private readonly SurveyViewModel _viewModel;

    public QuestionPage(QuestionGroup questionGroup)
    {
        InitializeComponent();
        _viewModel = new SurveyViewModel(questionGroup);
        BindingContext = _viewModel;

        CreateSurvey();
    }

    private void CreateSurvey()
    {
        int answerIndex = 0;
        foreach (var question in _viewModel.QuestionGroup.Questions)
        {
            var questionLabel = new Label
            {
                Text = question.PossibleQuestion,
                FontSize = 20,
                Margin = new Thickness(0, 10, 0, 5)
            };

            questionStack.Children.Add(questionLabel);

            if (question.Options == null || question.Options.Count == 0)
            {
                var entry = new Entry
                {
                    ClassId = answerIndex.ToString(),
                    Placeholder = "Enter your answer"
                };
                entry.SetBinding(Entry.TextProperty, $"AnswerGroup.Answers[{Convert.ToInt32(entry.ClassId)}].FreeTextAnswer");
                questionStack.Children.Add(entry);
            }
            else if (question.IsMultiple)
            {
                foreach (var option in question.Options)
                {
                    var checkBox = new CheckBox();
                    checkBox.ClassId = answerIndex.ToString();
                    checkBox.CheckedChanged += (s, e) =>
                    {
                        var selectedOption = e.Value ? option : null;
                        if (e.Value)
                        {
                            _viewModel.AnswerGroup.Answers[Convert.ToInt32(checkBox.ClassId)].Question.Options.Add(selectedOption);
                        }
                        else
                        {
                            _viewModel.AnswerGroup.Answers[Convert.ToInt32(checkBox.ClassId)].Question.Options.Remove(selectedOption);
                        }
                    };

                    var checkBoxLabel = new Label
                    {
                        Text = option.PossibleOption,
                        VerticalOptions = LayoutOptions.Center
                    };

                    var stack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { checkBox, checkBoxLabel }
                    };

                    questionStack.Children.Add(stack);
                }
            }
            else
            {

                var picker = new Picker();
                foreach (var option in question.Options)
                {
                    picker.Items.Add(option.PossibleOption);
                }
                picker.ClassId = answerIndex.ToString();
                picker.SelectedIndexChanged += (s, e) =>
                {
                    _viewModel.AnswerGroup.Answers[Convert.ToInt32(picker.ClassId)].SelectedAnswer = picker.SelectedItem.ToString();
                };

                questionStack.Children.Add(picker);
            }

            answerIndex++;
        }
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (_viewModel.ValidateAnswers(out string validationMessage))
        {
            // Proceed with submission
            DisplayAlert("Success", "Survey submitted successfully!", "OK");
            var a = _viewModel.AnswerGroup;
            var t = ";";
        }
        else
        {
            ValidationLabel.Text = validationMessage;
            ValidationLabel.IsVisible = true;
        }
        
    }

    private async void CancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}