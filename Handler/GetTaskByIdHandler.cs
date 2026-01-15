using CQRS_Pattern_WebAPI.Commands;
using CQRS_Pattern_WebAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace CQRS_Pattern_WebAPI.Handler
{
    public class GetTaskByIdHandler : IRequestHandler<GetTaskByIdQuery, TaskItem>
    {
        private readonly TaskDbContext _context;
        public GetTaskByIdHandler(TaskDbContext context) => _context = context;

        public async Task<TaskItem> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.TaskItems
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (task == null) { throw new Exception("Task not found"); }
            return task;
        }
    }
}
