// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.Method.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using OBeautifulCode.Assertion.Recipes;

    using Xunit;

    public static partial class ReflectionHelperTest
    {
        [Fact]
        public static void GetInterfaceDeclaredAndImplementedMethods___Should_throw_ArgumentNullException___When_parameter_interfaceType_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.GetInterfaceDeclaredAndImplementedMethods(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("interfaceType");
        }

        [Fact]
        public static void GetInterfaceDeclaredAndImplementedMethods___Should_throw_ArgumentException___When_parameter_interfaceType_is_not_an_interface_type()
        {
            // Arrange
            var notInterfaceTypes = new[]
            {
                typeof(object),
                typeof(string),
                typeof(int),
                typeof(int?),
                typeof(DayOfWeek),
            };

            // Act
            var actual = notInterfaceTypes.Select(_ => Record.Exception(_.GetInterfaceDeclaredAndImplementedMethods)).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("interfaceType is not an interface type.");
        }

        [Fact]
        public static void GetInterfaceDeclaredAndImplementedMethods___Should_return_declared_and_implemented_methods___When_callled()
        {
            // Arrange
            var interfaceTypeWithExpected = new[]
            {
                new
                {
                    InterfaceType = typeof(ITestEmpty),
                    Expected = (IReadOnlyCollection<string>)new string[] { },
                },
                new
                {
                    InterfaceType = typeof(ITestSingleLevel),
                    Expected = (IReadOnlyCollection<string>)new[]
                    {
                        nameof(ITestSingleLevel.TestSingleLevelMethod1),
                        nameof(ITestSingleLevel.TestSingleLevelMethod2),
                    },
                },
                new
                {
                    InterfaceType = typeof(ITestMultiLevelParent),
                    Expected = (IReadOnlyCollection<string>)new[]
                    {
                        nameof(ITestMultiLevelParent.TestMultiLevelParentMethod),
                    },
                },
                new
                {
                    InterfaceType = typeof(ITestMultiLevelChild),
                    Expected = (IReadOnlyCollection<string>)new[]
                    {
                        nameof(ITestMultiLevelParent.TestMultiLevelParentMethod),
                        nameof(ITestMultiLevelChild.TestMultiLevelChildMethod),
                    },
                },
                new
                {
                    InterfaceType = typeof(ITestMultiLevelGrandChild),
                    Expected = (IReadOnlyCollection<string>)new[]
                    {
                        nameof(ITestMultiLevelParent.TestMultiLevelParentMethod),
                        nameof(ITestMultiLevelChild.TestMultiLevelChildMethod),
                        nameof(ITestMultiLevelGrandChild.TestMultiLevelGrandChildMethod),
                    },
                },
            };

            var expectedMethodNames = interfaceTypeWithExpected.Select(_ => _.Expected).ToList();

            // Act
            var actual = interfaceTypeWithExpected.Select(_ => _.InterfaceType.GetInterfaceDeclaredAndImplementedMethods()).ToList();

            // Assert
            var actualMethodNames = actual.Select(_ => (IReadOnlyCollection<string>)_.Select(m => m.Name).ToList()).ToList();

            actualMethodNames.Must().BeEqualTo(expectedMethodNames);
        }
    }
}