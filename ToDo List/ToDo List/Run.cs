using ToDo_List;

var list = new ToDoList("My To-Do List", "My To-Do List");
const string divider = "----------------------------";



while (true)
{
        // Print Options Menu
        Console.WriteLine(divider);
        Console.WriteLine("Menu: ");
        Console.WriteLine("1: List Items");
        Console.WriteLine("2: List Specific Item Info");
        Console.WriteLine("3: Add Item");
        Console.WriteLine("4: Remove Item");
        Console.WriteLine("5: Exit");
        Console.WriteLine();

        // Simulate Shell Prompt
        Console.WriteLine("Please Enter a number corresponding to the option you would like to chose: ");

        var input = Console.ReadLine();

        switch (input)
    {
        case "5":
            System.Environment.Exit(0);
            break;

        case "1":
            Console.WriteLine("Listing Items...");
            Console.WriteLine(divider);
            list.ListItems();
            Console.WriteLine();
            Thread.Sleep(1000);
            break;

        case "2":
            Console.WriteLine("Which item info do you wish to see? ");
            var item = Console.ReadLine();
            Console.WriteLine();
            if (item != null) list.ListDetailedItemInfo(item);
            else
            {
                Console.WriteLine("Item Not Found");
            }
            break;

        case "3":
            Console.WriteLine(divider);
            Console.WriteLine("Please add the following info: ");
            // get title
            Console.Write("Title: ");
            var title = Console.ReadLine();

            // get description
            Console.Write("Description: ");
            var description = Console.ReadLine();

            // get Priority
            Console.Write("Priority: ");
            var priority = Console.ReadLine();

            // get status
            Console.Write("Status: ");
            var status = Console.ReadLine();

            // Due Date
            Console.Write("Due Date (Format yyyy mm dd: ");
            var date = Console.ReadLine();
            if (date != null)
            {
                var dateArray = date.Split(" ");
                var dueDate = new DateOnly(int.Parse(dateArray[0]), int.Parse(dateArray[1]), int.Parse(dateArray[2]));
                Console.WriteLine();

                // Add item to list
                if (title != null)
                {
                    Console.WriteLine(list.AddItem(new ToDoListItem(title, description, priority, status, dueDate)));
                }
                else
                {
                    Console.WriteLine("Title Cannot Be Empty");
                }
            }
            else
            {
                Console.WriteLine("Date Cannot Be Empty");
            }

            Thread.Sleep(1000);
            break;

        case "4":
            Console.WriteLine("Enter the title of the item you wish to remove: ");
            Console.WriteLine(list.RemoveItem(Console.ReadLine()));
            Thread.Sleep(1000);
            break;

        default:
            Console.WriteLine("Invalid Input. Please Try Again.");
            break;
    }

        
}
