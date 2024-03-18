using System;
using System.Collections.Generic;

namespace DailyManager.Models;

public class DataSetCus
{
    public List<Needs> Needes = 
    [
        new Needs(0,"Я хочу", 5),
        new Needs(1,"Мне надо", 7),
        new Needs(2,"Я должен", 10),
    ];
    
    public List<Action> Actions = 
    [
        new Action(0,"выпить энергос", "потратить время: ~20 мин.\nпотратить деньги: от 60 до 120 руб.", "эффекст бодрости", "тревожность, бессоница", new TimeSpan(0,20,0)),
        new Action(1,"спать", "потратить время: ~8 часов.", "эффекст бодрости, хорошее самочувствие", "?боль в мышцах", new TimeSpan(8,0,0)),
        new Action(2,"читать", "потратить время: ~2 час.", "досуг, новые знания", "?боль в мышцах, усталость", new TimeSpan(2,0,0)),
    ];
    
    public List<Time> Times = 
    [
        new Time(0,"сейчас", new TimeSpan(0,0,0)),
        new Time(1,"через час", new TimeSpan(1,0,0)),
        new Time(2,"через полдня", new TimeSpan(12,0,0)),
        new Time(3,"сегодня", new TimeSpan(0,0,0)),
        new Time(4,"c утра", new TimeSpan(0,0,0)),
        new Time(5,"до ночи", new TimeSpan(0,0,0)),
        new Time(6,"вечером", new TimeSpan(18,0,0)),
        new Time(7,"ночью", new TimeSpan(0,0,0)),
    ];
}