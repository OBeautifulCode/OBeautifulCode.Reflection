// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using FluentAssertions;

    using OBeautifulCode.Reflection.Recipes;

    using Xunit;

    public static class TypeHelperTest
    {
        [Fact]
        public static void IsAnonymous___Should_return_true_for_anonymous_type()
        {
            // Arrange, Act, Assert
            new { SomeProp = "prop value" }.GetType().IsAnonymous().Should().BeTrue();
        }

        [Fact]
        public static void IsAnonymous___Should_return_false_for_concrete_type()
        {
            // Arrange, Act, Assert
            "string type".GetType().IsAnonymous().Should().BeFalse();
        }

        // ReSharper restore InconsistentNaming
    }
}
