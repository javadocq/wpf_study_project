using SQLite;
using System;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DesktopContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Contacts.db";
        static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // 윈도우의 '내 문서' 폴더 경로를 자동으로 찾아준다.
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName); // C:\Users\이름\Documents\Contacts.db와 같은 전체 주소를 만든다.
    }

}
