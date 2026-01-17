using System;
using System.Collections.Generic;

namespace CQRS_Pattern_WebAPI.Models;

public partial class TaskItem
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public bool? IsCompleted { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Status { get; set; }
}
