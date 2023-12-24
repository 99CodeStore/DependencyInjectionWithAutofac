using Autofac;
using System;

namespace DependencyInjectionWithAutofac
{
    class Program
    {
        static void Main(string[] args)
        {

            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleLogger>().As<ILogger>();
            builder.RegisterType<Car>();
            builder.RegisterType<Engine>();

            IContainer container = builder.Build();
            var car=container.Resolve<Car>();

            car.Go();

        }
    }

    interface ILogger
    {
        void WriteLog(string logText);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string logText)
        {
            Console.WriteLine(logText);
        }
    }
    class Car
    {
        private readonly Engine engine;
        private readonly ILogger log;

        public Car(Engine engine, ILogger log)
        {
            this.engine = engine;
            this.log = log;
        }

        public void Go()
        {
            engine.Ahead(100);
            log.WriteLog("Car Moving Forward....");
        }
    }
    class Engine
    {
        private readonly ILogger log;

        public Engine(ILogger log)
        {
            this.log = log;
        }

        public void Ahead(int value)
        {
            log.WriteLog(value.ToString());
        }
    }
}
