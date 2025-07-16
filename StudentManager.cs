using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecttry2
{
   
    /// Manages student records and user interactions
  
    public class StudentManager
    {
        // Dependencies for file handling and calculation 

        // FileHandler is responsible for all file operations like saving/loading records
        //private means this class is used to handle file operations for student records 
        //readonly means that the value of the field cannot be changed once it is assigned
        //FileHandler is a class that handles file operations for student records
        //fhFileHandler is an instance of the FileHandler class
        private readonly FileHandler fhFileHandler;


        //GradeCalculator is used to calculate grades and validate marks 
        //private means this class is used to handle grade calculations for student records
        //readonly means that the value of the field cannot be changed once it is assigned
        //GradeCalculator is a class that handles grade calculations and validation of marks
        //gcGradeCalculator is an instance of the GradeCalculator class
        private readonly GradeCalculator gcGradeCalculator;


        /// Initialize dependencies


        //StudentManager is a constructor that takes two parameters, fhHandler and gcCalculator
        //fhHandler is an instance of the FileHandler class that handles file operations for student records
        //gcCalculator is an instance of the GradeCalculator class that handles grade calculations and validation of marks
        //The constructor initializes the fhFileHandler and gcGradeCalculator fields with the values passed in as parameters
        //public means that this class can be accessed from outside the assembly
        public StudentManager(FileHandler fhHandler, GradeCalculator gcCalculator)
        {
            //fhFileHandler is assigned the value of fhHandler
            fhFileHandler = fhHandler;

            //gcGradeCalculator is assigned the value of gcCalculator
            gcGradeCalculator = gcCalculator;
        }

        
        /// Creates a new student record 
        //void means that this method does not return a value
        //public means that this method can be accessed from outside the assembly

        public void CreateStudent()
        {
            //try catch block is used to handle exceptions that may occur during the execution of the code
            try
            {
                // Generate unique student ID and store it in sStudentId variable
                string sStudentId = fhFileHandler.GenerateStudentId();

                // Get student name from user
                Console.Write("Enter student name: ");
       
                //Console.ReadLine().Trim() is a method that reads a line of text from the console and removes any leading or trailing whitespace characters from the string
               //studentName is a variable that stores the name of the student
                string sStudentName = Console.ReadLine().Trim();

                // Validate name input
                //string.IsNullOrEmpty(sStudentName) is a method that checks if the string is null or empty
                if (string.IsNullOrEmpty(sStudentName))
                {
                    //ShowError is a method that displays an error message to the user
                    ShowError("Student name cannot be empty!");
                    return;
                }

                // Create initial record structure
                //fhFileHandler.SaveRecord is a method that saves the student record to a file
                //sStudentId is the variable that stores the student ID
                //sData is the variable that stores the student data
                //The SaveRecord method is called to save the student record to a file with the student ID as the filename
                fhFileHandler.SaveRecord(sStudentId, $"STUDENT RECORD\nID: {sStudentId}\nName: {sStudentName}\n");
                Console.WriteLine($"\n✅ Student created! ID: {sStudentId}");
            }
            //catch is a block of code that is executed if an exception is thrown in the try block
            //Exception ex is a variable that stores the exception that was thrown
            catch (Exception ex)
            {
                //ShowError is a method that displays an error message to the user
                ShowError($"Creation failed: {ex.Message}");
            }
        }


        /// Handles marks entry (initial or update)
        /// /// bIsUpdate indicates if this is an update operation
        /// bool is a data type that represents a boolean value (true or false) an here we are passing a boolean value

        public void HandleMarks(bool bIsUpdate)
        {
            //try catch block is used to handle exceptions that may occur during the execution of the code
            try
            {
                // Get student ID from user
                Console.Write("Enter student ID: ");

                //saving the student ID entered by the user in a variable called sStudentId
                string sStudentId = Console.ReadLine();

                // Load existing record
                //fhFileHandler.LoadRecord is a method that loads the student record from a file
                string sRecord = fhFileHandler.LoadRecord(sStudentId);

                // Check if student exists
                //if sRecord is null, it means that the student record does not exist
                if (sRecord == null)
                {
                    //ShowError is a method that displays an error message to the user
                    ShowError("Student not found!");
                    return;
                }

                // Array to store 6 subject marks
                int[] iMarks = new int[6];
               
                //for loop is used to iterate over the array of marks
                for (int i = 0; i < 6; i++)
                {
                    // Prompt for each subject mark
                    Console.Write($"Enter mark for subject{i + 1}: ");


                    // Input validation loop
                    //int.TryParse is a method that tries to convert the input string to an integer
                    //Console.ReadLine() is a method that reads a line of text from the console
                    
                    //while loop is used to validate the input
                    //if the input is not a valid integer or is not in the range of 0-100, the loop continues to prompt the user for a valid input
                    //out is a variable that stores the integer value of the input

                    while (!int.TryParse(Console.ReadLine(), out iMarks[i]) || iMarks[i] < 0 || iMarks[i] > 100)
                        Console.Write("Invalid input! Enter 0-100: ");

                }

                // Validate all marks
                // gcGradeCalculator.ValidateMarks is a method that validates the marks entered by the user
                if (!gcGradeCalculator.ValidateMarks(iMarks))
                {
                    //ShowError is a method that displays an error message to the user
                    ShowError("All marks must be between 0 and 100!");
                    return;
                }



                // Calculate results
                //gcGradeCalculator.CalculateAverage is a method that calculates the average of the marks entered by the user
                double dAverage = gcGradeCalculator.CalculateAverage(iMarks);
                //gcGradeCalculator.DetermineStatus is a method that determines the pass/fail status of the student based on the average of the marks entered by the user
                string sStatus = gcGradeCalculator.DetermineStatus(dAverage);

                // Create timestamped entry
                // DateTime.Now is a method that returns the current date and time
                //sEntry is a variable that stores the entry to be saved in the student record
                //string.Join is a method that joins the elements of an array into a single string, separated by a specified separator
                string sEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}\n" +
                               $"MARKS: {string.Join(", ", iMarks)}\n" +
                               $"AVERAGE: {dAverage}\nSTATUS: {sStatus}\n";

                // Update or create record
                //if bIsUpdate is true, the record is updated using the AppendRecord method
                if (bIsUpdate)
                {
                    //fhFileHandler.AppendRecord is a method that appends the entry to the student record
                    fhFileHandler.AppendRecord(sStudentId, $"\nUPDATE\n{sEntry}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n🔄 Marks updated successfully!");
                    Console.ResetColor();
                }
                //if bIsUpdate is false, the record is created using the SaveRecord method
                else
                {      
                    //fhFileHandler.SaveRecord is a method that saves the entry to the student record
                    fhFileHandler.SaveRecord(sStudentId, $"{sRecord}\nINITIAL MARKS\n{sEntry}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n📥 Initial marks saved!");
                    Console.ResetColor();
                }
            }
            //catch is a block of code that is executed if an exception is thrown in the try block
            //Exception ex is a variable that stores the exception that was thrown
            catch (Exception ex)
            {
            //ShowError is a method that displays an error message to the user
                ShowError($"Operation failed: {ex.Message}");
            }
        }


        /// Displays student record
        //ShowRecord is a method that displays the student record
        //void means that this method does not return a value
        //public means that this method can be accessed from outside the assembly
        //this method is called when the user selects the "Show Record" option from the menu
        public void ShowRecord()
        {
            //try catch block is used to handle exceptions that may occur during the execution of the code
            //try is a block of code that is executed if no exceptions are thrown
            try
            {
                // Get student ID from user
                Console.Write("Enter student ID: ");
                //save the input from the user in the variable sStudentId
                string sStudentId = Console.ReadLine();

                // Load record from file
                //fhFileHandler.LoadRecord is a method that loads the student record from the file
                //sRecord is a variable that stores the student record loaded from the file
                //if the record is not found, sRecord will be null
                string sRecord = fhFileHandler.LoadRecord(sStudentId);

                // Display results
                //if sRecord is not null, it means that the record was found and it is displayed to the user
                Console.WriteLine(sRecord != null
                    ? $"\n📖 STUDENT RECORD:\n{sRecord}"
                    : "\n❌ Record not found!");
            }
            //catch is a block of code that is executed if an exception is thrown in the try block
            //Exception ex is a variable that stores the exception that was thrown
            catch (Exception ex)
            {
                //ShowError is a method that displays an error message to the user
                ShowError($"Error: {ex.Message}");
            }
        }

        /// Displays error messages in red
      // /// This method is used to display error messages to the user in red color
        /// void means that this method does not return a value
        private void ShowError(string sMessage)
        {
            // Console.ForegroundColor is a property that sets the color of the text in the console
            Console.ForegroundColor = ConsoleColor.Red;
            // Console.WriteLine is a method that writes the specified message to the console
            Console.WriteLine($"\n❌ {sMessage}");
            Console.ResetColor();
        }
    }
}
