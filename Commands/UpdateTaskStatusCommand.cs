using CQRS_Pattern_WebAPI.Models;
using MediatR;

namespace CQRS_Pattern_WebAPI.Commands
{
    public class UpdateTaskStatusCommand : IRequest<TaskItem>
    {
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        public UpdateTaskStatusCommand(int id, bool isCompleted, string description, string title)
        {
            Id = id;
            IsCompleted = isCompleted;
            Description = description;
            Title = title;
        }
    }
}
