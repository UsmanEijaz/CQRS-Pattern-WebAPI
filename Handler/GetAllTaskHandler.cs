using CQRS_Pattern_WebAPI.Commands;
using CQRS_Pattern_WebAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace CQRS_Pattern_WebAPI.Handler
{
    public class GetAllTaskHandler : IRequestHandler<GetAllTasksQuery, List<TaskItem>>
    {
        private readonly TaskDbContext _context;
        public GetAllTaskHandler(TaskDbContext context) => _context = context;

        public async Task<List<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var task = await _context.TaskItems
                .AsNoTracking().ToListAsync(cancellationToken);
            return task;
        }
    }
}
