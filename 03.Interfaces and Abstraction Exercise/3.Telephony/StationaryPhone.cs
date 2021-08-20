namespace Telephony
{
    public class StationaryPhone : ICallable 
    {
        public string Call(string number)
        {
            Validator.ThrowIfNumberIsInvalid(number);
            return $"Dialing... {number}";
        }
    }
}
