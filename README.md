# SmartTaskManager

A console-based task management system built with C# demonstrating core Object-Oriented Programming principles.

## 📋 Project Overview

SmartTaskManager is a comprehensive OOP project that implements a personal productivity platform. Users can create accounts, manage tasks with different categories (Home, Work, Study), track task status, and organize their daily activities efficiently.

## ✨ Features

### Phase 1 - Core Functionality
- **User Management**: Create and manage user accounts with validation
- **Task Creation**: Add tasks with titles, descriptions, and due dates
- **Status Tracking**: Monitor task progress (Pending, InProgress, Done)
- **Date Validation**: Automatic handling of past dates
- **Search System**: Find tasks by title or status
- **Task Filtering**: View only active (non-completed) tasks

### Phase 2 - Task Categories
- **HomeTask**: Tasks related to household activities (includes Room)
- **WorkTask**: Professional tasks (includes Company)
- **StudyTask**: Academic tasks (includes Subject)

## 🎯 OOP Concepts Demonstrated

- **Encapsulation**: Private fields with controlled access through properties
- **Inheritance**: Specialized task types extend base TaskApp class
- **Polymorphism**: Override methods for customized task display
- **Abstraction**: Clean interfaces hiding implementation complexity
- **Composition**: Users contain collections of tasks

## 🚀 Getting Started

### Prerequisites
- .NET SDK (6.0 or higher)
- Any C# IDE (Visual Studio, VS Code, Rider)

### Installation

1. Clone the repository
```bash
git clone https://github.com/yourusername/SmartTaskManager.git
```

2. Navigate to the project directory
```bash
cd SmartTaskManager
```

3. Run the application
```bash
dotnet run
```

## 📖 Usage Example

```csharp
// Create a task manager
TaskManager manager = new TaskManager();

// Create a user
User user = new User("John Doe", "john@example.com");
manager.AddUser(user);

// Create different task types
HomeTask homeTask = new HomeTask("Clean kitchen", "Deep clean", DateTime.Now.AddDays(1), "Kitchen");
WorkTask workTask = new WorkTask("Finish report", "Q4 report", DateTime.Now.AddDays(5), "TechCorp");
StudyTask studyTask = new StudyTask("Study OOP", "Learn inheritance", DateTime.Now.AddDays(3), "CS");

// Add tasks to user
user.AddUserTask(homeTask);
user.AddUserTask(workTask);
user.AddUserTask(studyTask);

// Mark task as done
homeTask.MarkAsDone();

// Search tasks
manager.SearchTasks("report");
manager.SearchTasksByStatus(TaskStatus.Pending);

// Get active tasks
var activeTasks = user.GetActiveUserTasks();
```

## 🏗️ Project Structure

```
SmartTaskManager/
├── Program.cs
├── TaskApp.cs          # Base task class
├── HomeTask.cs         # Home-related tasks
├── WorkTask.cs         # Work-related tasks
├── StudyTask.cs        # Study-related tasks
├── User.cs             # User management
├── TaskManager.cs      # System coordinator
└── TaskStatus.cs       # Status enumeration
```

## ✅ Validation Rules

- **User Name**: Must be at least 3 characters
- **Email**: Must contain both '@' and '.'
- **Task Title**: Cannot be empty (defaults to "NO Title")
- **Due Date**: Past dates are automatically set to null
- **Task Status**: Cannot mark already completed tasks as done

## 🎓 Learning Outcomes

This project demonstrates:
- Proper class design and relationships
- Effective use of inheritance hierarchies
- Implementation of polymorphic behavior
- Data validation and error handling
- Clean code organization and structure

## 📝 Future Enhancements

- [ ] Add priority levels to tasks
- [ ] Implement task categories and tags
- [ ] Add file persistence (save/load from JSON)
- [ ] Create recurring tasks
- [ ] Add task reminders and notifications
- [ ] Implement user authentication

## 👤 Author

Your Name - [Your GitHub Profile](https://github.com/yourusername)

## 📄 License

This project is created for educational purposes as part of an OOP course assignment.

## 🙏 Acknowledgments

- Built as part of Object-Oriented Programming coursework
- Demonstrates practical application of OOP principles in C#
