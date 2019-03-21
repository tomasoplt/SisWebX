using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EF.EntityFrameworkCore.Domain.Entities
{
    /// <summary>
    /// A shortcut of <see cref="IEntity{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
    /// </summary>
    public interface IEntity : IEntity<int>
    {

    }
}
