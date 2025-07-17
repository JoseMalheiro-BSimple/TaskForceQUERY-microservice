using Infrastructure.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class TaskForceCMDContext : DbContext
{
    public virtual DbSet<CollaboratorDataModel> Collaborators { get; set; }
    public virtual DbSet<ProjectDataModel> Projects { get; set; }
    public virtual DbSet<SubjectDataModel> Subjects { get; set; }
    public virtual DbSet<TaskForceDataModel> TaskForces { get; set; }
    public virtual DbSet<TaskForceCollaboratorDataModel> TaskForceCollaborators { get; set; }

    public TaskForceCMDContext(DbContextOptions<TaskForceCMDContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TaskForceDataModel>(builder =>
        {
            builder.OwnsOne(s => s.Description, d =>
            {
                d.Property(p => p.Value)
                    .HasColumnName("Description") 
                    .IsRequired();
            });

            builder.OwnsOne(c => c.PeriodDate, period =>
            {
                period.Property(p => p.InitDate)
                    .HasColumnName("InitDate")
                    .IsRequired();

                period.Property(p => p.EndDate)
                    .HasColumnName("EndDate")
                    .IsRequired();
            });

            builder.HasKey(c => c.Id);
            builder.ToTable("TaskForce");
        });
    }
}
