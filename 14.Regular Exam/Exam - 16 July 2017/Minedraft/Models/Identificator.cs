
    public class Identificator
    {
        private string id;

        protected Identificator(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
            }
        }

    }

