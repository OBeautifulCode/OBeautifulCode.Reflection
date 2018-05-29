// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttributesOnTypes.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class

    [EqualOpportunity("enumerate everything")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "This is for test purposes.")]
    public enum EqualOpportunityEnum
    {
        None,
    }

    [EqualOpportunity("interface with everyone")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "This is for test purposes.")]
    public interface IAmEqualOpportunity
    {
    }

    [EqualOpportunity("interface for everything")]
    [EqualOpportunity("classify none")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "This is for test purposes.")]
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