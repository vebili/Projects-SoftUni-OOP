namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {
        private const string NameAstro = "Pesho";
        private const double OxygenInPercentage = 100.0;
        private Astronaut astronaut;
        private const string NameSpaceShip = "Apollo";
        private const int Capacity = 10;
        private Spaceship spaceship;

        [SetUp]
        public void SetUp()
        {
            astronaut = new Astronaut(NameAstro, OxygenInPercentage);

            spaceship = new Spaceship(NameSpaceShip, Capacity);
        }

        [Test]
        public void TestSpaceShipConstructorCreatesSpaceShip()
        {
            Spaceship space1 = new Spaceship(NameSpaceShip, Capacity);

            Assert.IsNotNull(space1);
            Assert.AreEqual(NameSpaceShip, space1.Name);
            Assert.AreEqual(Capacity, space1.Capacity);
            Assert.AreEqual(0, space1.Count);
        }

        [Test]
        public void TestNameThrowsWithNull()
        {
            Assert.Throws<ArgumentNullException>(() => new Spaceship(null, Capacity));
        }

        [Test]
        public void TestCapacityThrowsWithNegative()
        {
            Assert.Throws<ArgumentException>(() => new Spaceship(NameSpaceShip, -10));
        }

        [Test]
        public void TestAddWorksCorrectly()
        {
            spaceship.Add(astronaut);

            Assert.AreEqual(1, spaceship.Count);
        }

        [Test]
        public void TestAddThrowsWithFullCapacity()
        {
            Spaceship space1 = new Spaceship("Zero", 1);

            space1.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => space1.Add(new Astronaut("Gosho", 50)));
        }

        [Test]
        public void TestAddThrowsWithExistingAstronaut()
        {
            Spaceship space1 = new Spaceship("Zero", 5);

            space1.Add(astronaut);

            Assert.Throws<InvalidOperationException>(() => space1.Add(astronaut));
        }

        [Test]
        public void TestRemoveWorks()
        {
            spaceship.Add(astronaut);

            spaceship.Remove(astronaut.Name);

            Assert.AreEqual(0, spaceship.Count);
        }
    }
}