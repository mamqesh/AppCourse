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
        
        danil2Entities connection = new danil2Entities();
        public mainPage()
        {
            InitializeComponent();
#if DEBUG
            textBoxLogin.Text = "admin";
            passwordBoxPassword.Password = "adminboss";
#endif
        }
        void ClearElements()
        {
            textBoxLogin.Clear();
            passwordBoxPassword.Clear();
        }
        private void Button_Click(object sender, RoutedEventArgs e) //ВХОД
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBoxPassword.Password.Trim();
            var student = connection.Student.ToList();
            var teacher = connection.Teacher.ToList();
            var admin = connection.Admininstrator.ToList();
            int tryExit = 0;
            foreach (var _student in student)
            {
                if (login == _student.StudentTicket.ToString())
                {
                    if (password==_student.Password)
                    {
                        ClearElements();
                        NavigationService.Navigate(MainWindow.pageStudentPage);
                        tryExit++;
                        return;
                    }
                }
            }
            foreach (var _teacher in teacher)
            {
                if (login==_teacher.PersonnelNumber.ToString())
                {
                    if (password==_teacher.Password)
                    {
                        ClearElements();
                        NavigationService.Navigate(MainWindow.pageTeacherPage);
                        tryExit++;
                        return;
                    }
                }
            }
            foreach (var _admin in admin)
            {
                if (login==_admin.NameAdmininstrator)
                {
                    if (password==_admin.Password)
                    {
                        ClearElements();
                        NavigationService.Navigate(MainWindow.pageAdministrationPage);
                        return;
                    }
                }
            }
            if (tryExit==0)
            {
                MessageBox.Show("Данные введены некорректно");
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//ВЫХОД
        {
            MainWindow.Instance.Close();
        }
    }
}
