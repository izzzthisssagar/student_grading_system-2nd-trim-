using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projecttry2
{

    // Class to handle grade calculations
    //create a class called GradeCalculator
    // This class is responsible for calculating grades, validating marks, and determining pass/fail status
    public class GradeCalculator
    {
        // Check if all marks are valid (0-100)
        // This method takes an array of marks and returns true if all are valid, false otherwise
        // create a method called ValidateMarks
        //bool is a data type that represents a boolean value (true or false) an here we are returning a boolean value 
        public bool ValidateMarks(int[] marks)
        {
            // This loop iterates through each mark in the array and checks if it is within the valid range of 0-100
            // if the mark is less than 0 or greater than 100, the method returns false
            // if the mark is within the valid range, the loop continues to the next mark
            // all int marks are stored in the array and again stored in the variable mark
            foreach (int mark in marks)
            {
                if (mark < 0 || mark > 100)
                {
                    return false;
                }
            }
            return true;
        }

        // Calculate average of marks
     
        // create a method called CalculateAverage
        // the method takes an array of int marks and returns a double value
        // the method calculates the total of all marks and divides it by the number of marks to get the average
        // the average is then rounded to 2 decimal places using the Math.Round method
        // the method returns the average

        public double CalculateAverage(int[] marks)
        {
            // create a variable called total and set it to 0
            int total = 0;

            // This loop iterates through each mark in the array and adds it to the total
            foreach (int mark in marks)
            {
                // the mark is added to the total
                total += mark;
            }
            // the total is divided by the number of marks to get the average
            double average = (double)total / marks.Length;

            return Math.Round(average, 2);
        }

        // Determine pass/fail status
        // This method takes the average of marks and returns "Passed" if average >= 40, otherwise "Failed"
        // create a method called DetermineStatus
        // the method takes a double value called average and returns a string value
        // the method checks if the average is greater than or equal to 40
        public string DetermineStatus(double average)
        {
            // if the average is greater than or equal to 40, the method returns "Passed"
            if (average >= 40)
            {
                return "Passed";
            }
            // if the average is less than 40, the method returns "Failed"
            else
            {
                return "Failed";
            }
        }
    }
}
