using ActivityManagerConsoleApp.Models;

namespace TaskManagerConsoleApp
{
    public interface IArtDisplay
    {
        void PrintActivityDetails(Activity activity);
        void PrintCoolString(string input);
        void ShowTitle();
    }
}