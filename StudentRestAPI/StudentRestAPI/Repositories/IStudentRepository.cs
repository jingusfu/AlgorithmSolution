using StudentRestAPI.Models;

namespace StudentRestAPI.Repositories
{
    public interface IStudentRepository
    {
        Student InsertStudent(Student student);
        Student GetStudent(long id);
        IEnumerable<Student> GetAllStudents();
        void UpdateStudent(long id, Student updatedStudent);
        void DeleteStudent(long id);
    }
}
