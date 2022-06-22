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

namespace AppTasks
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        danil2Entities2 connection = new danil2Entities2();
        public static Pages.mainPage pageMainPage;
        public static Pages.studentPage pageStudentPage;
        public static Pages.teacherPage pageTeacherPage;
        public static Pages.administrationPage pageAdministrationPage;
        public static Pages.themePage pageThemePage;
        public static Pages.addTestPage pageAddTestPage;
        public static Pages.registrationAdmininstration pageRegistrationAdmininstrator;
        public static Pages.endTestPage pageEndTestPage;
        public static MainWindow Instance;
        public MainWindow()
        {
            
            InitializeComponent();
            Instance = this;
            pageTeacherPage = new Pages.teacherPage();
            pageMainPage = new Pages.mainPage();
            pageStudentPage = new Pages.studentPage();
            pageAdministrationPage = new Pages.administrationPage();
            pageThemePage = new Pages.themePage();
            pageAddTestPage = new Pages.addTestPage();
            pageRegistrationAdmininstrator = new Pages.registrationAdmininstration();
            pageEndTestPage = new Pages.endTestPage();
            var admin = connection.Admininstrator.ToList().Count();
            if (admin == 0)
            {
                string messageBoxText = "Не найден пользователь Администратор. Для полного использования " +
                   "функционала приложения нужно создать Администратора. Создать его?";
                string caption = "Проверка наличия администратора";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        MainFrame.NavigationService.Navigate(pageRegistrationAdmininstrator);
                        break;
                    case MessageBoxResult.No:
                        MainFrame.NavigationService.Navigate(pageMainPage);
                        break;
                }
            }
            else
            {
                MainFrame.Navigate(pageMainPage);
            }
        }
    }
}
