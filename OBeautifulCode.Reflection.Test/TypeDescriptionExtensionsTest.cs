// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDescriptionExtensionsTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using System;

    using FluentAssertions;

    using Xunit;

    public static class TypeDescriptionExtensionsTest
    {
        // ReSharper disable InconsistentNaming
        [Fact]
        public static void ToTypeDescription___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => TypeDescriptionExtensions.ToTypeDescription(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void ToTypeDescription___Should_return_type_description___When_called()
        {
            // Arrange
            var type = typeof(string);

            // Act
            var description = type.ToTypeDescription();

            // Assert
            description.AssemblyQualifiedName.Should().Be(type.AssemblyQualifiedName);
            description.Namespace.Should().Be(type.Namespace);
            description.Name.Should().Be(type.Name);
        }

        [Fact]
        public static void Resolve___Should_return_null___For_missing_type()
        {
            // Arrange
            var toFind = new TypeDescription("namespace", "name", "assemblyqualifiedname");

            // Act
            var result = toFind.ResolveFromLoadedTypes();

            // Assert
            result.Should().BeNull();
        }

        [Fact]
        public static void Resolve___Should_return_valid_type___For_found_type()
        {
            // Arrange
            var type = typeof(string);
            var toFind = type.ToTypeDescription();

            // Act
            var result = toFind.ResolveFromLoadedTypes();

            // Assert
            result.Should().NotBeNull();
            result.Should().Be(type);
        }

        // ReSharper restore InconsistentNaming
    }
}
