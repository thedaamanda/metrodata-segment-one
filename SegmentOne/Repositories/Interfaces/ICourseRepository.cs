using SegmentOne.Models;

namespace SegmentOne.Repositories.Interfaces;
public interface ICourseRepository
{
    List<Course> GetAll();
    Course GetById(int id);
    int Insert(Course course);
    int Update(Course course);
    int Delete(int id);
}
