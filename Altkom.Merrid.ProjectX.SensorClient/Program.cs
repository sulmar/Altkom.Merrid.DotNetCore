using Altkom.Merrid.ProjectX.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Altkom.Merrid.ProjectX.SensorClient
{
    class Program
    {
        private static HubConnection hubConnection;

        static void Main(string[] args)
        {
            Task.Run(() => ConnectAsync());

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
        }

        private static async Task ConnectAsync()
        {
            await SetupSignalRAsync();

            hubConnection
                .On<Measure>("Send", measure =>
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Received {measure.Value}");
                    Console.ResetColor();
                });

        }


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
