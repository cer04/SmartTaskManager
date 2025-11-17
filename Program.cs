using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartTaskManager
{
    // Enum for task status
    public enum TaskStatus
    {
        Pending,
        InProgress,
        Done
    }

    // Base class for all tasks
    public class TaskApp
    {
        private static int _idCounter = 1;
        
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskStatus Status { get; set; }

        public TaskApp(string title, string description, DateTime? dueDate)
        {
            Id = _idCounter++;
            
            if (string.IsNullOrWhiteSpace(title))
            {
                Title = "NO Title";
            }
            else
            {
                Title = title;
            }
            
            Description = description;
            
            // Check if date is in the past
            if (dueDate.HasValue && dueDate.Value < DateTime.Now)
            {
                DueDate = null;
            }
            else
            {
                DueDate = dueDate;
            }
            
            Status = TaskStatus.Pending;
        }

        public virtual void MarkAsDone()
        {
            if (Status == TaskStatus.Done)
            {
                Console.WriteLine("Task is already done.");
                return;
            }
            Status = TaskStatus.Done;
            Console.WriteLine($"Task '{Title}' marked as done.");
        }

        public virtual string GetFormattedDueDate()
        {
            if (DueDate.HasValue)
            {
                return $"{DueDate.Value.Day} - {DueDate.Value.Month} - {DueDate.Value.Year}";
            }
            return "No due date";
        }

        public virtual void DisplayTask()
        {
            Console.WriteLine($"ID: {Id} | Title: {Title} | Status: {Status} | Due: {GetFormattedDueDate()}");
            Console.WriteLine($"Description: {Description}");
        }
    }

    // HomeTask class
    public class HomeTask : TaskApp
    {
        public string Room { get; set; }

        public HomeTask(string title, string description, DateTime? dueDate, string room)
            : base(title, description, dueDate)
        {
            Room = room;
        }

        public override void DisplayTask()
        {
            base.DisplayTask();
            Console.WriteLine($"Room: {Room}");
        }
    }

    // WorkTask class
    public class WorkTask : TaskApp
    {
        public string Company { get; set; }

        public WorkTask(string title, string description, DateTime? dueDate, string company)
            : base(title, description, dueDate)
        {
            Company = company;
        }

        public override void DisplayTask()
        {
            base.DisplayTask();
            Console.WriteLine($"Company: {Company}");
        }
    }

    // StudyTask class
    public class StudyTask : TaskApp
    {
        public string Subject { get; set; }

        public StudyTask(string title, string description, DateTime? dueDate, string subject)
            : base(title, description, dueDate)
        {
            Subject = subject;
        }

        public override void DisplayTask()
        {
            base.DisplayTask();
            Console.WriteLine($"Subject: {Subject}");
        }
    }

    // User class
    public class User
    {
        private static int _idCounter = 1;
        
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<TaskApp> Tasks { get; set; }

        public User(string name, string email)
        {
            Id = _idCounter++;
            Tasks = new List<TaskApp>();
            
            if (name.Length < 3)
            {
                Console.WriteLine("Invalid name");
                Name = "Invalid";
            }
            else
            {
                Name = name;
            }
            
            if (!email.Contains("@") || !email.Contains("."))
            {
                Console.WriteLine("Invalid email");
                Email = "Invalid";
            }
            else
            {
                Email = email;
            }
        }

        public void AddUserTask(TaskApp task)
        {
            Tasks.Add(task);
            Console.WriteLine($"Task '{task.Title}' added to user {Name}.");
        }

        public void RemoveUserTask(int taskId)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                Tasks.Remove(task);
                Console.WriteLine($"Task ID {taskId} removed.");
            }
            else
            {
                Console.WriteLine($"Task ID {taskId} not found.");
            }
        }

        public List<TaskApp> GetActiveUserTasks()
        {
            return Tasks.Where(t => t.Status != TaskStatus.Done).ToList();
        }

        public void DisplayUser()
        {
            Console.WriteLine($"\nUser ID: {Id} | Name: {Name} | Email: {Email}");
            Console.WriteLine($"Total Tasks: {Tasks.Count}");
        }
    }

    // Task Manager class
    public class TaskManager
    {
        private List<User> users;
        private List<TaskApp> allTasks;

        public TaskManager()
        {
            users = new List<User>();
            allTasks = new List<TaskApp>();
        }

        public void AddUser(User user)
        {
            users.Add(user);
            Console.WriteLine($"User '{user.Name}' added successfully.");
        }

        public void AddTask(TaskApp task)
        {
            allTasks.Add(task);
            Console.WriteLine($"Task '{task.Title}' added to system.");
        }

        public void ListAllTasks()
        {
            if (allTasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }

            Console.WriteLine("\n=== All Tasks ===");
            foreach (var task in allTasks)
            {
                task.DisplayTask();
                Console.WriteLine("---");
            }
        }

        public void SearchTasks(string searchTerm)
        {
            var results = allTasks.Where(t => 
                t.Title.ToLower().Contains(searchTerm.ToLower())).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }

            Console.WriteLine($"\n=== Search Results for '{searchTerm}' ===");
            foreach (var task in results)
            {
                task.DisplayTask();
                Console.WriteLine("---");
            }
        }

        public void SearchTasksByStatus(TaskStatus status)
        {
            var results = allTasks.Where(t => t.Status == status).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }

            Console.WriteLine($"\n=== Tasks with Status: {status} ===");
            foreach (var task in results)
            {
                task.DisplayTask();
                Console.WriteLine("---");
            }
        }

        public void ListAllUsers()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("No users available.");
                return;
            }

            Console.WriteLine("\n=== All Users ===");
            foreach (var user in users)
            {
                user.DisplayUser();
            }
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();

            Console.WriteLine("=== Smart Task Manager System ===\n");

            // Create users
            User user1 = new User("John Doe", "john@example.com");
            User user2 = new User("Al", "invalid-email"); // Will show invalid email
            
            manager.AddUser(user1);
            manager.AddUser(user2);

            // Create various tasks
            TaskApp task1 = new TaskApp("Buy groceries", "Get milk and bread", DateTime.Now.AddDays(2));
            HomeTask task2 = new HomeTask("Clean kitchen", "Deep clean", DateTime.Now.AddDays(1), "Kitchen");
            WorkTask task3 = new WorkTask("Finish report", "Q4 report", DateTime.Now.AddDays(5), "TechCorp");
            StudyTask task4 = new StudyTask("Study OOP", "Learn inheritance", DateTime.Now.AddDays(3), "Computer Science");
            
            // Add tasks to system
            manager.AddTask(task1);
            manager.AddTask(task2);
            manager.AddTask(task3);
            manager.AddTask(task4);

            // Add tasks to user
            user1.AddUserTask(task1);
            user1.AddUserTask(task2);
            user1.AddUserTask(task3);

            // Display all tasks
            manager.ListAllTasks();

            // Mark a task as done
            Console.WriteLine("\n=== Marking Task as Done ===");
            task1.MarkAsDone();

            // Search tasks
            Console.WriteLine("\n=== Search Feature ===");
            manager.SearchTasks("clean");
            manager.SearchTasksByStatus(TaskStatus.Pending);

            // Display active tasks for user
            Console.WriteLine("\n=== Active Tasks for User ===");
            var activeTasks = user1.GetActiveUserTasks();
            Console.WriteLine($"User {user1.Name} has {activeTasks.Count} active tasks:");
            foreach (var task in activeTasks)
            {
                task.DisplayTask();
                Console.WriteLine("---");
            }

            // Remove a task from user
            Console.WriteLine("\n=== Remove Task ===");
            user1.RemoveUserTask(task2.Id);

            // List all users
            manager.ListAllUsers();

            Console.WriteLine("\n=== Program Complete ===");
        }
    }
}