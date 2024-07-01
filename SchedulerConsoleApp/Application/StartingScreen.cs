using ActivityManagerConsoleApp.DataAccess.Repository;
using ActivityManagerConsoleApp.Models;
using ActivityManagerConsoleApp.Utility;
using System;

namespace TaskManagerConsoleApp
{
    public class StartingScreen : IStartingScreen
    {
        private readonly IActivityManager _activityManager;
        private readonly IArtDisplay _artDisplay;
        public StartingScreen(IActivityManager activityManager, IArtDisplay artDisplay)
        {
            _activityManager = activityManager;
            _artDisplay = artDisplay;
        }
        public void Run()
        {
            while (true)
            {
                Console.Clear();
                _artDisplay.ShowTitle();
                _artDisplay.PrintCoolString("1. Add Activity");
                _artDisplay.PrintCoolString("2. View Activitys");
                _artDisplay.PrintCoolString("3. Update Activity");
                _artDisplay.PrintCoolString("4. Delete Activity");
                _artDisplay.PrintCoolString("5. Exit");
                _artDisplay.PrintCoolString("Select an option: ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            AddActivity();
                            break;
                        case 2:
                            ViewActivitys();
                            break;
                        case 3:
                            UpdateActivity();
                            break;
                        case 4:
                            DeleteActivity();
                            break;
                        case 5:
                            return;
                        default:
                            _artDisplay.PrintCoolString("Invalid option. Try again.");
                            _artDisplay.PrintCoolString("Press any key to continue...");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    _artDisplay.PrintCoolString("Invalid option. Try again.");
                    _artDisplay.PrintCoolString("Press any key to continue...");
                    Console.ReadKey();
                }

            }
        }
        private void DeleteActivity()
        {
            _artDisplay.PrintCoolString("Enter Activity ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            _activityManager.DeleteActivity(id);
        }

        private void UpdateActivity()
        {
            _artDisplay.PrintCoolString("Enter Activity ID to update: ");
            int id = int.Parse(Console.ReadLine());
            _artDisplay.PrintActivityDetails(_activityManager.GetActivity(id));
            Activity updatedActivity = AskForActivity();
            _activityManager.UpdateActivity(updatedActivity);
        }

        private void ViewActivitys()
        {
            var activities = _activityManager.GetActivities();
            foreach (var activity in activities)
            {
                _artDisplay.PrintActivityDetails(activity);
            }
            _artDisplay.PrintCoolString("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddActivity()
        {
            Activity newActivity = AskForActivity();
            _activityManager.AddActivity(newActivity);
        }

        private Activity AskForActivity()
        {
            _artDisplay.PrintCoolString("New Title: ");
            string title = Console.ReadLine();
            _artDisplay.PrintCoolString("New Description: ");
            string description = Console.ReadLine();
            _artDisplay.PrintCoolString("New Priority (High, Medium, Low): ");
            Priority priority = (Priority)Enum.Parse(typeof(Priority), Console.ReadLine(), true);
            _artDisplay.PrintCoolString("New Due Date (yyyy-mm-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());
            _artDisplay.PrintCoolString("New Category: ");
            string category = Console.ReadLine();
            _artDisplay.PrintCoolString("New Status (Pending, InProgress, Completed): ");
            Status status = (Status)Enum.Parse(typeof(Status), Console.ReadLine(), true);

            Activity updatedActivity = new Activity
            {
                Title = title,
                Description = description,
                Priority = priority,
                DueDate = dueDate,
                Category = category,
                Status = status
            };

            return updatedActivity;

        }
    }
}
