using ApiAccess;
using Models;

namespace UserApp.Pages;

public partial class ChangePasswordPage : ContentPage
{
    UserAccess userAccess = new UserAccess();
    public User User { get; set; }
    public ChangePasswordPage(User _user)
    {
        InitializeComponent();
        User = _user;
    }

    private async void ChangeBtnClicked(object sender, EventArgs e)
    {
        if (passwordEntry.Text.Length > 4)
        {
            (bool, string) result = await userAccess.UpdateUser(User);

            if (!result.Item1)
            {
                errorLabel.Text = result.Item2;
                errorLabel.IsEnabled = true;
            }
            else
            {
                await DisplayAlert("Success", "Your password is now updated", "Ok");
            }
        }
        else
        {
            errorLabel.Text = "Password must be atleast 5 letter long";
            errorLabel.IsEnabled = true;
        }


    }

    private async void CancelBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}