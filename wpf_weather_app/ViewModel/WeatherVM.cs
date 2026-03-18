using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Windows.Input;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;
using static WeatherApp.Model.WeatherModel;

namespace WeatherApp.ViewModel
{
    public class WeatherVM : INotifyPropertyChanged
    {
        private string lat = "37.56"; // 기본값 (서울 위도)
        private string lon = "126.97"; // 기본값 (서울 경도)

        public string Lat
        {
            get => lat;
            set
            {
                lat = value;
                OnPropertyChanged(nameof(Lat));
            }
        }

        public string Lon
        {
            get => lon;
            set
            {
                lon = value;
                OnPropertyChanged(nameof(Lon));
            }
        }

        private Root root;

        public  Root Root
        {
            get { return root; }
            set 
            { 
                root = value;
                OnPropertyChanged(nameof(Root));
            }
        }

        public ObservableCollection<Root> HistoryList { get; set; } = new ObservableCollection<Root>();

        public WeatherVM()
        {
            searchCommand = new SearchCommand(this);
            clearHistoryCommand = new ClearHistoryCommand(this);
        }

        public SearchCommand searchCommand { get; set; }
        public ClearHistoryCommand clearHistoryCommand { get; set; }

        public async void MakeWeatherData()
        {
            System.Diagnostics.Debug.WriteLine($"조회 시작: {Lat}, {Lon}");

            var weather = await OpenWeatherHelper.GetWeather(double.Parse(Lat), double.Parse(Lon));

            if (weather != null)
            {
                Root = weather;
                System.Diagnostics.Debug.WriteLine($"도시 이름: {Root.name}");
                // HistoryList.Add(Root); 밑에 삽입
                HistoryList.Insert(0, Root); // 최신 조회 결과를 맨 앞에 추가
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
