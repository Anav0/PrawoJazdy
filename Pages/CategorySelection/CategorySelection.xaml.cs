using PrawoJazdy.Enums;
using PrawoJazdy.Pages.CategorySelection;

namespace PrawoJazdy;

public partial class CategorySelectionPage : ContentPage
{
	public CategorySelectionPage(CategorySelectionViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

}
