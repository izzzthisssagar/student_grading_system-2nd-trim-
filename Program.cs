using projecttry2;

internal class Program
{
    private static void Main(string[] args)
    {
        // Initialize dependencies means that the program is initializing the dependencies that it needs to run properly
        //dependencies are classes and methods that the program needs to run in order to function properly
    
        //create an instance of the FileHandler class and assign it to the fhHandler variable
        FileHandler fhHandler = new FileHandler();

        //create an instance of the GradeCalculator class and assign it to the gcCalculator variable
        GradeCalculator gcCalculator = new GradeCalculator();

        //create an instance of the StudentManager class and pass the fhHandler and gcCalculator variables as parameters to the constructor
        StudentManager smManager = new StudentManager(fhHandler, gcCalculator);

        // Main program loop
        // this loop will continue to run until the user chooses to exit the program
        //while loop is used to run the program until the user chooses to exit
        while (true)
        {

            // Display menu
            // Console.ForegroundColor is used to change the color of the text in the console
            // Console.WriteLine is used to print the text to the console

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================");
            Console.WriteLine("  STUDENT GRADE SYSTEM");
            Console.WriteLine("======================");

            Console.WriteLine("1. Create Student");
            Console.WriteLine("2. Enter Initial Marks");
            Console.WriteLine("3. Update Marks");
            Console.WriteLine("4. View Record");
            Console.WriteLine("5. Exit");
            Console.ResetColor();

            // Get user choice
            // Console.Write is used to print the text to the console without a new line
            Console.Write("\nChoose option (1-5): ");
            // Read user input an store it in the sChoice variable
            string sChoice = Console.ReadLine();

            // Process user selection
            // switch statement is used to execute different code blocks based on the value of the sChoice variable
            switch (sChoice)
            {
                // if the user chooses option 1, the program will call the CreateStudent method
                case "1":
                    //smManager is an instance of the StudentManager class
                    //CreateStudent is a method of the StudentManager class that creates a new student record 
                    //and saves it to a file using the FileHandler class
                    //this method will prompt the user to enter the student name and then generate a unique student ID
                    //the student ID will be used as the filename for the student record
                    //and the student name will be saved in the record
                    //the method will also display a success message with the student ID
                    //and return to the main menu
                    smManager.CreateStudent();
                    break;

                //if the user chooses option 2, the program will call the HandleMarks method with the parameter false
                //this method will prompt the user to enter the student ID and then enter the marks for each subject
                //the marks will be validated using the GradeCalculator class and saved to the student record using the FileHandler class
                //the method will also display a success message with the student ID
                //and return to the main menu
                case "2":
                // HandleMarks method is used to enter initial marks for a student
                //(i.e., the marks that are entered for the first time for a student)
                //false indicates that these are initial marks and not updates
                    smManager.HandleMarks(false);
                    break;

                    //if the user chooses option 3, the program will call the HandleMarks method with the parameter true
                    //this method will prompt the user to enter the student ID and then enter the marks for each subject
                    //the marks will be validated using the GradeCalculator class and saved to the student record using the FileHandler class
                    //the method will also display a success message with the student ID
                    //and return to the main menu
                case "3":
                    //HandleMarks method is used to update marks for a student
                    //true indicates that these are updated marks and not initial marks
                    smManager.HandleMarks(true);
                    break;

                    //if the user chooses option 4, the program will call the ShowRecord method
                    //this method will display the student record for the given student ID
                    //the student record will be loaded from the file using the FileHandler class
                    //and displayed on the console
                    //smManager is an instance of the StudentManager class which is responsible for managing student records
                case "4":
                    //ShowRecord method is used to display the student record for a given student ID
                    smManager.ShowRecord();
                    break;

                //if the user chooses option 5, the program will exit
                //this case will break the loop and exit the program
                case "5":
                    Console.WriteLine("\n👋 Exiting system...");
                    return;

                    //if the user enters an invalid choice, the program will display an error message in red
                    //and return to the main menu
                default:
                    // Console.ForegroundColor is used to change the color of the text in the console
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice!");
                    Console.ResetColor();
                    break;
            }
            // Pause before clearing screen
            Console.WriteLine("\nPress any key to continue...");
            // Wait for user input before clearing the screen
            Console.ReadKey();
        }
    }
}