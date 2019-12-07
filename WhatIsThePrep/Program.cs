using Autofac;

namespace WhatIsThePrep
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = DiContainer.Init();
            using(var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }
    }
}
