namespace SegmentOne.Models;

public class Student
{
    public int Id { get; set; }
    public string NISN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool Status { get; set; }
    public int ClassroomId { get; set; }
}
