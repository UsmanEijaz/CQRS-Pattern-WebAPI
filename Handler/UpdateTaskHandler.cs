using CQRS_Pattern_WebAPI.Commands;
using CQRS_Pattern_WebAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace CQRS_Pattern_WebAPI.Handler
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskStatusCommand, TaskItem>
    {
        private readonly TaskDbContext _context;
        public UpdateTaskHandler(TaskDbContext context) => _context = context;

        public async Task<TaskItem> Handle(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
        {
            var task = await _context.TaskItems
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (task == null) { throw new Exception("Task not found"); }
            else
                task.Title = request.Title;
            task.Description = request.Description;
            task.IsCompleted = request.IsCompleted;

            _context.TaskItems.Attach(task);
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync(cancellationToken);
            return task;
        }
    }
}
