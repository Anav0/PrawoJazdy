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

    [ObservableProperty]
    public string progressLabel;

    [ObservableProperty]
    public string timerLabel = "10:00";

    [ObservableProperty]
    public string statusLabel;

    [ObservableProperty]
    public string modeLabel;

    [ObservableProperty]
    public string nextBtnLabel = "Sprawdź";

    public bool wasNextBtnClick = false;

    partial void OnCurrentQuestionIndexChanged(int value)
    {
        if (value < 0) value = 0;
        if (value >= Questions.Count) value = Questions.Count - 1;

        CanGoToNextQuestion = value < Questions.Count - 1;
        CanGoToPrevQuestion = value > 0;

        UpdateProgressLabel(value);

        CurrentQuestion = Questions[value];
        CurrentQuestionIndex = value;
    }

    public void UpdateProgressLabel(int newIndex)
    {
        ProgressLabel = $"{newIndex + 1}/{Questions.Count}";

    }

    [RelayCommand]
    void OnNextClicked()
    {
        if (CurrentQuestion.AnwserGivenIndex == null) return;

        if (Mode == Mode.Traning && !wasNextBtnClick)
        {
            wasNextBtnClick = true;
            NextBtnLabel = "Dalej";
            return;
        }
        else
        {
            wasNextBtnClick = true;
        }

        CurrentQuestionIndex++;
    }

    [RelayCommand]
    void OnPrevClicked()
    {
        CurrentQuestionIndex--;
    }
}
