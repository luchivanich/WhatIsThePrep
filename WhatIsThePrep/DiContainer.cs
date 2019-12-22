using Autofac;
using WitpBusinessLogic;

namespace WhatIsThePrep
{
    public static class DiContainer
    {
        public static IContainer Init()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FileExampleGenerator>().As<IExampleStorage>().SingleInstance().OnActivating(i => i.Instance.Init());
            builder.RegisterType<Training>().As<ITraining>().SingleInstance();
            builder.RegisterType<MainApplication>().As<IApplication>().SingleInstance();

            return builder.Build();
        }
    }
}
