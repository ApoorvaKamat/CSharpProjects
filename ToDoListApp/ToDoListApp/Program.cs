using System;


namespace ToDoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var taskList = new TaskList();
            
            var doTask = true;

            while (doTask)
            {
                Console.WriteLine("\n Press A to Add new Item \n B to View the List" +
                                  "\n D to Delete Item from List, \n E to Edit List item" +
                                  "\n C to mark an Item Completed");
                var userSelection = Console.ReadKey().Key.ToString();
                if (userSelection.Equals("A", StringComparison.OrdinalIgnoreCase))
                {
                    taskList.NewTaskItem();
                }
                else if (userSelection.Equals("B", StringComparison.OrdinalIgnoreCase))
                {
                    taskList.DisplayTaskList();
                }
                else if (userSelection.Equals("D", StringComparison.OrdinalIgnoreCase))
                {
                    taskList.DeleteTaskItem();
                }
                else if (userSelection.Equals("E", StringComparison.OrdinalIgnoreCase))
                {
                    taskList.EditListItem();
                }
                else if (userSelection.Equals("C", StringComparison.OrdinalIgnoreCase))
                {
                    taskList.MarkCompletedItems();
                }
                else if (userSelection.Equals(ConsoleKey.Escape.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    doTask = false;
                }
            }
            
            
        }
    }
}
