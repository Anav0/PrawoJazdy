using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrawoJazdy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrawoJazdy.Pages.CategorySelection;

public partial class CategorySelectionViewModel : ObservableObject
{
    [ObservableProperty]
    public LicenseCategory selectedCategory;

    [RelayCommand]
    void OnNextClicked() 
    {

    } 

}
