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
        }
        public void SetStudent(Student s)
        {
            student = s;
            labelRole.Content = s.StudentTicket;
            labelSurname.Content = s.Surname;
            labelName.Content = s.Name;
            labelPatronymic.Content = s.Patronymic;
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
        void ClearElements()
        {
            labelRole.Content = "";
            labelSurname.Content = "";
            labelName.Content = "";
            labelPatronymic.Content = "";
            listBoxSubject.SelectedIndex = -1;
        }
        void LoadSubject()
        {
            var subjects = connection.Subject.ToList();
            foreach (var _subject in subjects)
            {
                listBoxSubject.Items.Add(_subject);
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearElements();
            NavigationService.GoBack();
        }
        private void listBoxSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBoxTheme.SelectedIndex = -1;
            listBoxTheme.Items.Clear();
            var subject = listBoxSubject.SelectedItem as Database.Subject;
            if (subject != null)
            {
                if (subject.Theme.Count != 0)
                {
                    var theme = subject.Theme.ToList();
                    foreach (var themes in theme)
                    {
                        listBoxTheme.Items.Add(themes);
                    }
                }
            }
        }
        private void listBoxTheme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxTheme.SelectedIndex>=0)
            {
                if (MessageBox.Show("Вы действительно хотите пройти тестирование?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    NavigationService.Navigate(MainWindow.pageThemePage);
                    if (listBoxTheme.SelectedItem != null)
                    {
                        MainWindow.pageThemePage.SetTheme(((Theme)listBoxTheme.SelectedItem).ThemeID);
                    }
                }
                else
                {
                    listBoxTheme.SelectedIndex = -1;
                }
            }
        }
    }
}
