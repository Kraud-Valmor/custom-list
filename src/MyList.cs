using System;

namespace Task.List
{
    public sealed class MyList<T>
    {
        private const int InitialBufferSize = 4;
        private const float ResizeCoef = 2f;
        
        private T[] _array;
        private int _count;

        public int Count => _count;
        public int Capacity => _array.Length;

        public MyList()
        {
            _array = new T[InitialBufferSize];
            _count = 0;
        }

        public MyList(params T[] input)
        {
            _array = new T[BufferSizeFor(input.Length)];
            
            _count = input.Length;
            
            Array.Copy(input, _array, input.Length);
        }

        public T ItemAt(int i)
        {
            return _array[i];
        }

        public void Add(T item)
        {
            Resize(_count + 1);

            _array[_count++] = item;
        }

        public void AddRange(params T[] input)
        {
            Resize(_count + input.Length);

            var i = _count;

            foreach (T item in input)
                _array[i++] = item;

            _count += input.Length;
        }

        public void Insert(T item, int i)
        {
            if (i < 0 || i > _count)
                throw new IndexOutOfRangeException();

            Resize(_count + 1);

            Array.Copy(_array, i, _array, i + 1, _count - i);
            
            _array[i] = item;
            _count++;
        }

        public void DeleteAt(int i)
        {
            if (i < 0 || i >= _count)
                throw new IndexOutOfRangeException();

            Array.Copy(_array, i + 1, _array, i, _count - i);

            _count--;
        }

        public void Delete(T item)
        {
            DeleteAt(Array.IndexOf(_array, item));
        }

        private void Resize(int length)
        {
            if (length > _array.Length)
            {
                var newArray = new T[BufferSizeFor(length)];

                Array.Copy(_array, newArray, _count);

                _array = newArray;
            }
        }

        private static int BufferSizeFor(int length)
        {
            var coef = (double)length / InitialBufferSize;

            var pow = (int)Math.Log(coef, ResizeCoef) + 1;

            return (int)(InitialBufferSize * Math.Pow(ResizeCoef, pow));
        }
    }
}