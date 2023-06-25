using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrawoJazdy.Enums;
using PrawoJazdy.Pages;

namespace PrawoJazdy.ViewModels;

public partial class CategorySelectionViewModel : ObservableObject
{
    [ObservableProperty]
    public LicenseCategory selectedCategory;

    [ObservableProperty]
    public Mode selectedMode;

    [RelayCommand]
    async void OnNextClicked()
    {
        var url = $"{nameof(QuizPage)}?Mode={SelectedMode}&LicenseCategory={SelectedCategory}";
        await Shell.Current.GoToAsync(nameof(QuizPage), new Dictionary<string, object>()
        {
            { "Mode", SelectedMode},
            { "LicenseCategory", SelectedCategory},
        });
    }

}
