namespace WebApplication1.Requests;

public class CreateStudentRequest
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public int ClassId { get; set; }
}