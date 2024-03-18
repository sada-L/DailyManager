using System;

namespace DailyManager.Models;

public class Time
{
   public int Id;
   public string Name;
   public TimeSpan Count;
   
   public Time(int id, string name, TimeSpan count)
   {
      Id = id;
      Name = name;
      Count = count;
   }
}