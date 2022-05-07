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

namespace AppTasks
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Pages.mainPage pageMainPage;
        public static Pages.studentPage pageStudentPage;
        public static Pages.teacherPage pageTeacherPage;
        public static Pages.administrationPage pageAdministrationPage;
        public static MainWindow Instance;
        public MainWindow()
        {
            
            InitializeComponent();
            Instance = this;
            pageTeacherPage = new Pages.teacherPage();
            pageMainPage = new Pages.mainPage();
            pageStudentPage = new Pages.studentPage();
            pageAdministrationPage = new Pages.administrationPage();
            //MainFrame.Navigate(pageMainPage);
            MainFrame.Navigate(pageStudentPage);
        }
    }
}
