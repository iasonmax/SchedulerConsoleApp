using ActivityManagerConsoleApp.Models;
using System;

namespace TaskManagerConsoleApp
{
    public class ArtDisplay : IArtDisplay
    {
        public void ShowTitle()
        {
            string title = @"                                                   
             _____        _      _____                         
            |_   ____ ___| |_   |     |___ ___ ___ ___ ___ ___ 
              | || .'|_ -| '_|  | | | | .'|   | .'| . | -_|  _|
              |_||__,|___|_,_|  |_|_|_|__,|_|_|__,|_  |___|_|  
                                                  |___|        

            ";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title);
            Console.ResetColor();
        }
        public void PrintCoolString(string input)
        {
            int width = input.Length + 4; // Adding extra space for padding
            ConsoleColor originalColor = Console.ForegroundColor;

            // Change text color
            Console.ForegroundColor = ConsoleColor.Green;

            // Print top border
            Console.WriteLine(new string('-', width));

            // Print centered text with side borders
            PrintCenteredWithBorder(input, width);

            // Print bottom border
            Console.WriteLine(new string('-', width));

            // Reset text color
            Console.ForegroundColor = originalColor;
        }
        private void PrintCenteredWithBorder(string text, int width)
        {
            int leftPadding = (width - text.Length - 2) / 2; // Adjust for borders
            int rightPadding = width - text.Length - leftPadding - 2; // Adjust for borders
            string paddingLeft = new string(' ', leftPadding);
            string paddingRight = new string(' ', rightPadding);

            Console.WriteLine($"|{paddingLeft}{text}{paddingRight}|");

        }

        //Breaks if null
        public void PrintActivityDetails(Activity activity)
        {
            string border = new string('=', 50);
            ConsoleColor originalColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(border);

            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintCentered($"Activity Details", 50);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(border);

            PrintField("ID", activity?.Id.ToString());
            PrintField("Title", activity?.Title);
            PrintField("Priority", activity?.Priority.ToString());
            PrintField("Due Date", activity?.DueDate.ToShortDateString());
            PrintField("Status", activity?.Status.ToString());

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(border);

            Console.ForegroundColor = originalColor;
        }

        private void PrintField(string fieldName, string value)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"{fieldName}: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(value);
        }

        private void PrintCentered(string text, int width)
        {
            int leftPadding = (width - text.Length) / 2;
            string padding = new string(' ', leftPadding);
            Console.WriteLine(padding + text);
        }
    }
}