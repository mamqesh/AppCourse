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
using System.Data.Entity;
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
        public List <Database.Group> groups { get; set; }
        danil2Entities2 connection = new danil2Entities2();
        public administrationPage()
        {
            InitializeComponent();
            LoadSex();
            teachers = connection.Teacher.ToList();
            students = connection.Student.ToList();
            DataContext = this;
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
            comboBoxSexTeacher.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateTarget();
            listBoxTeacher.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
        }
        void LoadUsersStudent()
        {
            textBoxSurnameStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxNameStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxPatronymicStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxLoginStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxPasswordStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxGroupStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            textBoxSpecialityStudent.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
            comboBoxSexStudent.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateTarget();
            listBoxStudent.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
        }
        void LoadSex()
        {
            sexes = connection.Sex.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)//ПРИМЕНИТЬ РЕДАКТИРОВАНИЕ
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
        private void Button_Click_1(object sender, RoutedEventArgs e)//КНОПКА ВЫХОД
        {
            ClearTextBox();
            NavigationService.GoBack();
        }
        private void listBoxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)//КЛИК ПО СТУДЕНТУ
        {
            student = listBoxStudent.SelectedItem as Database.Student;
            LoadUsersStudent();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) //ЗАРЕГИСТРИРОВАТЬ СТУДЕНТА
        {   
            string surname = textBoxCreateSurnameStudent.Text.Trim();
            string name = textBoxCreateNameStudent.Text.Trim();
            string patronymic = textBoxCreatePatronymicStudent.Text.Trim();
            string login = textBoxCreateStudentTicketStudent.Text.Trim();
            //string password = textBoxCreatePasswordStudent.Text.Trim();
            //string sex = comboBoxSexStudent.SelectedItem.ToString();
            //string speciality = comboBoxCreateSpecialityStudent.SelectedItem.ToString();
            // group auto
            void ClearTextBox()
            {
                surname = "";
                name = "";
                patronymic = "";
                login = "";
                //password = "";
                //sex="";
                //speciality="";
                textBoxCreateSurnameStudent.Clear();
                textBoxCreateNameStudent.Clear();
                textBoxCreatePatronymicStudent.Clear();
                textBoxCreateStudentTicketStudent.Clear();
                //textBoxCreatePasswordStudent.Clear();
                //comboBoxSexStudent.SelectedIndex = -1;
                //comboBoxCreateSpecialityStudent.SelectedIndex = -1;
            }
            //+sex.Length+speciality.Length++password.Length
            if (surname.Length+name.Length+patronymic.Length+login.Length==0)
            {
                MessageBox.Show("Вы ввели не все данные");
            }
            else { 
            Database.Student student = new Database.Student();
            student.StudentTicket = int.Parse(login);
            student.Name = name;
            student.Surname = surname;
            student.Patronymic = patronymic;
            //sex combobox
            student.Sex = 1;
            //group auto
            student.Group = 3063;
            student.Password = "group" + 3063;
            connection.Student.Add(student);
            int result = connection.SaveChanges();
            if (result==1)
            {
                ClearTextBox();
                MessageBox.Show("Студент успешно добавлен");
            }
            else
            {
                MessageBox.Show("Ошибка добавления студента");
            }
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)//ЗАРЕГИСТРИРОВАТЬ УЧИТЕЛЯ
        {
            string login = textBoxCreatePersonnelNumberTeacher.Text.Trim();
            string name = textBoxCreateNameTeacher.Text.Trim();
            string surname = textBoxCreateSurnameTeacher.Text.Trim();
            string patronymic = textBoxCreatePatronymicTeacher.Text.Trim();
            //string sex = comboBoxCreateSexTeacher.Text.Trim();
            string password = textBoxCreatePasswordTeacher.Text.Trim();
            //string role = comboBoxCreateRoleTeacher.Text.Trim();
            void ClearTextBox()
            {
                surname = "";
                name = "";
                patronymic = "";
                login = "";
                //password = "";
                //sex="";
                //role="";
                textBoxCreatePersonnelNumberTeacher.Clear();
                textBoxCreateNameTeacher.Clear();
                textBoxCreateSurnameTeacher.Clear();
                textBoxCreatePatronymicTeacher.Clear();
                //comboBoxCreateSexTeacher.Clear();
                textBoxCreatePasswordTeacher.Clear();
                //comboBoxCreateRoleTeacher.Clear();
            }
            //+sex.Length+role.Length
            if (login.Length+name.Length+surname.Length+patronymic.Length+password.Length==0)
            {
                MessageBox.Show("Вы ввели не все данные");
            }
            else
            {
                Database.Teacher teacher = new Database.Teacher();
                teacher.PersonnelNumber = int.Parse(login);
                teacher.Name = name;
                teacher.Surname = surname;
                teacher.Patronymic = patronymic;
                teacher.Sex = 1;
                teacher.Password = password;
                teacher.Role = "Преподаватель";
                connection.Teacher.Add(teacher);
                int result = connection.SaveChanges();
                if (result == 1)
                {
                    ClearTextBox();
                    MessageBox.Show("Преподаватель успешно добавлен");
                }
                else
                {
                    MessageBox.Show("Ошибка добавления преподавателя");
                }
            }
        }
        private void TabItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ClearTextBox();
        }//ОЧИСТКА ПО КЛИКУ
        private void textBoxSearchTeacher_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                var text = textBox.Text.Trim();
               teachers = connection.Teacher.Where(t => DbFunctions.Like(t.Name, "%" + text + "%") || DbFunctions.Like(t.Surname, "%" + text + "%") || DbFunctions.Like(t.Patronymic, "%" + text + "%")).ToList();
                LoadUsersTeacher();
            }
        } //ПОИСК УЧИТЕЛЕЙ
        private void textBoxSearchStudent_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                var text = textBox.Text.Trim();
                students=connection.Student.Where(t => DbFunctions.Like(t.Name, "%" + text + "%") || DbFunctions.Like(t.Surname, "%" + text + "%") || DbFunctions.Like(t.Patronymic, "%" + text + "%")).ToList();
                LoadUsersStudent();
            }
        } //ПОИСК СТУДЕНТОВ
        private void Button_Click_4(object sender, RoutedEventArgs e)//СОЗДАТЬ ДОЛЖНОСТЬ
        {

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)//СОЗДАТЬ ПРЕДМЕТ
        {

        }
    }
}
