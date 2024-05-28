using Models;

namespace UserApp.Pages;

public partial class AccountPage : ContentPage
{
    public TokenUser User { get; set; }
    public AccountPage(TokenUser _user)
	{
		InitializeComponent();
        User = _user;

        userNameLabel.Text = _user.User.UserName;
        countryLabel.Text = _user.User.Country.PossibleCountry;
        areaLabel.Text = _user.User.Area.PossibleArea;
        roleLabel.Text = _user.User.Role.Name;
	}

    private async void ChangePasswordClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChangePasswordPage(User));
    }

    private async void BackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}