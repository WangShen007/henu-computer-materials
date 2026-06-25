using System.Collections.Generic;
using System.Windows.Controls;
namespace ExampleWpfApp.Ch05
{
    public partial class Z10CustomGeneric : Page
    {
        public Z10CustomGeneric()
        {
            InitializeComponent();
            var v = new CustomGenericDemo();
            uc.Result.Text = v.R;
        }
    }
    public class CustomGenericDemo
    {
        public string R { get; set; } = "";
        public CustomGenericDemo()
        {
            var v1 = new GenericList<Employee>();
            v1.AddHead(new Employee("a1", 15));
            v1.AddHead(new Employee("a2", 25));
            v1.AddHead(new Employee("a3", 35));
            var employees = v1.GetEnumerator();
            while(employees.MoveNext())
            {
                var c = employees.Current;
                R += $"Name={c.Name},ID={c.ID}{new string(' ',10)}";
            }
        }
    }
    public class Employee
    {
        public Employee(string s, int i)
        {
            Name = s;
            ID = i;
        }
        public string Name { get; set; }
        public int ID { get; set; }
    }

    public class GenericList<T> where T : Employee
    {
        private Node head;

        public GenericList() { head = null; }

        public void AddHead(T t)
        {
            Node n = new Node(t) { Next = head };
            head = n;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public T FindFirstOccurrence(string s)
        {
            Node current = head;
            T t = null;
            while (current != null)
            {
                //The constraint enables access to the Name property.
                if (current.Data.Name == s) { t = current.Data; break; }
                else { current = current.Next; }
            }
            return t;
        }
        private class Node
        {
            public Node Next { get; set; }
            public T Data { get; set; }
            public Node(T t) { Next = null; Data = t; }
        }
    }
}
