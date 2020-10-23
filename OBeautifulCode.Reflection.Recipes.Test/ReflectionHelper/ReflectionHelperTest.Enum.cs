// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.Enum.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;

    using FluentAssertions;

    using Xunit;

    public static partial class ReflectionHelperTest
    {
        [Fact]
        public static void GetEnumValuesHaving_TEnum_TAttribute___Should_throw_ArgumentException___When_TEnum_is_not_an_Enum_type()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.GetEnumValuesHaving<int, PurposeAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetEnumValuesHaving_TEnum_TAttribute____Should_return_empty_collection___When_none_of_the_enum_values_have_the_specified_attribute()
        {
            // Arrange, Act
            var actual1 = ReflectionHelper.GetEnumValuesHaving<GoodStuff, PurposeAttribute>();
            var actual2 = ReflectionHelper.GetEnumValuesHaving<GoodStuff, PurposeAttribute>(_ => _.Purpose == "none");

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().BeEmpty();
        }

        [Fact]
        public static void GetEnumValuesHaving_TEnum_TAttribute____Should_return_empty_collection___When_none_of_the_enum_values_have_the_specified_attribute_that_passes_the_specified_attributeFilter()
        {
            // Arrange, Act
            var actual1 = ReflectionHelper.GetEnumValuesHaving<Sweet, ColorAttribute>(_ => _.Color == "purple");
            var actual2 = ReflectionHelper.GetEnumValuesHaving<Sweet, MultipleAllowedAttribute>(_ => false);
            var actual3 = ReflectionHelper.GetEnumValuesHaving<Fruit, PurposeAttribute>(_ => _.Purpose == "no purpose");

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().BeEmpty();
            actual3.Should().BeEmpty();
        }

        [Fact]
        public static void GetEnumValuesHaving_TEnum_TAttribute____Should_return_all_enum_values_having_specified_attribute___When_some_enum_values_have_specified_attribute()
        {
            // Arrange, Act
            var actual1 = ReflectionHelper.GetEnumValuesHaving<Sweet, MultipleAllowedAttribute>();
            var actual2 = ReflectionHelper.GetEnumValuesHaving<Sweet, ColorAttribute>();
            var actual3 = ReflectionHelper.GetEnumValuesHaving<Fruit, PurposeAttribute>();

            // Assert
            actual1.Should().Equal(Sweet.Cake, Sweet.Chocolate);
            actual2.Should().Equal(Sweet.Chocolate, Sweet.Cookies);
            actual3.Should().Equal(Fruit.Pear);
        }

        [Fact]
        public static void GetEnumValuesHaving_TEnum_TAttribute____Should_return_all_enum_values_having_specified_attribute_that_passes_attributeFilter___When_some_enum_values_have_the_specified_attribute_that_passes_the_attributeFilter()
        {
            // Arrange, Act
            var actual1 = ReflectionHelper.GetEnumValuesHaving<Sweet, ColorAttribute>(_ => _.Color == "brown");
            var actual2 = ReflectionHelper.GetEnumValuesHaving<Sweet, ColorAttribute>(_ => _.Color == "brown" || _.Color == "green");
            var actual3 = ReflectionHelper.GetEnumValuesHaving<Fruit, PurposeAttribute>(_ => _.Purpose == "good shelf life");

            // Assert
            actual1.Should().Equal(Sweet.Chocolate);
            actual2.Should().Equal(Sweet.Chocolate, Sweet.Cookies);
            actual3.Should().Equal(Fruit.Pear);
        }

        [Fact]
        public static void GetEnumValuesHaving_TAttribute___Should_throw_ArgumentException___When_TEnum_is_not_an_Enum_type()
        {
            // Arrange, Act
            var ex = Record.Exception(() => typeof(int).GetEnumValuesHaving<PurposeAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetEnumValuesHaving_TAttribute____Should_return_empty_collection___When_none_of_the_enum_values_have_the_specified_attribute()
        {
            // Arrange, Act
            var actual1 = typeof(GoodStuff).GetEnumValuesHaving<PurposeAttribute>();
            var actual2 = typeof(GoodStuff).GetEnumValuesHaving<PurposeAttribute>(_ => _.Purpose == "none");

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().BeEmpty();
        }

        [Fact]
        public static void GetEnumValuesHaving_TAttribute____Should_return_empty_collection___When_none_of_the_enum_values_have_the_specified_attribute_that_passes_the_specified_attributeFilter()
        {
            // Arrange, Act
            var actual1 = typeof(Sweet).GetEnumValuesHaving<ColorAttribute>(_ => _.Color == "purple");
            var actual2 = typeof(Sweet).GetEnumValuesHaving<MultipleAllowedAttribute>(_ => false);
            var actual3 = typeof(Fruit).GetEnumValuesHaving<PurposeAttribute>(_ => _.Purpose == "no purpose");

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().BeEmpty();
            actual3.Should().BeEmpty();
        }

        [Fact]
        public static void GetEnumValuesHaving_TAttribute____Should_return_all_enum_values_having_specified_attribute___When_some_enum_values_have_specified_attribute()
        {
            // Arrange, Act
            var actual1 = typeof(Sweet).GetEnumValuesHaving<MultipleAllowedAttribute>();
            var actual2 = typeof(Sweet).GetEnumValuesHaving<ColorAttribute>();
            var actual3 = typeof(Fruit).GetEnumValuesHaving<PurposeAttribute>();

            // Assert
            actual1.Should().Equal(Sweet.Cake, Sweet.Chocolate);
            actual2.Should().Equal(Sweet.Chocolate, Sweet.Cookies);
            actual3.Should().Equal(Fruit.Pear);
        }

        [Fact]
        public static void GetEnumValuesHaving_TAttribute____Should_return_all_enum_values_having_specified_attribute_that_passes_attributeFilter___When_some_enum_values_have_the_specified_attribute_that_passes_the_attributeFilter()
        {
            // Arrange, Act
            var actual1 = typeof(Sweet).GetEnumValuesHaving<ColorAttribute>(_ => _.Color == "brown");
            var actual2 = typeof(Sweet).GetEnumValuesHaving<ColorAttribute>(_ => _.Color == "brown" || _.Color == "green");
            var actual3 = typeof(Fruit).GetEnumValuesHaving<PurposeAttribute>(_ => _.Purpose == "good shelf life");

            // Assert
            actual1.Should().Equal(Sweet.Chocolate);
            actual2.Should().Equal(Sweet.Chocolate, Sweet.Cookies);
            actual3.Should().Equal(Fruit.Pear);
        }
    }
}