using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MeBlazor.Shared.Dtos;

namespace MeBlazor.Shared.Entities
{
    public class TaskItem : Entity
    {
        [Required]
        [Column(name: "title")]
        public string Title { get; set; }
        [Column(name: "isdone")]
        public bool IsDone { get; set; } = false;
        [Column(name: "status")]
        public TaskItemStatus Status { get; set; } = TaskItemStatus.TODO;

        public string? Description { get; set; }

        public static TaskItem CreateFromDto(TaskItemCreateDto dto)
        {
            return new TaskItem()
            {
                Title = dto.TaskName,
                IsDone = false
            };
        }

        public TaskItemReadDto ReadToDto()
        {
            return new TaskItemReadDto()
            {
                Id = Id,
                TaskName = Title,
                IsComplete = IsDone,
                Status = Status,

            };
        }
        public void UpdateFromDto(TaskItemReadDto dto)
        {
            Title = dto.TaskName;
            IsDone = dto.IsComplete;
        }
    }
}