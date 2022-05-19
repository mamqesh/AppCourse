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
    /// Логика взаимодействия для addTestPage.xaml
    /// </summary>
    public partial class addTestPage : Page
    {
        danil2Entities2 connection = new danil2Entities2();
        public addTestPage()
        {
            InitializeComponent();
            LoadSubject();
            DataContext = this;
        }
        void LoadSubject()
        {
            var subjects = connection.Subject.ToList();
            foreach (var _subject in subjects)
            {
                listBoxSubject.Items.Add(_subject);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//НАЗАД
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//СОЗДАТЬ ТЕМУ С ВОПРОСАМИ
        {

        }
    }
}
