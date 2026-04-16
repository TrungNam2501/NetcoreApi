using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;

namespace CollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // ================= LIST =================
            Console.WriteLine("\n--- List ---");
            List<string> list = new List<string>();
            list.Add("Bánh");
            list.Add("Sữa");

            foreach (var item in list)
                Console.WriteLine(item);


            // ================= DICTIONARY =================
            Console.WriteLine("\n--- Dictionary ---");
            Dictionary<int, string> dict = new Dictionary<int, string>();
            dict.Add(1, "Bánh");
            dict.Add(2, "Sữa");

            Console.WriteLine(dict[1]);


            // ================= HASHSET =================
            Console.WriteLine("\n--- HashSet ---");
            HashSet<string> set = new HashSet<string>();
            set.Add("ORD001");
            set.Add("ORD001"); // bị bỏ

            foreach (var item in set)
                Console.WriteLine(item);


            // ================= QUEUE =================
            Console.WriteLine("\n--- Queue ---");
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Đơn 1");
            queue.Enqueue("Đơn 2");

            Console.WriteLine(queue.Dequeue());


            // ================= STACK =================
            Console.WriteLine("\n--- Stack ---");
            Stack<string> stack = new Stack<string>();
            stack.Push("Thao tác 1");
            stack.Push("Thao tác 2");

            Console.WriteLine(stack.Pop());


            // ================= SORTEDLIST =================
            Console.WriteLine("\n--- SortedList ---");
            SortedList<int, string> sortedList = new SortedList<int, string>();
            sortedList.Add(2, "B");
            sortedList.Add(1, "A");

            foreach (var item in sortedList)
                Console.WriteLine(item.Key + " - " + item.Value);


            // ================= LINKEDLIST =================
            Console.WriteLine("\n--- LinkedList ---");
            LinkedList<string> linkedList = new LinkedList<string>();
            linkedList.AddLast("Task thường");
            linkedList.AddFirst("Task gấp");

            foreach (var item in linkedList)
                Console.WriteLine(item);


            // ================= CONCURRENT =================
            Console.WriteLine("\n--- ConcurrentDictionary ---");
            ConcurrentDictionary<int, string> concurrent = new ConcurrentDictionary<int, string>();
            concurrent.TryAdd(1, "Data 1");

            Console.WriteLine(concurrent[1]);


            // ================= OBSERVABLE =================
            Console.WriteLine("\n--- ObservableCollection ---");
            ObservableCollection<string> observable = new ObservableCollection<string>();
            observable.CollectionChanged += (s, e) =>
            {
                Console.WriteLine("Có thay đổi dữ liệu!");
            };

            observable.Add("Item 1");


            // ================= ARRAYLIST =================
            Console.WriteLine("\n--- ArrayList ---");
            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add("Hello");

            foreach (var item in arrayList)
                Console.WriteLine(item);


            // ================= HASHTABLE =================
            Console.WriteLine("\n--- Hashtable ---");
            Hashtable hashtable = new Hashtable();
            hashtable["A"] = 100;

            Console.WriteLine(hashtable["A"]);


            Console.WriteLine("\n=== DONE ===");
            Console.ReadLine();
        }
    }
}