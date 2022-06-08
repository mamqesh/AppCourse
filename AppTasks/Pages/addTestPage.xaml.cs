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
    /// Логика взаимодействия для addTestPage.xaml
    /// </summary>
    public partial class addTestPage : Page
    {
        danil2Entities2 connection = new danil2Entities2();
        public Database.Theme theme { get; set; }
        public List<Database.Theme> themes { get; set; }
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
            listBoxQuestions.Items.Clear();
            listBoxTheme.Items.Clear();
            textBoxAddNameTheme.Clear();
            textBoxOption1.Clear();
            textBoxOption2.Clear();
            textBoxOption3.Clear();
            textBoxQuestion.Clear();
            textBoxSearchTheme.Clear();
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            radioButton3.IsChecked = false;
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//СОЗДАТЬ ТЕМУ С ВОПРОСАМИ
        {
            try
            {
                if (textBoxAddNameTheme.Text.Length != 0 || listBoxSubject.SelectedIndex != -1)
                {
                    string themeName = textBoxAddNameTheme.Text.Trim();
                    if (themeName.Length == 0)
                    {
                        MessageBox.Show("Вы не ввели название темы");
                        return;
                    }
                    else
                    {
                        if (listBoxSubject.SelectedItem == null)
                        {
                            MessageBox.Show("Вы не выбрали предмет");
                            return;
                        }
                        else
                        {
                            Database.Theme theme = new Theme();
                            theme.ThemeID = connection.Theme.ToList().Count() + 1;
                            theme.ThemeName = themeName;
                            theme.Subject1 = listBoxSubject.SelectedItem as Database.Subject;
                            connection.Theme.Add(theme);
                            int result = connection.SaveChanges();
                            if (result > 0)
                            {
                                textBoxAddNameTheme.Clear();
                                MessageBox.Show("Тема предмета успешно добавлена");
                                if (listBoxSubject.SelectedIndex != -1)
                                {
                                    listBoxTheme.Items.Clear();
                                    var subject = listBoxSubject.SelectedItem as Subject;
                                    var selectedSubject = connection.Subject.ToList();
                                    var loadThemes = connection.Theme.ToList();
                                    foreach (var _selectedSubject in selectedSubject)
                                    {
                                        if (subject.SubjectID == _selectedSubject.SubjectID)
                                        {
                                            foreach (var _loadThemes in loadThemes)
                                            {
                                                if (_selectedSubject.SubjectID == _loadThemes.Subject)
                                                {
                                                    listBoxTheme.Items.Add(_loadThemes);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ошбика добавление темы предмета");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Выберите предмет и введите название темы");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        void ClearQuestionOption()
        {
            textBoxQuestion.Clear();
            textBoxOption1.Clear();
            textBoxOption2.Clear();
            textBoxOption3.Clear();
            radioButton1.IsChecked = false;
            radioButton2.IsChecked = false;
            radioButton3.IsChecked = false;
        }
        int teacherPesonalNumber = 0;
        public void Teacher(Teacher t)
        {
            teacherPesonalNumber = t.PersonnelNumber;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)//ДОБАВИТЬ ПОЛЯ ДЛЯ ЗАПОЛНЕНИЯ 
        {
            try
            {
                if (listBoxSubject.SelectedIndex != -1)
                {

                    string questionName = textBoxQuestion.Text.Trim();
                    string option1 = textBoxOption1.Text.Trim();
                    string option2 = textBoxOption2.Text.Trim();
                    string option3 = textBoxOption3.Text.Trim();
                    Database.Question question = new Database.Question();//НАЗВАНИЕ ВОПРОСА
                   
                    if (option1.Length > 0 || option2.Length > 0 || option3.Length > 0)
                    {
                        if (radioButton1.IsChecked == false && radioButton2.IsChecked == false && radioButton3.IsChecked == false)
                        {
                            MessageBox.Show("Выберите правильный ответ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        if (MessageBox.Show("Вы действительно хотите добавить вопрос?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                        {
                            int countID = connection.OptionText.ToList().Count();
                            listBoxQuestions.Items.Add(textBoxQuestion.Text);

                            if (radioButton1.IsChecked == true)
                            {
                                Database.OptionText optionText = new Database.OptionText//ВАРИАНТЫ ОТВЕТА
                                {
                                    IDOptionText = countID + 1,
                                    Answer = option1,
                                    TrueFalse = "True"
                                };
                                connection.OptionText.Add(optionText);

                                //optionText.IDOptionText = countID + 1;
                                //optionText.Answer = option1;
                                //optionText.TrueFalse = "True";
                                //connection.OptionText.Add(optionText);
                                //connection.SaveChanges();
                            }
                            if (radioButton1.IsChecked == false)
                            {
                                Database.OptionText optionText = new Database.OptionText//ВАРИАНТЫ ОТВЕТА
                                {
                                   IDOptionText = countID + 1,
                                   Answer = option1,
                                    TrueFalse = "False"
                                };
                                connection.OptionText.Add(optionText);
                            }
                            if (radioButton2.IsChecked == true)
                            {
                                Database.OptionText optionText = new Database.OptionText//ВАРИАНТЫ ОТВЕТА
                                {
                                    IDOptionText = countID + 2,
                                    Answer = option2,
                                    TrueFalse = "True"
                                };
                                connection.OptionText.Add(optionText);
                            }
                            if (radioButton2.IsChecked == false)
                            {
                                Database.OptionText optionText = new Database.OptionText//ВАРИАНТЫ ОТВЕТА
                                {
                                    IDOptionText = countID + 2,
                                    Answer = option2,
                                    TrueFalse = "False"
                                };
                                connection.OptionText.Add(optionText);
                            }
                            if (radioButton3.IsChecked == true)
                            {
                                Database.OptionText optionText = new Database.OptionText//ВАРИАНТЫ ОТВЕТА
                                {
                                    IDOptionText = countID + 3,
                                    Answer = option3,
                                    TrueFalse = "True"
                                };
                                connection.OptionText.Add(optionText);
                            }
                            if (radioButton3.IsChecked == false)
                            {
                                Database.OptionText optionText = new Database.OptionText//ВАРИАНТЫ ОТВЕТА
                                {
                                    IDOptionText = countID + 3,
                                    Answer = option3,
                                    TrueFalse = "False"
                                };
                                connection.OptionText.Add(optionText);
                            }
                            question.QuestionsID = connection.Question.ToList().Count() + 1;
                            question.Question1 = questionName;
                            question.Teacher = teacherPesonalNumber;
                            question.Subject1 = listBoxSubject.SelectedItem as Database.Subject;
                            connection.Question.Add(question);
                            int result = connection.SaveChanges();
                            if (result > 0)
                            {
                                MessageBox.Show("Вопрос и варианты ответа успешно добавлены.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля для ввода", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо выбрать предмет", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void textBoxSearchTheme_TextChanged(object sender, TextChangedEventArgs e) //ПОИСК ТЕМЫ
        {
            //TextBox textBox = sender as TextBox;
            //if (textBox != null)
            //{
            //    var text = textBox.Text.Trim();
            //    themes = connection.Theme.Where(t => DbFunctions.Like(t.ThemeName, "%" + text + "%")).ToList();
            //    listBoxTheme.GetBindingExpression(ListBox.ItemsSourceProperty)?.UpdateTarget();
            //}
        }
        private void listBoxSubject_SelectionChanged(object sender, SelectionChangedEventArgs e) //КЛИК ПО ПРЕДМЕТУ
        {
            if (listBoxSubject.SelectedIndex != -1)
            {
                listBoxTheme.Items.Clear();
                var subject = listBoxSubject.SelectedItem as Subject;
                var selectedSubject = connection.Subject.ToList();
                var loadThemes = connection.Theme.ToList();
                foreach (var _selectedSubject in selectedSubject)
                {
                    if (subject.SubjectID == _selectedSubject.SubjectID)
                    {
                        foreach (var _loadThemes in loadThemes)
                        {
                            if (_selectedSubject.SubjectID == _loadThemes.Subject)
                            {
                                listBoxTheme.Items.Add(_loadThemes);
                            }
                        }
                    }
                }
            }
        }
    }
}
