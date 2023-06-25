using PrawoJazdy.ViewModels;

namespace PrawoJazdy.Pages;

public partial class CategorySelectionPage : ContentPage
{
	public CategorySelectionPage(CategorySelectionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}
