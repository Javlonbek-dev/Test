using FastEndpoints;
using WebApplication1.Models;
using WebApplication1.Requests;

namespace WebApplication1.Controllers;

public class CreateStudentEndpoint : Endpoint<CreateStudentRequest>
{
    public override void Configure()
    {
        Post("/api/students");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateStudentRequest req, CancellationToken ct)
    {
        var student = new Student
        {
            FullName = req.FullName,
            BirthDate = req.BirthDate,
            ClassId = req.ClassId
        };

        await SaveStudentToDbAsync(student);

        await SendOkAsync(student);  
    }

    private Task SaveStudentToDbAsync(Student student)
    {
        return Task.CompletedTask;
    }
}
