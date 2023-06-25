using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PrawoJazdy.Enums;
using PrawoJazdy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    [ObservableProperty]
    public bool isLoading = false;

    [ObservableProperty]
    public float loadingProgress = 0.5f;

    [ObservableProperty]
    public ObservableCollection<Question> questions = new();

    [ObservableProperty]
    public Question currentQuestion;

    [ObservableProperty]
    public int currentQuestionIndex;

    [ObservableProperty]
    public bool canGoToPrevQuestion;

    [ObservableProperty]
    public bool canGoToNextQuestion;


    partial void OnCurrentQuestionIndexChanged(int value)
    {
        if (value < 0) value = 0;
        if (value >= Questions.Count) value = Questions.Count - 1;

        CanGoToNextQuestion = value < Questions.Count - 1;
        CanGoToPrevQuestion = value > 0;

        CurrentQuestion = Questions[value];
        CurrentQuestionIndex = value;
    }

    [RelayCommand]
    void OnNextClicked()
    {
        var checkedAnwserIndex = CurrentQuestion.PossibleAnwsers.FindIndex(x => x.IsChecked);

        if (checkedAnwserIndex == -1) return;

        CurrentQuestionIndex++;
    }

    [RelayCommand]
    void OnPrevClicked()
    {
        CurrentQuestionIndex--;
    }
}
