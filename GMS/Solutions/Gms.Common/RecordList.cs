using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gms.Common
{
    public class RecordList<T>
    {
        public RecordList()
        {

        }

        public RecordList(IList<T> data)
        {
            this.Data = data;
        }

       // [JsonProperty("rows")]
        public IList<T> Data { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        //[JsonProperty("total")]
        public int RecordCount { get; set; }

        public int StartIndex
        {
            get { return (PageIndex - 1) * PageSize; }
        }

        public int EndIndex
        {
            get { return StartIndex + PageSize - 1; }
        }

        public int PageCount
        {
            get { return (int)Math.Ceiling(RecordCount * 1.0 / PageSize); }
        }
        

        public int IndexOf(T item)
        {
            return Data.IndexOf(item);
        }
        
        public T this[int index]
        {
            get
            {
                return Data[index];
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public bool Contains(T item)
        {
            return Data.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Data.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return Data.Count; }
        }

        public bool IsReadOnly
        {
            get { return true; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Data.GetEnumerator();
        }

        public static RecordList<T> FromIList(IList<T> list)
        {
            return new RecordList<T> { Data = list };
        }
    }
}
