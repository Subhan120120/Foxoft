using System;

namespace System.ComponentModel
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class DefaultValueSqlAttribute : Attribute
    {
        public DefaultValueSqlAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}