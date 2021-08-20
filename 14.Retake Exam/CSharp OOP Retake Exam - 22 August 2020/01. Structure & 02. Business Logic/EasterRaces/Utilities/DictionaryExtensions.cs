using System.Collections.Generic;

namespace EasterRaces.Utilities
{
    public static class DictionaryExtensions
    {
        public static TValue GetByKeyOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            // TValue result = default(TValue); before last CSharp syntaxes
            TValue result = default;

            if (dictionary.ContainsKey(key))
            {
                result = dictionary[key];
            }

            return result;
        }
    }
}
