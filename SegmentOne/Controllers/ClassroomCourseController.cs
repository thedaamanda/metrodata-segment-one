using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using SegmentOne.Views;

namespace SegmentOne.Controllers;

public class ClassroomCourseController
{
    private IClassroomCourseRepository _repository;
    private VClassroomCourse _view;

    public ClassroomCourseController(IClassroomCourseRepository repository, VClassroomCourse view)
    {
        _repository = repository;
        _view = view;
    }

    public void GetAll()
    {
        var classroomCourse = _repository.GetAll();

        if (classroomCourse == null)
        {
            _view.DataNotFound();
        }

        _view.GetAll(classroomCourse);
    }

    public void Insert(List<ClassroomCourse> classroomCourses)
    {
        try {
            Console.WriteLine("Inserting classroom courses...");
            foreach (var classroomCourse in classroomCourses)
            {
                _repository.Insert(classroomCourse);
            }

            _view.Success("inserted");
        } catch (Exception ex) {
            _view.Failure("insert");
        }
    }
}
