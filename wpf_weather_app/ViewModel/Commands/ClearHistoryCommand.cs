using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class ClearHistoryCommand : ICommand
    {
        public WeatherVM VM { get; set; }
        public ClearHistoryCommand(WeatherVM vm)
        {
            VM = vm;
        }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object? parameter)
        {
            return VM.HistoryList.Count > 0;
        }
        public void Execute(object? parameter)
        {
            VM.HistoryList.Clear();
        }
    }
}
