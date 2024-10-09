using FastEndpoints;
using WebApplication1.Models;
using WebApplication1.Requests;

namespace WebApplication1.Controllers;

public class UpdateStudentEndpoint : Endpoint<UpdateStudentRequest>
{
    public override void Configure()
    {
        Put("/api/students/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateStudentRequest req, CancellationToken ct)
    {
        var student = await GetStudentByIdAsync(req.Id);

        if (student is null)
        {
            await SendNotFoundAsync();
            return;
        }

        student.FullName = req.FullName;
        student.BirthDate = req.BirthDate;
        student.ClassId = req.ClassId;

        await UpdateStudentInDbAsync(student);
        await SendOkAsync(student);
    }

    private Task<Student> GetStudentByIdAsync(int id)
    {
        return Task.FromResult(new Student
        {
            Id = id,
            FullName = "Test Student",
            BirthDate = DateTime.Now.AddYears(-20),
            ClassId = 1
        });
    }

    private Task UpdateStudentInDbAsync(Student student)
    {
        return Task.CompletedTask;
    }
}
