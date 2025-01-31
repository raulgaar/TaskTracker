using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program 
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Use: task-cli [command] [arguments]");
            return;
        }

        string command = args[0];

        switch (command)
        {
            case "add":
                if (args.Length < 2)
                {
                    Console.WriteLine("Use: task-cli add \"Task Description\"");
                    return;
                }
                TaskManager.AddTask(args[1]);
                break;
            
            case "list":
                TaskManager.ListTasks();
                break;
            
            default:
                Console.WriteLine("Command not found.");
                break;
        }
    }
}