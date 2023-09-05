using H3_Tests___Application.GUI.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Tests___Application.GUI.Utilities
{
    /// <summary>
    /// A toolbox of reusable components for varies Console views
    /// </summary>
    internal static class ViewComponents
    {
        /// <summary>
        /// <para>Displays a Header component in the Console in this format:</para>
        /// <para>------------------------------------------------- </para>
        /// <para>-------------- [HeaderName] ----------------- </para>
        /// <para>------------------------------------------------- </para>
        /// </summary>
        /// <param name="headerName">The name to be in the header</param>
        public static void DisplayViewHeader(string headerName)
        {
            // Get divider line
            string dividerLine = GetDividerLine();

            // Calculate number of char's should be on each side of the headerName
            // the -1 is for spacing around the header name
            int headerPrefixWidth = (dividerLine.Length - headerName.Length) / 2 - 1;
            if (headerPrefixWidth < 0)
            {
                headerPrefixWidth = 0;
            }
            string headerNamePrefix = GetDividerLine(dividerCount: headerPrefixWidth);

            // Display the header in the Console window
            Console.WriteLine(dividerLine);
            Console.WriteLine($"{headerNamePrefix} {headerName} {headerNamePrefix}");
            Console.WriteLine(dividerLine);
            Console.WriteLine();
        }

        /// <summary>
        /// Get a divider line of a single char in a adjustable number of times
        /// </summary>
        /// <param name="dividerChar">The char to create the line from</param>
        /// <param name="dividerCount">The amount of chars to be in the line</param>
        /// <returns>The divider line</returns>
        public static string GetDividerLine(char dividerChar = '-', int dividerCount = 40)
        {
            if (dividerCount < 0)
            {
                throw new ArgumentException("DividerCount cannot be less than 0");
            }
            char[] dividerLine = new char[dividerCount];
            for (int i = 0; i < dividerCount; i++)
            {
                dividerLine[i] = dividerChar;
            }
            return new string(dividerLine);
        }

        /// <summary>
        /// Prompts the user for a text input
        /// </summary>
        /// <param name="question">The text to inform the user what to input</param>
        /// <param name="nullable">If the user is allowed to enter empty input</param>
        /// <returns>The users string input</returns>
        public static string GetUserInput(string question, bool nullable = false)
        {
            bool looper = true; // looper to stay in view
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine(question);
                input = Console.ReadLine(); // Get user input
                // If empty input is not allowed, inform user and keep them in loop
                if (nullable == false && string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty, press any key to try again.");
                    Console.ReadKey();
                }
                else
                {
                    looper = false; //  Exit loop if input is accepted
                }
            } while (looper);
            return input;
        }

        /// <summary>
        /// Display a selection of view options and return the one choosen
        /// </summary>
        /// <param name="viewNavigationOptions">The options to choose from</param>
        /// <returns>The selected View options</returns>
        public static ViewNavigationOption GetNavigationChoice(ViewNavigationOption[] viewNavigationOptions)
        {
            // Minimum of 1 option
            if (viewNavigationOptions.Length == 0)
            {
                throw new ArgumentException("No options was parsed, a minimum of 1 options is required");
            }
            // A maximum of 9 options
            if (viewNavigationOptions.Length > 9)
            {
                throw new ArgumentException($"Only allowed a maximum of 9 options, {viewNavigationOptions.Length} options received");
            }

            Console.WriteLine("Choose an option:");
            Console.WriteLine();
            // Display the options
            for (int i = 0; i < viewNavigationOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}. " + viewNavigationOptions[i].DisplayName);
            }
            Console.WriteLine();
            ConsoleKeyInfo userChoice = Console.ReadKey();
            int userChoiceIndex = -1;

            // Evaluate the user choice
            switch (userChoice.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    userChoiceIndex = 1;
                    break;
                case ConsoleKey.D2:
                    userChoiceIndex = 2;
                    break;
                case ConsoleKey.D3:
                    userChoiceIndex = 3;
                    break;
                case ConsoleKey.D4:
                    userChoiceIndex = 4;
                    break;
                case ConsoleKey.D5:
                    userChoiceIndex = 5;
                    break;
                case ConsoleKey.D6:
                    userChoiceIndex = 6;
                    break;
                case ConsoleKey.D7:
                    userChoiceIndex = 7;
                    break;
                case ConsoleKey.D8:
                    userChoiceIndex = 8;
                    break;
                case ConsoleKey.D9:
                    userChoiceIndex = 9;
                    break;
            }

            // If a choice was made
            if (userChoiceIndex > -1 && userChoiceIndex < viewNavigationOptions.Length)
            {
                return viewNavigationOptions[userChoiceIndex - 1];
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Input not recognised, please select a number between {1} and {viewNavigationOptions.Length}");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }

            return null;
        }
    }
}
