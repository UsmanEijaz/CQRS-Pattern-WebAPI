using CQRS_Pattern_WebAPI.Commands;
using CQRS_Pattern_WebAPI.Models;
using MediatR;
using System;

namespace CQRS_Pattern_WebAPI.Handler
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskCommand, TaskItem>
    {
        private readonly TaskDbContext _context;
        public CreateTaskHandler(TaskDbContext context) => _context = context;

        public async Task<TaskItem> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem { Title = request.Title, Description = request.Description, CreatedAt = DateTime.UtcNow };
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync(cancellationToken);
            return task;
        }
    }
}
