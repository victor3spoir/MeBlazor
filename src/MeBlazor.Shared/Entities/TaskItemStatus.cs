using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Shared.Entities;

// [Flags]
public enum TaskItemStatus
{
    [Description("Todo")]
    TODO,
    [Description("Pending")]
    PENDING,
    [Description("Done")]
    DONE
}