using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using SegmentOne.Views;

namespace SegmentOne.Controllers;

public class ClassroomController
{
    private IClassroomRepository _repository;
    private VClassroom _view;

    public ClassroomController(IClassroomRepository repository, VClassroom view)
    {
        _repository = repository;
        _view = view;
    }

    public void GetAll()
    {
        var classrooms = _repository.GetAll();

        if (classrooms == null)
        {
            _view.DataNotFound();
        }

        _view.GetAll(classrooms);
    }

    public void GetById(int id)
    {
        var classroom = _repository.GetById(id);

        if (classroom == null)
        {
            _view.DataNotFound();
        }

        _view.GetById(classroom);
    }

    public void Insert(Classroom classroom)
    {
        var result = _repository.Insert(classroom);

        if (result > 0)
        {
            _view.Success("inserted");
        }
        else
        {
            _view.Failure("insert");
        }
    }

    public void Update(Classroom classroom)
    {
        var result = _repository.Update(classroom);

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
