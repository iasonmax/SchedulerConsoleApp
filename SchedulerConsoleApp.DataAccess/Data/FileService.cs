using ActivityManagerConsoleApp.Models;
using ActivityManagerConsoleApp.Utility;

namespace SchedulerConsoleApp.DataAccess.Data
{
    public class FileService : IFileService
    {
        private const string filePath = "activities.txt";
        public List<Activity> ReadFile()
        {
            List<Activity> activities = new List<Activity>();
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split('|');
                        var activity = new Activity
                        {
                            Id = int.Parse(parts[0]),
                            Title = parts[1],
                            Description = parts[2],
                            Priority = (Priority)Enum.Parse(typeof(Priority), parts[3]),
                            DueDate = DateTime.Parse(parts[4]),
                            Category = parts[5],
                            Status = (Status)Enum.Parse(typeof(Status), parts[6])
                        };
                        activities.Add(activity);
                    }
                }
            }
            return activities;
        }

        public void SaveActivitys(List<Activity> activities)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var activity in activities)
                {
                    writer.WriteLine($"{activity.Id}|{activity.Title}|{activity.Description}|{activity.Priority}|{activity.DueDate}|{activity.Category}|{activity.Status}");
                }
            }
        }

        public void SaveActivity(Activity activity)
        {
            List<Activity> activities = ReadFile();
            Activity tobeUpadated = activities.FirstOrDefault(t => t.Id == activity.Id);
            if (tobeUpadated != null)
            {
                tobeUpadated = activity;
            }
            SaveActivitys(activities);
        }

    }
}
