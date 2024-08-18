using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_C
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initializes the control variable to manage the program's loop
            bool finished = false;

            // Creates an instance of the AVLTree with string data type
            AVLTree<string> wordTree = new AVLTree<string>();

            do
            {
                // Prompts the user to press ENTER and waits for input
                Console.WriteLine("Press ENTER");
                Console.ReadKey();
                Console.Clear();

                // Displays the main menu options to the user
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products");
                Console.WriteLine("3. Display the total number of Products");
                Console.WriteLine("4. Check Product");
                Console.WriteLine("5. Exit");
                Console.WriteLine("\n Choose a function");

                // Retrieves the user's choice
                string option = Console.ReadLine();
                int items = 0;

                switch (option)
                {
                    case "1":
                        // Asks the user to insert a product name and adds it to the tree
                        Console.WriteLine("Please insert product name:");
                        wordTree.InsertItem(Console.ReadLine());
                        break;
                    case "2":
                        // Calls the traversal method to display the tree
                        traversal();
                        break;
                    case "3":
                        // Counts and displays the total number of items in the tree
                        wordTree.Count(ref items);
                        Console.WriteLine("Number of items: {0}", items);
                        break;
                    case "4":
                        // Prompts the user to check for a product in the tree
                        Console.WriteLine("Which product would you like to check?");
                        string check = Console.ReadLine();
                        wordTree.Contains(ref check);
                        wordTree.Checkrep(ref check);
                        Console.WriteLine(wordTree.Contains(ref check));
                        Console.WriteLine("Number of times product has been added: {0}", wordTree.Repetition());
                        wordTree.resetRepetition();
                        break;
                    case "5":
                        // Ends the program loop
                        finished = true;
                        break;
                }
            } while (!finished);

            // Defines the traversal method to display the tree in different orders
            void traversal()
            {
                Console.WriteLine("1. in-order");
                Console.WriteLine("2. post-order");
                Console.WriteLine("3. pre-order");
                Console.WriteLine("\nChoose a tree traversal method:");

                string buffer = "";
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // Displays the tree in in-order traversal
                        wordTree.InOrder(ref buffer);
                        Console.WriteLine(buffer);
                        break;
                    case "2":
                        // Displays the tree in post-order traversal
                        wordTree.PostOrder(ref buffer);
                        Console.WriteLine(buffer);
                        break;
                    case "3":
                        // Displays the tree in pre-order traversal
                        wordTree.PreOrder(ref buffer);
                        Console.WriteLine(buffer);
                        break;
                }
            }
        }
    }
}
