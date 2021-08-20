using System;
using NUnit.Framework;
//using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
        }

        [Test]
        public void Counter_IsZeroByDefault()
        {
            Assert.That(this.raceEntry.Counter, Is.Zero);
        }

        [Test]
        public void Counter_Increases_WhenAddingDriver()
        {
            this.raceEntry.AddDriver(new UnitDriver("Nasko", new UnitCar("Tesla", 400, 500)));
            Assert.That(this.raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriver_ThrowsException_WhenDriverNameExist()
        {
            var driverName = "Nasko";
            this.raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("Tesla S", 400, 500)));

            Assert.Throws<InvalidOperationException>(() =>
                this.raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("Tesla Cybertruck", 300, 700))));
        }

        [Test]
        public void AddDriver_ReturnExpectedResultMessage()
        {
            var driverName = "Nasko";
            var actual = this.raceEntry.AddDriver(new UnitDriver(driverName, new UnitCar("Tesla S", 400, 500)));

            var expected = $"Driver {driverName} added in race.";

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsException_WhenParticipiantsAreLessThanREquired()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());

            this.raceEntry.AddDriver(new UnitDriver("Nasko", new UnitCar("Tesla", 500, 600)));

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ReturnsExpectedCalculatedResult()
        {
            int n = 10;
            double expected = 0;

            for (int i = 0; i < n; i++)
            {
                int hp = 450 + i;
                expected += hp;
                this.raceEntry.AddDriver(new UnitDriver($"Name={i}", new UnitCar("Model", hp, 550)));
            }

            expected /= n;

            double actual = this.raceEntry.CalculateAverageHorsePower();
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}