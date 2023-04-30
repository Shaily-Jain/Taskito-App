using System;
using System.Collections.Generic;

namespace TaskListApp
{
    internal class Program
    {
        enum operation
        {
            Additem = 1,
            Undoitem = 2,
            Redoitem = 3,
            Traverseitem = 4,
            Searchitem = 5,
            Exit
        }

        public static void additem(List<string> list)
        {
            Console.WriteLine("Enter an item to add:");
            string item = Console.ReadLine();

            list.Add(item);
            Console.WriteLine("Item added successfully!!\n");
        }
        public static void undoitem(List<string> list, List<string> undolist)
        {
            string value = list[list.Count - 1];
            undolist.Add(value);
            list.Remove(value);
            Console.WriteLine("Undo action performed\n");
        }
        public static void redoitem(List<string> list, List<string> undolist)
        {
            string redo = undolist[undolist.Count - 1];
            list.Add(redo);
            undolist.Remove(redo);
            Console.WriteLine("Redo action performed\n");
        }
        public static void display(List<string> list)
        {
            if (list.Count > 0)
            {
                Console.WriteLine("List items:");
                foreach (string i in list) Console.WriteLine("- " + i);
                Console.WriteLine();
            }
            else
                Console.WriteLine("No item present in a list\n");
        }
        public static void search(List<string> list)
        {
            Console.WriteLine("Enter the item which you want to search:");
            string searchval = Console.ReadLine();

            if (list.Contains(searchval) == true) Console.WriteLine("Searched item is present in list\n");
            else Console.WriteLine("Searched item is not present in list\n");
        }

        public static void Main(string[] args)
        {
            List<string> list = new List<string>();
            List<string> undolist = new List<string>();

            while (true)
            {
                Console.WriteLine(" 1.Add item\n 2.Undo Item\n 3.Redo Item\n 4.Traverse list\n 5.Search item\n 6.Perform operation using enum\n 7.Exit\n Enter your choice:");
                int n = Convert.ToInt32(Console.ReadLine());

                if (n == 1)
                {
                    additem(list);
                }
                else if (n == 2)
                {
                    undoitem(list, undolist);
                }
                else if (n == 3)
                {
                    redoitem(list, undolist);
                }
                else if (n == 4)
                {
                    display(list);
                }
                else if (n == 5)
                {
                    search(list);
                }
                else if (n == 6)
                {
                    // use enum
                    Console.WriteLine("Enter choice:");
                    int ch = Convert.ToInt32(Console.ReadLine());

                    if (ch == (int)operation.Additem)
                        additem(list);
                    else if (ch == (int)operation.Undoitem)
                        undoitem(list, undolist);
                    else if (ch == (int)operation.Redoitem)
                        redoitem(list, undolist);
                    else if (ch == (int)operation.Traverseitem)
                        display(list);
                    else if (ch == (int)operation.Searchitem)
                        search(list);
                    else
                        Console.Write("Invalid Choice");
                }
                else
                {
                    Console.WriteLine("Please input a valid choice!!\n");
                    Environment.Exit(0);
                }
            }
            Console.ReadKey();
        }
    }
}