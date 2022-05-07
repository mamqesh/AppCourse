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
        public List <Database.Sex> sexes { get; set; }



        danil2Entities2 connection = new danil2Entities2();
        public administrationPage()
        {
            InitializeComponent();
            LoadTeacher();
            LoadSex();
            LoadStudent();
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
        void LoadStudent()
        {
            var students = connection.Student.ToList();
            foreach (var student in students)
            {
                listBoxStudent.Items.Add(student);
            }
        }
        void ClearTextBox()
        {
            textBoxLoginTeacher.Clear();
            textBoxNameTeacher.Clear();
            textBoxPasswordTeacher.Clear();
            textBoxPatronymicTeacher.Clear();
            textBoxSurnameTeacher.Clear();
            comboBoxSexTeacher.SelectedIndex = -1;

            textBoxGroupStudent.Clear();
            textBoxLoginStudent.Clear();
            textBoxSurnameStudent.Clear();
            textBoxPatronymicStudent.Clear();
            textBoxNameStudent.Clear();
            textBoxPasswordStudent.Clear();
            textBoxSpecialityStudent.Clear();
            comboBoxSexStudent.SelectedIndex = -1;
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
        void LoadUsersStudent()
        {
            textBoxSurnameStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxNameStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxPatronymicStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxLoginStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxPasswordStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxGroupStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            var sex = comboBoxSexStudent.GetBindingExpression(ComboBox.SelectedItemProperty);
            if (sex != null)
            {
                sex.UpdateTarget();
            }
        }
        void LoadSex()
        {
            sexes = connection.Sex.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = connection.SaveChanges();
            if (result ==1)
            {
                MessageBox.Show("Данные успешно отредактированы!");
            }
        }
        private void listBoxTeacher_SelectionChanged(object sender, SelectionChangedEventArgs e)//КЛИК ПО ПРЕПОДАВАТЕЛЮ
        {
            teacher = listBoxTeacher.SelectedItem as Database.Teacher;
            LoadUsersTeacher();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClearTextBox();
            NavigationService.GoBack();
        }

        private void listBoxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)//КЛИК ПО СТУДЕНТУ
        {
            student = listBoxStudent.SelectedItem as Database.Student;
            LoadUsersStudent();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string surname = textBoxCreateSurnameStudent.Text.Trim();
            string name = textBoxCreateNameStudent.Text.Trim();
            string patronymic = textBoxCreatePatronymicStudent.Text.Trim();
            string group = textBoxCreateGroupStudent.Text.Trim();
            string login = textBoxCreateStudentTicketStudent.Text.Trim();
            string password = textBoxCreatePasswordStudent.Text.Trim();
            //group,sex

        }
    }
}
