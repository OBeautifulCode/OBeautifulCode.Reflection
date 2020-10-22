// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterfaceTestTypes.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
    public interface ITestEmpty
    {
    }

    public interface ITestSingleLevel
    {
        string TestSingleLevelMethod1();

        string TestSingleLevelMethod2(int value);
    }

    public interface ITestMultiLevelParent
    {
        string TestMultiLevelParentMethod();
    }

    public interface ITestMultiLevelChild : ITestMultiLevelParent
    {
        string TestMultiLevelChildMethod();
    }

    public interface ITestMultiLevelGrandChild : ITestMultiLevelChild
    {
        string TestMultiLevelGrandChildMethod();
    }
#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}