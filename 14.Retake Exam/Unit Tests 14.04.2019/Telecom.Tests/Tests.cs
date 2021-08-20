namespace Telecom.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using NUnit.Framework;

    public class Tests
    {
        private const string Make = "Samsung";
        private const string Model = "A1";
        private Phone phone;

        [SetUp]
        public void Setup()
        {
            this.phone = new Phone(Make, Model);
        }

        [Test]
        public void TestConstructorShouldCreatePhone()
        {
            Phone testPhone = new Phone(Make, Model);

            Assert.That(testPhone != null);
        }

        [Test]
        public void TestPhoneShouldHavePrivateFieldDictionaryPhoneBook()
        {
            var fields = typeof(Phone)
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            var field = fields.Last();

            Assert.AreEqual(field.FieldType, typeof(Dictionary<string, string>));
        }

        [Test]
        public void TestConstructorShouldInstantiatePhoneBook()
        {
            Assert.That(phone.Count == 0);
        }

        [Test]
        public void TestMakeShouldReturnPhonesMake()
        {
            Assert.AreEqual(Make, phone.Make);
        }

        [Test]
        public void TestModelShouldReturnPhonesModel()
        {
            Assert.AreEqual(Model, phone.Model);
        }

        [Test]
        public void TestPhoneShouldNotBeCreatedWithNullMake()
        {
            Assert.Throws<ArgumentException>(() => new Phone(null, Model));
        }

        [Test]
        public void TestPhoneShouldNotBeCreatedWithNullModel()
        {
            Assert.Throws<ArgumentException>(() => new Phone(Make, null));
        }

        [Test]
        public void TestPhoneBookShouldAddContactCorrectly()
        {
            string name = "Pesho";
            string phoneNumber = "007";

            phone.AddContact(name, phoneNumber);
            int expectedCount = 1;
            int actualCount = phone.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestAddExistingNameThrowsException()
        {
            string name = "Pesho";
            string phoneNumber = "007";

            phone.AddContact(name, phoneNumber);

            Assert.Throws<InvalidOperationException>(() => phone.AddContact(name, "001"));
        }

        [Test]
        public void TestCallExistingContact()
        {
            string name = "Pesho";
            string phoneNumber = "007";

            phone.AddContact(name, phoneNumber);
            string expectedResult = $"Calling {name} - {phoneNumber}...";
            string actualResult = phone.Call(name);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void TestCallNonExistingContact()
        {
            string name = "Pesho";
            string phoneNumber = "007";

            phone.AddContact(name, phoneNumber);

            Assert.Throws<InvalidOperationException>(() => phone.Call("Gosho"));
        }
    }
}