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
            // Call the Welcome() method to start the program
            Welcome();
        }

        /// <summary>
        /// This function takes a selected time string and compares it to the current time.
        /// If the two times are equal, the program will shut down the computer.
        /// </summary>
        /// <param name="selected_time">The time selected by the user in HH:mm:ss format</param>
        public static void TurnOffComputer(string selected_time)
        {
            var targetTime = DateTime.Parse(selected_time);
            var timeDifference = targetTime - DateTime.Now;
            var timeToTurnOff = timeDifference.ToString(@"hh\:mm\:ss");
            Console.WriteLine($"Time to turn off:{timeToTurnOff}");
            // Wait until the target time is reached
            while (DateTime.Now < targetTime)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Time to turn off: {timeDifference}");
            }
            Console.WriteLine("Shutting down the computer...");
            System.Diagnostics.Process.Start("shutdown", "/s /t 0");
        }

        /// <summary>
        /// This is the main entry point for the Welcome() method.
        /// It is called from the Main() method and is responsible for starting the program.
        /// </summary>
        /// <remarks>
        /// This method is the first method that is called when the program is started.
        /// It is responsible for printing a welcome message to the user and asking them to enter the time in 24-hour format that they want the computer to shut down.
        /// </remarks>
        public static void Welcome() {
            // Print a welcome message to the user
            Console.WriteLine("Welcome to the TurnOffComputer program!");

            // Ask the user to enter the time in 24-hour format that they want the computer to shut down
            Console.WriteLine("Select a time to turn off the computer:");

            // Call the setTime() method to get the user's input for the time to shut down the computer
            setTime();
        }


        /// <summary>
        /// This is the main entry point for the setTime() method.
        /// It is called from the Welcome() method and is responsible for getting the user's input for the time to shut down the computer.
        /// </summary>
        public static void setTime() {
            // Print a message to the user asking them to enter the time in 24-hour format
            Console.Write("Enter the time in 24-hour format (HH:mm): ");

            // Read the user's input in one line
            #pragma warning disable CS8602 // Dereference of a possibly null reference.
            string[] input = Console.ReadLine().Split(':');
            #pragma warning restore CS8602 // Dereference of a possibly null reference.

            // Check if the input is valid
            if (input.Length == 2 && int.TryParse(input[0], out int hour) && int.TryParse(input[1], out int minute) && hour >= 0 && hour < 24 && minute >= 0 && minute < 60) {
                // Concatenate the hour and minute to get the selected time in the format "HH:mm:ss"
                string selected_time = $"{hour:D2}:{minute:D2}:00";

                // Print the selected time to the user
                Console.WriteLine($"Selected time: {selected_time}");

                // Call the TurnOffComputer() method and pass the selected time as an argument
                TurnOffComputer(selected_time);
            }
            else {
                Console.WriteLine("Invalid input. Please enter the time in 24-hour format (HH:mm).");
                setTime();
            }
        }
    }
}

