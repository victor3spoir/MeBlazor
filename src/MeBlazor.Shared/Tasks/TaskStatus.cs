using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Shared.Tasks;

[Flags]
public enum TaskStatus : byte
{
    TODO, PENDING, DONE
}