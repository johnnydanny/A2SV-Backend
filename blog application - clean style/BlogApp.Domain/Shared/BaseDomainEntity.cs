using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Domain.Shared
{
    public abstract class BaseDomainEntity
    {
        public int Id { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}
