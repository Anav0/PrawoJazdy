using PrawoJazdy.ViewModels;

namespace PrawoJazdy.Pages;

public partial class QuizPage : ContentPage
{
	public QuizPage(QuizViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}