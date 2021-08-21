using System;
using System.Reflection;

namespace ValidationAttributes.Models
{
    using ValidationAttributes.CustomAttributes;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj
                .GetType()
                .GetProperties();
            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute customAttribute = 
                    (MyValidationAttribute)property
                    .GetCustomAttribute(typeof(MyValidationAttribute), false);

                bool isValid = customAttribute.IsValid(property.GetValue(obj));
                if (!isValid)
                {
                    return false ;
                }
            }
            return true;
        }
    }
}
