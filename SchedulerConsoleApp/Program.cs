using Autofac;
using SchedulerConsoleApp;
using System;
using TaskManagerConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var container = ContainerConfig.Configure();
        using (var scope = container.BeginLifetimeScope())
        {
            var app = scope.Resolve<IStartingScreen>();
            app.Run();
        }

        Console.ReadLine();
    }

}