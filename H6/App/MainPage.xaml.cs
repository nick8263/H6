using Models;
using App.Pages;

namespace App
{
    public partial class MainPage : ContentPage
    {      

        ApiAccess apiAccess { get; set; }

        public MainPage()
        {
            InitializeComponent();
            apiAccess = new ApiAccess();
        }

        private async Task OnLoginClicked(object sender, EventArgs e)
        {
            var result = await apiAccess.Login(new User { UserName = userNameEntry.Text, Password = passwordEntry.Text});

            if (result.Item2 == null)
            {
                await Navigation.PushAsync(new QuestionPage(result.Item1));
            }
        }
    }

}
