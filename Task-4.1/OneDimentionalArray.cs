using System;
using System.Collections;

namespace Task_3_4
{
    public sealed class OneDimentionalArray<T>
    {
        const int default_length = 7;
        private int capacity;
        private int currentLength;
        private T[] array;

        public void CreateArray(int length)
        {
            if (length <= 0)
            {
                throw new Exception("длина массива должна быть больше 0");
            }
            else
            {
                array = new T[length];
                capacity = length;
            }

        }

        public void CreateArray()
        {
            CreateArray(default_length);
        }

        public void Resize()
        {
            capacity = capacity * 2 + 1;
            T[] newArray = new T[capacity];
            array.CopyTo(newArray, 0);
            array = newArray;
        }

        public void Add(T el)
        {
            if (capacity <= currentLength)
            {
                Resize();
            }
            array[currentLength] = el;
            currentLength++;
        }
        public int IndexEl(T el)
        {
            for (int i = 0; i < currentLength; i++)
            {
                if (array[i].Equals(el))
                {
                    return i;
                }
            }
        throw new Exception("данного элемента нет в массиве");
        }
        public void Remove(T el)
        {
            int index = IndexEl(el);
            currentLength--;
            Array.Copy(array, index + 1, array, index, currentLength - index);
        }

        public int CountEl()
        {
            return currentLength;
        }

        public void CoupArray()
        {
            T[] array1 = new T[capacity];
            for (int i = 0; i < currentLength; i++)
            {
                array1[currentLength - i - 1] = array[i];
            }
            array = array1;
        }
        public int ConditionCountEl(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);
            int c = 0;
            for (int i = 0; i < currentLength; i++)
            {
                if (condition(array[i]))
                {
                    c++;
                }
            }
            return c;
        }

        public T ConditionFind(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);
            for (int i = 0; i < currentLength; i++)
            {
                if (condition(array[i]))
                {
                    return array[i];
                }
            }
            throw new Exception("в массиве нет ни одного элемента, подходящего под условие");
        }

        public T ConditionAll(Func<T, bool> condition)
        {
            ArgumentNullException.ThrowIfNull(condition);
            for (int i = 0; i < currentLength; i++)
            {
                if (!(condition(array[i])))
                {
                    return array[i];
                }
            }
            throw new Exception("в массиве все элементы подходят условию");
        }

        public bool IsEquals(T el)
        {
            for (int i = 0; i < currentLength; i++)
            {
                if (array[i].Equals(el))
                {
                    return true;
                }
            }
            return false;
        }

        public T Minimum()
        {
            Comparer<T> comparer = Comparer<T>.Default;
            T minimumEl = array[0];
            for (int i = 0; i < currentLength; i++)
            {
                if (comparer.Compare(array[i], minimumEl) == -1)
                {
                    minimumEl = array[i];
                }
            }
            return minimumEl;
        }
        public void Print()
        {
            for (int i = 0; i < currentLength; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}

