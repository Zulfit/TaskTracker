using TaskTracker.Models;

namespace TaskTracker.Data;

public class TrackerMemory
{
    public List<Project> Projects { get; } = new()
    {
        new Project
        {
            Id = 1,
            Name = "Website Redesign",
            Description = "New look for the company site",
            CreatedAt = new DateTime(2026, 10, 1),
            Tasks =
            [
                new TaskItem
                {
                    Id = 1,
                    ProjectId = 1,
                    Title = "Create wireframes",
                    Status = Status.Todo,
                    DueDate = new DateTime(2026, 10, 28),
                    CreatedAt = new DateTime(2026, 10, 1)
                },
                new TaskItem
                {
                    Id = 2,
                    ProjectId = 1,
                    Title = "Write homepage copy",
                    Status = Status.InProgress,
                    DueDate = new DateTime(2026, 10, 30),
                    CreatedAt = new DateTime(2026, 10, 2)
                }
            ]
        },
        new Project
        {
            Id = 2,
            Name = "Office Move",
            Description = "Move the team to the new floor",
            CreatedAt = new DateTime(2026, 10, 10),
            Tasks =
            [
                new TaskItem
                {
                    Id = 3,
                    ProjectId = 2,
                    Title = "Book the van",
                    Status = Status.Done,
                    DueDate = new DateTime(2026, 10, 20),
                    CreatedAt = new DateTime(2026, 10, 10)
                },
                new TaskItem
                {
                    Id = 4,
                    ProjectId = 2,
                    Title = "Pack the meeting room",
                    Status = Status.Todo,
                    DueDate = new DateTime(2026, 10, 25),
                    CreatedAt = new DateTime(2026, 10, 11)
                }
            ]
        }
    };
}
