namespace SegmentOne.Models;

public class Course
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int GradeId { get; set; }
    public int TeacherId { get; set; }
}
