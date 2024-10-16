using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Microsoft.Win32;

public class TurnOff
{

    //public string[] Inputs = new string[5];
    //public List<string> TimeInput = new List<string>(5); // Class-level list to track last inputs.

    /// <summary>
    /// Main entry point for the program.
    /// </summary>
    static void Main(string[] args)
    {
        Welcome();
    }

    // This method represents the starting point of the program.
    static void Start()
    {
        // Display a message indicating that the program is starting.

        // Pause the program execution for 3 seconds.
        Thread.Sleep(2000);

        // Clear the console screen.
        Console.Clear();

        // Prompt the user for a time input using the placeholder method.

        // Set the time for the computer to turn off based on the user input.

        // Display a message indicating that the program has finished.I
        Input();
    }


    /// <summary>
    /// This method prompts the user for a time input using a placeholder in the format of "HH : MM".
    /// It then waits for the user to press Enter or Esc.
    /// If the user presses Enter, the method returns the user's input as a string.
    /// If the user presses Esc, the method exits and does not return a value.
    /// </summary>
    /// <returns>The user's input as a string.</returns>
    static void Input()
    {
        // Set the placeholder string to "HH : MM".

        // Write the placeholder string to the console, and then move the cursor to the left by the length of the placeholder string.
        Console.Write("HH:MM");
        Console.CursorLeft -= "HH:MM".Length;
        string userInput = string.Join("", Console.ReadLine());

        Console.WriteLine($"Your Input: {userInput}");
        Console.WriteLine("Press Enter to continue or Esc to exit the program.\n");
        // Write a message to the console ind

        // Call the HandleUserKeyInput method to capture user input.
        // If the user presses Enter, HandleUserKeyInput returns true and the program starts.
        // If the user presses Esc, HandleUserKeyInput returns false and the program exits.
        if (HandleUserKeyInput()) {
        Console.Clear();
        Console.WriteLine($"{userInput} as set successfully");
        SetTime(userInput);
        }
        // Return the user's input as a string.
    }

    /// <summary>
    /// This method is the starting point of the program.
    /// It displays a welcome message and waits for the user to press Enter or Esc.
    /// If the user presses Enter, the program starts.
    /// If the user presses Esc, the program exits.
    /// </summary>
    static void Welcome()
    {
        // Pause the program execution for 3 seconds.
        Thread.Sleep(3000);

        // Display the welcome message.
        Console.WriteLine("------------------------------------------------------------------");
        Console.WriteLine("Welcome to the TurnOff program!");
        Console.WriteLine("This program will turn off your computer at a specific time.");
        Console.WriteLine("Please enter the time you would like to turn off your computer.");
        Console.WriteLine("------------------------------------------------------------------");

        // Prompt the user to press Enter to continue or Esc to exit the program.
        Console.WriteLine("Press Enter to continue...");
        Console.WriteLine("or Press Esc to exit the program.\n");

        // Call the HandleUserKeyInput method to capture user input.
        // If the user presses Enter, HandleUserKeyInput returns true and the program starts.
        // If the user presses Esc, HandleUserKeyInput returns false and the program exits.
        if (HandleUserKeyInput()) Start();
        else Console.WriteLine("Select a valid option.");
    }

    /// <summary>
    /// This method takes a user-input string and attempts to parse it into a DateTime object.
    /// If successful, it sets the computer to turn off at the specified time.
    /// </summary>
    /// <param name="input">The user-input string to parse.</param>
    static void SetTime(string input)
    {
        // Define the DateTime format for parsing the input.
        const string DateTimeFormat = "HH:mm";

        // If the input string is not in the correct format, display an error message.
        if (!DateTime.TryParseExact(input, DateTimeFormat, null, DateTimeStyles.None, out DateTime selectedTime))
        {
            Console.WriteLine("Invalid time format. Please try again.");
            return;
        }

        // Create a list to store the last 5 inputs, removing the oldest one if we reach the limit.
        var lastInputs = new List<string>(5) { selectedTime.ToString(DateTimeFormat + ":00") };

        // Display last inputs if the list is not empty
        if (lastInputs.Count > 0)
        {
            Console.WriteLine("Last Inputs:");
            Console.WriteLine(string.Join(", ", lastInputs));
            GetLastInputs(lastInputs);
            HandleLastInputsSelection(lastInputs);
        }

        if (lastInputs.Count > 5) lastInputs.RemoveAt(0);

        // Wait until the selected time is reached.
        while (DateTime.Now < selectedTime)
        {
            Thread.Sleep(1000);
        }

        Console.Clear();
        Console.WriteLine("Your PC will turn off at " + selectedTime.ToString(DateTimeFormat));

        // Call the TurnOffComputer method to turn off the computer.
        TurnOffComputer();
    }

    static string GetLastInputs(List<string> TimeInput)
    {
        Console.WriteLine("Last Inputs:");
        foreach (var input in TimeInput) Console.WriteLine(input);
        return string.Join(", ", TimeInput);
    }

    /// <summary>
    ///     Handles the user's selection of a last input item.
    ///     The method will wait for the user to press the DownArrow, UpArrow, Enter, or Escape keys.
    ///     If the user presses DownArrow or UpArrow, the method will move the selection to the next or previous item in the list.
    ///     If the user presses Enter, the method will call the SetTime method with the selected item and return.
    ///     If the user presses Escape, the method will clear the console and call the Start method, effectively exiting the last inputs menu.
    /// </summary>
    /// <param name="TimeInput">The list of last inputs to select from.</param>
    static void HandleLastInputsSelection(List<string> TimeInput)
    {
        // Store the current index of the selected item.
        var selectedIndex = 0;

        // Loop indefinitely until the user presses Enter or Escape.
        while (true)
        {
            // Move the console cursor to the beginning of the current line.
            Console.SetCursorPosition(0, Console.CursorTop);

            // Print the selected item.
            Console.WriteLine(TimeInput[selectedIndex]);

            // Read the user's key input.
            var key = Console.ReadKey(intercept: true).Key;

            // Handle the user's input.
            switch (key)
            {
                // If the user pressed DownArrow, move the selection to the next item in the list.
                case ConsoleKey.DownArrow:
                    // Calculate the new index by adding 1 to the current index and taking the remainder of the list count.
                    // This will wrap around to the beginning of the list if the user presses DownArrow when at the last item.
                    selectedIndex = (selectedIndex + 1) % TimeInput.Count;
                    break;

                // If the user pressed UpArrow, move the selection to the previous item in the list.
                case ConsoleKey.UpArrow:
                    // Calculate the new index by subtracting 1 from the current index and taking the remainder of the list count.
                    // This will wrap around to the end of the list if the user presses UpArrow when at the first item.
                    selectedIndex = (selectedIndex - 1 + TimeInput.Count) % TimeInput.Count;
                    break;

                // If the user pressed Enter, call the SetTime method with the selected item and return.
                case ConsoleKey.Enter:
                    SetTime(TimeInput[selectedIndex]);
                    return;

                // If the user pressed Escape, clear the console and call the Start method to exit the last inputs menu.
                case ConsoleKey.Escape:
                    Console.Clear();
                    Start();
                    return;
            }
        }
    }

    /// <summary>
    ///     This method will wait for the user to press the Enter or Escape keys.
    ///     If the user presses Enter, the method will return true.
    ///     If the user presses Escape, the method will exit the program after 5 seconds.
    ///     If the user presses any other key, the method will print an error message and continue waiting.
    /// </summary>
    /// <returns>
    ///     True if the user pressed Enter, false if the user pressed Escape.
    /// </returns>
    static bool HandleUserKeyInput()
    {
        while (true)
        {
            Console.WriteLine("Press Enter to continue or Esc to exit the program...");

            var pressedKey = Console.ReadKey(intercept: true).Key; // Read the key the user pressed

            if (pressedKey == ConsoleKey.Enter)
            {
                Console.WriteLine("Continuing the program...");
                return true; // Return true if the user pressed Enter
            }
            else if (pressedKey == ConsoleKey.Escape)
            {
                Console.WriteLine("Exiting the program...");

                Thread.Sleep(5000); // Wait for 5 seconds before exiting the program

                Environment.Exit(0); // Exit the program
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    /// <summary>
    ///     This method will turn off the computer.
    /// </summary>
    /// <remarks>
    ///     This method will wait for 10 seconds and then start the shutdown process.
    ///     The shutdown process is started by running the "shutdown" command with the "/s" and "/t 0" parameters.
    ///     The "/s" parameter tells the shutdown command to shut down the local computer.
    ///     The "/t 0" parameter tells the shutdown command to shut down the computer immediately.
    /// </remarks>
    public static void TurnOffComputer()
    {
        // Wait for 10 seconds before shutting down the computer.
        for (int i = 10; i > 0; i--)
        {
            // Print a message to the console to let the user know how much time is left.
            Console.WriteLine($"Turning off in {i} seconds...");

            // Wait for 1 second before continuing the countdown.
            Thread.Sleep(1000);
        }

        // Start the shutdown process.
        // The shutdown command is run with the "/s" and "/t 0" parameters.
        // The "/s" parameter tells the shutdown command to shut down the local computer.
        // The "/t 0" parameter tells the shutdown command to shut down the computer immediately.
        System.Diagnostics.Process.Start("shutdown", "/s /t 0");
    }


    public void BackGroundRun()
    {
        while (true)
        {
            Thread.Sleep(1000);
        }
    }

    public static void RegisterInStartup()
    {
        /*
        const string runKeyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        try
        {
            using var registryKey = Registry.CurrentUser.OpenSubKey(runKeyPath, true);
            registryKey?.SetValue(Application.ProductName, Application.ExecutablePath, RegistryValueKind.String);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to register the program in the startup folder: {ex.Message}");
        }
        */
        Console.WriteLine("Not Implemented");
    }

}
