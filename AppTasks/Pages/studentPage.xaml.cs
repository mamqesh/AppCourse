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
    /// Логика взаимодействия для studentPage.xaml
    /// </summary>
    public partial class studentPage : Page
    {
        public static Database.Student student;
        danil2Entities2 connection = new danil2Entities2();
        public studentPage()
        {
            InitializeComponent();
            LoadSubject();
            //LoadUser();
        }

        public void SetStudent(Student s)
        {
            student = s;
            labelRole.Content = s.StudentTicket;
            labelSurname.Content = s.Surname;
            labelName.Content = s.Name;
            labelPatronymic.Content = s.Patronymic;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("girl.png");
            image.EndInit();
            imageWindow.Source = image;
        }
        
        void ClearElements()
        {
            labelRole.Content = "";
            labelSurname.Content = "";
            labelName.Content = "";
            labelPatronymic.Content = "";
            listBoxLesson.SelectedIndex=-1;
        }
        void LoadSubject()
        {
            var subjects = connection.Subject.ToList();
            foreach (var _subject in subjects)
            {
                listBoxLesson.Items.Add(_subject);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearElements();
            NavigationService.GoBack();
        }

        private void listBoxLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
