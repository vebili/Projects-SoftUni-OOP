namespace PlayersAndMonsters.Common
{
    public static class ExceptionMessages
    {
        public const string ExcUsername = "Player's username cannot be null or an empty string.";

        public const string ExcHealth = "Player's health bonus cannot be less than zero.";

        public const string ExcDamagePoints = "Damage points cannot be less than zero.";

        public const string ExcCardname = "Card's name cannot be null or an empty string.";

        public const string ExcHealthPointsCard = "Card's HP cannot be less than zero.";

        public const string ExcDamagePointsCard = "Card's damage points cannot be less than zero.";

        public const string ExcDeadPlayer = "Player is dead!";

        public const string ExcAddNullPlayer = "Player cannot be null";

        public const string ExcAddExistingPlayer = "Player {0} already exists!";

        public const string ExcRemovePlayer = "Player cannot be null";

        public const string ExcAddNullCard = "Card cannot be null!";

        public const string ExcAddExistingCard = "Card {0} already exists!";

        public const string ExcRemoveCard = "Card cannot be null!";


    }
}