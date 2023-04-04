namespace SegmentOne.Models;

public class ClassroomCourse
{
    public int Id { get; set; }
    public int ClassroomId { get; set; }
    public Classroom Classroom { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}
