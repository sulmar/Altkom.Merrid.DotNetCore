using Altkom.Merrid.ProjectX.FakeServices;
using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Altkom.Merrid.ProjectX.ConsoleClient
{
    // PM> Install-Package Microsoft.AspNet.WebApi.Client
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Downloading...");

            AddMeterTest();

            GetMetersTest();

            Console.WriteLine("Downloaded.");

            //SendSms("Hello World");
            //SendPost("Hello World");

            // DelegatesTest();
           


        }

        private static void AddMeterTest()
        {
            Meter meter = new Meter
            {
                Id = 1001,
                Name = "Marcin",
                Address = "f2:f2:f3:f3",
                Firmware = "1.0.0.0",
                IsPowerOn = true
            };

            string json = JsonConvert.SerializeObject(meter);

            string uri = "api/meters";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316");

            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            // client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            HttpResponseMessage response = client.PostAsync(uri, content).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Created!");
            }


        }

        private static void AddMeter2Test()
        {
            Meter meter = new Meter
            {
                Id = 1001,
                Name = "Marcin",
                Address = "f2:f2:f3:f3",
                Firmware = "1.0.0.0",
                IsPowerOn = true
            };

            // string json = JsonConvert.SerializeObject(meter);

            string uri = "api/meters";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316");

            //  HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            // client.DefaultRequestHeaders.Add("Content-Type", "application/json");

            HttpResponseMessage response = client.PostAsJsonAsync<Meter>(uri, meter).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Created!");
            }


        }


        private static void GetMeters2Test()
        {
            string uri = "api/meters";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316");

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                // string json = response.Content.ReadAsStringAsync().Result;
                //  IList<Meter> meters = JsonConvert.DeserializeObject<IList<Meter>>(json);

                IList<Meter> meters = response.Content.ReadAsAsync<IList<Meter>>().Result;

                foreach (var meter in meters)
                {
                    Console.WriteLine($"{meter.Id} {meter.Name} {meter.Address}");
                }

            }

        }

        private static void GetMetersTest()
        {
            string uri = "api/meters";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44316");

            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                IList<Meter> meters = JsonConvert.DeserializeObject<IList<Meter>>(json);

                foreach (var meter in meters)
                {
                    Console.WriteLine($"{meter.Id} {meter.Name} {meter.Address}");
                }

            }

        }

        private static void DelegatesTest()
        {
            Send send = null;

            send += SendSms;
            send += SendPost;

            send += Console.WriteLine;

            send += delegate (string message)
            {
                Console.WriteLine($"{message} inline");
            };

            send += message => Console.WriteLine($"{message}");


            send.Invoke("Hello World");

            send -= SendSms;

            send.Invoke("Hello .NET Core");

            Calculate calculate = CalculateAmount;
            calculate += CalculateAmount3;

            Delegate[] delegates = calculate.GetInvocationList();

            decimal result = calculate.Invoke(100);

            Console.WriteLine(result);
        }

        delegate void Send(string mesage);

        // public Action<string> Send;


        static void SendSms(string message)
        {
            Console.WriteLine($"Send {message} via sms");
        }

        static void SendPost(string post)
        {
            Console.WriteLine($"Send {post} to facebook");
        }


        delegate decimal Calculate(decimal amount);

        static decimal CalculateAmount(decimal amount)
        {
            return amount * 2;
        }

        static decimal CalculateAmount3(decimal amount)
        {
            return amount * 3;
        }

    }



}
