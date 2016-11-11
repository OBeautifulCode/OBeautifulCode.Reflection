// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDescriptionTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    public static class TypeDescriptionTest
    {
        // ReSharper disable InconsistentNaming
        [Fact]
        public static void EqualsOperator___Should_return_true___When_both_sides_of_operator_are_null()
        {
            // Arrange
            TypeDescription typeDescription1 = null;
            TypeDescription typeDescription2 = null;

            // Act
            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            var result = typeDescription1 == typeDescription2;

            // Assert
            result.Should().BeTrue();
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
        }

        [Fact]
        public static void EqualsOperator___Should_return_false___When_one_side_of_operator_is_null_and_the_other_side_is_not_null()
        {
            // Arrange
            TypeDescription typeDescription1 = null;
            var typeDescription2 = A.Dummy<TypeDescription>();

            // Act
            // ReSharper disable ExpressionIsAlwaysNull
            var result1 = typeDescription1 == typeDescription2;
            var result2 = typeDescription2 == typeDescription1;

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
            // ReSharper restore ExpressionIsAlwaysNull
        }

        [Fact]
        public static void EqualsOperator___Should_return_true___When_same_object_is_on_both_sides_of_operator()
        {
            // Arrange
            var typeDescription = A.Dummy<TypeDescription>();

            // Act
            // ReSharper disable EqualExpressionComparison
#pragma warning disable CS1718 // Comparison made to same variable
            var result = typeDescription == typeDescription;
#pragma warning restore CS1718 // Comparison made to same variable

            // Assert
            result.Should().BeTrue();
            // ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public static void EqualsOperator___Should_return_false___When_objects_being_compared_have_different_property_values()
        {
            // Arrange
            var typeDescription1A = A.Dummy<TypeDescription>();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = A.Dummy<string>(), Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = null, Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription3A = A.Dummy<TypeDescription>();
            var typeDescription3B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = A.Dummy<string>(), Namespace = typeDescription1A.Namespace };

            var typeDescription4A = A.Dummy<TypeDescription>();
            var typeDescription4B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = null, Namespace = typeDescription1A.Namespace };

            var typeDescription5A = A.Dummy<TypeDescription>();
            var typeDescription5B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = A.Dummy<string>() };

            var typeDescription6A = A.Dummy<TypeDescription>();
            var typeDescription6B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = null };

            // Act
            var result1 = typeDescription1A == typeDescription1B;
            var result2 = typeDescription2A == typeDescription2B;
            var result3 = typeDescription3A == typeDescription3B;
            var result4 = typeDescription4A == typeDescription4B;
            var result5 = typeDescription5A == typeDescription5B;
            var result6 = typeDescription6A == typeDescription6B;

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
            result3.Should().BeFalse();
            result4.Should().BeFalse();
            result5.Should().BeFalse();
            result6.Should().BeFalse();
        }

        [Fact]
        public static void EqualsOperator___Should_return_true___When_objects_being_compared_have_same_property_values()
        {
            // Arrange
            var typeDescription1A = new TypeDescription();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = null, Name = null, Namespace = null };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = typeDescription2A.AssemblyQualifiedName, Name = typeDescription2A.Name, Namespace = typeDescription2A.Namespace };

            // Act
            var result1 = typeDescription1A == typeDescription1B;
            var result2 = typeDescription2A == typeDescription2B;

            // Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Fact]
        public static void NotEqualsOperator___Should_return_false___When_both_sides_of_operator_are_null()
        {
            // Arrange
            TypeDescription typeDescription1 = null;
            TypeDescription typeDescription2 = null;

            // Act
            // ReSharper disable ConditionIsAlwaysTrueOrFalse
            var result = typeDescription1 != typeDescription2;

            // Assert
            result.Should().BeFalse();
            // ReSharper restore ConditionIsAlwaysTrueOrFalse
        }

        [Fact]
        public static void NotEqualsOperator___Should_return_true___When_one_side_of_operator_is_null_and_the_other_side_is_not_null()
        {
            // Arrange
            TypeDescription typeDescription1 = null;
            var typeDescription2 = A.Dummy<TypeDescription>();

            // Act
            // ReSharper disable ExpressionIsAlwaysNull
            var result1 = typeDescription1 != typeDescription2;
            var result2 = typeDescription2 != typeDescription1;

            // Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
            // ReSharper restore ExpressionIsAlwaysNull
        }

        [Fact]
        public static void NotEqualsOperator___Should_return_false___When_same_object_is_on_both_sides_of_operator()
        {
            // Arrange
            var typeDescription = A.Dummy<TypeDescription>();

            // Act
            // ReSharper disable EqualExpressionComparison
#pragma warning disable CS1718 // Comparison made to same variable
            var result = typeDescription != typeDescription;
#pragma warning restore CS1718 // Comparison made to same variable

            // Assert
            result.Should().BeFalse();
            // ReSharper restore EqualExpressionComparison
        }

        [Fact]
        public static void NotEqualsOperator___Should_return_true___When_objects_being_compared_have_different_property_values()
        {
            // Arrange
            var typeDescription1A = A.Dummy<TypeDescription>();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = A.Dummy<string>(), Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = null, Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription3A = A.Dummy<TypeDescription>();
            var typeDescription3B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = A.Dummy<string>(), Namespace = typeDescription1A.Namespace };

            var typeDescription4A = A.Dummy<TypeDescription>();
            var typeDescription4B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = null, Namespace = typeDescription1A.Namespace };

            var typeDescription5A = A.Dummy<TypeDescription>();
            var typeDescription5B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = A.Dummy<string>() };

            var typeDescription6A = A.Dummy<TypeDescription>();
            var typeDescription6B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = null };

            // Act
            var result1 = typeDescription1A != typeDescription1B;
            var result2 = typeDescription2A != typeDescription2B;
            var result3 = typeDescription3A != typeDescription3B;
            var result4 = typeDescription4A != typeDescription4B;
            var result5 = typeDescription5A != typeDescription5B;
            var result6 = typeDescription6A != typeDescription6B;

            // Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
            result3.Should().BeTrue();
            result4.Should().BeTrue();
            result5.Should().BeTrue();
            result6.Should().BeTrue();
        }

        [Fact]
        public static void NotEqualsOperator___Should_return_false___When_objects_being_compared_have_same_property_values()
        {
            // Arrange
            var typeDescription1A = new TypeDescription();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = null, Name = null, Namespace = null };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = typeDescription2A.AssemblyQualifiedName, Name = typeDescription2A.Name, Namespace = typeDescription2A.Namespace };

            // Act
            var result1 = typeDescription1A != typeDescription1B;
            var result2 = typeDescription2A != typeDescription2B;

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_false___When_calling_typed_overload_and_parameter_other_is_null()
        {
            // Arrange
            var typeDescription = A.Dummy<TypeDescription>();

            // Act
            var result1 = typeDescription.Equals(null);

            // Assert
            result1.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_calling_typed_overload_and_parameter_other_is_same_object()
        {
            // Arrange
            var typeDescription = A.Dummy<TypeDescription>();

            // Act
            var result = typeDescription.Equals(typeDescription);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_calling_typed_overload_and_objects_being_compared_have_different_property_values()
        {
            // Arrange
            var typeDescription1A = A.Dummy<TypeDescription>();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = A.Dummy<string>(), Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = null, Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription3A = A.Dummy<TypeDescription>();
            var typeDescription3B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = A.Dummy<string>(), Namespace = typeDescription1A.Namespace };

            var typeDescription4A = A.Dummy<TypeDescription>();
            var typeDescription4B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = null, Namespace = typeDescription1A.Namespace };

            var typeDescription5A = A.Dummy<TypeDescription>();
            var typeDescription5B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = A.Dummy<string>() };

            var typeDescription6A = A.Dummy<TypeDescription>();
            var typeDescription6B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = null };

            // Act
            var result1 = typeDescription1A.Equals(typeDescription1B);
            var result2 = typeDescription2A.Equals(typeDescription2B);
            var result3 = typeDescription3A.Equals(typeDescription3B);
            var result4 = typeDescription4A.Equals(typeDescription4B);
            var result5 = typeDescription5A.Equals(typeDescription5B);
            var result6 = typeDescription6A.Equals(typeDescription6B);

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
            result3.Should().BeFalse();
            result4.Should().BeFalse();
            result5.Should().BeFalse();
            result6.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_calling_typed_overload_and_objects_being_compared_have_same_property_values()
        {
            // Arrange
            var typeDescription1A = new TypeDescription();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = null, Name = null, Namespace = null };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = typeDescription2A.AssemblyQualifiedName, Name = typeDescription2A.Name, Namespace = typeDescription2A.Namespace };

            // Act
            var result1 = typeDescription1A.Equals(typeDescription1B);
            var result2 = typeDescription2A.Equals(typeDescription2B);

            // Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_calling_untyped_overload_and_parameter_other_is_null()
        {
            // Arrange
            var typeDescription = A.Dummy<TypeDescription>();

            // Act
            var result1 = typeDescription.Equals(null);

            // Assert
            result1.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_false___When_calling_untyped_overload_and_parameter_other_is_not_of_the_same_type()
        {
            // Arrange
            var typeDescription1 = A.Dummy<TypeDescription>();
            var typeDescription2 = A.Dummy<string>();

            // Act
            // ReSharper disable SuspiciousTypeConversion.Global
            // ReSharper disable RedundantCast
            var result1 = typeDescription1.Equals((object)typeDescription2);
            // ReSharper restore RedundantCast
            // ReSharper restore SuspiciousTypeConversion.Global

            // Assert
            result1.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_calling_untyped_overload_and_parameter_other_is_same_object()
        {
            // Arrange
            var typeDescription = A.Dummy<TypeDescription>();

            // Act
            var result = typeDescription.Equals((object)typeDescription);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public static void Equals___Should_return_false___When_calling_untyped_overload_and_objects_being_compared_have_different_property_values()
        {
            // Arrange
            var typeDescription1A = A.Dummy<TypeDescription>();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = A.Dummy<string>(), Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = null, Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription3A = A.Dummy<TypeDescription>();
            var typeDescription3B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = A.Dummy<string>(), Namespace = typeDescription1A.Namespace };

            var typeDescription4A = A.Dummy<TypeDescription>();
            var typeDescription4B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = null, Namespace = typeDescription1A.Namespace };

            var typeDescription5A = A.Dummy<TypeDescription>();
            var typeDescription5B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = A.Dummy<string>() };

            var typeDescription6A = A.Dummy<TypeDescription>();
            var typeDescription6B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = null };

            // Act
            var result1 = typeDescription1A.Equals((object)typeDescription1B);
            var result2 = typeDescription2A.Equals((object)typeDescription2B);
            var result3 = typeDescription3A.Equals((object)typeDescription3B);
            var result4 = typeDescription4A.Equals((object)typeDescription4B);
            var result5 = typeDescription5A.Equals((object)typeDescription5B);
            var result6 = typeDescription6A.Equals((object)typeDescription6B);

            // Assert
            result1.Should().BeFalse();
            result2.Should().BeFalse();
            result3.Should().BeFalse();
            result4.Should().BeFalse();
            result5.Should().BeFalse();
            result6.Should().BeFalse();
        }

        [Fact]
        public static void Equals___Should_return_true___When_calling_untyped_overload_and_objects_being_compared_have_same_property_values()
        {
            // Arrange
            var typeDescription1A = new TypeDescription();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = null, Name = null, Namespace = null };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = typeDescription2A.AssemblyQualifiedName, Name = typeDescription2A.Name, Namespace = typeDescription2A.Namespace };

            // Act
            var result1 = typeDescription1A.Equals((object)typeDescription1B);
            var result2 = typeDescription2A.Equals((object)typeDescription2B);

            // Assert
            result1.Should().BeTrue();
            result2.Should().BeTrue();
        }

        [Fact]
        public static void GetHashCode___Should_not_be_equal___When_objects_have_different_property_values()
        {
            // Arrange
            var typeDescription1A = A.Dummy<TypeDescription>();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = A.Dummy<string>(), Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = null, Name = typeDescription1A.Name, Namespace = typeDescription1A.Namespace };

            var typeDescription3A = A.Dummy<TypeDescription>();
            var typeDescription3B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = A.Dummy<string>(), Namespace = typeDescription1A.Namespace };

            var typeDescription4A = A.Dummy<TypeDescription>();
            var typeDescription4B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = null, Namespace = typeDescription1A.Namespace };

            var typeDescription5A = A.Dummy<TypeDescription>();
            var typeDescription5B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = A.Dummy<string>() };

            var typeDescription6A = A.Dummy<TypeDescription>();
            var typeDescription6B = new TypeDescription { AssemblyQualifiedName = typeDescription1A.AssemblyQualifiedName, Name = typeDescription1A.Name, Namespace = null };

            // Act
            var hash1A = typeDescription1A.GetHashCode();
            var hash1B = typeDescription1B.GetHashCode();

            var hash2A = typeDescription2A.GetHashCode();
            var hash2B = typeDescription2B.GetHashCode();

            var hash3A = typeDescription3A.GetHashCode();
            var hash3B = typeDescription3B.GetHashCode();

            var hash4A = typeDescription4A.GetHashCode();
            var hash4B = typeDescription4B.GetHashCode();

            var hash5A = typeDescription5A.GetHashCode();
            var hash5B = typeDescription5B.GetHashCode();

            var hash6A = typeDescription6A.GetHashCode();
            var hash6B = typeDescription6B.GetHashCode();

            // Assert
            hash1A.Should().NotBe(hash1B);
            hash2A.Should().NotBe(hash2B);
            hash3A.Should().NotBe(hash3B);
            hash4A.Should().NotBe(hash4B);
            hash5A.Should().NotBe(hash5B);
            hash6A.Should().NotBe(hash6B);
        }

        [Fact]
        public static void GetHashCode___Should_be_equal___When_objects_have_the_same_property_values()
        {
            // Arrange
            var typeDescription1A = new TypeDescription();
            var typeDescription1B = new TypeDescription { AssemblyQualifiedName = null, Name = null, Namespace = null };

            var typeDescription2A = A.Dummy<TypeDescription>();
            var typeDescription2B = new TypeDescription { AssemblyQualifiedName = typeDescription2A.AssemblyQualifiedName, Name = typeDescription2A.Name, Namespace = typeDescription2A.Namespace };

            // Act
            var hash1A = typeDescription1A.GetHashCode();
            var hash1B = typeDescription1B.GetHashCode();

            var hash2A = typeDescription2A.GetHashCode();
            var hash2B = typeDescription2B.GetHashCode();

            // Assert
            hash1A.Should().Be(hash1B);
            hash2A.Should().Be(hash2B);
        }

        // ReSharper restore InconsistentNaming
    }
}
