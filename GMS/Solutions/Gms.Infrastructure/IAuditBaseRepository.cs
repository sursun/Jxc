﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gms.Domain;

namespace Gms.Infrastructure
{
    public interface IAuditBaseRepository<T> : IRepositoryBase<T> where T : Gms.Domain.AuditBase
    {
    }
}
