// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Attributes.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using System;

#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class)]
    public sealed class NotAppliedAnywhereAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class MultipleAllowedAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class)]
    public sealed class MultipleNotAllowedAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class)]
    public sealed class ColorAttribute : Attribute
    {
        public ColorAttribute(string color)
        {
            this.Color = color;
        }

        public string Color { get; }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class PurposeAttribute : Attribute
    {
        public PurposeAttribute(string purpose)
        {
            this.Purpose = purpose;
        }

        public string Purpose { get; }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Interface, AllowMultiple = true)]
    public sealed class EqualOpportunityAttribute : Attribute
    {
        public EqualOpportunityAttribute(string theOpportunity)
        {
            this.TheOpportunity = theOpportunity;
        }

        public string TheOpportunity { get; }
    }

#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}