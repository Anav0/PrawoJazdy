using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using PrawoJazdy.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrawoJazdy.Models;

public class Question
{
    public string QuestionAsked { get; set; }

    public int CorrectAnwserIndex { get; set; }
    public int? AnwserGivenIndex { get; set; }
    public Anwser AnwserGiven { get; set; }

    public List<Anwser> PossibleAnwsers { get; set; }

    public string ImagePath { get; set; }
    public MediaSource VideoPath { get; set; }

    public ResourceType ResourceType { get; set; }

    public int Points { get;set; }
    public string Name { get; internal set; }
    public string Number { get; internal set; }
    public string Scope { get; internal set; }
    public string Category { get; internal set; }
    public string BlockName { get; internal set; }
    public string Source { get; internal set; }
    public HashSet<string> Categories { get; internal set; }
    public MaterialRange Range { get; internal set; }
}
