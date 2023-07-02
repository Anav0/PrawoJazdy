namespace PrawoJazdy.Models;

public class Anwser
{
    public Anwser(string label, int value)
    {
        Text = label;
        Value = value;
    }

    public string Text { get; set; }
    public int Value { get; set; }
}
