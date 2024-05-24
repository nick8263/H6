using Models;
using UserApp.Pages;
using ApiAccess;
namespace UserApp
{
    public partial class MainPage : ContentPage
    {

        UserAccess userAccess { get; set; }

        public MainPage()
        {
            InitializeComponent();
            userAccess = new UserAccess();
        }        

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var user = await userAccess.Login(new LoginModel { UserName = userNameEntry.Text, Password = passwordEntry.Text});

            if (user.Item2 == null)
            {
                errorLabel.IsEnabled = false;
                await Navigation.PushAsync(new MenuPage(user.Item1));
            }   
            else
            {
                errorLabel.Text = user.Item2;
                errorLabel.IsEnabled = true;
            }
        }
    }
}