// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.Constructor.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using FakeItEasy;
    using FluentAssertions;

    using Xunit;

    public static partial class ReflectionHelperTest
    {
        [Fact]
        public static void Construct___Should_construct_an_object_with_a_parameterless_constructor___When_parameter_parameters_is_null_or_empty()
        {
            // Arrange
            var type = typeof(Dog);

            // Act
            var actual1 = type.Construct();
            var actual2 = type.Construct(null);

            // Assert
            actual1.Should().BeOfType<Dog>();
            actual2.Should().BeOfType<Dog>();
        }

        [Fact]
        public static void Construct___Should_construct_a_object_whose_constructor_has_parameters___When_parameter_parameters_specifies_all_parameters_for_that_constructor()
        {
            // Arrange
            var numberOfLives = A.Dummy<int>();
            var type = typeof(Cat);

            // Act
            var actual = type.Construct(numberOfLives);

            // Assert
            actual.Should().BeOfType<Cat>();
            ((Cat)actual).NumberOfLives.Should().Be(numberOfLives);
        }

        [Fact]
        public static void Construct_T_objectArray___Should_construct_an_object_with_a_parameterless_constructor___When_parameter_parameters_is_null_or_empty()
        {
            // Arrange
            object[] nullParams = null;

            // Act
            var actual1 = ReflectionHelper.Construct<Dog>();
            var actual2 = ReflectionHelper.Construct<Dog>(nullParams);

            // Assert
            actual1.Should().NotBeNull();
            actual2.Should().NotBeNull();
        }

        [Fact]
        public static void Construct_T_objectArray___Should_construct_a_object_whose_constructor_has_parameters___When_parameter_parameters_specifies_all_parameters_for_that_constructor()
        {
            // Arrange
            var numberOfLives = A.Dummy<int>();

            // Act
            var actual = ReflectionHelper.Construct<Cat>(numberOfLives);

            // Assert
            actual.NumberOfLives.Should().Be(numberOfLives);
        }

        [Fact]
        public static void Construct_T_type_objectArray___Should_construct_an_object_with_a_parameterless_constructor___When_parameter_parameters_is_null_or_empty()
        {
            // Arrange
            var type = typeof(Dog);

            // Act
            var actual1 = type.Construct<Dog>();
            var actual2 = type.Construct<Dog>(null);
            var actual3 = type.Construct<IAnimal>();
            var actual4 = type.Construct<IAnimal>(null);

            // Assert
            actual1.Should().NotBeNull();
            actual2.Should().NotBeNull();
            actual3.Should().NotBeNull();
            actual4.Should().NotBeNull();
        }

        [Fact]
        public static void Construct_T_type_objectArray___Should_construct_a_object_whose_constructor_has_parameters___When_parameter_parameters_specifies_all_parameters_for_that_constructor()
        {
            // Arrange
            var numberOfLives = A.Dummy<int>();
            var type = typeof(Cat);

            // Act
            var actual1 = type.Construct<Cat>(numberOfLives);
            var actual2 = type.Construct<IAnimal>(numberOfLives);

            // Assert
            actual1.NumberOfLives.Should().Be(numberOfLives);
            ((Cat)actual2).NumberOfLives.Should().Be(numberOfLives);
        }
    }
}