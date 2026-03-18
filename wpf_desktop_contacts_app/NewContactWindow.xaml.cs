using SQLite;
using DesktopContactsApp.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.Specialized;

namespace DesktopContactsApp
{
    /// <summary>
    /// NewContactWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow; // 이 창의 부모 창을 MainWindow로 설정한다. 이렇게 하면 이 창이 MainWindow 위에 뜨고, MainWindow가 최소화되면 이 창도 최소화된다.
            WindowStartupLocation = WindowStartupLocation.CenterOwner; // 창이 열릴 때 부모 창의 중앙에 뜨도록 설정한다.
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Contact contact = new Contact() { 
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };
            
            //SQLiteConnection connection = new SQLiteConnection(databasePath); // 지정한 경로의 DB 파일을 연다.
            //connection.CreateTable<Contact>(); // 이미 있다면 이 구문은 무시된다.
            //connection.Insert(contact); // 저장
            //connection.Close(); // 닫지 않으면 다른 곳에서 이 파일을 열 수 없다.

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Contact>(); // 이미 있다면 이 구문은 무시된다.
                var row = connection.Insert(contact); // 저장
                Console.Write(row.ToString());
            } // using 블록이 끝나면 자동으로 Close 호출

            Close();
        }
    }
}
