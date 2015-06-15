using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Common
{
    public class Range<T>
    {
        public Range()
        {
        }

        public Range(T start, T end)
        {
            Start = start;
            End = end;
        }

        public T Start { get; set; }
        public T End { get; set; }

        public static Range<T> Create(T start, T end)
        {
            return new Range<T>(start, end);
        }
    }
}
