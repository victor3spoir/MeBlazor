using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Shared.Dtos
{
    public class TaskItemCreateDto
    {
         [Required]
         [MinLength(5)]
        public string TaskName { get; set; }

    }
}