using Models;

namespace UserApp.Pages;

public partial class AccountPage : ContentPage
{
    public User User { get; set; }
    public AccountPage(User _user)
	{
		InitializeComponent();
        User = _user;

        userNameLabel.Text = _user.UserName;
        countryLabel.Text = _user.Country;
        areaLabel.Text = _user.Area;
        roleLabel.Text = _user.Role;
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