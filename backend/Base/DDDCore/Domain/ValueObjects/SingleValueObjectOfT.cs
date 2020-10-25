﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace DDDCore.Domain.ValueObjects
{
    public abstract class SingleValueObject<T> : ValueObject, IComparable
        where T : IComparable
    {
        private static readonly Type Type = typeof(T);
        private static readonly TypeInfo TypeInfo = typeof(T).GetTypeInfo();

        public T Value { get; }

        protected SingleValueObject(T value)
        {
            if (TypeInfo.IsEnum && !Enum.IsDefined(Type, value))
            {
                throw new ArgumentException($"The value '{value}' isn't defined in enum '{Type}'");
            }

            Value = value;
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var other = obj as SingleValueObject<T>;
            if (other == null)
            {
                throw new ArgumentException($"Cannot compare '{GetType()}' and '{obj.GetType()}'");
            }

            return Value.CompareTo(other.Value);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public override string ToString()
        {
            return ReferenceEquals(Value, null)
                ? string.Empty
                : Value.ToString();
        }
    }
}