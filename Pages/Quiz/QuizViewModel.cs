using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrawoJazdy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrawoJazdy.ViewModels;

[QueryProperty("Mode", "Mode")]
[QueryProperty("LicenseCategory", "LicenseCategory")]
public partial class QuizViewModel : ObservableObject
{
    [ObservableProperty]
    public LicenseCategory licenseCategory;

    [ObservableProperty]
    public Mode mode;

    [RelayCommand]
    void OnClick()
    {

    }
}
