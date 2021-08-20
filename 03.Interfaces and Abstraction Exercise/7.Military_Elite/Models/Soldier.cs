namespace MilitaryElite
{
    public abstract class Soldier:ISoldier 
    {
        public Soldier(string id, string firstname, string lastName)
        {
            this.Id = id;
            this.FirstName = firstname;
            this.LastName = lastName;
        }

        public string Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this .LastName} Id: {this .Id}";
        }
    }
}
