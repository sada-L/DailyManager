namespace DailyManager.Models;

public class Needs
{
    public int Id;
    public string Name;
    public int Degree;
    
    public Needs(int id, string name, int degree)
    {
        Id = id;
        Name = name;
        Degree = degree;
    }
}