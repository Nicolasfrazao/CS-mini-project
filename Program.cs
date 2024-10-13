using System;
using System.Threading;
using Microsoft.VisualBasic;

using Tests;

public class TurnOff
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// </summary>
        public static void Main()
        {
            RunTest();
            Start();
        }

        public static void Start() {
            //TODO
            //Manage the program
        }

        public static void placeholder() {
            //TODO
            //Placeholder for the time in console
        }

        public static void InputWithPlaceholder() {
            //TODO
            //Remove the placeholder and allow the user to input the time
            //Provindg an example to the user
        }

        public static void Welcome() {
            //TODO
            //Gives a welcome message to the user
        }

        public string GetTime() {
            //TODO
            //Get the current time
            string DateFormat = "HH : MM";

            DateTime currentTime = DateTime.Now;
            string CurrentTime = currentTime.ToString(DateFormat);

            return CurrentTime;   
        }
        
        public void SetTime(string time) {
            //TODO
            //Set the time to turn off the computer
        }

        public void SetLastInputs() {
            //TODO
            //Set the user last five inputs
            //Create a list and add the last inputs
        }

        public string GetLastInputs() {
            //TODO
            //Get the user last five inputs
            //Get the List of last inputs and return in order of the most recent
            return "";
        }

        public void handleUserKeyInput() {
            //TODO
            //Get the user key input
        }


        public static void TurnOffComputer() {
            //TODO
            //Turn off the computer
        }

        public void BackGroundRun() {
            //TODO
            //Run the program in the background
        }

        public static void RegisterInSystem() {
            //TODO
            //Register the user in the system
            //Add the user to the system
            //Add program to the system
            //Program the Program to start with the pc
        }
    }

}

/*
using System;

class Program
{
    static void Main()
    {
        string placeholder = "HH : MM";
        Console.Write(placeholder);

        // Move cursor to start of placeholder
        int startPosition = Console.CursorLeft - placeholder.Length;
        Console.SetCursorPosition(startPosition, Console.CursorTop);

        string timeInput = ReadTimeInputWithPlaceholder(placeholder);
        
        Console.WriteLine("\nYou entered: " + timeInput);
    }

    static string ReadTimeInputWithPlaceholder(string placeholder)
    {
        ConsoleKeyInfo key;
        string userInput = string.Empty;

        while ((key = Console.ReadKey(intercept: true)).Key != ConsoleKey.Enter)
        {
            if (userInput.Length == 0 && key.Key != ConsoleKey.Backspace)
            {
                // Clear placeholder text
                Console.Write(new string(' ', placeholder.Length));
                Console.SetCursorPosition(Console.CursorLeft - placeholder.Length, Console.CursorTop);
            }

            if (key.Key == ConsoleKey.Backspace && userInput.Length > 0)
            {
                // Handle backspace: Remove last character
                userInput = userInput.Substring(0, userInput.Length - 1);
                Console.Write("\b \b"); // Move back, print space to clear, move back again
            }
            else if (key.KeyChar >= '0' && key.KeyChar <= '9')
            {
                // Allow only digits
                if (userInput.Length == 2)
                {
                    userInput += " : ";
                    Console.Write(" : ");
                }
                userInput += key.KeyChar;
                Console.Write(key.KeyChar);
            }
        }

        return userInput;
    }
}


*/