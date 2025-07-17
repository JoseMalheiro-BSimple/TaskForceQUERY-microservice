using Application.IServices;
using Application.Services;
using Domain.Factory;
using Domain.IRepository;
using Infrastructure;
using Infrastructure.Repositories;
using Infrastructure.Resolvers;
using InterfaceAdapters;
using InterfaceAdapters.Consumer;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// read env variables for connection string
builder.Configuration.AddEnvironmentVariables();

builder.Services.AddDbContext<TaskForceCMDContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

//Services
builder.Services.AddTransient<ICollaboratorService, CollaboratorService>();
builder.Services.AddTransient<IProjectService, ProjectService>();
builder.Services.AddTransient<ISubjectService, SubjectService>();
builder.Services.AddTransient<ITaskForceService, TaskForceService>();
builder.Services.AddTransient<ITaskForceCollaboratorService, TaskForceCollaboratorService>();

//Repositories
builder.Services.AddTransient<ICollaboratorRepository, CollaboratorRepository>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<ISubjectRepository, SubjectRepository>();
builder.Services.AddTransient<ITaskForceRepository, TaskForceRepository>();
builder.Services.AddTransient<ITaskForceCollaboratorRepository, TaskForceCollaboratorRepository>();

//Factories
builder.Services.AddTransient<ICollaboratorFactory, CollaboratorFactory>();
builder.Services.AddTransient<IProjectFactory, ProjectFactory>();
builder.Services.AddTransient<ISubjectFactory, SubjectFactory>();
builder.Services.AddTransient<ITaskForceFactory, TaskForceFactory>();
builder.Services.AddTransient<ITaskForceCollaboratorFactory, TaskForceCollaboratorFactory>();

//Mappers
builder.Services.AddTransient<CollaboratorDataModelConverter>();
builder.Services.AddTransient<ProjectDataModelConverter>();
builder.Services.AddTransient<SubjectDataModelConverter>();
builder.Services.AddTransient<TaskForceDataModelConverter>();
builder.Services.AddTransient<TaskForceCollaboratorDataModelConverter>();
builder.Services.AddAutoMapper(cfg =>
{
    //DataModels
    cfg.AddProfile<DataModelMappingProfile>();

});

// MassTransit Configuration
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CollaboratorCreatedConsumer>();
    x.AddConsumer<ProjectCreatedConsumer>();
    x.AddConsumer<SubjectCreatedConsumer>();
    x.AddConsumer<TaskForceCreatedConsumer>();
    x.AddConsumer<TaskForceCollaboratorCreatedConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");

        cfg.ReceiveEndpoint($"taskforce-query-{InstanceInfo.InstanceId}", e =>
        {
            e.ConfigureConsumers(context);
        });
    });
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

    if (!env.IsEnvironment("Testing"))
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<TaskForceCMDContext>();
        dbContext.Database.Migrate();
    }
}

app.Run();

public partial class Program { }