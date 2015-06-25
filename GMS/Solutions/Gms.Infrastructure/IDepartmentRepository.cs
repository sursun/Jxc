using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public interface IDepartmentRepository : IRepositoryBase<Department>
    {
        IList<Department> GetRoot();
        IList<Department> GetChildren(int parentId);
    }
}
