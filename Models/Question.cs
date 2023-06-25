using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using PrawoJazdy.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrawoJazdy.Models;

public class Question
{
    public string QuestionAsked { get; set; }

    public int CorrectAnwserIndex { get; set; }

    public List<Anwser> PossibleAnwsers { get; set; }

    public string ImagePath { get; set; }
    public MediaSource VideoPath { get; set; }

    public ResourceType ResourceType { get; set; }
}
