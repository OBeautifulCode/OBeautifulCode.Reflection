// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.Attribute.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    public static partial class ReflectionHelperTest
    {
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
    }
}