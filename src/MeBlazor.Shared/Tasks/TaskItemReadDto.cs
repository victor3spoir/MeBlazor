using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Shared.Tasks
{
    public class TaskItemReadDto
    {
        public string? Id { get; set; }
        public string TaskName { get; set; }
        public bool IsComplete { get; set; }
    }
}