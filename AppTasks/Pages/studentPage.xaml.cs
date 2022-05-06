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
        danil2Entities connection = new danil2Entities();
        public studentPage()
        {
            InitializeComponent();
            LoadSubject();
        }
        void LoadSubject()
        {
            var subjects = connection.Subject.ToList();
            foreach (var _subject in subjects)
            {
                listBoxLesson.Items.Add(_subject);
            }
        }
        void LoadUser()
        {

        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void listBoxLesson_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
