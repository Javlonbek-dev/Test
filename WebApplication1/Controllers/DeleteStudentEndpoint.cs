using FastEndpoints;
using WebApplication1.Models;
using WebApplication1.Requests;

namespace WebApplication1.Controllers;

public class DeleteStudentEndpoint : Endpoint<DeleteStudentRequest>
{
    public override void Configure()
    {
        Delete("/api/students/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteStudentRequest req, CancellationToken ct)
    {
        var student = await GetStudentByIdAsync(req.Id);

        if (student is null)
        {
            await SendNotFoundAsync();
            return;
        }

        await DeleteStudentFromDbAsync(req.Id);
        await SendOkAsync("Student deleted successfully.");
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

    private Task DeleteStudentFromDbAsync(int id)
    {
        return Task.CompletedTask;
    }
}
