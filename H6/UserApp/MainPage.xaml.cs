using Models;
using UserApp.Pages;
namespace UserApp
{
    public partial class MainPage : ContentPage
    {

        ApiAccess apiAccess { get; set; }

        public MainPage()
        {
            InitializeComponent();
            apiAccess = new ApiAccess();
        }        

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var user = await apiAccess.Login(new LoginModel { UserName = userNameEntry.Text, Password = passwordEntry.Text});

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