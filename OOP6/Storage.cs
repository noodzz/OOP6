using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP6
{
    internal class MyStorage 
    {
        private Shapes[] arr;
        private int Capacity => arr.Length;
        public int Count { get; private set; }

        public Shapes this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }
        private void TryResize()
        {
            Count++;
            if (arr.Length < Count)
            {
                Array.Resize(ref arr, arr.Length == 0 ? 1 : arr.Length * 2);
            }
        }
        public void RemoveAt(int pos)
        {
            arr[pos].NotifyRemove();
            for (var i = pos; i < Count - 1; i++)
            {
                arr[i] = arr[i + 1];
            }
            arr[Count - 1] = default(Shapes);
            Count--;
        }
        public MyStorage()
        {
            arr = new Shapes[0];
            arr.Initialize();
        }

        public MyStorage(int l)
        {
            if (l > 0)
            {
                arr = new Shapes[l];
                arr.Initialize();
            }
            else
            {
                throw new Exception("Length cannot be less than 0");
            }
        }
        public void Add(Shapes item)
        {
            TryResize();
            arr[this.Count - 1] = item;
            arr[this.Count - 1].NotifyAdd();
        }
        public void setObject(Shapes element, int pos)
        {
            if (pos > 0 && pos < arr.Length)
                arr.SetValue(element, pos);
            else throw new ArgumentOutOfRangeException();
        }
        public int size()
        {
            return arr.Length;
        }
        public Shapes getObject(int index)
        {
            if (index >= 0 && index < arr.Length)
                return arr[index];
            else return default(Shapes);

        }
        public Shapes getObjectAndDelete(int index)
        {
            if (index >= 0 && index < arr.Length && empty() == false)
            {
                Shapes tmp = getObject(index);
                RemoveAt(index);
                return tmp;
            }
            else throw new Exception("Invalid index");

        }
        public bool empty()
        {
            if (arr.Length == 0) return true;
            else return false;
        }
        public virtual Shapes CreateObject(string code)
        {
            return default;
        }
        public int GetIndex(Shapes s)
        {
            for (int i = 0; i < Count; i++)
            {
                if (s == arr[i])
                    return i;
            }
            return -1;

        }
        public void SaveCount(StreamWriter stream)
        {
            stream.WriteLine(Count);
            
        }
        public void LoadObjects(StreamReader stream)
        {
            string code;

            if (!stream.EndOfStream)
            {
                Count = Int32.Parse(stream.ReadLine());
                arr = new Shapes[Count];
                for (int i = 0; i < Count; i++)
                {
                    code = stream.ReadLine();
                    arr[i] = CreateObject(code);
                    if (arr[i] != null)
                    {
                        arr[i].Load(stream);
                    }
                }
            }

        }

    }
}
