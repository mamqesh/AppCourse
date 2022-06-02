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
            textBoxAddNameTheme.Text = "";
            listBoxSubject.SelectedIndex = -1;
            NavigationService.GoBack();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)//СОЗДАТЬ ТЕМУ С ВОПРОСАМИ
        {

            string theme = textBoxAddNameTheme.Text.Trim();
            string subject = listBoxSubject.SelectedItem.ToString();
            if (theme.Length == 0)
            {
                MessageBox.Show("Вы не ввели название темы");
                return;
            }
            else
            {
                if (listBoxSubject.SelectedItem==null)
                {
                    MessageBox.Show("Вы не выбрали предмет");
                    return;
                }
                else
                {
                    NavigationService.Navigate(MainWindow.pageAddQuestionsPage);
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)//ДОБАВИТЬ ПОЛЯ ДЛЯ ЗАПОЛНЕНИЯ 
        {
            
            string questionName = textBoxQuestion.Text.Trim();
            string option1 = textBoxOption1.Text.Trim();
            string option2 = textBoxOption2.Text.Trim();
            string option3 = textBoxOption3.Text.Trim();
            Database.Question question = new Database.Question();//НАЗВАНИЕ ВОПРОСА
            Database.OptionText optionText = new Database.OptionText();//ВАРИАНТЫ ОТВЕТА
            int countQuestions = connection.Question.ToList().Count();
            int countOption = connection.OptionText.ToList().Count();
            if (option1.Length > 0 || option2.Length > 0 || option3.Length > 0 || radioButton1 != null || radioButton2 != null || radioButton3 != null)
            {
                listBoxQuestions.Items.Add(textBoxQuestion.Text);
                if (radioButton1.IsChecked == true)
                {
                    optionText.IDOptionText = countOption + 1;
                    optionText.Answer = option1;
                    optionText.TrueFalse = "True";
                }
                else
                {
                    optionText.IDOptionText = countOption + 1;
                    optionText.Answer = option1;
                    optionText.TrueFalse = "False";
                }
                if (radioButton2.IsChecked == true)
                {
                    optionText.IDOptionText = countOption + 1;
                    optionText.Answer = option2;
                    optionText.TrueFalse = "True";
                }
                else
                {
                    optionText.IDOptionText = countOption + 1;
                    optionText.Answer = option2;
                    optionText.TrueFalse = "False";
                }
                if (radioButton3.IsChecked == true)
                {
                    optionText.IDOptionText = countOption + 1;
                    optionText.Answer = option3;
                    optionText.TrueFalse = "True";
                }
                else
                {
                    optionText.IDOptionText = countOption + 1;
                    optionText.Answer = option3;
                    optionText.TrueFalse = "False";
                }
            }
            else
            {
                MessageBox.Show("Данные введенны некорректно");
            }
            textBoxQuestion.Clear();
            textBoxOption1.Clear();
            textBoxOption2.Clear();
            textBoxOption3.Clear();
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            radioButton3.IsChecked = false;
        }
    }
}
