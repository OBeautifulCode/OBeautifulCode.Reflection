﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Attributes.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace OBeautifulCode.Reflection.Test
{
    using System;

#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class NotAppliedAnywhereAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public sealed class MultipleAllowedAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class MultipleNotAllowedAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Field)]
    public sealed class ColorAttribute : Attribute
    {
        public ColorAttribute(string color)
        {
            this.Color = color;
        }

        public string Color { get; }
    }

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public sealed class PurposeAttribute : Attribute
    {
        public PurposeAttribute(string purpose)
        {
            this.Purpose = purpose;
        }

        public string Purpose { get; }
    }

#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}

// ReSharper restore CheckNamespace