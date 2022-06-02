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
    public class QuestionOption
    {
        public string question;
        public List<Option> option;
    }
    /// <summary>
    /// Логика взаимодействия для themePage.xaml
    /// </summary>
    public partial class themePage : Page
    {
        danil2Entities2 connection = new danil2Entities2();
        List<QuestionOption> questionOptions;
        int themeIndex = 0;
        public themePage()
        {
            InitializeComponent();
            SetTheme(1);
        }
        public void SetTheme(int themeID)
        {
            var option = connection.Option.Where(o => o.Theme == themeID).ToList();

            var questions = new Dictionary<int, string>();
            questionOptions = new List<QuestionOption>();

            foreach (var options in option)
            {
                questions[options.Question] = options.Question1.Question1;
            }

            foreach (var _questions in questions)
            {
                var optionTheme = connection.Option.Where(o => o.Theme == themeID && o.Question == _questions.Key).ToList();

                //Console.WriteLine("\nВОПРОС");
                //Console.WriteLine(_questions.Value);
                questionOptions.Add(new QuestionOption()
                {
                    question = _questions.Value,
                    option = optionTheme,
                });

                //Console.WriteLine("\nВАРИАНТЫ ОТВЕТОВ");
                //foreach (var _optionTheme in optionTheme)
                //{
                //    if (_optionTheme.OptionText.TrueFalse == "True")
                //    {
                //        Console.Write("X ");
                //    }
                //    Console.WriteLine(_optionTheme.OptionText.Answer);
                //}

                labelNameQuestion.Content = questionOptions[themeIndex].question;
                radioButton1.Content = questionOptions[themeIndex].option[0].OptionText.Answer;
                radioButton2.Content = questionOptions[themeIndex].option[1].OptionText.Answer;
                radioButton3.Content = questionOptions[themeIndex].option[2].OptionText.Answer;

            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)//ДАЛЕЕ
        {
            

            themeIndex++;
            labelNameQuestion.Content = questionOptions[themeIndex].question;
            radioButton1.Content = questionOptions[themeIndex].option[0].OptionText.Answer;
            radioButton2.Content = questionOptions[themeIndex].option[1].OptionText.Answer;
            radioButton3.Content = questionOptions[themeIndex].option[2].OptionText.Answer;



        }
    }
}
