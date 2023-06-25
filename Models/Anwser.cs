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
