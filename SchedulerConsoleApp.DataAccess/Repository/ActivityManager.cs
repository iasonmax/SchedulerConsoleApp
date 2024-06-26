using ActivityManagerConsoleApp.DataAccess.Data;
using ActivityManagerConsoleApp.Models;

namespace ActivityManagerConsoleApp.DataAccess.Repository
{
    public class ActivityManager : IActivityManager
    {
        private readonly IFileService _fileService;

        public ActivityManager(IFileService fileService)
        {
            _fileService = fileService;
        }
        public List<Activity> GetActivities()
        {
            List<Activity> activities = _fileService.ReadFile();
            return activities;
        }

        //Create
        public void AddActivity(Activity activity)
        {
            List<Activity> activities = _fileService.ReadFile();
            if (activities == null || activities.Count == 0)
            {
                activity.Id = 1;
            }
            else
            {
                activity.Id = activities.Last().Id + 1;
            }

            activities.Add(activity);
            _fileService.SaveActivitys(activities);
        }

        public Activity? GetActivity(int id) => GetActivities().FirstOrDefault(t => t.Id == id);

        //Delete
        public void DeleteActivity(int id)
        {
            var activity = GetActivity(id);
            List<Activity> activities = _fileService.ReadFile();
            activities.Remove(activity);
            _fileService.SaveActivitys(activities);
        }

        //Update
        public void UpdateActivity(Activity updatedActivity)
        {
            _fileService.SaveActivity(updatedActivity);
        }


    }
}
