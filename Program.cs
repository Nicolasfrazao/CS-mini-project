using System;
using System.Threading;

public class TurnOff
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// </summary>
        public static void Main()
        {
        }

        public static void Start() {
            
        }

        public static void Welcome() {
        }

        pu
        public static void TurnOffComputer() {

        }



        public static void RegisterInSystem() {
            // Check if the program is already registered in the system
            //##TODO
            /*
            if (IsRegistered()) {
                Console.WriteLine("The program is already registered in the system.");
                return;
            }

            // Register the program in the system
            Register();
            */
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