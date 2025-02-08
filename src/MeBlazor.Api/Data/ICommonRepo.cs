using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeBlazor.Api.Data;

public interface ICommonRepo<T> : IEntityRepo<T> where T : Entity
{
}