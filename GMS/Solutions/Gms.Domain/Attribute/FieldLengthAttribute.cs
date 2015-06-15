using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Domain.Attribute
{
    public class FieldLengthAttribute : System.Attribute
    {
        public FieldLengthAttribute(int length)
        {
            this.Length = length;
        }
        public int Length { get; set; }
    }
}
