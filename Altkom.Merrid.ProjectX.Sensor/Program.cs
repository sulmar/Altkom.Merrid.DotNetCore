using Altkom.Merrid.ProjectX.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Altkom.Merrid.ProjectX.Sensor
{
    class Program
    {
        private static HubConnection hubConnection;

        // static void Main(string[] args) => MainAsync(args).GetAwaiter().GetResult();

        static void Main(string[] args)
        {
            Task.Run(()=>ConnectAsync());

            // TasksTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static async Task ConnectAsync()
        {
            await SetupSignalRAsync();

            Random random = new Random();

            while (true)
            {
                Measure measure = new Measure { Value = random.Next(0, 100) };
                await hubConnection.SendAsync("Send", measure);
                Console.WriteLine($"Send {measure.Value}");
                await Task.Delay(TimeSpan.FromSeconds(random.Next(1, 5)));
            }
        }



        private static void TasksTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} UI");

            Task task = Task.Run(() =>
            {
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sleeping");
                Thread.Sleep(TimeSpan.FromSeconds(5));

            }

            );

            task
                .ContinueWith(t => Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} boxing"))
                    .ContinueWith(t => Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} bye bye"));
        }





        // PM> Install-Package Microsoft.AspNetCore.SignalR.Client

       

        public static async Task SetupSignalRAsync()
        {
            hubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/measures")
                .Build();

            try
            {
                await hubConnection.StartAsync();

                Console.WriteLine("connected!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

     
    }
}
