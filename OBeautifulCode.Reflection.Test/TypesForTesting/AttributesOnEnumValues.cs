// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributesOnEnumValues.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace OBeautifulCode.Reflection.Test
{
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "this is for testing purposes.")]
    public enum Empty
    {
    }

    public enum GoodStuff
    {
        WorkingFromHome,

        Chocolate,

        Vacation,

        Bulldogs
    }

    public enum Sweet
    {
        [MultipleAllowed]
        Cake,

        [MultipleAllowed]
        [MultipleAllowed]
        [Color("brown")]
        Chocolate,

        [Color("green")]
        Cookies
    }

    public enum Fruit
    {
        Mango,

        Grape,

        [Purpose("toddlers love it")]
        [Purpose("good shelf life")]
        Pear
    }

#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}

// ReSharper restore CheckNamespace