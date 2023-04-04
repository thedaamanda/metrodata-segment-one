using SegmentOne.Models;

namespace SegmentOne.Repositories.Interfaces;
public interface IGradeRepository
{
    List<Grade> GetAll();
    Grade GetById(int id);
    int Insert(Grade grade);
    int Update(Grade grade);
    int Delete(int id);
}
