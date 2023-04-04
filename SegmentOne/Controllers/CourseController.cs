using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using SegmentOne.Views;

namespace SegmentOne.Controllers;

public class CourseController
{
    private ICourseRepository _repository;
    private VCourse _view;

    public CourseController(ICourseRepository repository, VCourse view)
    {
        _repository = repository;
        _view = view;
    }

    public void GetAll()
    {
        var courses = _repository.GetAll();

        if (courses == null)
        {
            _view.DataNotFound();
        }

        _view.GetAll(courses);
    }

    public void GetById(int id)
    {
        var course = _repository.GetById(id);

        if (course == null)
        {
            _view.DataNotFound();
        }

        _view.GetById(course);
    }

    public void Insert(Course course)
    {
        var result = _repository.Insert(course);

        if (result > 0)
        {
            _view.Success("inserted");
        }
        else
        {
            _view.Failure("insert");
        }
    }

    public void Update(Course course)
    {
        var result = _repository.Update(course);

        if (result > 0)
        {
            _view.Success("updated");
        }
        else
        {
            _view.Failure("update");
        }
    }

    public void Delete(int id)
    {
        var result = _repository.Delete(id);

        if (result > 0)
        {
            _view.Success("deleted");
        }
        else
        {
            _view.Failure("delete");
        }
    }
}
