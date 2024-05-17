namespace App.Pages;
using Models;
public partial class QuestionPage : ContentPage
{

	public QuestionPage()
	{
        InitializeComponent();
        questionStack.Children.Add(new Entry() { Text = "hej" });
    }
}