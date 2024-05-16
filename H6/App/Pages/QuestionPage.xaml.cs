namespace App.Pages;
using Models;
public partial class QuestionPage : ContentPage
{

	public QuestionPage(QuestionGroup questionGroup)
	{
		questionStack.Children.Add(new Entry() { Text = "hej"});
	}
}