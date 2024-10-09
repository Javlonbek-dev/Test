using FastEndpoints;
using WebApplication1.Models;
using WebApplication1.Requests;

namespace WebApplication1.Controllers;


public class GetStudentEndpoint : Endpoint<GetStudentRequest>
{
    public override void Configure()
    {
        Get("/api/students/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetStudentRequest req, CancellationToken ct)
    {
        var student = await GetStudentByIdAsync(req.Id);

        if (student is null)
        {
            await SendNotFoundAsync();
            return;
        }

        await SendOkAsync(student);
    }

    private Task<Student> GetStudentByIdAsync(int id)
    {
        return Task.FromResult(new Student
        {
            Id = id,
            FullName = "Test Student",
            BirthDate = DateTime.Now,
            ClassId = 1
        });
    }
}