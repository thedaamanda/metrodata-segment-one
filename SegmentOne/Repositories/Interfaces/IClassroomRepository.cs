using SegmentOne.Models;

namespace SegmentOne.Repositories.Interfaces;
public interface IClassroomRepository
{
    List<Classroom> GetAll();
    Classroom GetById(int id);
    int Insert(Classroom classroom);
    int Update(Classroom classroom);
    int Delete(int id);
}
