using System;
using System.Threading;
using Microsoft.VisualBasic;


public class TurnOff
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// </summary>
        public static void Main()
        {
            Welcome();


        }

        public static void Start() {
            //TODO
            //Manage the program
            Console.WriteLine("Starting . . . ");
            HandleUserKeyInput();
        }

        public static void placeholder() {
            //TODO
            //Placeholder for the time in console
            string PlaceHolderTime = "HH : MM";
            Console.WriteLine(PlaceHolderTime);

            int CursorStartPosition = Console.CursorLeft - PlaceHolderTime.Length;
            Console.SetCursorPosition(CursorStartPosition, Console.CursorTop);

            
            string timeInput = InputWithPlaceholder(Pl);
        
            Console.WriteLine("\nYou entered: " + timeInput);

        }

        static string InputWithPlaceholder(string placeholder) {
            //TODO
            //Remove he placeholder and allow the user to input the time
            //Providing an example to the user

            return "";
        }

        static void Welcome() {
            //TODO
            //Gives a welcome message to the user
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Welcome to the TurnOff program!");
            Console.WriteLine("This program will turn off your computer at a specific time.");
            Console.WriteLine("Please enter the time you would like to turn off your computer.");
            Console.WriteLine("------------------------------------------------------------------"); Console.WriteLine("");
            Console.WriteLine("Press Enter to continue... or Press Esc to exit the program.");         

            HandleUserKeyInput();

            if (HandleUserKeyInput() == true) {
                Start();
            }   
        }

        string GetTime() {
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

        private static Boolean HandleUserKeyInput() {
            //TODO
            //Get the user key input

            if ( Console.ReadKey(intercept: true).Key == ConsoleKey.Enter) {
                Console.WriteLine("Continuing the program...");
                return true;
            }

            if (Console.ReadKey(intercept: true).Key == ConsoleKey.Escape) {
                //Exit the program
                Console.WriteLine("Exiting the program...");
                for (int i = 0; i < 5; i++) {
                    Console.WriteLine("Exiting in " + (5 - i) + " seconds...");
                    Thread.Sleep(1000);
                }
                Environment.Exit(0);
                return false;
            }
            else {
                Console.WriteLine("Invalid input. Please try again.");
                return HandleUserKeyInput();
            }
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