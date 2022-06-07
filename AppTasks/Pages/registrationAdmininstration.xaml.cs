using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppTasks.Database;

namespace AppTasks.Pages
{
    /// <summary>
    /// Логика взаимодействия для registrationAdmininstration.xaml
    /// </summary>
    public partial class registrationAdmininstration : Page
    {
        danil2Entities2 connection = new danil2Entities2();   
        public registrationAdmininstration()
        {
            InitializeComponent();
        }

        void ClearTextBox()
        {
            textBoxAdmLogin.Clear();
            textBoxAdmRepeatLogin.Clear();
            textBoxAdmPassword.Clear();
            textBoxAdmRepeatPassword.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            MainWindow.Instance.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxAdmLogin.Text.Length > 0 && textBoxAdmRepeatLogin.Text.Length >0 && textBoxAdmPassword.Text.Length>0 && textBoxAdmRepeatPassword.Text.Length>0)
            {
                if (textBoxAdmLogin.Text==textBoxAdmRepeatLogin.Text)
                {
                    if (textBoxAdmPassword.Text==textBoxAdmRepeatPassword.Text)
                    {
                        string login = textBoxAdmLogin.Text.Trim();
                        string password = textBoxAdmPassword.Text.Trim();
                        Database.Admininstrator admininstrator = new Database.Admininstrator();
                        admininstrator.NameAdmininstrator = login;
                        admininstrator.Password = password;
                        connection.Admininstrator.Add(admininstrator);
                        int result= connection.SaveChanges();
                        if (result>0)
                        {
                            NavigationService.Navigate(MainWindow.pageAdministrationPage);
                            MessageBox.Show("Администратор успешно зарегестрирован\nЛогин: "+login+"\nПароль: "+password);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Логин не совпадает");
                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
