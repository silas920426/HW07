using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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

namespace chooselesson
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Student> students = new List<Student>();
        Student selectedStudent = null;

        List<Course> courses = new List<Course>();
        Course selectedCourse = null;

        List<Teacher> teachers = new List<Teacher>();
        Teacher selectedTeacher = null;

        List<Record> records = new List<Record>();
        Record selectedRecord = null;
        public MainWindow()
        {
            InitializeComponent();
            InitializeStudent();
            InitializeCourse();
        }

        private void InitializeCourse()
        {
            Teacher teacher1 = new Teacher { TeacherName = "吳庭旭" };
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName="視窗程式設計" , OpeningClass= "四技二甲",Point=3, Type="選修"});
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二乙", Point = 3, Type = "選修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二丙", Point = 3, Type = "選修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "五專三甲", Point = 3, Type = "必修" });

            Teacher teacher2 = new Teacher { TeacherName = "江家滑起來" };
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "印度搖", OpeningClass = "四技二乙", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "印度C++", OpeningClass = "四技二乙", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "攝影", OpeningClass = "四技二乙", Point = 3, Type = "選修" });

            Teacher teacher3 = new Teacher { TeacherName = "陳建祥麟麥快" };
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "蓋房子", OpeningClass = "四技一丙", Point = 3, Type = "必修" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "偉積分", OpeningClass = "四技一甲", Point = 3, Type = "必修" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "米奇妙妙屋", OpeningClass = "四技一乙", Point = 3, Type = "必修" });

            teachers.Add(teacher1);
            teachers.Add(teacher2);
            teachers.Add(teacher3);
            tvTeacher.ItemsSource = teachers;

            foreach(Teacher teacher in teachers)
            {
                foreach(Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }
            lbCourse.ItemsSource = courses;

        }

        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1234567" , StudentName = "屎珍香" });
            students.Add(new Student { StudentId = "A1234987" , StudentName = "王大名" });
            students.Add(new Student { StudentId = "A1234789" , StudentName = "菁雖小" });
            students.Add(new Student { StudentId = "A1234765" , StudentName = "黯魔陰帝" });

            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
            selectedStudent = (Student)cmbStudent.SelectedItem;
        }

        private void cmbStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            labelStatus.Content = $"選取學生{selectedStudent.ToString()}";

        }

        private void tvTeacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvTeacher.SelectedItem is Teacher) 
            {
                selectedTeacher = (Teacher)tvTeacher.SelectedItem; ;
                labelStatus.Content = $"選取老師{selectedTeacher.ToString()}"; 
            }
            else if(tvTeacher.SelectedItem is Course)
            {
                selectedCourse = (Course)tvTeacher.SelectedItem;
                labelStatus.Content = $"選取課程{selectedCourse.ToString()}";
            }
        }

        private void lbCourse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCourse= (Course)lbCourse.SelectedItem;
            labelStatus.Content = $"選取課程{selectedCourse.ToString()}";
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if(selectedStudent== null || selectedCourse==null) 
            {
                MessageBox.Show("請選取學生或課程");
                return;
            }
            else
            {
                Record newRecord = new Record { SelectedStudent = selectedStudent, SelectedCourse = selectedCourse } ;
                foreach(Record r in records)
                {
                    if (newRecord.Equals(r))
                    {
                        MessageBox.Show($"{selectedStudent.StudentName}以選取{selectedCourse.CourseName}");
                        return;
                    }
                }
                records.Add(newRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();                            
            }
        }

        private void lvRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvRecord.SelectedItem != null)
            {
                selectedRecord = (Record)lvRecord.SelectedItem;
                labelStatus.Content = $"選取紀錄{selectedRecord.SelectedStudent.StudentName}{selectedRecord.SelectedCourse.CourseName}";
            }
        }

        private void btnWithdrawl_Click(object sender, RoutedEventArgs e)
        {
            if(selectedRecord!=null)
            {
                records.Remove(selectedRecord);
                lvRecord.Items.Refresh();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //開啟一個對話方塊將records內容存成json黨
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|.json|All files (*.*)|*.*";
            if(saveFileDialog.ShowDialog()==true)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    ReferenceHandler = ReferenceHandler.Preserve,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string json = JsonSerializer.Serialize(records,options);
                File.WriteAllText(saveFileDialog.FileName, json ); 
            }
        }
    }
}
