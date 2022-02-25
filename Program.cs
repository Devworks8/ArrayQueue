using System;

namespace ArrayQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayQueue<char> q = new ArrayQueue<char>();

            for (int i = 0; i < 8; i++)
            {
                q.add((char)('a' + i));
                q.printAll();
            }
            
            q.add((char)('a'));
            q.add((char)('a'));
            q.add((char)('a'));
            q.printAll();

            for (int i = 0; i < 8; i++)
            {
                q.remove();
                q.printAll();
            }

            q.add((char)('b'));
            q.remove();
            //q.printAll();
            q.add((char)('c'));
            q.remove();
            q.printAll();

            // Figure 2.2 test sequence
            q.add('d');
            q.add('e');
            q.remove();
            q.add('f');
            q.add('g');
            q.add('h');
            q.remove();
            //q.printAll();
            
            Console.ReadKey(true);
        }
    }

    public class ArrayQueue<T>
    {
        private T[] a;
        private int j;
        private int n;

        public ArrayQueue()
        {
            a = new T[0];
            n = a.Length;
            j = 0;
        }

        public Boolean add(T x)
        {
            if (n + 1 > a.Length) resize();
            a[(j + n) % a.Length] = x;
            n++;
            return true;
        }

        public T remove()
        {
            if (n == 0) throw new InvalidOperationException();
            
            T x = a[j];
            j = (j + 1) % a.Length;
            n--;

            if (a.Length >= 3 * n) resize();
            return x;
        }

        private void resize()
        {
            T[] b = new T[Math.Max(1, n * 2)];

            for (int k = 0; k < n; k++)
                b[k] = a[(j + k) % a.Length];

            a = b;
            j = 0;
        }

        public void printAll()
        {
            Console.Write("j = " + j + ", n = " + n + "\t");
            if (j < (j + n) % a.Length)
            {
                for (int i = 0; i < j; i++)
                    Console.Write("[_]");
                for (int i = j; i < (j + n) % a.Length; i++)
                    Console.Write("[" + a[i] + "]");
                for (int i = j + n; i < a.Length; i++)
                    Console.Write("[_]");
            }
            else
            {
                for (int i = 0; i < (j + n) % a.Length; i++)
                    Console.Write("[" + a[i] + "]");
                for (int i = (j + n) % a.Length; i < j; i++)
                    Console.Write("[_]");
                for (int i = j; i < a.Length; i++)
                    Console.Write("[" + a[i] + "]");
            }
            Console.WriteLine();
        }
    }
}
