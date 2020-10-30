// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.Field.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;
    using System.Linq;

    using OBeautifulCode.Assertion.Recipes;

    using Xunit;

    public static partial class ReflectionHelperTest
    {
        [Fact]
        public static void IsConstField___Should_throw_ArgumentNullException___When_parameter_fieldInfo_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.IsConstField(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("fieldInfo");
        }

        [Fact]
        public static void IsConstField___Should_return_false___When_field_is_not_a_const()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.ReadOnlyInstanceField),
                nameof(FieldMutability.ReadOnlyStaticField),
                nameof(FieldMutability.InstanceField),
                nameof(FieldMutability.StaticField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsConstField());

            // Assert
            actual.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void IsConstField___Should_return_true___When_field_is_a_const()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.ConstField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsConstField());

            // Assert
            actual.AsTest().Must().Each().BeTrue();
        }

        [Fact]
        public static void IsNotWritableField___Should_throw_ArgumentNullException___When_parameter_fieldInfo_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.IsNotWritableField(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("fieldInfo");
        }

        [Fact]
        public static void IsNotWritableField___Should_return_false___When_field_is_writable()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.InstanceField),
                nameof(FieldMutability.StaticField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsNotWritableField());

            // Assert
            actual.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void IsNotWritableField___Should_return_true___When_field_is_not_writable()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.ConstField),
                nameof(FieldMutability.ReadOnlyInstanceField),
                nameof(FieldMutability.ReadOnlyStaticField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsNotWritableField());

            // Assert
            actual.AsTest().Must().Each().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyField___Should_throw_ArgumentNullException___When_parameter_fieldInfo_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.IsReadOnlyField(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("fieldInfo");
        }

        [Fact]
        public static void IsReadOnlyField___Should_return_false___When_field_is_not_read_only()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.InstanceField),
                nameof(FieldMutability.StaticField),
                nameof(FieldMutability.ConstField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsReadOnlyField());

            // Assert
            actual.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyField___Should_return_true___When_field_is_read_only()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.ReadOnlyInstanceField),
                nameof(FieldMutability.ReadOnlyStaticField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsReadOnlyField());

            // Assert
            actual.AsTest().Must().Each().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyOrConstField___Should_throw_ArgumentNullException___When_parameter_fieldInfo_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.IsReadOnlyOrConstField(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("fieldInfo");
        }

        [Fact]
        public static void IsReadOnlyOrConstField___Should_return_false___When_field_is_not_read_only_and_not_const()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.InstanceField),
                nameof(FieldMutability.StaticField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsReadOnlyOrConstField());

            // Assert
            actual.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyOrConstField___Should_return_true___When_field_is_read_only_or_const()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.ConstField),
                nameof(FieldMutability.ReadOnlyInstanceField),
                nameof(FieldMutability.ReadOnlyStaticField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsReadOnlyOrConstField());

            // Assert
            actual.AsTest().Must().Each().BeTrue();
        }

        [Fact]
        public static void IsWritableField___Should_throw_ArgumentNullException___When_parameter_fieldInfo_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.IsWritableField(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("fieldInfo");
        }

        [Fact]
        public static void IsWritableField___Should_return_false___When_field_is_not_writable()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.ConstField),
                nameof(FieldMutability.ReadOnlyInstanceField),
                nameof(FieldMutability.ReadOnlyStaticField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsWritableField());

            // Assert
            actual.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void IsWritableField___Should_return_true___When_field_is_writable()
        {
            // Arrange
            var fields = new[]
            {
                nameof(FieldMutability.InstanceField),
                nameof(FieldMutability.StaticField),
            }
            .Select(_ => typeof(FieldMutability).GetFieldFiltered(_))
            .ToList();

            // Act
            var actual = fields.Select(_ => _.IsWritableField());

            // Assert
            actual.AsTest().Must().Each().BeTrue();
        }
    }
}