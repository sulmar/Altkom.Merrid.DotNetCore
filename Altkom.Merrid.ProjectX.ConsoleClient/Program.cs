using Altkom.Merrid.ProjectX.FakeServices;
using Altkom.Merrid.ProjectX.IServices;
using Altkom.Merrid.ProjectX.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Altkom.Merrid.ProjectX.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //SendSms("Hello World");
            //SendPost("Hello World");

            // DelegatesTest();

            IList<Meter> meters = Generator.GenerateMeters(1000);


            IMetersService metersService = new FakeMetersService();
            metersService.Add(meters);



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
