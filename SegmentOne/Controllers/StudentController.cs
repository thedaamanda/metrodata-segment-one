using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using SegmentOne.Views;

namespace SegmentOne.Controllers;

public class StudentController
{
    private IStudentRepository _repository;
    private VStudent _view;

    public StudentController(IStudentRepository repository, VStudent view)
    {
        _repository = repository;
        _view = view;
    }

    public void GetAll()
    {
        var students = _repository.GetAll();

        if (students == null)
        {
            _view.DataNotFound();
        }

        _view.GetAll(students);
    }

    public void GetById(int id)
    {
        var student = _repository.GetById(id);

        if (student == null)
        {
            _view.DataNotFound();
        }

        _view.GetById(student);
    }

    public void Insert(Student student)
    {
        var result = _repository.Insert(student);

        if (result > 0)
        {
            _view.Success("inserted");
        }
        else
        {
            _view.Failure("insert");
        }
    }

    public void Update(Student student)
    {
        var result = _repository.Update(student);

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
