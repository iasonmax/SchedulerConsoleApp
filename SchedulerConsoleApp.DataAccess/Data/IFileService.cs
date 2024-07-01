using ActivityManagerConsoleApp.Models;

namespace SchedulerConsoleApp.DataAccess.Data
{
    public interface IFileService
    {
        List<Activity> ReadFile();
        void SaveActivitys(List<Activity> activities);

        public void SaveActivity(Activity updatedActivity);
    }
}