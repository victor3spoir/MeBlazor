using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeBlazor.Shared.Entities;

namespace MeBlazor.Shared.Dtos;

public class TaskItemUpdateDto
{
    public string? TaskName { get; set; }
    public bool? IsComplete { get; set; }
    public TaskItemStatus? Status { get; set; }
    public static TaskItemUpdateDto FromReadDto(TaskItemReadDto dto) => new TaskItemUpdateDto()
    {
        TaskName = dto.TaskName,
        IsComplete = dto.IsComplete,
        Status = dto.Status
    };
}


