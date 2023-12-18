using System.Collections.ObjectModel;

namespace chooselesson
{
    internal class Teacher
    {
        public string TeacherName { get; set; }
        public ObservableCollection<Course> TeachingCourses { get; set; }

        public Teacher() 
        { 
            this.TeachingCourses = new ObservableCollection<Course>();
        }

        public override string ToString()
        {
            return $"{TeacherName}";
        }
    }
}
