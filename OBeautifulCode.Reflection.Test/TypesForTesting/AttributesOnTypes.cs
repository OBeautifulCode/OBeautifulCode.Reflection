// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributesOnTypes.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace OBeautifulCode.Reflection.Test
{
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class

    [EqualOpportunity("enumerate everything")]
    public enum EqualOpportunityEnum
    {
    }

    [EqualOpportunity("interface with everyone")]
    public interface IAmEqualOpportunity
    {
    }

    [EqualOpportunity("interface for everything")]
    [EqualOpportunity("classify none")]
    public interface IHaveEqualOpportunity
    {
    }

    [EqualOpportunity("classify none")]
    public class EqualOpportunityClassy
    {
    }

    [EqualOpportunity("something else")]
    [EqualOpportunity("classify none")]
    public class EqualOpportunityClassless
    {
    }
#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}

// ReSharper restore CheckNamespace