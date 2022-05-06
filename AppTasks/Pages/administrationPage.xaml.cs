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
    /// Логика взаимодействия для administrationPage.xaml
    /// </summary>
    public partial class administrationPage : Page
    {
        public Database.Teacher teacher { get; set; }
        public List <Database.Teacher> teachers { get; set; }
        public Database.Student student { get; set; }
        public List <Database.Student> students { get; set; }

        danil2Entities connection = new danil2Entities();
        public administrationPage()
        {
            InitializeComponent();
            LoadTeacher();
            LoadSex();
            teachers = connection.Teacher.ToList();
            students = connection.Student.ToList();
            DataContext = this;
        }
        void LoadTeacher()
        {
            var teachers = connection.Teacher.ToList();
            foreach (var teacher in teachers)
            {
                listBoxTeacher.Items.Add(teacher);
            }
        }
        void ClearTextBoxTeacher()
        {
            textBoxLoginTeacher.Clear();
            textBoxNameTeacher.Clear();
            textBoxPasswordTeacher.Clear();
            textBoxPatronymicTeacher.Clear();
            textBoxSurnameTeacher.Clear();
            comboBoxSexTeacher.Items.Clear();
        }
        void LoadUsersTeacher()
        {
            textBoxSurnameTeacher.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxNameTeacher.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxPatronymicTeacher.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxLoginTeacher.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxPasswordTeacher.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            var sex = comboBoxSexTeacher.GetBindingExpression(ComboBox.SelectedItemProperty);
            if (sex != null)
            {
                sex.UpdateTarget();
            }
        }
        void LoadSex()//НЕ РАБОТАЕТ
        {
            var sex = connection.Teacher.ToList();
            foreach (var _sex in sex)
            {
                comboBoxSexTeacher.Items.Add(_sex.Sex);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = connection.SaveChanges();
            if (result ==1)
            {
                MessageBox.Show("Данные успешно отредактированы!");
            }
        }

        private void listBoxTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            teacher = listBoxTeacher.SelectedItem as Database.Teacher;
            LoadUsersTeacher();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
