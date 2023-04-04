using SegmentOne.Models;

namespace SegmentOne.Repositories.Interfaces;
public interface ITeacherRepository
{
    List<Teacher> GetAll();
    Teacher GetById(int id);
    int Insert(Teacher teacher);
    int Update(Teacher teacher);
    int Delete(int id);
}
