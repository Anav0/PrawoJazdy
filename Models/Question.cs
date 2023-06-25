using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrawoJazdy.Models;

public class Anwser
{
    public Anwser(string label, int value)
    {
        Label = label;
        Value = value;
    }

    public string Label { get; set; }
    public int Value { get; set; }
    public bool IsChecked { get; set; }
}

public class Question
{
    public string QuestionAsked { get; set; }

    public int CorrectAnwserIndex { get; set; }

    public List<Anwser> PossibleAnwsers { get; set; }
    
    public string ResourcePath { get; set; }
}
