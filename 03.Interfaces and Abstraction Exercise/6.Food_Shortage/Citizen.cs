namespace PersonInfo
{
    public class Citizen : Person, IBirthable, IIdentifiable
    {
        public Citizen(string name, int age, string birthDate, string id)
        :base(name, age)
        {
            this.BirthDate = birthDate;
            this.Id = id;
        }
        
        public string BirthDate { get; private set; }

        public string Id { get; private set; }

        public override void BuyFood()
        {
            this.Food += 10;
        }


    }
}
