using CQRS_Pattern_WebAPI.Models;
using MediatR;

namespace CQRS_Pattern_WebAPI.Commands
{
    public class CreateTaskCommand : IRequest<TaskItem>
    {
        public string? Title { get; set; }
        public string Description { get; set; }
    }
}
