using PrawoJazdy.Models;
using PrawoJazdy.ViewModels;

namespace PrawoJazdy.Pages;

public partial class QuizPage : ContentPage
{
    public QuizPage(QuizViewModel vm)
    {
        vm.Questions.Add(new Question()
        {
            QuestionAsked = "Ma mały ogon 1",
            CorrectAnwserIndex = 0,
            PossibleAnwsers = new List<Anwser>()
            {
                new Anwser("Kot",0),
                new Anwser("Pies",1),
                new Anwser("Mysz",2),
            }
        });

        vm.Questions.Add(new Question()
        {
            QuestionAsked = "Ma mały ogon 2",
            CorrectAnwserIndex = 2,
            PossibleAnwsers = new List<Anwser>()
            {
                new Anwser("Kotek",0),
                new Anwser("Piesek",1),
                new Anwser("Myszek",2),
            }
        });

        vm.CurrentQuestionIndex = 0;
        vm.CurrentQuestion = vm.Questions[0];
        vm.CanGoToNextQuestion = true;
        vm.CanGoToPrevQuestion = false;

        InitializeComponent();

        BindingContext = vm;
    }
}