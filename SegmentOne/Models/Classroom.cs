namespace SegmentOne.Models;

public class Classroom
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Year { get; set; }
    public int GradeId { get; set; }
    public ICollection<ClassroomCourse> ClassroomCourses { get; set; }
}
