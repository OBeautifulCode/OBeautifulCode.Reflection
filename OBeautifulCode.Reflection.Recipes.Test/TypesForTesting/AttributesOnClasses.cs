// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributesOnClasses.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
    public class ClassWithNoAttributes
    {
    }

    [Color("blue")]
    public class ClassWithColor
    {
    }

    [Purpose("some purpose")]
    [Purpose("some other purpose")]
    public class ClassWithPurpose
    {
    }
#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}