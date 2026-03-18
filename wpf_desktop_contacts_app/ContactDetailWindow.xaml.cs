using DesktopContactsApp.Classes;
using SQLite;
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

namespace DesktopContactsApp
{
    /// <summary>
    /// ContactDetailWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ContactDetailWindow : Window
    {
        Contact contact;
        public ContactDetailWindow(Contact contact)
        {

            InitializeComponent();

            Owner = Application.Current.MainWindow; // 이 창의 부모 창을 MainWindow로 설정한다. 이렇게 하면 이 창이 MainWindow 위에 뜨고, MainWindow가 최소화되면 이 창도 최소화된다.
            WindowStartupLocation = WindowStartupLocation.CenterOwner; // 창이 열릴 때 부모 창의 중앙에 뜨도록 설정한다.

            this.contact = contact;
            nameTextBox.Text = contact.Name;
            emailTextBox.Text = contact.Email;
            phoneTextBox.Text = contact.Phone;

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            contact.Name = nameTextBox.Text;
            contact.Email = emailTextBox.Text;
            contact.Phone = phoneTextBox.Text;
            using (SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                conn.Update(contact);
            }

            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            using(SQLiteConnection conn = new SQLiteConnection(App.databasePath))
            {
                conn.CreateTable<Contact>();
                conn.Delete(contact);
            }

            Close();
        }
    }
}
