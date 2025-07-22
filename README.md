# Student Grading System

A console-based Student Grading System for academic purposes, developed in C#. This project allows efficient management and evaluation of student grades by supporting record-keeping, grade calculation, and basic reporting.

## Features

- **Student Management**
  - Add, update, search, and delete student records.
  - Unique student identification via ID or roll number.

- **Grade Management**
  - Input scores for assignments, quizzes, projects, and exams.
  - Automatic computation of total, percentage, and final grade.
  - Supports modification or removal of grade entries.

- **File Handling**
  - Save and load student and grade data using text files for persistent storage during sessions.

- **Reports**
  - Generate simple mark sheets displaying scores, grades, and remarks.
  - Display all records or search by student.

- **Console Interface**
  - User-friendly prompts and navigation for performing actions.

## Technologies

- **Language:** C#
- **Platform:** .NET Core/Framework (Console Application)
- **IDE:** Visual Studio

## Project Structure

```plaintext
student_grading_system-2nd-trim-
├─ .gitignore
├─ FileHandler.cs         // Handles reading/writing student data to files
├─ GradeCalculator.cs     // Contains grade computation logic
├─ Program.cs             // Entry point, drives menu and system logic
├─ StudentManager.cs      // Student record management and utilities
├─ studentRecords/        // (Folder for sample/output record files)
├─ projecttry2.csproj
├─ projecttry2.sln
```

## Getting Started

### Prerequisites

- Visual Studio 2019 or newer
- .NET Framework 4.7.2 or later / .NET Core (version matching project file)
- Basic understanding of console applications

### How to Run

1. **Clone this repository:**
   ```bash
   git clone https://github.com/izzzthisssagar/student_grading_system-2nd-trim-
   ```

2. **Open the solution file** (`projecttry2.sln`) with Visual Studio.

3. **Restore NuGet packages** if prompted.

4. **Build the project:** `Build > Build Solution`.

5. **Run the application:** Start without debugging (Ctrl+F5).

## Usage

- Navigate menu options to add/manage students or grades.
- Enter student details as prompted (ID, name, scores).
- View, modify, or delete existing records.
- Review grade summaries and mark sheets output to the console or files.

## Example Menu Flow

```csharp
Console.WriteLine("1. Add Student");
Console.WriteLine("2. Enter Grades");
Console.WriteLine("3. View Student Records");
Console.WriteLine("4. Search Student");
Console.WriteLine("5. Delete Record");
Console.WriteLine("6. Exit");
```

## Grading Logic

| Marks/Percentage        | Grade | Remarks      |
|-------------------------|-------|--------------|
| 90–100                  | A     | Excellent    |
| 80–89                   | B     | Very Good    |
| 70–79                   | C     | Good         |
| 60–69                   | D     | Satisfactory |
| Below 60                | F     | Poor         |

*(Actual ranges/logic may be adjusted in `GradeCalculator.cs`.)*

## Limitations

- Data is stored in local files; no database integration.
- Single-user, console-based interface.
- No advanced authentication or role management.

## Contributing

Contributions are welcome! Fork the repository, create a branch, and submit a pull request with your suggestions or improvements.

## License

This project is open-source and intended for educational/demo use.

## Contact

For issues or questions, please open an issue on the repository.
