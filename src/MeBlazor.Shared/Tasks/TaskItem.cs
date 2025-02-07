using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Shared.Tasks
{
    public class TaskItem : Entity
    {
        [Required]
        [Column(name: "title")]
        public string Title { get; set; }
        [Column(name: "isdone")]
        public bool IsDone { get; set; } = false;
        [Column(name: "status")]
        public TaskStatus Status { get; set; } = TaskStatus.TODO;

        public string? Description { get; set; }

        public static TaskItem CreateFromDto(TaskItemCreateDto dto)
        {
            return new TaskItem()
            {
                Id = Guid.NewGuid().ToString(),
                Title = dto.TaskName,
                IsDone = false
            };
        }

        public TaskItemReadDto ReadToDto()
        {
            return new TaskItemReadDto()
            {
                Id = this.Id,
                TaskName = this.Title,
                IsComplete = this.IsDone,
            };
        }
        public void UpdateFromDto(TaskItemReadDto dto)
        {
            this.Title = dto.TaskName;
            this.IsDone = dto.IsComplete;
        }
    }
}