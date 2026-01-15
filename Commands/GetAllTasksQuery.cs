using CQRS_Pattern_WebAPI.Models;
using MediatR;

namespace CQRS_Pattern_WebAPI.Commands
{
    public class GetAllTasksQuery : IRequest<List<TaskItem>> 
    {   
    
    }
}
