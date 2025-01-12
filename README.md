# Task Manager

A simple and user-friendly web application to manage tasks. Users can create, update, and delete tasks, track their status (Pending, In Progress, Completed), and set due dates for efficient task management.

## Technologies Used

- **Backend:** ASP.NET Core
- **Frontend:** HTML, CSS, JavaScript, Bootstrap
- **Database:** SQL Server (EF Core)
- **API:** RESTful API with CRUD operations

## Features

- **Task Management:** Create, edit, and delete tasks.
- **Status Management:** Track the status of each task (Pending, In Progress, Completed).
- **Due Dates:** Set and manage due dates for each task.
- **Responsive UI:** User-friendly interface to manage tasks with dynamic updates.
- **Color-Coded Status:** Tasks are color-coded based on their status for easy identification.
  
## Installation Instructions

1. **Clone the repository:**

   git clone https://github.com/AymanBerri/TaskManager.git


2. **Install dependencies:**
    ### Backend Dependencies (ASP.NET Core)

    - **Microsoft.AspNetCore.Mvc**: For building the Web API.
    - **Microsoft.EntityFrameworkCore**: For database access with Entity Framework Core.
    - **Microsoft.EntityFrameworkCore.SqlServer**: For SQL Server integration with Entity Framework Core.
    - **Microsoft.EntityFrameworkCore.Tools**: For EF Core tools like migrations.

    ### Frontend Dependencies

    - **Bootstrap**: For styling the frontend (task list table, forms, etc.).
    - **jQuery** (Optional): For DOM manipulation if needed.

    ### Database

    - **SQL Server**: This project uses SQL Server as the database. Ensure that you have SQL Server installed and configured on your machine or server for the application to work properly.


3. **Set up the database:**
    1. Create the initial migration:
    ``` dotnet ef migrations add InitialCreate ```

    2. Update the database to apply the migration:
    ``` dotnet ef database update```

4. **Configure the environment:**
   - Make sure your `appsettings.json` contains the correct connection string to the database.

## How to Run

1. Open the project in Visual Studio or your preferred editor.
2. Run the project using the command:

   ```dotnet run```

   This will start the web server locally, usually accessible at `https://localhost:5410`.

3. Open your browser and navigate to `https://localhost:5410` to use the Task Manager application.

## API Endpoints

### GET /api/tasks
Retrieve all tasks in the system.

### GET /api/tasks/{id}
Retrieve a task by its ID.

### POST /api/tasks
Create a new task. (Body: `title`, `description`, `status`, `dueDate`)

### PUT /api/tasks/{id}
Update an existing task by its ID. (Body: `title`, `description`, `status`, `dueDate`)

### DELETE /api/tasks/{id}
Delete a task by its ID.


## Contributions

Contributions are welcome! If you'd like to contribute to the project, please fork the repository, make your changes, and submit a pull request.

