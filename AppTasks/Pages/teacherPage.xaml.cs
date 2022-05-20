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
    /// Логика взаимодействия для teacherPage.xaml
    /// </summary>
    public partial class teacherPage : Page
    {
        danil2Entities2 connection = new danil2Entities2();
        public static Database.Teacher teacher;
        public static Database.Role role { get; set; }
        public static List<Database.Teacher> teachers { get; set; }
        public teacherPage()
        {
            InitializeComponent();
            DataContext = this;
        }
        public void SetTeacher(Teacher s)
        {
            teacher = s;
            labelPersonnelNumber.Content = s.PersonnelNumber;
            labelSurname.Content = s.Surname;
            labelName.Content = s.Name;
            labelPatronymic.Content = s.Patronymic;
            labelRole.Content = s.Role1.RoleName;
            if (s.Sex == 2)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("../girl.png", UriKind.Relative);
                image.EndInit();
                imageWindow.Source = image;
            }
            else
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri("../man.png", UriKind.Relative);
                image.EndInit();
                imageWindow.Source = image;
            }

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(MainWindow.pageAddTestPage);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
