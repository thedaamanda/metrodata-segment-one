using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using SegmentOne.Views;

namespace SegmentOne.Controllers;

public class TeacherController
{
    private ITeacherRepository _repository;
    private VTeacher _view;

    public TeacherController(ITeacherRepository repository, VTeacher view)
    {
        _repository = repository;
        _view = view;
    }

    public void GetAll()
    {
        var teachers = _repository.GetAll();

        if (teachers == null)
        {
            _view.DataNotFound();
        }

        _view.GetAll(teachers);
    }

    public void GetById(int id)
    {
        var teacher = _repository.GetById(id);

        if (teacher == null)
        {
            _view.DataNotFound();
        }

        _view.GetById(teacher);
    }

    public void Insert(Teacher teacher)
    {
        var result = _repository.Insert(teacher);

        if (result > 0)
        {
            _view.Success("inserted");
        }
        else
        {
            _view.Failure("insert");
        }
    }

    public void Update(Teacher teacher)
    {
        var result = _repository.Update(teacher);

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
