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
    /// Логика взаимодействия для mainPage.xaml
    /// </summary>
    public partial class mainPage : Page
    {

        danil2Entities2 connection = new danil2Entities2();
        public mainPage()
        {
            InitializeComponent();
#if DEBUG
            textBoxLogin.Text = "1163";
            passwordBoxPassword.Password = "qwerty123";
#endif
        }
        void ClearElements()
        {
            textBoxLogin.Clear();
            passwordBoxPassword.Clear();
        }
        private void Button_Click(object sender, RoutedEventArgs e) //ВХОД
        {
            try
            {
                int tryExit = 0;
                int login = int.Parse(textBoxLogin.Text.Trim());
                string password = passwordBoxPassword.Password.Trim();
                var student = connection.Student.Where(s => s.StudentTicket == login && s.Password == password).FirstOrDefault();

                if (student != null)
                {
                    ClearElements();
                    MainWindow.pageStudentPage.SetStudent(student);
                    NavigationService.Navigate(MainWindow.pageStudentPage);
                    tryExit++;
                    return;
                }
                var teacher = connection.Teacher.Where(t => t.PersonnelNumber == login && t.Password == password).FirstOrDefault();
                if (teacher != null)
                {
                    ClearElements();
                    MainWindow.pageTeacherPage.SetTeacher(teacher);
                    MainWindow.pageAddTestPage.Teacher(teacher);
                    NavigationService.Navigate(MainWindow.pageTeacherPage);
                    tryExit++;
                    return;
                }
            }
            catch (Exception)
            {
                int tryExit = 0;
                string login = textBoxLogin.Text.Trim();
                string password = passwordBoxPassword.Password.Trim();
                var admin = connection.Admininstrator.Where(a => a.NameAdmininstrator == login.ToString() && a.Password == password).FirstOrDefault();
                if (admin != null)
                {
                    ClearElements();
                    NavigationService.Navigate(MainWindow.pageAdministrationPage);
                    return;
                }
                if (tryExit == 0)
                {
                    MessageBox.Show("Данные введены некорректно");
                }
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)//ВЫХОД
        {
            MainWindow.Instance.Close();
        }
    }
}
