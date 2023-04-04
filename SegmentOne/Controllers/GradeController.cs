using SegmentOne.Models;
using SegmentOne.Repositories.Interfaces;
using SegmentOne.Views;

namespace SegmentOne.Controllers;

public class GradeController
{
    private IGradeRepository _repository;
    private VGrade _view;

    public GradeController(IGradeRepository repository, VGrade view)
    {
        _repository = repository;
        _view = view;
    }

    public void GetAll()
    {
        var grades = _repository.GetAll();

        if (grades == null)
        {
            _view.DataNotFound();
        }

        _view.GetAll(grades);
    }

    public void GetById(int id)
    {
        var grade = _repository.GetById(id);

        if (grade == null)
        {
            _view.DataNotFound();
        }

        _view.GetById(grade);
    }

    public void Insert(Grade grade)
    {
        var result = _repository.Insert(grade);

        if (result > 0)
        {
            _view.Success("inserted");
        }
        else
        {
            _view.Failure("insert");
        }
    }

    public void Update(Grade grade)
    {
        var result = _repository.Update(grade);

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
