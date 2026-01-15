using CQRS_Pattern_WebAPI.Models;
using MediatR;

namespace CQRS_Pattern_WebAPI.Commands
{
    public class GetTaskByIdQuery : IRequest<TaskItem>
    {
        public int Id { get; set; }
        public GetTaskByIdQuery(int id)
        {
            Id = id;
        }

    }
}
