using Autofac;

namespace SchedulerConsoleApp
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType < Bu >

            return builder.Build();
        }
    }
}
