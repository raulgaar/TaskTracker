using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class TaskManager
{
    private static string filePath = "tasks.json";

    public static void AddTask(string description)
    {
        List<TaskItem> tasks = LoadTasks();
        int newId = tasks.Count > 0 ? tasks[^1].Id + 1 : 1;

        TaskItem newTask = new TaskItem
        {
            Id = newId,
            Description = description
        };

        tasks.Add(newTask);
        SaveTasks(tasks);
        
        Console.WriteLine($"Task added: {description} (ID: {newId})");
    }

    public static void ListTasks()
    {
        List<TaskItem> tasks = LoadTasks();
        
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine($"[{task.Id}] {task.Description} - {task.Status}");
        }
    }

    private static List<TaskItem> LoadTasks()
    {
        if (!File.Exists(filePath)) return new List<TaskItem>();

        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    private static void SaveTasks(List<TaskItem> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}