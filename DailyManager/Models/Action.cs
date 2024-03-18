using System;

namespace DailyManager.Models;

public class Action
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Request { get; set; }
    public string EffectsPos { get; set; }
    public string EffectsNeg { get; set; }
    public TimeSpan Time { get; set; }
    public Action(int id, string name, string request, string effectsPos, string effectsNeg, TimeSpan time)
    {
        Id = id;
        Name = name;
        Request = request;
        EffectsPos = effectsPos;
        EffectsNeg = effectsNeg;
        Time = time;
    }
}