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
        public List<Database.Teacher> teachers { get; set; }
        public Database.Student student { get; set; }
        public List<Database.Student> students { get; set; }
        public List<Database.Sex> sexes { get; set; }
        public List<Database.Group> groups { get; set; }
        public List<Database.Speciality> specialities { get; set; }
        public List<Database.Role> roles { get; set; }
        danil2Entities2 connection = new danil2Entities2();
        public administrationPage()
        {
            InitializeComponent();
            LoadSex();
            LoadSpecialityStudent();
            LoadRoleTeacher();
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
        void LoadSpecialityStudent()
        {
            specialities = connection.Speciality.ToList();
        }
        void LoadRoleTeacher()
        {
            roles = connection.Role.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)//ПРИМЕНИТЬ РЕДАКТИРОВАНИЕ
        {
            try
            {
                int result = connection.SaveChanges();
                if (result == 1)
                {
                    MessageBox.Show("Данные успешно отредактированы!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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
            NavigationService.Navigate(MainWindow.pageMainPage);
        }
        private void listBoxStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)//КЛИК ПО СТУДЕНТУ
        {
            student = listBoxStudent.SelectedItem as Database.Student;
            LoadUsersStudent();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e) //ЗАРЕГИСТРИРОВАТЬ СТУДЕНТА
        {
            try
            {
                string surname = textBoxCreateSurnameStudent.Text.Trim();
                string name = textBoxCreateNameStudent.Text.Trim();
                string patronymic = textBoxCreatePatronymicStudent.Text.Trim();
                string login = textBoxCreateStudentTicketStudent.Text.Trim();
                string password = textBoxCreatePasswordStudent.Text.Trim();
                void ClearTextBox()
                {
                    surname = "";
                    name = "";
                    patronymic = "";
                    login = "";
                    password = "";
                    textBoxCreateSurnameStudent.Clear();
                    textBoxCreateNameStudent.Clear();
                    textBoxCreatePatronymicStudent.Clear();
                    textBoxCreateStudentTicketStudent.Clear();
                    textBoxCreatePasswordStudent.Clear();
                    comboBoxSexStudent.SelectedIndex = -1;
                    comboBoxCreateSpecialityStudent.SelectedIndex = -1;
                }
                if (surname.Length == 0 || name.Length == 0 || patronymic.Length == 0 || login.Length == 0 || password.Length == 0)
                {
                    MessageBox.Show("Вы ввели не все данные", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    Database.Student student = new Database.Student();
                    student.StudentTicket = int.Parse(login);
                    student.Name = name;
                    student.Surname = surname;
                    student.Patronymic = patronymic;
                    student.Sex1 = comboBoxCreateSexStudent.SelectedItem as Sex;
                    student.Group1 = comboBoxCreateGroupStudent.SelectedItem as Group;
                    student.Password = textBoxCreatePasswordStudent.Text.Trim();
                    connection.Student.Add(student);
                    int result = connection.SaveChanges();
                    if (result == 1)
                    {
                        ClearTextBox();
                        students = connection.Student.ToList();
                        LoadUsersStudent();
                        MessageBox.Show("Студент успешно добавлен", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void comboBoxCreateGroupStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBoxCreatePasswordStudent.Text = "";
            textBoxCreatePasswordStudent.Text = "group" + (comboBoxCreateGroupStudent.SelectedItem as Group).IDGroup;
        }
        private void comboBoxCreateSpecialityStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxCreateSpecialityStudent.SelectedIndex != -1)
            {
                comboBoxCreateGroupStudent.Items.Clear();
                var speciality = comboBoxCreateSpecialityStudent.SelectedItem as Speciality;
                groups = speciality.Group.ToList();
                comboBoxCreateGroupStudent.GetBindingExpression(ComboBox.ItemsSourceProperty)?.UpdateTarget();
            }
        } // ДОБАВЛЕНИЕ НОМЕРА ГРУППЫ
        private void Button_Click_3(object sender, RoutedEventArgs e)//ЗАРЕГИСТРИРОВАТЬ УЧИТЕЛЯ
        {
            try
            {
                string login = textBoxCreatePersonnelNumberTeacher.Text.Trim();
                string name = textBoxCreateNameTeacher.Text.Trim();
                string surname = textBoxCreateSurnameTeacher.Text.Trim();
                string patronymic = textBoxCreatePatronymicTeacher.Text.Trim();
                string sex = comboBoxCreateSexTeacher.Text.Trim();
                string password = textBoxCreatePasswordTeacher.Text.Trim();
                string role = comboBoxCreateRoleTeacher.Text.Trim();
                void ClearTextBox()
                {
                    surname = "";
                    name = "";
                    patronymic = "";
                    login = "";
                    password = "";
                    sex = "";
                    role = "";
                    textBoxCreatePersonnelNumberTeacher.Clear();
                    textBoxCreateNameTeacher.Clear();
                    textBoxCreateSurnameTeacher.Clear();
                    textBoxCreatePatronymicTeacher.Clear();
                    comboBoxCreateSexTeacher.SelectedIndex = -1;
                    textBoxCreatePasswordTeacher.Clear();
                    comboBoxCreateRoleTeacher.SelectedIndex = -1;
                }
                if (login.Length == 0 || name.Length == 0 || surname.Length == 0 || patronymic.Length == 0 || password.Length == 0 || sex.Length == 0 || role.Length == 0)
                {
                    MessageBox.Show("Вы ввели не все данные", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    if (comboBoxCreateSexTeacher.SelectedIndex < 0 || comboBoxCreateRoleTeacher.SelectedIndex < 0)
                    {
                        MessageBox.Show("Данные заполнены не все", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    Database.Teacher teacher = new Database.Teacher();
                    teacher.PersonnelNumber = int.Parse(login);
                    teacher.Name = name;
                    teacher.Surname = surname;
                    teacher.Patronymic = patronymic;
                    teacher.Password = password;
                    teacher.Sex1 = comboBoxCreateSexTeacher.SelectedItem as Sex;
                    teacher.Role1 = comboBoxCreateRoleTeacher.SelectedItem as Role;
                    connection.Teacher.Add(teacher);
                    int result = connection.SaveChanges();
                    if (result == 1)
                    {
                        ClearTextBox();
                        teachers = connection.Teacher.ToList();
                        LoadUsersTeacher();
                        MessageBox.Show("Преподаватель успешно добавлен", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(),"Ошибка",MessageBoxButton.OK, MessageBoxImage.Error);
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
                students = connection.Student.Where(t => DbFunctions.Like(t.Name, "%" + text + "%") || DbFunctions.Like(t.Surname, "%" + text + "%") || DbFunctions.Like(t.Patronymic, "%" + text + "%")).ToList();
                LoadUsersStudent();
            }
        } //ПОИСК СТУДЕНТОВ
        private void Button_Click_4(object sender, RoutedEventArgs e)//СОЗДАТЬ ДОЛЖНОСТЬ
        {
            try
            {
                string roleTextBox = textBoxCreateRole.Text.Trim();
                if (roleTextBox.Length == 0)
                {
                    MessageBox.Show("Вы не ввели данные", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                //ОГРАНИЧЕНИЕ
                var roles = connection.Role.Where(r => r.RoleName == roleTextBox).FirstOrDefault();
                if (roles == null)
                {
                    void ClearItem()
                    {
                        textBoxCreateRole.Clear();
                        roleTextBox = "";
                    }
                    Database.Role role = new Role();
                    int roleID = connection.Role.ToList().Count() + 1;
                    role.RoleID = roleID;
                    role.RoleName = roleTextBox;
                    connection.Role.Add(role);
                    int result = connection.SaveChanges();
                    if (result > 0)
                    {
                        LoadRoleTeacher();
                        comboBoxCreateRoleTeacher.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateTarget();
                        MessageBox.Show("Специальность добавлена", "Предупреждние", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearItem();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)//СОЗДАТЬ ПРЕДМЕТ
        {
            try
            {
                string subjectTextBox = textBoxCreateSubject.Text.Trim();
                if (subjectTextBox.Length == 0)
                {
                    MessageBox.Show("Вы не ввели данные","Предупреждение",MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                //ОГРАНИЧЕНИЕ
                var subjects = connection.Subject.Where(s => s.SubjectName == subjectTextBox).FirstOrDefault();
                if (subjects == null)
                {
                    void ClearItem()
                    {
                        textBoxCreateSubject.Clear();
                        subjectTextBox = "";
                    }
                    Database.Subject subject = new Subject();
                    int subjectID = connection.Subject.ToList().Count() + 1;
                    subject.SubjectID = subjectID;
                    subject.SubjectName = subjectTextBox;
                    connection.Subject.Add(subject);
                    int result = connection.SaveChanges();
                    if (result > 0)
                    {
                        MessageBox.Show("Предмет добавлен", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearItem();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                
            }
        }
        private void Button_Click_6(object sender, RoutedEventArgs e) //СОЗДАТЬ СПЕЦИАЛЬНОСТЬ
        {
            try
            {
                string createSpeciality = textBoxCreateSpeciality.Text.Trim();
                void ClearItem()
                {
                    textBoxCreateRole.Clear();
                    textBoxCreateSpeciality.Text = "";
                }
                if (textBoxCreateSpeciality.Text.Length == 0)
                {
                    MessageBox.Show("Вы не ввели данные", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                var specialities = connection.Speciality.Where(s => s.SpecialityName == textBoxCreateSpeciality.Text).FirstOrDefault();
                if (specialities == null)
                {
                    Database.Speciality speciality = new Speciality();
                    int roleID = connection.Speciality.ToList().Count() + 1;
                    speciality.IDSpeciality = roleID;
                    speciality.SpecialityName = createSpeciality;
                    connection.Speciality.Add(speciality);
                    int result = connection.SaveChanges();
                    if (result > 0)
                    {
                        LoadSpecialityStudent();
                        comboBoxCreateSpecialityStudent.GetBindingExpression(ComboBox.SelectedItemProperty)?.UpdateTarget();
                        MessageBox.Show("Специальность добавлена", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                        ClearItem();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
