using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace DataStructures 
{
    public class Buffer<T> : IBuffer<T>
    {
        protected Queue<T> _queue = new Queue<T>();
        public virtual bool IsEmpty => _queue.Count == 0;

        public virtual T Read() => _queue.Dequeue();

        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}