// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using System;
    using System.IO;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    /// <summary>
    /// Tests the <see cref="ReflectionHelper"/> class.
    /// </summary>
    /// <remarks>
    /// This was ported from an older code base.
    /// The test are monolitic and need to be broken up.
    /// Also, need to use latest unit testing conventions.
    /// </remarks>
    public static class ReflectionHelperTest
    {
        [Fact]
        public static void Construct_untyped___Should_construct_an_object_with_a_parameterless_constructor___When_parameter_parameters_is_null_or_empty()
        {
            // Arrange
            var type = typeof(Dog);

            // Act
            var result1 = type.Construct();
            var result2 = type.Construct(null);

            // Assert
            result1.Should().BeOfType<Dog>();
            result2.Should().BeOfType<Dog>();
        }

        [Fact]
        public static void Construct_untyped___Should_construct_a_object_whose_constructor_has_parameters___When_parameter_parameters_specifies_all_parameters_for_that_constructor()
        {
            // Arrange
            int numberOfLives = A.Dummy<int>();
            var type = typeof(Cat);

            // Act
            var result = type.Construct(numberOfLives);

            // Assert
            result.Should().BeOfType<Cat>();
            ((Cat)result).NumberOfLives.Should().Be(numberOfLives);
        }

        [Fact]
        public static void Construct_with_same_type_to_construct_as_type_to_return___Should_construct_an_object_with_a_parameterless_constructor___When_parameter_parameters_is_null_or_empty()
        {
            // Arrange
            object[] nullParams = null;

            // Act
            // ReSharper disable ExpressionIsAlwaysNull
            var result1 = ReflectionHelper.Construct<Dog>();
            var result2 = ReflectionHelper.Construct<Dog>(nullParams);
            // ReSharper restore ExpressionIsAlwaysNull

            // Assert
            result1.Should().NotBeNull();
            result2.Should().NotBeNull();
        }

        [Fact]
        public static void Construct_with_same_type_to_construct_as_type_to_return___Should_construct_a_object_whose_constructor_has_parameters___When_parameter_parameters_specifies_all_parameters_for_that_constructor()
        {
            // Arrange
            int numberOfLives = A.Dummy<int>();

            // Act
            var result = ReflectionHelper.Construct<Cat>(numberOfLives);

            // Assert
            result.NumberOfLives.Should().Be(numberOfLives);
        }

        [Fact]
        public static void Construct_with_different_type_to_construct_and_type_to_return___Should_construct_an_object_with_a_parameterless_constructor___When_parameter_parameters_is_null_or_empty()
        {
            // Arrange
            var type = typeof(Dog);

            // Act
            // ReSharper disable ExpressionIsAlwaysNull
            var result1 = type.Construct<Dog>();
            var result2 = type.Construct<Dog>(null);
            var result3 = type.Construct<IAnimal>();
            var result4 = type.Construct<IAnimal>(null);
            // ReSharper restore ExpressionIsAlwaysNull

            // Assert
            result1.Should().NotBeNull();
            result2.Should().NotBeNull();
            result3.Should().NotBeNull();
            result4.Should().NotBeNull();
        }

        [Fact]
        public static void Construct_with_different_type_to_construct_and_type_to_return___Should_construct_a_object_whose_constructor_has_parameters___When_parameter_parameters_specifies_all_parameters_for_that_constructor()
        {
            // Arrange
            int numberOfLives = A.Dummy<int>();
            var type = typeof(Cat);

            // Act
            var result1 = type.Construct<Cat>(numberOfLives);
            var result2 = type.Construct<IAnimal>(numberOfLives);

            // Assert
            result1.NumberOfLives.Should().Be(numberOfLives);
            ((Cat)result2).NumberOfLives.Should().Be(numberOfLives);
        }

        [Fact]
        public static void GetAttribute___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.GetAttribute<NotAppliedAnywhereAttribute>(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttribute___Should_return_null___When_attribute_is_not_applied_to_type()
        {
            // Arrange
            var type1 = typeof(ClassWithNoAttributes);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var attribute1 = type1.GetAttribute<NotAppliedAnywhereAttribute>();
            var attribute2 = type2.GetAttribute<ColorAttribute>();

            // Assert
            attribute1.Should().BeNull();
            attribute2.Should().BeNull();
        }

        [Fact]
        public static void GetAttribute___Should_throw_InvalidOperationException___When_attribute_is_applied_multiple_times_to_type()
        {
            // Arrange
            var type = typeof(ClassWithPurpose);

            // Act
            var ex = Record.Exception(() => type.GetAttribute<PurposeAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void GetAttribute___Should_return_attribute_applied_to_class___When_attribute_is_only_applied_once_to_type()
        {
            // Arrange
            var type = typeof(ClassWithColor);

            // Act
            var attribute = type.GetAttribute<ColorAttribute>();

            // Assert
            attribute.Should().NotBeNull();
            attribute.Color.Should().Be("blue");
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_Enum___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_Enum___Should_return_null___When_attribute_is_not_applied_to_enum_value()
        {
            // Arrange
            var enumValue = A.Dummy<GoodStuff>();

            // Act
            var attribute = enumValue.GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            attribute.Should().BeNull();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_Enum___Should_throw_InvalidOperationException___When_attribute_is_applied_multiple_times_to_enum_value()
        {
            // Arrange, Act
            var ex = Record.Exception(() => Sweet.Chocolate.GetAttributeOnEnumValue<MultipleAllowedAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_Enum___Should_return_attribute_applied_to_enum_value___When_attribute_is_only_applied_once()
        {
            // Arrange, Act
            var attribute1 = Sweet.Cake.GetAttributeOnEnumValue<MultipleAllowedAttribute>();
            var attribute2 = Sweet.Cookies.GetAttributeOnEnumValue<ColorAttribute>();
            var attribute3 = Sweet.Chocolate.GetAttributeOnEnumValue<ColorAttribute>();

            // Assert
            attribute1.Should().NotBeNull();
            attribute2.Color.Should().Be("green");
            attribute3.Color.Should().Be("brown");
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_object___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((object)null).GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_object___Should_throw_ArgumentException___When_parameter_enumValue_is_not_an_Enum()
        {
            // Arrange
            var enumValue = A.Dummy<string>();

            // Act
            var ex = Record.Exception(() => enumValue.GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_object___Should_return_null___When_attribute_is_not_applied_to_enum_value()
        {
            // Arrange
            var enumValue = (object)A.Dummy<GoodStuff>();

            // Act
            var attribute = enumValue.GetAttributeOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            attribute.Should().BeNull();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_object___Should_throw_InvalidOperationException___When_attribute_is_applied_multiple_times_to_enum_value()
        {
            // Arrange
            var enumValue = (object)Sweet.Chocolate;

            // Act
            var ex = Record.Exception(() => enumValue.GetAttributeOnEnumValue<MultipleAllowedAttribute>());

            // Assert
            ex.Should().BeOfType<InvalidOperationException>();
        }

        [Fact]
        public static void GetAttributeOnEnumValue_with_object___Should_return_attribute_applied_to_enum_value___When_attribute_is_only_applied_once()
        {
            // Arrange
            var enumValue1 = (object)Sweet.Cake;
            var enumValue2 = (object)Sweet.Cookies;
            var enumValue3 = (object)Sweet.Chocolate;

            // Act
            var attribute1 = enumValue1.GetAttributeOnEnumValue<MultipleAllowedAttribute>();
            var attribute2 = enumValue2.GetAttributeOnEnumValue<ColorAttribute>();
            var attribute3 = enumValue3.GetAttributeOnEnumValue<ColorAttribute>();

            // Assert
            attribute1.Should().NotBeNull();
            attribute2.Color.Should().Be("green");
            attribute3.Color.Should().Be("brown");
        }

        [Fact]
        public static void GetAttributes___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.GetAttributes<NotAppliedAnywhereAttribute>(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributes___Should_return_empty_collection___When_no_attributes_of_specified_type_are_applied_to_type()
        {
            // Arrange
            var type1 = typeof(ClassWithNoAttributes);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var attributes1 = type1.GetAttributes<NotAppliedAnywhereAttribute>();
            var attributes2 = type2.GetAttributes<ColorAttribute>();

            // Assert
            attributes1.Should().BeEmpty();
            attributes2.Should().BeEmpty();
        }

        [Fact]
        public static void GetAttributes_Enum___Should_return_all_attributes_of_specified_type_applied_to_type___When_called()
        {
            // Arrange
            var type1 = typeof(ClassWithColor);
            var type2 = typeof(ClassWithPurpose);

            // Act
            var attributes1 = type1.GetAttributes<ColorAttribute>();
            var attributes2 = type2.GetAttributes<PurposeAttribute>();

            // Assert
            attributes1.Should().ContainSingle();
            attributes1.Single().Color.Should().Be("blue");

            attributes2.Should().HaveCount(2);
            attributes2.First().Purpose.Should().Be("some purpose");
            attributes2.Last().Purpose.Should().Be("some other purpose");
        }

        [Fact]
        public static void GetAttributesOnEnumValue_with_Enum___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((Enum)null).GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_with_Enum___Should_return_empty_collection___When_no_attributes_of_specified_type_are_applied_to_enum_value()
        {
            // Arrange
            var goodStuff = A.Dummy<GoodStuff>();

            // Act
            var attributes = goodStuff.GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            attributes.Should().BeEmpty();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_with_Enum___Should_return_all_attributes_of_specified_type_applied_to_enum_value___When_called()
        {
            // Arrange, Act
            var attributes1 = Sweet.Cookies.GetAttributesOnEnumValue<ColorAttribute>();
            var attributes2 = Fruit.Pear.GetAttributesOnEnumValue<PurposeAttribute>();

            // Assert
            attributes1.Should().ContainSingle();
            attributes1.Single().Color.Should().Be("green");

            attributes2.Should().HaveCount(2);
            attributes2.First().Purpose.Should().Be("toddlers love it");
            attributes2.Last().Purpose.Should().Be("good shelf life");
        }

        [Fact]
        public static void GetAttributesOnEnumValue_with_object___Should_throw_ArgumentNullException___When_parameter_enumValue_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ((object)null).GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_with_object___Should_throw_ArgumentException___When_parameter_enumValue_is_not_of_type_Enum()
        {
            // Arrange
            var enumValue = A.Dummy<string>();

            // Act
            var ex = Record.Exception(() => enumValue.GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>());

            // Assert
            ex.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_with_object___Should_return_empty_collection___When_no_attributes_of_specified_type_are_applied_to_enum_value()
        {
            // Arrange
            var goodStuff = (object)A.Dummy<GoodStuff>();

            // Act
            var attributes = goodStuff.GetAttributesOnEnumValue<NotAppliedAnywhereAttribute>();

            // Assert
            attributes.Should().BeEmpty();
        }

        [Fact]
        public static void GetAttributesOnEnumValue_with_object___Should_return_all_attributes_of_specified_type_applied_to_enum_value___When_called()
        {
            // Arrange
            var enumValue1 = (object)Sweet.Cookies;
            var enumValue2 = (object)Fruit.Pear;

            // Act
            var attributes1 = enumValue1.GetAttributesOnEnumValue<ColorAttribute>();
            var attributes2 = enumValue2.GetAttributesOnEnumValue<PurposeAttribute>();

            // Assert
            attributes1.Should().ContainSingle();
            attributes1.Single().Color.Should().Be("green");

            attributes2.Should().HaveCount(2);
            attributes2.First().Purpose.Should().Be("toddlers love it");
            attributes2.Last().Purpose.Should().Be("good shelf life");
        }

        [Fact]
        public static void GetEnumValues_T___Should_throw_ArgumentException___When_generic_type_parameter_is_not_of_type_Enum()
        {
            // Arrange, Act
            var ex1 = Record.Exception(() => ReflectionHelper.GetEnumValues<int>());
            var ex2 = Record.Exception(() => ReflectionHelper.GetEnumValues<bool>());
            var ex3 = Record.Exception(() => ReflectionHelper.GetEnumValues<byte>());
            var ex4 = Record.Exception(() => ReflectionHelper.GetEnumValues<char>());

            // Assert
            ex1.Should().BeOfType<ArgumentException>();
            ex2.Should().BeOfType<ArgumentException>();
            ex3.Should().BeOfType<ArgumentException>();
            ex4.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetEnumValues_T___Should_return_enum_values_in_order___When_called()
        {
            // Arrange, Act
            var enumValues1 = ReflectionHelper.GetEnumValues<Empty>();
            var enumValues2 = ReflectionHelper.GetEnumValues<GoodStuff>();

            // Assert
            enumValues1.Should().BeEmpty();
            enumValues2.Should().Equal(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs);
        }

        [Fact]
        public static void GetEnumValues_enumType___Should_throw_ArgumentException___When_generic_type_parameter_is_not_of_type_Enum()
        {
            // Arrange, Act
            var ex1 = Record.Exception(() => typeof(int).GetEnumValues());
            var ex2 = Record.Exception(() => typeof(bool).GetEnumValues());
            var ex3 = Record.Exception(() => typeof(byte).GetEnumValues());
            var ex4 = Record.Exception(() => typeof(char).GetEnumValues());

            // Assert
            ex1.Should().BeOfType<ArgumentException>();
            ex2.Should().BeOfType<ArgumentException>();
            ex3.Should().BeOfType<ArgumentException>();
            ex4.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public static void GetEnumValues_enumType___Should_return_enum_values_in_order___When_called()
        {
            // Arrange, Act
            var enumValues1 = typeof(Empty).GetEnumValues();
            var enumValues2 = typeof(GoodStuff).GetEnumValues();

            // Assert
            enumValues1.Should().BeEmpty();
            enumValues2.Should().Equal(GoodStuff.WorkingFromHome, GoodStuff.Chocolate, GoodStuff.Vacation, GoodStuff.Bulldogs);
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
            var enumValues1 = ReflectionHelper.GetEnumValuesHaving<GoodStuff, PurposeAttribute>();
            var enumValues2 = ReflectionHelper.GetEnumValuesHaving<GoodStuff, PurposeAttribute>(_ => _.Purpose == "none");

            // Assert
            enumValues1.Should().BeEmpty();
            enumValues2.Should().BeEmpty();
        }

        [Fact]
        public static void GetEnumValuesHaving_TEnum_TAttribute____Should_return_empty_collection___When_none_of_the_enum_values_have_the_specified_attribute_that_passes_the_specified_attributeFilter()
        {
            // Arrange, Act
            var enumValues1 = ReflectionHelper.GetEnumValuesHaving<Sweet, ColorAttribute>(_ => _.Color == "purple");
            var enumValues2 = ReflectionHelper.GetEnumValuesHaving<Sweet, MultipleAllowedAttribute>(_ => false);
            var enumValues3 = ReflectionHelper.GetEnumValuesHaving<Fruit, PurposeAttribute>(_ => _.Purpose == "no purpose");

            // Assert
            enumValues1.Should().BeEmpty();
            enumValues2.Should().BeEmpty();
            enumValues3.Should().BeEmpty();
        }

        [Fact]
        public static void GetEnumValuesHaving_TEnum_TAttribute____Should_return_all_enum_values_having_specified_attribute___When_some_enum_values_have_specified_attribute()
        {
            // Arrange, Act
            var enumValues1 = ReflectionHelper.GetEnumValuesHaving<Sweet, MultipleAllowedAttribute>();
            var enumValues2 = ReflectionHelper.GetEnumValuesHaving<Sweet, ColorAttribute>();
            var enumValues3 = ReflectionHelper.GetEnumValuesHaving<Fruit, PurposeAttribute>();

            // Assert
            enumValues1.Should().Equal(Sweet.Cake, Sweet.Chocolate);
            enumValues2.Should().Equal(Sweet.Chocolate, Sweet.Cookies);
            enumValues3.Should().Equal(Fruit.Pear);
        }

        [Fact]
        public static void GetEnumValuesHaving_TEnum_TAttribute____Should_return_all_enum_values_having_specified_attribute_that_passes_attributeFilter___When_some_enum_values_have_the_specified_attribute_that_passes_the_attributeFilter()
        {
            // Arrange, Act
            var enumValues1 = ReflectionHelper.GetEnumValuesHaving<Sweet, ColorAttribute>(_ => _.Color == "brown");
            var enumValues2 = ReflectionHelper.GetEnumValuesHaving<Sweet, ColorAttribute>(_ => _.Color == "brown" || _.Color == "green");
            var enumValues3 = ReflectionHelper.GetEnumValuesHaving<Fruit, PurposeAttribute>(_ => _.Purpose == "good shelf life");

            // Assert
            enumValues1.Should().Equal(Sweet.Chocolate);
            enumValues2.Should().Equal(Sweet.Chocolate, Sweet.Cookies);
            enumValues3.Should().Equal(Fruit.Pear);
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
            var enumValues1 = typeof(GoodStuff).GetEnumValuesHaving<PurposeAttribute>();
            var enumValues2 = typeof(GoodStuff).GetEnumValuesHaving<PurposeAttribute>(_ => _.Purpose == "none");

            // Assert
            enumValues1.Should().BeEmpty();
            enumValues2.Should().BeEmpty();
        }

        [Fact]
        public static void GetEnumValuesHaving_TAttribute____Should_return_empty_collection___When_none_of_the_enum_values_have_the_specified_attribute_that_passes_the_specified_attributeFilter()
        {
            // Arrange, Act
            var enumValues1 = typeof(Sweet).GetEnumValuesHaving<ColorAttribute>(_ => _.Color == "purple");
            var enumValues2 = typeof(Sweet).GetEnumValuesHaving<MultipleAllowedAttribute>(_ => false);
            var enumValues3 = typeof(Fruit).GetEnumValuesHaving<PurposeAttribute>(_ => _.Purpose == "no purpose");

            // Assert
            enumValues1.Should().BeEmpty();
            enumValues2.Should().BeEmpty();
            enumValues3.Should().BeEmpty();
        }

        [Fact]
        public static void GetEnumValuesHaving_TAttribute____Should_return_all_enum_values_having_specified_attribute___When_some_enum_values_have_specified_attribute()
        {
            // Arrange, Act
            var enumValues1 = typeof(Sweet).GetEnumValuesHaving<MultipleAllowedAttribute>();
            var enumValues2 = typeof(Sweet).GetEnumValuesHaving<ColorAttribute>();
            var enumValues3 = typeof(Fruit).GetEnumValuesHaving<PurposeAttribute>();

            // Assert
            enumValues1.Should().Equal(Sweet.Cake, Sweet.Chocolate);
            enumValues2.Should().Equal(Sweet.Chocolate, Sweet.Cookies);
            enumValues3.Should().Equal(Fruit.Pear);
        }

        [Fact]
        public static void GetEnumValuesHaving_TAttribute____Should_return_all_enum_values_having_specified_attribute_that_passes_attributeFilter___When_some_enum_values_have_the_specified_attribute_that_passes_the_attributeFilter()
        {
            // Arrange, Act
            var enumValues1 = typeof(Sweet).GetEnumValuesHaving<ColorAttribute>(_ => _.Color == "brown");
            var enumValues2 = typeof(Sweet).GetEnumValuesHaving<ColorAttribute>(_ => _.Color == "brown" || _.Color == "green");
            var enumValues3 = typeof(Fruit).GetEnumValuesHaving<PurposeAttribute>(_ => _.Purpose == "good shelf life");

            // Assert
            enumValues1.Should().Equal(Sweet.Chocolate);
            enumValues2.Should().Equal(Sweet.Chocolate, Sweet.Cookies);
            enumValues3.Should().Equal(Fruit.Pear);
        }

        [Fact]
        public static void GetTypesHaving_TAttribute___Should_throw_ArgumentNullException___When_parameter_assembly_is_null()
        {
            // Arrange, Act
            var ex = Record.Exception(() => ReflectionHelper.GetTypesHaving<EqualOpportunity>(null));

            // Assert
            ex.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void GetTypesHaving_TAttribute___Should_return_all_types_in_assembly_having_specified_attribute___When_called()
        {
            // Arrange
            var assembly = typeof(ReflectionHelperTest).Assembly;

            // Act
            var types = assembly.GetTypesHaving<EqualOpportunity>();

            // Assert
            types.Should().HaveCount(5);
            types.Should().BeEquivalentTo(typeof(EqualOpportunityEnum), typeof(IAmEqualOpportunity), typeof(IHaveEqualOpportunity), typeof(EqualOpportunityClassy), typeof(EqualOpportunityClassless));
        }

        [Fact]
        public static void GetTypesHaving_TAttribute___Should_return_all_types_in_assembly_having_specified_attribute_that_passes_attributeFilter___When_called()
        {
            // Arrange
            var assembly = typeof(ReflectionHelperTest).Assembly;

            // Act
            var types = assembly.GetTypesHaving<EqualOpportunity>(_ => _.TheOpportunity == "classify none");

            // Assert
            types.Should().HaveCount(3);
            types.Should().BeEquivalentTo(typeof(IHaveEqualOpportunity), typeof(EqualOpportunityClassy), typeof(EqualOpportunityClassless));
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
    }
}
