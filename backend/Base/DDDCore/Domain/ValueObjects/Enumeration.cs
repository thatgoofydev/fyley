using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DDDCore.Domain.ValueObjects
{
    public abstract class Enumeration<TEnum> : SingleValueObject<int>
        where TEnum : Enumeration<TEnum>
    {
        private static IEnumerable<TEnum> _all;
        private static Dictionary<int, TEnum> _lookupById;
        private static Dictionary<string, TEnum> _lookupByName;
        
        public string Name { get; }

        public static IEnumerable<TEnum> All => _all ??= typeof(TEnum)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<TEnum>();

        private static Dictionary<int, TEnum> LookupByValue => _lookupById ??= All.ToDictionary(@enum => @enum.Value);
        private static Dictionary<string, TEnum> LookupByName => _lookupByName ??= All.ToDictionary(@enum => @enum.Name);

        protected Enumeration(int value, string name) : base(value)
        {
            Name = name;
        }
        
        public override string ToString()
        {
            return Name;
        }

        public static TEnum FromValue(int value)
        {
            return LookupByValue[value];
        }

        public static TEnum FromName(string name)
        {
            return LookupByName[name];
        }
    }
}