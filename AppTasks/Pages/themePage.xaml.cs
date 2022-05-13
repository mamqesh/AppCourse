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
            foreach (var options in option)
            {
                
            }

        }
    }
}
