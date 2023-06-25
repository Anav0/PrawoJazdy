using CommunityToolkit.Maui.Views;
using PrawoJazdy.Enums;
using PrawoJazdy.Models;
using PrawoJazdy.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PrawoJazdy.Pages;

public partial class QuizPage : ContentPage
{
    public QuizPage(QuizViewModel vm)
    {
        Application excel = new Application();

        var lines = File.ReadAllLines("d:\\Projects\\PrawoJazdy\\Resources\\Raw\\pytania.csv");

        var headers = lines[0].Split(";");

        var questions = new List<Question>();

        var linesSkipped = new List<string[]>();
        for (int i = 1; i < lines.Length; i++)
        {
            var values = lines[i].Split(";");

            if (values.Length != 33)
            {
                linesSkipped.Add(values);
                continue;
            }

            var isYesOrNoQuestion = values[3] == "";
            var possibleAnwsers = new List<Anwser>();
            var correctAnwserIndex = -1;
            var resourceName = values[15];

            if (isYesOrNoQuestion)
            {
                possibleAnwsers.Add(new Anwser("Tak", 0));
                possibleAnwsers.Add(new Anwser("Nie", 1));
                correctAnwserIndex = values[14] == "T" ? 0 : 1;
            }
            else
            {
                possibleAnwsers.Add(new Anwser(values[3], 0));
                possibleAnwsers.Add(new Anwser(values[4], 1));
                possibleAnwsers.Add(new Anwser(values[5], 2));
                var correctAnwser = values[14];
                correctAnwserIndex = possibleAnwsers.FindIndex(x => x.Label == correctAnwser);
            }

            var question = new Question()
            {
                Name = values[0],
                Number = values[1],
                QuestionAsked = values[2],
                PossibleAnwsers = possibleAnwsers,
                CorrectAnwserIndex = correctAnwserIndex,
                Scope = values[16],
                Points = int.Parse(values[17]),
                Categories = new HashSet<string>(values[18].Split(",")),
                BlockName = values[19],
                Source = values[20],
                Range = values[16] == "PODSTAWOWY" ? MaterialRange.Base : MaterialRange.Specialist,
            };

            question.ResourceType = resourceName.EndsWith(".wmv") ? ResourceType.Video : ResourceType.Image;

            if (question.ResourceType == ResourceType.Image)
                question.ImagePath = $"Obrazy/{values[15]}";
            else
                question.VideoPath = MediaSource.FromFile($"Filmy/{values[15]}");

            questions.Add(question);
        }

        var selectedCategoryStr = vm.LicenseCategory == LicenseCategory.A ? "A" : "B";

        var relevanteQuestions = questions.FindAll(q => q.Categories.Contains(selectedCategoryStr));

        var examQuestions = PickExamQuestions(relevanteQuestions);

        vm.Questions = new ObservableCollection<Question>(examQuestions);
        vm.CurrentQuestionIndex = 0;
        vm.CurrentQuestion = vm.Questions[0];
        vm.CanGoToNextQuestion = true;
        vm.CanGoToPrevQuestion = false;

        InitializeComponent();

        BindingContext = vm;
    }

    private IEnumerable<Question> PickExamQuestions(List<Question> relevanteQuestions)
    {
        //Sekcja podstawowa
        // 10 za 3
        // 6 za 2
        // 4 za 1

        //Sekcja specjalistyczna
        // 6 za 3
        // 4 za 2
        // 2 za 1

        //Aby zdać 68pkt

        var random = new Random();

        var pickedQuestions = new List<Question>();

        var specialistRange = relevanteQuestions.FindAll(q => q.Range == MaterialRange.Specialist).OrderBy(x => random.Next()).ToList();
        var baseRange = relevanteQuestions.FindAll(q => q.Range == MaterialRange.Base).OrderBy(x => random.Next()).ToList();

        var howManyOfEachTypeForBase = new Dictionary<int, int>()
        {
            {10, 3},
            {6, 2},
            {4, 1},
        };

        var howManyOfEachTypeForSpecialits = new Dictionary<int, int>()
        {
            {6, 3},
            {4, 2},
            {2, 1},
        };

        List<Question> finalQuestions = new();
        foreach (var pair in howManyOfEachTypeForBase)
        {
            var questionsWithGivenNumberOfPoints = baseRange.FindAll(x => x.Points == pair.Value);
            finalQuestions.AddRange(questionsWithGivenNumberOfPoints.Take(pair.Key));
        }


        foreach (var pair in howManyOfEachTypeForSpecialits)
        {
            var questionsWithGivenNumberOfPoints = baseRange.FindAll(x => x.Points == pair.Value);
            finalQuestions.AddRange(questionsWithGivenNumberOfPoints.Take(pair.Key));
        }

        var total = finalQuestions.Sum(q => q.Points);

        if (total != 74) throw new Exception("Number of points is not equal 74!");

        return relevanteQuestions;
    }
}