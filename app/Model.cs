using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    public class Model
    {
        public static bool IsPolindrom(string value) => new string(value.Reverse().ToArray()) == value;

        public static int Sum(int[] values) => Math.Abs(values
            .Where(x => (x % 2) > 0).Where((value, index) => (index % 2) > 0).Sum());

        public static Node<char> Add(IEnumerable<char> x, IEnumerable<char> y) => 
            new Node<char>((int.Parse(new string(x.Reverse().ToArray())) + int.Parse(y.Reverse().ToArray())).ToString());
    }

    /// <summary>
    /// json can`t work with generics
    /// </summary>
    public class StringNode
    {
        public string Value;
        public StringNode Next;

        public Node<char> ToGeneric()
        {
            var node = this;
            Node<char> current = null;
            Node<char> root = null;
            while (node != null)
            {
                if (current == null)
                {
                    root = current = new Node<char>(node.Value[0]);
                }
                else
                {
                    current.Next = new Node<char>(node.Value[0]);
                    current = current.Next;
                }
                node = node.Next;
            }
            return root;
        }
    }


    public class Node<T> : IEnumerable<T>
    {
        public Node<T> Next { get; set; }
        public T Value { get; set;}

        public Node()
        {
        }

        public Node(T value)
        {
            Value = value;
        }

        public Node(IEnumerable<T> items)
        {
            var first = true;
            var current = this;
            foreach(var item in items)
            {
                if (first)
                {
                    current.Value = item;
                    first = false;
                }
                else {
                    current.Next = new Node<T>(item);
                    current = current.Next;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this;
            while(current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
