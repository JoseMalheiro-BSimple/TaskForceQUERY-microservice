using Application.DTO;
using Domain.ValueObjects;
using Infrastructure;
using Infrastructure.DataModel;
using InterfaceAdapters.IntegrationTests;
using Microsoft.Extensions.DependencyInjection;

namespace InterfaceAdapters.Tests.ControllerTests;

public class TaskForceControllerTests : IntegrationTestBase, IClassFixture<IntegrationTestsWebApplicationFactory<Program>>
{
    private readonly IntegrationTestsWebApplicationFactory<Program> _factory;

    public TaskForceControllerTests(IntegrationTestsWebApplicationFactory<Program> factory) : base(factory.CreateClient())
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetAll_ReturnsAllTaskForces()
    {
        // Arrange
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TaskForceCMDContext>();

        var taskForce1 = new TaskForceDataModel
        {
            Id = Guid.NewGuid(),
            SubjectId = Guid.NewGuid(),
            ProjectId = Guid.NewGuid(),
            Description = new Description("TaskForce 1"),
            PeriodDate = new PeriodDate(DateOnly.Parse("2025-01-01"), DateOnly.Parse("2025-12-31"))
        };

        var taskForce2 = new TaskForceDataModel
        {
            Id = Guid.NewGuid(),
            SubjectId = Guid.NewGuid(),
            ProjectId = Guid.NewGuid(),
            Description = new Description("TaskForce 2"),
            PeriodDate = new PeriodDate(DateOnly.Parse("2025-02-01"), DateOnly.Parse("2025-11-30"))
        };

        context.TaskForces.AddRange(taskForce1, taskForce2);
        await context.SaveChangesAsync();

        // Act
        var response = await GetAndDeserializeAsync<IEnumerable<TaskForceDTO>>("/api/taskForces");
        
        // Assert
        Assert.NotNull(response);
        Assert.Equal(2, response.Count());
    }

    [Fact]
    public async Task GetByProjectId_ReturnsCorrectTaskForces()
    {
        // Arrange
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TaskForceCMDContext>();

        var projectId = Guid.NewGuid();

        var taskForce1 = new TaskForceDataModel
        {
            Id = Guid.NewGuid(),
            SubjectId = Guid.NewGuid(),
            ProjectId = projectId,
            Description = new Description("TaskForce A"),
            PeriodDate = new PeriodDate(DateOnly.Parse("2025-03-01"), DateOnly.Parse("2025-09-30"))
        };

        var unrelatedTaskForce = new TaskForceDataModel
        {
            Id = Guid.NewGuid(),
            SubjectId = Guid.NewGuid(),
            ProjectId = Guid.NewGuid(), // Different project
            Description = new Description("TaskForce B"),
            PeriodDate = new PeriodDate(DateOnly.Parse("2025-04-01"), DateOnly.Parse("2025-10-30"))
        };

        context.TaskForces.AddRange(taskForce1, unrelatedTaskForce);
        await context.SaveChangesAsync();

        // Act
        var response = await GetAndDeserializeAsync<IEnumerable<TaskForceDTO>>($"/api/taskForces/project/{projectId}");

        // Assert
        Assert.NotNull(response);
        Assert.Single(response);
        Assert.Equal(projectId, response.ToList()[0].ProjectId);
    }

}
