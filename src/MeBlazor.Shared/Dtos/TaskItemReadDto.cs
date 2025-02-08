using System;
using System.Collections.Generic;
using System.Linq;

using MeBlazor.Shared.Entities;

namespace MeBlazor.Shared.Dtos
{
    public class TaskItemReadDto
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public bool IsComplete { get; set; }
        public TaskItemStatus Status { get; set; }
    }
}