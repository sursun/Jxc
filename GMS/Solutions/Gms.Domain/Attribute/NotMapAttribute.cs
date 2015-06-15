using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Domain.Attribute
{
    public class NotMapAttribute : System.Attribute
    {
        public NotMapAttribute()
        { }
        public bool IsMap { get; set; }
    }
}
