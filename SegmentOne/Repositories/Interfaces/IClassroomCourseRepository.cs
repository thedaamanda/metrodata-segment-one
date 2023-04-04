using SegmentOne.Models;

namespace SegmentOne.Repositories.Interfaces;
public interface IClassroomCourseRepository
{
    List<ClassroomCourse> GetAll();
    int Insert(ClassroomCourse classroomCourse);
}
