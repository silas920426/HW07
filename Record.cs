namespace chooselesson
{
    internal class Record
    {
        
        public Student SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }

        public bool Equals(Record r)
        {
            return this.SelectedStudent.StudentId == r.SelectedStudent.StudentId && this.SelectedCourse.CourseName == r.SelectedCourse.CourseName;
        }
    }
}
