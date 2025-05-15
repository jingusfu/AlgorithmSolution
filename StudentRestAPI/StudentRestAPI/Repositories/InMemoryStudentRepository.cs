using StudentRestAPI.Models;

namespace StudentRestAPI.Repositories
{
    public class InMemoryStudentRepository : IStudentRepository
    {
        private readonly List<Student> _students = new List<Student>();

        public Student InsertStudent(Student student)
        {
            student.Id = _students.Any() ? _students.Max(s => s.Id) + 1 : 1;
            _students.Add(student);
            return student;
        }

        public Student GetStudent(long id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }

        public void UpdateStudent(long id, Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.FirstName = updatedStudent.FirstName;
                student.LastName = updatedStudent.LastName;
                student.Address = updatedStudent.Address;
                student.DateOfBirth = updatedStudent.DateOfBirth;
                student.Email = updatedStudent.Email;
                student.Grade = updatedStudent.Grade;
                student.Phone = updatedStudent.Phone;
            }
        }

        public void DeleteStudent(long id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}
