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

namespace AppTasks.Pages
{
    /// <summary>
    /// Логика взаимодействия для endTestPage.xaml
    /// </summary>
    public partial class endTestPage : Page
    {
        public endTestPage()
        {
            InitializeComponent();
        }
        public void SetTrueFalseQuestion(int trueQuestion, int falseQuestion)
        {
            labelTrueQuestion.Content = trueQuestion.ToString();
            labelFalseQuestion.Content = falseQuestion.ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите перейти на главную страницу?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning)==MessageBoxResult.Yes)
            {
                NavigationService.Navigate(MainWindow.pageStudentPage);
            }
            else
            {
                return;
            }
        }
    }
}
