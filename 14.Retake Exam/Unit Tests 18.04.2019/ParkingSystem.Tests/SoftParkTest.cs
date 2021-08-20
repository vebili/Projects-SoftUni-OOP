namespace ParkingSystem.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class SoftParkTest
    {
        private const string Make = "Opel";
        private const string RegistrationNumber = "01234";
        private const string CarSpot = "A1";
        private Car testCar;
        private SoftPark testPark;

        [SetUp]
        public void Setup()
        {
            testCar =  new Car(Make, RegistrationNumber);
            testPark = new SoftPark();
        }

        [Test]
        public void TestCarConstructorShouldCreateCar()
        {
            Car newCar = new Car(Make, RegistrationNumber);

            Assert.That(newCar != null);
        }

        [Test]
        public void TestCarMakeShouldReturnMakeCorrectly()
        {
            Assert.AreEqual(Make, testCar.Make);
        }

        [Test]
        public void TestCarRegistrationNumberShouldReturnRegistrationNumberCorrectly()
        {
            Assert.AreEqual(RegistrationNumber, testCar.RegistrationNumber);
        }

        [Test]
        public void TestSoftParkConstructorShouldCreateSoftPark()
        {
            SoftPark park = new SoftPark();

            Assert.That(park != null);
        }

        [Test]
        public void TestPhoneShouldHavePrivateFieldDictionaryPhoneBook()
        {
            var fields = typeof(SoftPark)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var field = fields.First();

            Assert.AreEqual(field.FieldType, typeof(Dictionary<string, Car>));
        }

        [Test]
        public void TestConstructorShouldInstantiateParking()
        {
            Assert.That(testPark.Parking.Count == 12);
        }

        [Test]
        public void TestParkingShouldReturnCorrectCollection()
        {
            var properties = typeof(SoftPark)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var property = properties.FirstOrDefault(p => p.PropertyType == typeof(IReadOnlyDictionary<string, Car>));

            Assert.That(property != null);
        }

        [Test]
        public void TestParkCorrectlyCar()
        {
            string expectedResult = $"Car:{RegistrationNumber} parked successfully!";
            string actualResult = testPark.ParkCar(CarSpot, testCar);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestParkOnNonExistingSpot()
        {
            Assert.Throws<ArgumentException>(() => testPark.ParkCar("Z1", testCar));
        }

        [Test]
        public void TestParkOnFullSpot()
        {
            Car newCar  = new Car("Mazda", "005");
            testPark.ParkCar(CarSpot, testCar);
            
            Assert.Throws<ArgumentException>(() => testPark.ParkCar("A1", testCar));
        }

        [Test]
        public void TestParkExistingCar()
        {
            testPark.ParkCar(CarSpot, testCar);
            
            Assert.Throws<InvalidOperationException>(() => testPark.ParkCar("B1", testCar));
        }

        [Test]
        public void TestRemoveSuccessfullyCar()
        {
            testPark.ParkCar(CarSpot, testCar);
            testPark.RemoveCar(CarSpot, testCar);

            Car expectedResult = null;
            Car actualResult = testPark.Parking[CarSpot];

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestRemoveCarReturnCorrectResult()
        {
            testPark.ParkCar(CarSpot, testCar);
            
            string expectedResult = $"Remove car:{testCar.RegistrationNumber} successfully!";
            string actualResult = testPark.RemoveCar(CarSpot, testCar);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestRemoveFromNonExistingSpot()
        {
            testPark.ParkCar(CarSpot, testCar);

            Assert.Throws<ArgumentException>(() => testPark.RemoveCar("Z1", testCar));
        }

        [Test]
        public void TestCarThatIsNotOnThatSpot()
        {
            Car newCar  = new Car("Mazda", "005");
            testPark.ParkCar(CarSpot, testCar);
            testPark.ParkCar("A2", newCar);

            Assert.Throws<ArgumentException>(() => testPark.RemoveCar(CarSpot, newCar));
        }
    }
}