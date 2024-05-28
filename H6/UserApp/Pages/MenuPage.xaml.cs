
using Models;

namespace UserApp.Pages;

public partial class MenuPage : ContentPage
{
    public TokenUser User { get; set; }
    public MenuPage(TokenUser _user)
	{
		InitializeComponent();
        User = _user;
	}

    private async void SurveyClicked(object sender, EventArgs e)
    {
        //var result = await apiAccess.Login(new User { UserName = userNameEntry.Text, Password = passwordEntry.Text });
        //if (result.Item2 == null)
        //{
        //    await Navigation.PushAsync(new QuestionPage(result.Item1));
        //}

        var result = new QuestionGroup
        {
            Id = 1,
            Country = new Country { PossibleCountry = "Kibæk" },
            Area = new Area { PossibleArea = "Finger" },
            Questions = new()
            {
                new Question(){
                    PossibleQuestion = "Hvad er en hund",
                    IsMultiple = false,
                    Options = null
                },
                new Question()
                {
                    PossibleQuestion = "Hvilken af disse dyr er en Kat",
                    IsMultiple = false,
                    Options = new()
                    {
                        new Option{Id = 4, PossibleOption = "Hund"},
                        new Option{Id = 4, PossibleOption = "Kat"},
                        new Option{Id = 4, PossibleOption = "Hest"},
                        new Option{Id = 4, PossibleOption = "Ged"}
                    }
                },
                new Question()
                {
                    PossibleQuestion = "Hvilken af disse dyr er ikke en Kat",
                    IsMultiple = true,
                    Options = new()
                    {
                        new Option{Id = 4, PossibleOption = "Hund"},
                        new Option{Id = 4, PossibleOption = "Kat"},
                        new Option{Id = 4, PossibleOption = "Hest"},
                        new Option{Id = 4, PossibleOption = "Ged"}
                    }
                }
            }
        };
        await Navigation.PushAsync(new QuestionPage(result));
    }

    private async void AccountBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AccountPage(User));
    }

    private async void LogoutBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}