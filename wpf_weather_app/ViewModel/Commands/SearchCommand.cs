using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WeatherApp.ViewModel.Commands
{
    public class SearchCommand : ICommand // ICommand를 작성하면 인터페이스 구현 버튼을 누르면 기본 인터페이스들이 알아서 구현된다.
    {
        public WeatherVM VM { get; set; }

        public SearchCommand(WeatherVM vm)
        {
            VM = vm;
        }

        public event EventHandler? CanExecuteChanged
        {
            // 사용자가 키보드를 치거나 마우스를 클릭하는 등 UI에 변화가 생기면 
            // 모든 버튼의 CanExecute를 강제로 다시 실행하게 만듭니다.
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object? parameter) // CanExecute 메서드는 명령이 현재 실행 가능한지 여부를 결정하는 메서드입니다. 예를 들어, 사용자가 입력한 데이터가 유효한지 확인하거나, 특정 조건이 충족되었는지 등을 검사할 수 있습니다.
        {
            return !string.IsNullOrEmpty(VM.Lat) && !string.IsNullOrEmpty(VM.Lon);
        }

        public void Execute(object? parameter) // Execute 메서드는 명령이 실행될 때 호출되는 메서드입니다. 이 메서드에는 명령이 수행해야 하는 작업을 구현합니다. 예를 들어, 사용자가 버튼을 클릭했을 때 데이터를 검색하거나, 다른 창을 열거나, 특정 로직을 실행하는 등의 작업을 수행할 수 있습니다.
        {
            VM.MakeWeatherData(); // WeatherVM의 MakeWeatherData 메서드를 호출하여 날씨 데이터를 가져오는 작업을 수행합니다.
        }
    }
}
