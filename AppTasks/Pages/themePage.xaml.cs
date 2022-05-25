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
    /// Логика взаимодействия для themePage.xaml
    /// </summary>
    public partial class themePage : Page
    {
        danil2Entities2 connection = new danil2Entities2();
        public themePage()
        {
            InitializeComponent();
        }
        public void SetTheme(int themeID)
        {
            var option = connection.Option.Where(o => o.Theme == themeID).ToList();

            var q = new Dictionary<int, string>();

            foreach (var options in option)
            {
                q[options.Question] = options.Question1.Question1;
            }

            foreach (var question in q) 
            { 
                var a = connection.Option.Where(o => o.Theme == themeID && o.Question == question.Key).ToList();

                Console.WriteLine("\nВОПРОС");
                Console.WriteLine(question.Value);

                Console.WriteLine("\nВАРИАНТЫ ОТВЕТОВ");
                foreach (var b in a)
                {
                    if (b.OptionText.TrueFalse == "True")
                    {
                        Console.Write("X ");
                    }

                    Console.WriteLine(b.OptionText.Answer);
                }
            }
            //radio button
        }
    }
}
