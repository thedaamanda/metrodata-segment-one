using SegmentOne.Models;

namespace SegmentOne.Repositories.Interfaces;
public interface IStudentRepository
{
    List<Student> GetAll();
    Student GetById(int id);
    int Insert(Student student);
    int Update(Student student);
    int Delete(int id);
}
