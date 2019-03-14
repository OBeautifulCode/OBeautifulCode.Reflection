// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using OBeautifulCode.Reflection.Recipes;

    using Xunit;

    public static class ReflectionHelperTest
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

        [Fact]
        public static void GetAttribute_TAttribute___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.GetAttribute<NotAppliedAnywhereAttribute>(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttribute_TAttribute___Should_return_null___When_attribute_is_not_applied_to_type()
        {
            // Arrange
            var type1 = typeof(ClassWithNoAttributes);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var actual1 = type1.GetAttribute<NotAppliedAnywhereAttribute>();
            var actual2 = type2.GetAttribute<ColorAttribute>();

            // Assert
            actual1.Should().BeNull();
            actual2.Should().BeNull();
        }

        [Fact]
        public static void GetAttribute_TAttribute___Should_throw_InvalidOperationException___When_attribute_is_applied_multiple_times_to_type()
        {
            // Arrange
            var type = typeof(ClassWithPurpose);

            // Act
            var ex = Record.Exception(() => type.GetAttribute<PurposeAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void GetAttribute_TAttribute___Should_return_attribute_applied_to_class___When_attribute_is_only_applied_once_to_type()
        {
            // Arrange
            var type = typeof(ClassWithColor);

            // Act
            var actual = type.GetAttribute<ColorAttribute>();

            // Assert
            actual.Should().NotBeNull();
            actual.Color.Should().Be("blue");
        }

        [Fact]
        public static void GetAttributes_TAttribute___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.GetAttributes<NotAppliedAnywhereAttribute>(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributes_TAttribute___Should_return_empty_collection___When_no_attributes_of_specified_type_are_applied_to_type()
        {
            // Arrange
            var type1 = typeof(ClassWithNoAttributes);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var actual1 = type1.GetAttributes<NotAppliedAnywhereAttribute>();
            var actual2 = type2.GetAttributes<ColorAttribute>();

            // Assert
            actual1.Should().BeEmpty();
            actual2.Should().BeEmpty();
        }

        [Fact]
        public static void GetAttributes_TAttribute___Should_return_all_attributes_of_specified_type_applied_to_type___When_called()
        {
            // Arrange
            var type1 = typeof(ClassWithColor);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var actual1 = type1.GetAttributes<ColorAttribute>();
            var actual2 = type2.GetAttributes<PurposeAttribute>();

            // Assert
            actual1.Should().ContainSingle();
            actual1.Single().Color.Should().Be("blue");

            actual2.Should().HaveCount(2);
            actual2.First().Purpose.Should().Be("some purpose");
            actual2.Last().Purpose.Should().Be("some other purpose");
        }

        [Fact]
        public static void HasAttribute_TAttribute___Should_throw_ArgumentNullException___When_parameter_throwOnMultiple_is_true_and_parameter_type_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.HasAttribute<NotAppliedAnywhereAttribute>(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void HasAttribute_TAttribute___Should_return_false___When_parameter_throwOnMultiple_is_true_and_attribute_is_not_applied_to_type()
        {
            // Arrange
            var type1 = typeof(ClassWithNoAttributes);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var actual1 = type1.HasAttribute<NotAppliedAnywhereAttribute>();
            var actual2 = type2.HasAttribute<ColorAttribute>();

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void HasAttribute_TAttribute___Should_throw_InvalidOperationException___When_parameter_throwOnMultiple_is_true_and_attribute_is_applied_multiple_times_to_type()
        {
            // Arrange
            var type = typeof(ClassWithPurpose);

            // Act
            var ex = Record.Exception(() => type.HasAttribute<PurposeAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void HasAttribute_TAttribute___Should_return_true___When_parameter_throwOnMultiple_is_true_and_attribute_is_only_applied_once_to_type()
        {
            // Arrange
            var type = typeof(ClassWithColor);

            // Act
            var actual = type.HasAttribute<ColorAttribute>();

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void HasAttributes_TAttribute___Should_throw_ArgumentNullException___When_parameter_throwOnMultiple_is_false_and_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.HasAttribute<NotAppliedAnywhereAttribute>(null, throwOnMultiple: false));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void HasAttribute_TAttribute___Should_return_false___When_parameter_throwOnMultiple_is_false_and_no_attributes_of_specified_type_are_applied_to_type()
        {
            // Arrange
            var type1 = typeof(ClassWithNoAttributes);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var actual1 = type1.HasAttribute<NotAppliedAnywhereAttribute>(throwOnMultiple: false);
            var actual2 = type2.HasAttribute<ColorAttribute>(throwOnMultiple: false);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
        }

        [Fact]
        public static void HasAttribute_TAttribute___Should_return_true___When_parameter_throwOnMultiple_is_false_and_multiple_attributes_of_specified_type_are_applied_to_type()
        {
            // Arrange
            var type1 = typeof(ClassWithColor);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var actual1 = type1.HasAttribute<ColorAttribute>(throwOnMultiple: false);
            var actual2 = type2.HasAttribute<PurposeAttribute>(throwOnMultiple: false);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_Enum___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_Enum___Should_return_null___When_attribute_is_not_applied_to_enum_value()
        {
            // Arrange
            var enumValue = A.Dummy<GoodStuff>();

            // Act
            var actual = enumValue.GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            actual.Should().BeNull();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_Enum___Should_throw_InvalidOperationException___When_attribute_is_applied_multiple_times_to_enum_value()
        {
            // Arrange, Act
            var ex = Record.Exception(() => Sweet.Chocolate.GetAttributeOnEnumValue<MultipleAllowedAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_Enum___Should_return_attribute_applied_to_enum_value___When_attribute_is_only_applied_once()
        {
            // Arrange, Act
            var actual1 = Sweet.Cake.GetAttributeOnEnumValue<MultipleAllowedAttribute>();
            var actual2 = Sweet.Cookies.GetAttributeOnEnumValue<ColorAttribute>();
            var actual3 = Sweet.Chocolate.GetAttributeOnEnumValue<ColorAttribute>();

            // Assert
            actual1.Should().NotBeNull();
            actual2.Color.Should().Be("green");
            actual3.Color.Should().Be("brown");
        }

        [Fact]
        public static void GetAttributesOnEnumValue_TAttribute_Enum___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_TAttribute_Enum___Should_return_empty_collection___When_no_attributes_of_specified_type_are_applied_to_enum_value()
        {
            // Arrange
            var goodStuff = A.Dummy<GoodStuff>();

            // Act
            var actual = goodStuff.GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            actual.Should().BeEmpty();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_TAttribute_Enum___Should_return_all_attributes_of_specified_type_applied_to_enum_value___When_called()
        {
            // Arrange, Act
            var actual1 = Sweet.Cookies.GetAttributesOnEnumValue<ColorAttribute>();
            var actual2 = Fruit.Pear.GetAttributesOnEnumValue<PurposeAttribute>();

            // Assert
            actual1.Should().ContainSingle();
            actual1.Single().Color.Should().Be("green");

            actual2.Should().HaveCount(2);
            actual2.First().Purpose.Should().Be("toddlers love it");
            actual2.Last().Purpose.Should().Be("good shelf life");
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_Enum___Should_throw_ArgumentNullException___When_parameter_throwOnMultiple_is_true_and_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_Enum___Should_return_false___When_parameter_throwOnMultiple_is_true_and_attribute_is_not_applied_to_enum_value()
        {
            // Arrange
            var enumValue = A.Dummy<GoodStuff>();

            // Act
            var actual = enumValue.HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_Enum___Should_throw_InvalidOperationException___When_parameter_throwOnMultiple_is_true_and_attribute_is_applied_multiple_times_to_enum_value()
        {
            // Arrange, Act
            var ex = Record.Exception(() => Sweet.Chocolate.HasAttributeOnEnumValue<MultipleAllowedAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_Enum___Should_return_true___When_parameter_throwOnMultiple_is_true_and_attribute_is_only_applied_once()
        {
            // Arrange, Act
            var actual1 = Sweet.Cake.HasAttributeOnEnumValue<MultipleAllowedAttribute>();
            var actual2 = Sweet.Cookies.HasAttributeOnEnumValue<ColorAttribute>();
            var actual3 = Sweet.Chocolate.HasAttributeOnEnumValue<ColorAttribute>();

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_Enum___Should_throw_ArgumentNullException___When_parameter_throwOnMultiple_is_false_and_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>(throwOnMultiple: false));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_Enum___Should_return_false___When_parameter_throwOnMultiple_is_false_and_no_attributes_of_specified_type_are_applied_to_enum_value()
        {
            // Arrange
            var goodStuff = A.Dummy<GoodStuff>();

            // Act
            var actual = goodStuff.HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>(throwOnMultiple: false);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_Enum___Should_return_all_attributes_of_specified_type_applied_to_enum_value___When_parameter_throwOnMultiple_is_false_and_multiple_attributes_of_specified_type_are_applied_to_specified_enum_value()
        {
            // Arrange, Act
            var actual1 = Sweet.Cookies.HasAttributeOnEnumValue<ColorAttribute>(throwOnMultiple: false);
            var actual2 = Fruit.Pear.HasAttributeOnEnumValue<PurposeAttribute>(throwOnMultiple: false);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_object___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((object)null).GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_object___Should_throw_ArgumentException___When_parameter_enumValue_is_not_an_Enum()
        {
            // Arrange
            var enumValue = A.Dummy<string>();

            // Act
            var ex = Record.Exception(() => enumValue.GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_object___Should_return_null___When_attribute_is_not_applied_to_enum_value()
        {
            // Arrange
            var enumValue = (object)A.Dummy<GoodStuff>();

            // Act
            var actual = enumValue.GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            actual.Should().BeNull();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_object___Should_throw_InvalidOperationException___When_attribute_is_applied_multiple_times_to_enum_value()
        {
            // Arrange
            var enumValue = (object)Sweet.Chocolate;

            // Act
            var ex = Record.Exception(() => enumValue.GetAttributeOnEnumValue<MultipleAllowedAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_TAttribute_object___Should_return_attribute_applied_to_enum_value___When_attribute_is_only_applied_once()
        {
            // Arrange
            var enumValue1 = (object)Sweet.Cake;
            var enumValue2 = (object)Sweet.Cookies;
            var enumValue3 = (object)Sweet.Chocolate;

            // Act
            var actual1 = enumValue1.GetAttributeOnEnumValue<MultipleAllowedAttribute>();
            var actual2 = enumValue2.GetAttributeOnEnumValue<ColorAttribute>();
            var actual3 = enumValue3.GetAttributeOnEnumValue<ColorAttribute>();

            // Assert
            actual1.Should().NotBeNull();
            actual2.Color.Should().Be("green");
            actual3.Color.Should().Be("brown");
        }

        [Fact]
        public static void GetAttributesOnEnumValue_TAttribute_object___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((object)null).GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_TAttribute_object___Should_throw_ArgumentException___When_parameter_enumValue_is_not_of_type_Enum()
        {
            // Arrange
            var enumValue = A.Dummy<string>();

            // Act
            var ex = Record.Exception(() => enumValue.GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_TAttribute_object___Should_return_empty_collection___When_no_attributes_of_specified_type_are_applied_to_enum_value()
        {
            // Arrange
            var goodStuff = (object)A.Dummy<GoodStuff>();

            // Act
            var actual = goodStuff.GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            actual.Should().BeEmpty();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_TAttribute_object___Should_return_all_attributes_of_specified_type_applied_to_enum_value___When_called()
        {
            // Arrange
            var enumValue1 = (object)Sweet.Cookies;
            var enumValue2 = (object)Fruit.Pear;

            // Act
            var actual1 = enumValue1.GetAttributesOnEnumValue<ColorAttribute>();
            var actual2 = enumValue2.GetAttributesOnEnumValue<PurposeAttribute>();

            // Assert
            actual1.Should().ContainSingle();
            actual1.Single().Color.Should().Be("green");

            actual2.Should().HaveCount(2);
            actual2.First().Purpose.Should().Be("toddlers love it");
            actual2.Last().Purpose.Should().Be("good shelf life");
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_throw_ArgumentNullException___When_parameter_throwOnMultiple_is_true_and_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((object)null).HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_throw_ArgumentException___When_parameter_throwOnMultiple_is_true_parameter_enumValue_is_not_an_Enum()
        {
            // Arrange
            var enumValue = A.Dummy<string>();

            // Act
            var ex = Record.Exception(() => enumValue.HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_return_false___When_parameter_throwOnMultiple_is_true_attribute_is_not_applied_to_enum_value()
        {
            // Arrange
            var enumValue = (object)A.Dummy<GoodStuff>();

            // Act
            var actual = enumValue.HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_throw_InvalidOperationException___When_parameter_throwOnMultiple_is_true_attribute_is_applied_multiple_times_to_enum_value()
        {
            // Arrange
            var enumValue = (object)Sweet.Chocolate;

            // Act
            var ex = Record.Exception(() => enumValue.HasAttributeOnEnumValue<MultipleAllowedAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_return_true___When_parameter_throwOnMultiple_is_true_attribute_is_only_applied_once()
        {
            // Arrange
            var enumValue1 = (object)Sweet.Cake;
            var enumValue2 = (object)Sweet.Cookies;
            var enumValue3 = (object)Sweet.Chocolate;

            // Act
            var actual1 = enumValue1.HasAttributeOnEnumValue<MultipleAllowedAttribute>();
            var actual2 = enumValue2.HasAttributeOnEnumValue<ColorAttribute>();
            var actual3 = enumValue3.HasAttributeOnEnumValue<ColorAttribute>();

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_throw_ArgumentNullException___When_parameter_throwOnMultiple_is_false_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((object)null).HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>(throwOnMultiple: false));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_throw_ArgumentException___When_parameter_throwOnMultiple_is_false_parameter_enumValue_is_not_of_type_Enum()
        {
            // Arrange
            var enumValue = A.Dummy<string>();

            // Act
            var ex = Record.Exception(() => enumValue.HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>(throwOnMultiple: false));

            // Assert
            ex.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_return_false___When_parameter_throwOnMultiple_is_false_no_attributes_of_specified_type_are_applied_to_enum_value()
        {
            // Arrange
            var goodStuff = (object)A.Dummy<GoodStuff>();

            // Act
            var actual = goodStuff.HasAttributeOnEnumValue<NotAppliedAnywhereAttribute>(throwOnMultiple: false);

            // Assert
            actual.Should().BeFalse();
        }

        [Fact]
        public static void HasAttributeOnEnumValue_TAttribute_object___Should_return_true___When_parameter_throwOnMultiple_is_false_and_multiple_attributes_of_specified_type_are_applied_to_enum_value()
        {
            // Arrange
            var enumValue1 = (object)Sweet.Cookies;
            var enumValue2 = (object)Fruit.Pear;

            // Act
            var actual1 = enumValue1.HasAttributeOnEnumValue<ColorAttribute>(throwOnMultiple: false);
            var actual2 = enumValue2.HasAttributeOnEnumValue<PurposeAttribute>(throwOnMultiple: false);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
        }

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

        [Fact]
        public static void GetTypesHaving_TAttribute___Should_throw_ArgumentNullException___When_parameter_assembly_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.GetTypesHaving<EqualOpportunityAttribute>(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetTypesHaving_TAttribute___Should_return_all_types_in_assembly_having_specified_attribute___When_called()
        {
            // Arrange
            var assembly = typeof(ReflectionHelperTest).Assembly;

            // Act
            var actual = assembly.GetTypesHaving<EqualOpportunityAttribute>();

            // Assert
            actual.Should().HaveCount(5);
            actual.Should().BeEquivalentTo(typeof(EqualOpportunityEnum), typeof(IAmEqualOpportunity), typeof(IHaveEqualOpportunity), typeof(EqualOpportunityClassy), typeof(EqualOpportunityClassless));
        }

        [Fact]
        public static void GetTypesHaving_TAttribute___Should_return_all_types_in_assembly_having_specified_attribute_that_passes_attributeFilter___When_called()
        {
            // Arrange
            var assembly = typeof(ReflectionHelperTest).Assembly;

            // Act
            var actual = assembly.GetTypesHaving<EqualOpportunityAttribute>(_ => _.TheOpportunity == "classify none");

            // Assert
            actual.Should().HaveCount(3);
            actual.Should().BeEquivalentTo(typeof(IHaveEqualOpportunity), typeof(EqualOpportunityClassy), typeof(EqualOpportunityClassless));
        }

        [Fact]
        public static void HasPropertyTest()
        {
            var parentClass = new Parent();

            // exceptions
            Assert.Throws<ArgumentNullException>(() => ReflectionHelper.HasProperty(null, "PrivateParentDoubleProperty"));
            Assert.Throws<ArgumentNullException>(() => parentClass.HasProperty(null));
            Assert.Throws<ArgumentException>(() => parentClass.HasProperty(string.Empty));
            Assert.Throws<ArgumentException>(() => parentClass.HasProperty("\r\n"));
            Assert.Throws<ArgumentException>(() => parentClass.HasProperty("      \r\n       "));

            // property doesn't exist - case matters
            Assert.False(parentClass.HasProperty("privateParentDoubleProperty"));
            Assert.False(parentClass.HasProperty("privateParentStringproperty"));
            Assert.False(parentClass.HasProperty("_privateParentDoubleField"));
            Assert.False(parentClass.HasProperty("_privateParentStringField"));
            Assert.False(parentClass.HasProperty(" a "));

            // property does exist
            Assert.True(parentClass.HasProperty("PrivateParentDoubleProperty"));
            Assert.True(parentClass.HasProperty("PrivateParentStringProperty"));
            Assert.True(parentClass.HasProperty("PrivateStaticParentStringProperty"));

            // subclasses are accessed
            var childClass = new Child();
            Assert.True(childClass.HasProperty("PrivateParentDoubleProperty"));
            Assert.True(childClass.HasProperty("PrivateParentStringProperty"));

            // property does exist
            Assert.True(childClass.HasProperty("PrivateChildDoubleProperty"));
            Assert.True(childClass.HasProperty("PrivateChildStringProperty"));
        }

        [Fact]
        public static void HasFieldTest()
        {
            var parentClass = new Parent();

            // exceptions
            Assert.Throws<ArgumentNullException>(() => ReflectionHelper.HasField(null, "_privateParentDoubleField"));
            Assert.Throws<ArgumentNullException>(() => parentClass.HasField(null));
            Assert.Throws<ArgumentException>(() => parentClass.HasField(string.Empty));
            Assert.Throws<ArgumentException>(() => parentClass.HasField("\r\n"));
            Assert.Throws<ArgumentException>(() => parentClass.HasField("      \r\n       "));

            // property doesn't exist - case matters
            Assert.False(parentClass.HasField("_PrivateParentDoubleField"));
            Assert.False(parentClass.HasField("_PrivateParentStringField"));
            Assert.False(parentClass.HasField("PrivateParentDoubleProperty"));
            Assert.False(parentClass.HasField("PrivateParentStringProperty"));
            Assert.False(parentClass.HasField(" a "));

            // property does exist
            Assert.True(parentClass.HasField("_privateParentDoubleField"));
            Assert.True(parentClass.HasField("_privateParentStringField"));
            Assert.True(parentClass.HasField("_privateStaticParentStringField"));

            // subclasses are accessed
            var childClass = new Child();
            Assert.True(childClass.HasField("_privateParentDoubleField"));
            Assert.True(childClass.HasField("_privateParentStringField"));

            // property does exist
            Assert.True(childClass.HasField("_privateChildDoubleField"));
            Assert.True(childClass.HasField("_privateChildStringField"));
        }

        [Fact]
        public static void GetPropertyValueTest()
        {
            var parentClass = new Parent();

            // argument exceptions
            Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetPropertyValue<string>(null, "PrivateParentDoubleProperty"));
            Assert.Throws<ArgumentNullException>(() => parentClass.GetPropertyValue<string>(null));
            Assert.Throws<ArgumentException>(() => parentClass.GetPropertyValue<string>(string.Empty));
            Assert.Throws<ArgumentException>(() => parentClass.GetPropertyValue<string>("\r\n"));
            Assert.Throws<ArgumentException>(() => parentClass.GetPropertyValue<string>("      \r\n       "));

            // property doesn't exist - case matters
            Assert.Throws<InvalidOperationException>(() => parentClass.GetPropertyValue<double>("privateParentDoubleProperty"));
            Assert.Throws<InvalidOperationException>(() => parentClass.GetPropertyValue<string>("privateParentStringproperty"));
            Assert.Throws<InvalidOperationException>(() => parentClass.GetPropertyValue<double>("_privateParentDoubleField"));
            Assert.Throws<InvalidOperationException>(() => parentClass.GetPropertyValue<string>("_privateParentStringField"));
            Assert.Throws<InvalidOperationException>(() => parentClass.GetPropertyValue<string>(" a "));

            // property does exist, but is wrong type
            Assert.Throws<InvalidCastException>(() => parentClass.GetPropertyValue<string>("PrivateParentDoubleProperty"));
            Assert.Throws<InvalidCastException>(() => parentClass.GetPropertyValue<double>("PrivateParentStringProperty"));
            Assert.Throws<InvalidCastException>(() => parentClass.GetPropertyValue<string>("PrivateParentStreamProperty"));
            Assert.Throws<InvalidCastException>(() => parentClass.GetPropertyValue<string>("PrivateParentNullStreamProperty"));

            // property exists
            Assert.Equal(0d, parentClass.GetPropertyValue<double>("PrivateParentDoubleProperty"));
            Assert.Null(parentClass.GetPropertyValue<string>("PrivateParentStringProperty"));
            Assert.Equal("whatever3", parentClass.GetPropertyValue<string>("PrivateStaticParentStringProperty2"));

            // subclasses are accessed
            var childClass = new Child();
            Assert.Equal(0d, childClass.GetPropertyValue<double>("PrivateParentDoubleProperty"));
            Assert.Null(childClass.GetPropertyValue<string>("PrivateParentStringProperty"));

            // property exists
            Assert.Equal(456d, childClass.GetPropertyValue<double>("PrivateChildDoubleProperty"));
            Assert.Equal("Testing456", childClass.GetPropertyValue<string>("PrivateChildStringProperty"));

            // try getting MemoryStream for Stream
            Assert.Equal(2, parentClass.GetPropertyValue<Stream>("PrivateParentStreamProperty").Length);
            Assert.Equal(2, parentClass.GetPropertyValue<MemoryStream>("PrivateParentStreamProperty").Length);

            // try getting FileStream for Stream
            Assert.Throws<InvalidCastException>(() => parentClass.GetPropertyValue<FileStream>("PrivateParentStreamProperty").Length);

            // try getting MemoryStream for IDisposable
            Assert.Equal(3, parentClass.GetPropertyValue<Stream>("PrivateParentIDisposableProperty").Length);
            Assert.Equal(3, parentClass.GetPropertyValue<MemoryStream>("PrivateParentIDisposableProperty").Length);

            // try getting FileStream for IDisposable
            Assert.Throws<InvalidCastException>(() => parentClass.GetPropertyValue<FileStream>("PrivateParentIDisposableProperty").Length);
        }

        [Fact]
        public static void GetFieldValueTest()
        {
            var parentClass = new Parent();

            // argument exceptions
            Assert.Throws<ArgumentNullException>(() => ReflectionHelper.GetFieldValue<string>(null, "_privateParentDoubleField"));
            Assert.Throws<ArgumentNullException>(() => parentClass.GetFieldValue<string>(null));
            Assert.Throws<ArgumentException>(() => parentClass.GetFieldValue<string>(string.Empty));
            Assert.Throws<ArgumentException>(() => parentClass.GetFieldValue<string>("\r\n"));
            Assert.Throws<ArgumentException>(() => parentClass.GetFieldValue<string>("      \r\n       "));

            // field doesn't exist - case matters
            Assert.Throws<InvalidOperationException>(() => parentClass.GetFieldValue<double>("privateParentDoubleField"));
            Assert.Throws<InvalidOperationException>(() => parentClass.GetFieldValue<string>("_privateParentStringfield"));
            Assert.Throws<InvalidOperationException>(() => parentClass.GetFieldValue<double>("PrivateParentDoubleProperty"));
            Assert.Throws<InvalidOperationException>(() => parentClass.GetFieldValue<string>("PrivateParentStringProperty"));
            Assert.Throws<InvalidOperationException>(() => parentClass.GetFieldValue<string>(" a "));

            // field does exist, but is wrong type
            Assert.Throws<InvalidCastException>(() => parentClass.GetFieldValue<string>("_privateParentDoubleField"));
            Assert.Throws<InvalidCastException>(() => parentClass.GetFieldValue<double>("_privateParentStringField"));
            Assert.Throws<InvalidCastException>(() => parentClass.GetFieldValue<string>("_privateParentStreamField"));
            Assert.Throws<InvalidCastException>(() => parentClass.GetFieldValue<string>("_privateParentNullStreamField"));

            // field exists
            Assert.Equal(0d, parentClass.GetFieldValue<double>("_privateParentDoubleField"));
            Assert.Null(parentClass.GetFieldValue<string>("_privateParentStringField"));
            Assert.Equal("whatever2", parentClass.GetFieldValue<string>("_privateStaticParentStringField2"));

            // subclasses are accessed
            var childClass = new Child();
            Assert.Equal(0d, childClass.GetFieldValue<double>("_privateParentDoubleField"));
            Assert.Null(childClass.GetFieldValue<string>("_privateParentStringField"));

            // field exists
            Assert.Equal(123d, childClass.GetFieldValue<double>("_privateChildDoubleField"));
            Assert.Equal("Testing123", childClass.GetFieldValue<string>("_privateChildStringField"));

            // try getting MemoryStream for Stream
            Assert.Equal(1, parentClass.GetFieldValue<Stream>("_privateParentStreamField").Length);
            Assert.Equal(1, parentClass.GetFieldValue<MemoryStream>("_privateParentStreamField").Length);

            // try getting FileStream for Stream
            Assert.Throws<InvalidCastException>(() => parentClass.GetFieldValue<FileStream>("_privateParentStreamField").Length);

            // try getting MemoryStream for IDisposable
            Assert.Equal(0, parentClass.GetFieldValue<Stream>("_privateParentIDisposableField").Length);
            Assert.Equal(0, parentClass.GetFieldValue<MemoryStream>("_privateParentIDisposableField").Length);

            // try getting FileStream for IDisposable
            Assert.Throws<InvalidCastException>(() => parentClass.GetFieldValue<FileStream>("_privateParentIDisposableField").Length);
        }

        [Fact]
        public static void SetPropertyValueTest()
        {
            var parentClass = new Parent();

            // argument exceptions
            Assert.Throws<ArgumentNullException>(() => ReflectionHelper.SetPropertyValue<string>(null, "PrivateParentDoubleProperty", null));
            Assert.Throws<ArgumentNullException>(() => parentClass.SetPropertyValue<string>(null, null));
            Assert.Throws<ArgumentException>(() => parentClass.SetPropertyValue<string>(string.Empty, null));
            Assert.Throws<ArgumentException>(() => parentClass.SetPropertyValue<string>("\r\n", null));
            Assert.Throws<ArgumentException>(() => parentClass.SetPropertyValue<string>("      \r\n       ", null));

            // property doesn't exist - case matters
            Assert.Throws<InvalidOperationException>(() => parentClass.SetPropertyValue<double>("privateParentDoubleProperty", 789));
            Assert.Throws<InvalidOperationException>(() => parentClass.SetPropertyValue<string>("privateParentStringproperty", null));
            Assert.Throws<InvalidOperationException>(() => parentClass.SetPropertyValue<double>("_privateParentDoubleField", 789));
            Assert.Throws<InvalidOperationException>(() => parentClass.SetPropertyValue<string>("_privateParentStringField", null));
            Assert.Throws<InvalidOperationException>(() => parentClass.SetPropertyValue<string>(" a ", null));

            // property does exist, but is wrong type
            Assert.Throws<InvalidCastException>(() => parentClass.SetPropertyValue("PrivateParentDoubleProperty", "abcd"));
            Assert.Throws<InvalidCastException>(() => parentClass.SetPropertyValue("PrivateParentStringProperty", 123d));

            // property exists
            parentClass.SetPropertyValue("PrivateParentDoubleProperty", 8910d);
            Assert.Equal(8910d, parentClass.PublicParentDoubleProperty);
            parentClass.SetPropertyValue("PrivateParentStringProperty", "Testing8910");
            Assert.Equal("Testing8910", parentClass.PublicParentStringProperty);
            parentClass.SetPropertyValue("PrivateStaticParentStringProperty", "testing151617");
            Assert.Equal("testing151617", parentClass.PublicStaticParentStringProperty);

            // subclasses are accessed
            var childClass = new Child();
            childClass.SetPropertyValue("PrivateParentDoubleProperty", 123d);
            Assert.Equal(123d, childClass.PublicParentDoubleProperty);
            childClass.SetPropertyValue("PrivateParentStringProperty", "abc");
            Assert.Equal("abc", childClass.PublicParentStringProperty);

            // property exists
            childClass.SetPropertyValue("PrivateChildDoubleProperty", 111213d);
            childClass.SetPropertyValue("PrivateChildStringProperty", "Testing111213");
            Assert.Equal(111213d, childClass.PublicChildDoubleProperty);
            Assert.Equal("Testing111213", childClass.PublicChildStringProperty);

            // try setting MemoryStream for Stream
            parentClass.SetPropertyValue("PrivateParentStreamProperty", new MemoryStream(new byte[] { 0, 0, 0, 0 }, true));
            Assert.Equal(4, parentClass.PublicParentStreamProperty.Length);

            // testing MemoryStream for IDisposeable
            parentClass.SetPropertyValue("PrivateParentIDisposableProperty", new MemoryStream(new byte[] { 0, 0, 0, 0, 0 }, true));
            Assert.Equal(5, ((MemoryStream)parentClass.PublicParentIDisposableProperty).Length);
        }

        [Fact]
        public static void SetFieldValueTest()
        {
            var parentClass = new Parent();

            // argument exceptions
            Assert.Throws<ArgumentNullException>(() => ReflectionHelper.SetFieldValue<string>(null, "_privateParentDoubleField", null));
            Assert.Throws<ArgumentNullException>(() => parentClass.SetFieldValue<string>(null, null));
            Assert.Throws<ArgumentException>(() => parentClass.SetFieldValue<string>(string.Empty, null));
            Assert.Throws<ArgumentException>(() => parentClass.SetFieldValue<string>("\r\n", null));
            Assert.Throws<ArgumentException>(() => parentClass.SetFieldValue<string>("      \r\n       ", null));

            // property doesn't exist - case matters
            Assert.Throws<InvalidOperationException>(() => parentClass.SetFieldValue<double>("privateParentDoubleField", 789));
            Assert.Throws<InvalidOperationException>(() => parentClass.SetFieldValue<string>("privateParentStringfield", null));
            Assert.Throws<InvalidOperationException>(() => parentClass.SetFieldValue<double>("PrivateParentDoubleProperty", 789));
            Assert.Throws<InvalidOperationException>(() => parentClass.SetFieldValue<string>("PrivateParentStringProperty", null));
            Assert.Throws<InvalidOperationException>(() => parentClass.SetFieldValue<string>(" a ", null));

            // property does exist, but is wrong type
            Assert.Throws<InvalidCastException>(() => parentClass.SetFieldValue("_privateParentDoubleField", "abcd"));
            Assert.Throws<InvalidCastException>(() => parentClass.SetFieldValue("_privateParentStringField", 123d));

            // property exists
            parentClass.SetFieldValue("_privateParentDoubleField", 8910d);
            Assert.Equal(8910d, parentClass.PublicParentDoubleField);
            parentClass.SetFieldValue("_privateParentStringField", "Testing8910");
            Assert.Equal("Testing8910", parentClass.PublicParentStringField);
            parentClass.SetFieldValue("_privateStaticParentStringField", "Testing151617");
            Assert.Equal("Testing151617", parentClass.PublicStaticParentStringField);

            // subclasses are accessed
            var childClass = new Child();
            childClass.SetFieldValue("_privateParentDoubleField", 123d);
            Assert.Equal(123d, childClass.PublicParentDoubleField);
            childClass.SetFieldValue("_privateParentStringField", "abc");
            Assert.Equal("abc", childClass.PublicParentStringField);

            // property exists
            childClass.SetFieldValue("_privateChildDoubleField", 111213d);
            childClass.SetFieldValue("_privateChildStringField", "Testing111213");
            Assert.Equal(111213d, childClass.PublicChildDoubleField);
            Assert.Equal("Testing111213", childClass.PublicChildStringField);

            // try setting MemoryStream for Stream
            parentClass.SetFieldValue("_privateParentStreamField", new MemoryStream(new byte[] { 0, 0, 0, 0 }, true));
            Assert.Equal(4, parentClass.PublicParentStreamField.Length);

            // testing MemoryStream for IDisposable
            parentClass.SetFieldValue("_privateParentIDisposableField", new MemoryStream(new byte[] { 0, 0, 0, 0, 0 }, true));
            Assert.Equal(5, ((MemoryStream)parentClass.PublicParentIDisposableField).Length);
        }

        [Fact]
        public static void GetPropertyValue___Should_throw_InvalidCastException___When_property_value_is_null_and_property_type_is_not_assignable_to_generic_type_parameter()
        {
            // Arrange
            var item = new NullAndNotNullProperties
            {
                NotNullObject = new object(),
                NotNullString = A.Dummy<string>(),
            };

            // Act
            var actual1 = Record.Exception(() => item.GetPropertyValue<IDictionary<string, string>>(nameof(NullAndNotNullProperties.NullString)));
            var actual2 = Record.Exception(() => item.GetPropertyValue<IDictionary<string, string>>(nameof(NullAndNotNullProperties.NullObject)));
            var actual3 = Record.Exception(() => item.GetPropertyValue<string>(nameof(NullAndNotNullProperties.NullObject)));

            // Assert
            actual1.Should().BeOfType<InvalidCastException>();
            actual2.Should().BeOfType<InvalidCastException>();
            actual3.Should().BeOfType<InvalidCastException>();
        }

        [Fact]
        public static void GetPropertyValue___Should_throw_InvalidCastException___When_property_value_is_not_null_and_cannot_be_casted_to_generic_type_parameter()
        {
            // Arrange
            var item = new NullAndNotNullProperties
            {
                NotNullObject = new object(),
                NotNullString = A.Dummy<string>(),
            };

            // Act
            var actual1 = Record.Exception(() => item.GetPropertyValue<IDictionary<string, string>>(nameof(NullAndNotNullProperties.NotNullString)));
            var actual2 = Record.Exception(() => item.GetPropertyValue<IDictionary<string, string>>(nameof(NullAndNotNullProperties.NotNullObject)));
            var actual3 = Record.Exception(() => item.GetPropertyValue<string>(nameof(NullAndNotNullProperties.NotNullObject)));

            // Assert
            actual1.Should().BeOfType<InvalidCastException>();
            actual2.Should().BeOfType<InvalidCastException>();
            actual3.Should().BeOfType<InvalidCastException>();
        }

        [Fact]
        public static void GetPropertyValue___Should_return_null___When_property_value_is_null_and_property_type_is_assignable_to_generic_type_parameter()
        {
            // Arrange
            var item = new NullAndNotNullProperties
            {
                NotNullObject = A.Dummy<string>(),
                NotNullString = A.Dummy<string>(),
            };

            // Act
            var actual1 = item.GetPropertyValue<string>(nameof(NullAndNotNullProperties.NullString));
            var actual2 = item.GetPropertyValue<object>(nameof(NullAndNotNullProperties.NullString));
            var actual3 = item.GetPropertyValue<object>(nameof(NullAndNotNullProperties.NullString));

            // Assert
            actual1.Should().BeNull();
            actual2.Should().BeNull();
            actual3.Should().BeNull();
        }

        [Fact]
        public static void GetPropertyValue___Should_return_property_value___When_property_value_is_not_null_and_can_be_casted_to_generic_type_parameter()
        {
            // Arrange
            var item = new NullAndNotNullProperties
            {
                NotNullObject = A.Dummy<string>(),
                NotNullString = A.Dummy<string>(),
            };

            // Act
            var actual1 = item.GetPropertyValue<string>(nameof(NullAndNotNullProperties.NotNullString));
            var actual2 = item.GetPropertyValue<object>(nameof(NullAndNotNullProperties.NotNullString));
            var actual3 = item.GetPropertyValue<string>(nameof(NullAndNotNullProperties.NotNullObject));
            var actual4 = item.GetPropertyValue<object>(nameof(NullAndNotNullProperties.NotNullObject));

            // Assert
            actual1.Should().Be(item.NotNullString);
            actual2.Should().Be(item.NotNullString);
            actual3.Should().Be(item.NotNullObject.ToString());
            actual4.Should().Be(item.NotNullObject);
        }

        [Fact]
        public static void GetFieldValue___Should_throw_InvalidCastException___When_field_value_is_null_and_field_type_is_not_assignable_to_generic_type_parameter()
        {
            // Arrange
            var item = new NullAndNotNullFields
            {
                NotNullObject = new object(),
                NotNullString = A.Dummy<string>(),
            };

            // Act
            var actual1 = Record.Exception(() => item.GetFieldValue<IDictionary<string, string>>(nameof(NullAndNotNullFields.NullString)));
            var actual2 = Record.Exception(() => item.GetFieldValue<IDictionary<string, string>>(nameof(NullAndNotNullFields.NullObject)));
            var actual3 = Record.Exception(() => item.GetFieldValue<string>(nameof(NullAndNotNullFields.NullObject)));

            // Assert
            actual1.Should().BeOfType<InvalidCastException>();
            actual2.Should().BeOfType<InvalidCastException>();
            actual3.Should().BeOfType<InvalidCastException>();
        }

        [Fact]
        public static void GetFieldValue___Should_throw_InvalidCastException___When_field_value_is_not_null_and_cannot_be_casted_to_generic_type_parameter()
        {
            // Arrange
            var item = new NullAndNotNullFields
            {
                NotNullObject = new object(),
                NotNullString = A.Dummy<string>(),
            };

            // Act
            var actual1 = Record.Exception(() => item.GetFieldValue<IDictionary<string, string>>(nameof(NullAndNotNullFields.NotNullString)));
            var actual2 = Record.Exception(() => item.GetFieldValue<IDictionary<string, string>>(nameof(NullAndNotNullFields.NotNullObject)));
            var actual3 = Record.Exception(() => item.GetFieldValue<string>(nameof(NullAndNotNullFields.NotNullObject)));

            // Assert
            actual1.Should().BeOfType<InvalidCastException>();
            actual2.Should().BeOfType<InvalidCastException>();
            actual3.Should().BeOfType<InvalidCastException>();
        }

        [Fact]
        public static void GetFieldValue___Should_return_null___When_field_value_is_null_and_field_type_is_assignable_to_generic_type_parameter()
        {
            // Arrange
            var item = new NullAndNotNullFields
            {
                NotNullObject = A.Dummy<string>(),
                NotNullString = A.Dummy<string>(),
            };

            // Act
            var actual1 = item.GetFieldValue<string>(nameof(NullAndNotNullFields.NullString));
            var actual2 = item.GetFieldValue<object>(nameof(NullAndNotNullFields.NullString));
            var actual3 = item.GetFieldValue<object>(nameof(NullAndNotNullFields.NullString));

            // Assert
            actual1.Should().BeNull();
            actual2.Should().BeNull();
            actual3.Should().BeNull();
        }

        [Fact]
        public static void GetFieldValue___Should_return_field_value___When_field_value_is_not_null_and_can_be_casted_to_generic_type_parameter()
        {
            // Arrange
            var item = new NullAndNotNullFields
            {
                NotNullObject = A.Dummy<string>(),
                NotNullString = A.Dummy<string>(),
            };

            // Act
            var actual1 = item.GetFieldValue<string>(nameof(NullAndNotNullFields.NotNullString));
            var actual2 = item.GetFieldValue<object>(nameof(NullAndNotNullFields.NotNullString));
            var actual3 = item.GetFieldValue<string>(nameof(NullAndNotNullFields.NotNullObject));
            var actual4 = item.GetFieldValue<object>(nameof(NullAndNotNullFields.NotNullObject));

            // Assert
            actual1.Should().Be(item.NotNullString);
            actual2.Should().Be(item.NotNullString);
            actual3.Should().Be(item.NotNullObject.ToString());
            actual4.Should().Be(item.NotNullObject);
        }
    }
}
