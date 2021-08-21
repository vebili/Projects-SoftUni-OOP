namespace ValidationAttributes.CustomAttributes
{
    using System;

    public class MyRangeAttribute : MyValidationAttribute
    {
        private int _minValue;
        private int _maxValue;

        public MyRangeAttribute(int minValue, int maxValue)
        {
            this._minValue = minValue;
            this._maxValue = maxValue;
        }
        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException("invalid data type");
            }

            int valueAsInt = (int)obj;

            bool isInRange = valueAsInt >= _minValue && valueAsInt <= _maxValue;

            if (!isInRange)
            {
                return false;
            }
            return true;
        }
    }
}
