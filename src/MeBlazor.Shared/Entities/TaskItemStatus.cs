using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Shared.Entities;

[Flags]
public enum TaskItemStatus : byte
{
    TODO, PENDING, DONE
}