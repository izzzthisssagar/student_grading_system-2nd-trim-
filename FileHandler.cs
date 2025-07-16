using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecttry2
{
    /// Handles all file operations for student records
    //create a new class called FileHandler
    // This class is responsible for generating student IDs, saving/loading records, and checking existence of records

    public class FileHandler
    {
        // Constant base path for storing student files
        // This is the directory where all student records will be stored
        private const string sBasePath = @"C:\Users\LOQ\Desktop\ismt\2nd trim\programming\projecttry2/studentRecords";

        // Random number generator for creating student IDs
        // This is used to generate a unique 8-digit student ID
        // It ensures that each student ID is unique and not already in use
        // Using a static instance to avoid creating multiple Random objects
        // This improves performance and ensures better randomness
        private static readonly Random sRandom = new Random();



        /// Constructor ensures storage directory exists
         /// Initializes the file handler and creates the base directory if it doesn't exist
        public FileHandler()
        {
            // Create directory if it doesn't exist
            Directory.CreateDirectory(sBasePath);
        }

        
        /// Generates a unique 8-digit student ID
        /// /// This method generates a random 8-digit number between 10,000,000 and 99,999,999
        /// It repeats the generation process until a unique ID is found
        /// This ensures that each student ID is unique and not already in use
        /// The generated ID is returned as a string
        
        public string GenerateStudentId()
        {
            // Declare a variable to store the generated student ID
            int iStudentId;

            // Loop until a unique student ID is found
            do
            {
                // Generate random 8-digit number between 10,000,000 and 99,999,999
                iStudentId = sRandom.Next(10000000, 100000000);
            }
            
            //  Check if the generated ID already exists in the records and repeat the process until a unique ID is found
            while (StudentExists(iStudentId.ToString()));

            // Return the generated student ID as a string
            return iStudentId.ToString();
        }


        /// Saves student data to a text file
        /// This method writes the provided student data to a text file with the student ID as the filename
        /// The file is saved in the base directory specified by the sBasePath constant
        /// The method overwrites any existing content in the file
        ///creates a method called SaveRecord which takes two parameters, sStudentId and sData
        /// sStudentId is a string representing the student ID
        /// sData is a string representing the student data to be saved
        /// 
        public void SaveRecord(string sStudentId, string sData)
        {
            // Write all text to file (overwrites existing content)
            // The File.WriteAllText method is used to write the provided student data to a text file with the student ID as the filename
            // The file is saved in the base directory specified by the sBasePath constant
            // The GetFilePath method is used to construct the full file path by combining the base path with the student ID filename

            File.WriteAllText(GetFilePath(sStudentId), sData);
            
        }

        /// Loads student data from file
        /// This method reads the contents of the text file associated with the provided student ID
        /// The file is located in the base directory specified by the sBasePath constant
        /// The method returns the contents of the file as a string
        /// If the file does not exist, the method returns null
        
        public string LoadRecord(string sStudentId)

        {
            // Check if file exists before reading
            // get the file path using the GetFilePath method
            string sPath = GetFilePath(sStudentId);

            // Check if file exists before reading
            if (!File.Exists(sPath))
            { 
               // If the file does not exist, return null
                return null;
            }
            // If the file exists, read the contents and return as a string
            // The File.ReadAllText method is used to read the contents of the text file associated with the provided student ID

            else
            {
                // Read all text from file and return
                return File.ReadAllText(sPath);
            }
        }

       
        /// Appends new data to existing student record
        /// This method appends the provided data to the end of the text file associated with the provided student ID
        /// The file is located in the base directory specified by the sBasePath constant
        /// The method adds a new line with the timestamped data
        /// If the file does not exist, the method creates a new file with the provided data
        /// The AppendRecord method takes two parameters, sStudentId and sData
        /// sStudentId is a string representing the student ID
        /// sData is a string representing the data to be appended to the student record
        
        public void AppendRecord(string sStudentId, string sData)
        {
            // Check if file exists before appending
            if (!File.Exists(GetFilePath(sStudentId)))
            {
                // If the file does not exist, create a new file with the provided data
                SaveRecord(sStudentId, sData);
                return;
            }
            else
            {
                // If the file exists, append the new data to the existing file
                // The File.AppendAllText method is used to append the provided data to the end of the text file associated with the provided student ID
                // The GetFilePath method is used to construct the full file path by combining the base path with the student ID filename
                // The method adds a new line with the timestamped data
                File.AppendAllText(GetFilePath(sStudentId), $"\n{sData}");
            }



        }

        
        /// Helper method to construct full file path
        /// This method constructs the full file path by combining the base path with the student ID filename
        /// The GetFilePath method takes one parameter, sStudentId
        /// sStudentId is a string representing the student ID
        /// The method returns the full file path as a string
        private string GetFilePath(string sStudentId)
        {
            
            // Combine base path with student ID filename
            // The Path.Combine method is used to combine the base path with the student ID filename
            // The student ID filename is constructed by appending the ".txt" extension to the student ID
            // The base path is specified by the sBasePath constant
            // The full file path is returned as a string

            return Path.Combine(sBasePath, $"{sStudentId}.txt");
        }

       
        /// Checks if student record exists
        /// This method checks if the text file associated with the provided student ID exists
        /// The file is located in the base directory specified by the sBasePath constant
        /// The method returns true if the file exists, false otherwise
        /// The StudentExists method takes one parameter, sStudentId
        /// sStudentId is a string representing the student ID
        /// The method returns a boolean value indicating whether the student record exists or not
        private bool StudentExists(string sStudentId)
        {
            // Verify file existence
            // The File.Exists method is used to check if the file associated with the provided student ID exists
            return File.Exists(GetFilePath(sStudentId));
        }
    }
}
