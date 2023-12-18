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
        List<Teacher> teachers = new List<Teacher>();
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
            labelStatus.Content = $"選取學生,{selectedStudent.ToString()}";

        }
    }
}
