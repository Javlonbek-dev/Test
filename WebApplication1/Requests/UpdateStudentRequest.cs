namespace WebApplication1.Requests;

public class UpdateStudentRequest
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public int ClassId { get; set; }
}