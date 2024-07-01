using ActivityManagerConsoleApp.DataAccess.Repository;
using Autofac;
using SchedulerConsoleApp.DataAccess.Data;
using TaskManagerConsoleApp;

namespace SchedulerConsoleApp
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<ActivityManager>().As<IActivityManager>();
            builder.RegisterType<ArtDisplay>().As<IArtDisplay>();
            builder.RegisterType<StartingScreen>().As<IStartingScreen>();

            return builder.Build();
        }
    }
}
