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
        private Faker<Meter> FakeMeters => new Faker<Meter>()
            .StrictMode(true)
            .RuleFor(p => p.Id, f => f.IndexFaker)
            .RuleFor(p => p.Name, f => f.Name.FirstName())
            .RuleFor(p => p.Firmware, f => f.System.Version().ToString())
            .RuleFor(p => p.Address, f => f.Internet.Mac())
            .RuleFor(p => p.IsPowerOn, f => f.Random.Bool(0.8f))
            .FinishWith((f, meter) => Console.WriteLine($"Meter {meter.Address} was created."))
            ;

        private Faker<Measure> FakeMeasures => new Faker<Measure>()
            .StrictMode(true)
            .RuleFor(p => p.Id, f=>f.IndexFaker)
            .RuleFor(p => p.Meter, f => f.PickRandom(Meters))
            .RuleFor(p => p.Unit, f => new Unit { Id = 1, Name = "Celsius" })
            // .Ignore(p => p.MeasureDate)
            .RuleFor(p => p.MeasureDate, f => f.Date.Past(1))
            .RuleFor(p=>p.Value, f=>f.Random.Float(0, 100))
            .FinishWith((f, measure) => Console.WriteLine($"Masure {measure.MeasureDate} {measure.Value}"))
            ;

        public IList<Meter> Meters { get; private set; }
        public IList<Measure> Measures { get; private set; }

        public Generator()
        {
            Meters = FakeMeters.Generate(1000);
            Measures = FakeMeasures.Generate(1000);
        }

    }
}
