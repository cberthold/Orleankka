﻿using System;
using System.Reflection;

using Orleankka;
using Orleankka.Cluster;

using Orleans.Runtime.Configuration;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running demo. Booting cluster might take some time ...\n");

            var config = new ClusterConfiguration()
                .LoadFromEmbeddedResource<Program>("Server.xml");
            
            var system = ActorSystem.Configure()
                .Cluster()
                .From(config)
                .Register(typeof(Join).Assembly)
                .Register(Assembly.GetExecutingAssembly())
                .Done();

            system.Start();

            Console.WriteLine("Finished booting cluster...");
            Console.ReadLine();
            
            system.Dispose();
        }
    }
}