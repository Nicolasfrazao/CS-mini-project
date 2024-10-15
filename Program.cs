﻿using System;
using System.Threading;
using Microsoft.VisualBasic;


public class TurnOff
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// </summary>
        public static void Main() => Welcome();

        public static void Start() {
            // This method is the main entry point for the program once the user has
            // pressed Enter to start the program.
            // It will print out a message to the console, indicating that the program
            // is starting.
            Console.WriteLine("Starting . . . ");

            // The method will then call the HandleUserKeyInput method, which will
            // handle any key presses by the user, such as pressing Enter to continue
            // the program, or pressing Esc to exit the program.
            HandleUserKeyInput();
        }


        public static void placeholder() {
            // This method is a placeholder and does not have any meaningful functionality.
            // It is here to demonstrate how to use the InputWithPlaceholder method.
            // The method will print "HH : MM" to the console, and then move the cursor
            // 8 characters to the left, so that the user can type over the placeholder text.
            Console.Write("HH : MM");
            Console.CursorLeft -= 8;

            // The method will then call the InputWithPlaceholder method, passing in the
            // placeholder text as a parameter.
            var timeInput = InputWithPlaceholder("HH : MM");

            // Finally, the method will print out a message to the console, displaying
            // what the user typed in.
            Console.WriteLine($"\nYou entered: {timeInput}");
        }

        /// <summary>
        /// This method allows the user to input a time in the format of HH:MM.
        /// It displays a placeholder text and waits for the user to press Enter.
        /// The user can type in the time and then press Enter to confirm.
        /// The method will return the time inputted by the user as a string.
        /// </summary>
        /// <param name="placeholderText">The text to display as a placeholder.</param>
        /// <returns>The time inputted by the user as a string.</returns>
        static string InputWithPlaceholder(string placeholderText)
        {
            // Store the user's input in this variable
            var userInput = string.Empty;

            // Store the current position of the cursor in this variable
            var cursorLeft = Console.CursorLeft;

            // Loop until the user presses Enter
            while (true)
            {
                // Read the next key press
                var key = Console.ReadKey(intercept: true);

                // If the user pressed Enter, break out of the loop
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                // If the user pressed Backspace and there is some text to remove, remove it
                if (key.Key == ConsoleKey.Backspace && userInput.Length > 0)
                {
                    userInput = userInput.Substring(0, userInput.Length - 1);
                    Console.Write("\b \b");
                    Console.CursorLeft = cursorLeft;
                }

                // If the user pressed a number key, add it to the input
                else if (key.KeyChar >= '0' && key.KeyChar <= '9')
                {
                    // If the user has already entered two digits, add a colon
                    if (userInput.Length == 2)
                    {
                        userInput += ':';
                        Console.Write(':');
                        cursorLeft++;
                    }

                    // Add the number to the input
                    userInput += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }

            // Return the inputted time as a string
            return userInput;
        }

        static void Welcome() {
            // Prints a welcome message to the console
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Welcome to the TurnOff program!");
            Console.WriteLine("This program will turn off your computer at a specific time.");
            Console.WriteLine("Please enter the time you would like to turn off your computer.");
            Console.WriteLine("------------------------------------------------------------------");

            // Prints a message telling the user to press Enter to continue
            Console.WriteLine("Press Enter to continue...");

            // Prints a message telling the user to press Esc to exit the program
            Console.WriteLine("or Press Esc to exit the program.");
            Console.WriteLine();

            // Calls the HandleUserKeyInput method, which will handle the user's key press
            // If the user presses Enter, the method will return true
            // If the user presses Esc, the method will return false
            if (HandleUserKeyInput() == true) {
                // If the user pressed Enter, call the Start method to start the program
                Start();

                // Clear the console
                Console.Clear();
            } else {
                // If the user pressed Esc, print a message telling the user to select a valid option
                Console.WriteLine("Select a valid option.");
            }
        }
        string GetTime() => DateTime.Now.ToString("HH:mm");
        
        void SetTime(string time) {
            // This method takes a string parameter, which is the time the user wants to set as the time to turn off the computer.
            // It parses the string into a DateTime object, and then checks if the user wants to confirm the time to turn off the computer.
            // If the user confirms, it sets the last input to the time entered by the user, and then calls the TurnOffComputer method to turn off the computer at the specified time.

            var DateFormat = "HH : MM";
            // Parse the string into a DateTime object
            DateTime TimeToTurnOff = DateTime.ParseExact(time, DateFormat, null);

            // Check if the user wants to confirm the time to turn off the computer
            if (HandleUserKeyInput()) {
                // If the user confirms, print a message to the console with the time to turn off the computer
                Console.WriteLine($"Turning off the computer at {TimeToTurnOff}");

                // Set the last input to the time entered by the user
                SetLastInputs(time);

                // Call the TurnOffComputer method to turn off the computer at the specified time
                TurnOffComputer();
            }
        }

        /// <summary>
        /// This method sets the user's last five inputs.
        /// It takes one parameter, a string, which is the time the user wants to set as their last input.
        /// The method creates a list and adds the last input to it.
        /// If the list already has five items, it removes the oldest item.
        /// This is done to ensure that the user's last five inputs are always saved, even if they enter more than five inputs.
        /// </summary>
        /// <param name="time">The time the user wants to set as their last input.</param>
        void SetLastInputs(string time) {
            // Create a list to store the user's last five inputs
            // The list will be used to store the user's last five inputs, in the order that they were entered
            // The list will be used to display the user's last five inputs, so that they can select one of them to use as their next input
            List<string> LastInputs = new List<string>(5);

            // Add the last input to the list
            // The last input is added to the beginning of the list, so that the most recent input is always at the beginning of the list
            LastInputs.Insert(0, time);

            // If the list already has five items, remove the oldest item
            // This is done to ensure that the list never has more than five items
            // If the list had more than five items, the oldest item would be removed, so that the list always has five items
            if (LastInputs.Count > 5) {
                // Remove the oldest item from the list
                // The oldest item is the last item in the list, so we remove it using the RemoveAt method
                LastInputs.RemoveAt(LastInputs.Count - 1);
            }
        }

        /// <summary>
        /// This method gets the user's last five inputs.
        /// It takes a parameter, a List of strings, which is the list of the user's last five inputs.
        /// The method prints the user's last five inputs to the console, with the most recent one first.
        /// Then, it calls the HandleLastInputsSelection method, which handles the user's selection of the last inputs.
        /// Finally, it returns a string with the user's last five inputs, separated by commas.
        /// </summary>
        /// <param name="LastInputs">The List of strings that contains the user's last five inputs.</param>
        /// <returns>A string with the user's last five inputs, separated by commas.</returns>
        string GetLastInputs(List<string> LastInputs) {

            //Print the user's last five inputs to the console
            Console.WriteLine("Last Inputs:");

            //Use a for loop to print the last inputs
            for(int i = 0; i < LastInputs.Count; i++) {
                Console.WriteLine(LastInputs[i] + "\n");
            }

            //Call the HandleLastInputsSelection method to handle the user's selection of the last inputs
            HandleLastInputsSelection();

            //Return a string with the user's last five inputs, separated by commas
            return string.Join(", ", LastInputs);
        }


        private static void HandleLastInputsSelection() {
            var SelectedInput = Console.ReadKey(intercept: true);

            switch (SelectedInput.Key) {
                case ConsoleKey.DownArrow:
                    //TODO
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    break;
                case ConsoleKey.UpArrow:
                    break;

                case ConsoleKey.Enter:
                    var currentInput = GetLastInputs[Console.GetCursorPosition().Top - 1];
                    SetTime(currentInput);
                    break;

                case ConsoleKey.Escape:
                    //Exit the program
                    Console.Clear();
                    Start();
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    //Recursively call the function until the user press a valid key
                    HandleLastInputsSelection();
                    break;
            }
        }

        private static bool HandleUserKeyInput() {
            //This function handles the user key input and perform the action accordingly
            //The user can either press Enter to continue the program, or press Esc to exit the program
            //If the user press an invalid key, the function will recursively call itself until the user press a valid key

            var pressedKey = Console.ReadKey(intercept: true).Key;

            if (pressedKey == ConsoleKey.Enter) {
                Console.WriteLine("Continuing the program...");
                return true;
            }

            if (pressedKey == ConsoleKey.Escape) {
                //Exit the program
                Console.WriteLine("Exiting the program...");
                Thread.Sleep(5000);
                Environment.Exit(0);
                return false;
            }

            Console.WriteLine("Invalid input. Please try again.");
            //Recursively call the function until the user press a valid key
            return HandleUserKeyInput();
        }
        public static void TurnOffComputer() {
            //This function will turn off the computer
            //The function will start a countdown from 10 seconds
            //The countdown will be shown in the console
            //When the countdown reaches 0, the function will turn off the computer
            for (int i = 10; i > 0; i--) {
                Console.WriteLine("Turning off in " + i + " seconds...");
                //Wait for 1 second
                Thread.Sleep(1000);
            }
            //Turn off the computer
            //The "/s" option will shutdown the local computer
            //The "/t 0" option will turn off the computer immediately
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        public void BackGroundRun() {
            //TODO
            //Run the program in the background
            //Ensure that program is running in the background
            //Without being heavy on the system
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

