using Altkom.Merrid.ProjectX.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.Merrid.ProjectX.FakeServices
{
    // PM> Install-Package Bogus

    public class Generator
    {
        public static Faker<Meter> Meters => new Faker<Meter>()
            .StrictMode(true)
            .RuleFor(p => p.Id, f => f.IndexFaker)
            .RuleFor(p => p.Name, f => f.Name.FirstName())
            .RuleFor(p => p.Firmware, f => f.System.Version().ToString())
            .RuleFor(p => p.Address, f => f.Internet.Mac())
            .RuleFor(p => p.IsPowerOn, f => f.Random.Bool(0.8f))
            .FinishWith((f, meter) => Console.WriteLine($"Meter {meter.Address} was created."))
            ;


        public static IList<Meter> GenerateMeters(int count) => Meters.Generate(count);
    }
}
