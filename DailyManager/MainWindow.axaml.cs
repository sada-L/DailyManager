using System;
using System.Linq;
using Avalonia.Controls;
using DailyManager.Models;
using Action = DailyManager.Models.Action;

namespace DailyManager;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        ComboBoxNeeds.ItemsSource = Helper.DataSet.Needes.Select(x => new {x.Name}); 
        ComboBoxActions.ItemsSource =  Helper.DataSet.Actions.Select(x => new {x.Name}); 
        ComboBoxTime.ItemsSource =  Helper.DataSet.Times.Select(x => new {x.Name});
        
        ComboBoxNeeds.SelectedIndex = 0;
        ComboBoxActions.SelectedIndex = 0;
        ComboBoxTime.SelectedIndex = 0;
        
        ComboBoxNeeds.SelectionChanged += ComboBoxNeedsOnSelectionChanged;
        ComboBoxActions.SelectionChanged += ComboBoxActionsOnSelectionChanged;
        ComboBoxTime.SelectionChanged += ComboBoxTimeOnSelectionChanged;
    }

    private void ComboBoxTimeOnSelectionChanged(object? sender, SelectionChangedEventArgs e) => Load();
    
    private void ComboBoxActionsOnSelectionChanged(object? sender, SelectionChangedEventArgs e) => Load();
    
    private void ComboBoxNeedsOnSelectionChanged(object? sender, SelectionChangedEventArgs e) => Load();
    
    private void Load()
    {
        
        Needs need = Helper.DataSet.Needes.Find(x => x.Id == ComboBoxNeeds.SelectedIndex)!;
        Action action = Helper.DataSet.Actions.Find(x => x.Id == ComboBoxActions.SelectedIndex)!;
        Time time = Helper.DataSet.Times.Find(x => x.Id == ComboBoxTime.SelectedIndex)!;
        
        TextBlockOutPut.Text = $"Вам надо:" +
                               $"\n{action.Request}" +
                               $"\nВы получите:" +
                               $"\n+:{action.EffectsPos}" +
                               $"\n-:{action.EffectsNeg}" +
                               $"\nВы должны это сделать до: {TimeCount(time,action)}";
        NeedDegree(need);
    }

    private string TimeCount(Time time,Action action)
    {
        TimeSpan now = DateTime.Now.TimeOfDay;
        TimeSpan notToday = new TimeSpan(22, 0, 0);
        TimeSpan nextDay = new TimeSpan(6, 0, 0);
        TimeSpan workDay = notToday - nextDay;
        TimeSpan notWorkDay = new TimeSpan(24, 0, 0) - notToday + nextDay;
        string lastTime = time.Id switch
        {
            0 => @$"{now + action.Time + time.Count:hh\:mm}",
            1 => @$"{now + action.Time + time.Count:hh\:mm}",
            2 => @$"{now + action.Time + time.Count:hh\:mm}",
            3 => now + action.Time < notToday && now + time.Count + action.Time > nextDay ? @$"{notToday:hh\:mm}": "Не успели",
            4 => nextDay + action.Time < notToday ? @$"{action.Time + nextDay:hh\:mm}": @$"За день не успеть, продолжите на следующий день и закончите до: {nextDay + (workDay - action.Time):hh\:mm}",
            5 => now + action.Time < notToday ? @$"{notToday:hh\:mm}": "Не успели",
            6 => time.Count + action.Time < notToday ? @$"{time.Count + action.Time:hh\:mm}": "Не успеть",
            7 => action.Time <= notWorkDay ? @$"{nextDay:hh\:mm}": "Не успеть",
            _ => ""
        };
        return lastTime;
    }

    private void NeedDegree(Needs needs)
    {
        string ans = needs.Degree switch
        {
            5 => "Вы точно этого хотите?",
            7 => "Вам надо это сделать",
            10 => "Вам небходимо это сделать прямо сейчас!",
            _ => ""
        };
        TextBlockOut.Text = ans;
    }
}