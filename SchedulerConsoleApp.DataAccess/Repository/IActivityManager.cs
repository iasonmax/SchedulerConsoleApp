using ActivityManagerConsoleApp.Models;

namespace ActivityManagerConsoleApp.DataAccess.Repository
{
    public interface IActivityManager
    {
        void AddActivity(Activity activity);
        void DeleteActivity(int id);
        List<Activity> GetActivities();
        void UpdateActivity(Activity updatedActivity);
        Activity GetActivity(int id);
    }
}