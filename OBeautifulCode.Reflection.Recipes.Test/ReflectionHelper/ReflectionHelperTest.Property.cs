// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.Property.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FakeItEasy;

    using OBeautifulCode.Assertion.Recipes;
    using OBeautifulCode.AutoFakeItEasy;
    using OBeautifulCode.Collection.Recipes;

    using Xunit;

    public static partial class ReflectionHelperTest
    {
        [Fact]
        public static void GetPropertyNames___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.GetPropertyNames(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("type");
        }

        [Fact]
        public static void GetPropertyNames___Should_return_all_properties_names___When_called()
        {
            // Arrange
            var type1 = typeof(ParentInstanceProperties);

            var expected1 = (IReadOnlyCollection<string>)GetParentPropertyNames();

            var type2 = typeof(ChildInstanceProperties);

            var expected2 = (IReadOnlyCollection<string>)new string[0]
                .Concat(GetChildPropertyNames())
                .Concat(GetParentPublicPropertyNames())
                .Concat(GetParentProtectedPropertyNames())
                .ToList();

            // Act
            var actuals1 = (IReadOnlyCollection<string>)type1.GetPropertyNames();
            var actuals2 = (IReadOnlyCollection<string>)type2.GetPropertyNames();

            // Assert
            actuals1.AsTest().Must().BeEqualTo(expected1);
            actuals2.AsTest().Must().BeEqualTo(expected2);
        }

        [Fact]
        public static void GetPropertyInfo___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange
            var propertyName = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ReflectionHelper.GetPropertyInfo(null, propertyName));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("type");
        }

        [Fact]
        public static void GetPropertyInfo___Should_throw_ArgumentNullException___When_parameter_propertyName_is_null()
        {
            // Arrange
            var type = typeof(ParentInstanceProperties);

            // Act
            var actual = Record.Exception(() => type.GetPropertyInfo(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
        }

        [Fact]
        public static void GetPropertyInfo___Should_throw_ArgumentException___When_parameter_propertyName_is_white_space()
        {
            // Arrange
            var type = typeof(ParentInstanceProperties);

            // Act
            var actual = Record.Exception(() => type.GetPropertyInfo(" \r\n "));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
            actual.Message.AsTest().Must().ContainString("white space");
        }

        [Fact]
        public static void GetPropertyInfo___Should_throw_ArgumentException___When_property_does_not_exist()
        {
            // Arrange
            var parentType = typeof(ParentInstanceProperties);

            var parentPropertyNamesThatDoNotExist = GetParentPropertyNamesThatDoNotExist();

            var childType = typeof(ChildInstanceProperties);

            var childPropertyNamesThatDoNotExist = GetChildPropertyNamesThatDoNotExist();

            // Act
            var actuals1 = parentPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => parentType.GetPropertyInfo(_))).ToList();
            var actuals2 = childPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => childType.GetPropertyInfo(_))).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeOfType<ArgumentException>();
            actuals2.Select(_ => _.Message).AsTest().Must().Each().ContainString("There is no property named");
        }

        [Fact(Skip = "Test using these ideas: https://stackoverflow.com/questions/64487350/is-it-possible-to-create-a-type-with-two-properties-having-the-same-name/64488044#64488044")]
        public static void GetPropertyInfo___Should_throw_ArgumentException___When_multiple_properties_with_the_same_name_exist()
        {
        }

        [Fact]
        public static void GetPropertyInfo___Should_return_PropertyInfo___When_property_exists()
        {
            // Arrange
            var expected1 = GetParentPropertyNames().ToList();

            var parentType = typeof(ParentInstanceProperties);

            var childType = typeof(ChildInstanceProperties);

            var expected2 = new string[0]
                .Concat(GetChildPropertyNames())
                .Concat(GetParentPublicPropertyNames())
                .Concat(GetParentProtectedPropertyNames())
                .ToList();

            // Act
            var actuals1 = expected1.Select(_ => parentType.GetPropertyInfo(_)).ToList();
            var actuals2 = expected2.Select(_ => childType.GetPropertyInfo(_)).ToList();

            // Assert
            actuals1.Select(_ => _.Name).ToList().AsTest().Must().BeEqualTo(expected1);
            actuals2.Select(_ => _.Name).ToList().AsTest().Must().BeEqualTo(expected2);
        }

        [Fact]
        public static void GetPropertyValue_T___Should_throw_ArgumentNullException___When_parameter_item_is_null()
        {
            // Arrange
            var propertyName = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ReflectionHelper.GetPropertyValue<string>(null, propertyName));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("item");
        }

        [Fact]
        public static void GetPropertyValue_T___Should_throw_ArgumentNullException___When_parameter_propertyName_is_null()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            // Act
            var actual = Record.Exception(() => item.GetPropertyValue<string>(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
        }

        [Fact]
        public static void GetPropertyValue_T___Should_throw_ArgumentException___When_parameter_propertyName_is_white_space()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            // Act
            var actual = Record.Exception(() => item.GetPropertyValue<string>(" \r\n "));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
            actual.Message.AsTest().Must().ContainString("white space");
        }

        [Fact]
        public static void GetPropertyValue_T___Should_throw_ArgumentException___When_property_does_not_exist()
        {
            // Arrange
            var item1 = A.Dummy<ParentInstanceProperties>();

            var parentPropertyNamesThatDoNotExist = GetParentPropertyNamesThatDoNotExist();

            var item2 = A.Dummy<ChildInstanceProperties>();

            var childPropertyNamesThatDoNotExist = GetChildPropertyNamesThatDoNotExist();

            // Act
            var actuals1 = parentPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => item1.GetPropertyValue<string>(_))).ToList();
            var actuals2 = childPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => item2.GetPropertyValue<string>(_))).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeOfType<ArgumentException>();
            actuals2.Select(_ => _.Message).AsTest().Must().Each().ContainString("There is no property named");
        }

        [Fact(Skip = "Test using these ideas: https://stackoverflow.com/questions/64487350/is-it-possible-to-create-a-type-with-two-properties-having-the-same-name/64488044#64488044")]
        public static void GetPropertyValue_T___Should_throw_ArgumentException___When_multiple_properties_with_the_same_name_exist()
        {
        }

        [Fact]
        public static void GetPropertyValue_T___Should_throw_ArgumentException___When_property_does_not_have_a_get_method()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            var writeOnlyProperties = GetParentNotReadablePropertyNames();

            // Act
            var actual = writeOnlyProperties.Select(_ => Record.Exception(() => item.GetPropertyValue<object>(_))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("Property Get method was not found.");
        }

        [Fact]
        public static void GetPropertyValue_T___Should_throw_InvalidCastException___When_property_value_is_null_and_property_type_is_not_assignable_to_T()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();
            item.ParentPublicReadWriteReferenceTypeProperty = null;
            item.ParentPublicReadWriteNullableTypeProperty = null;
            item.ParentPublicReadWriteStringTypeProperty = null;

            // Act
            var actual1 = Record.Exception(() => item.GetPropertyValue<string>(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty)));
            var actual2 = Record.Exception(() => item.GetPropertyValue<int>(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty)));
            var actual3 = Record.Exception(() => item.GetPropertyValue<Version>(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty)));

            // Assert
            actual1.AsTest().Must().BeOfType<InvalidCastException>();
            actual1.Message.Must().BeEqualTo("Unable to cast object of type 'Version' to type 'string'.");

            actual2.AsTest().Must().BeOfType<InvalidCastException>();
            actual2.Message.Must().BeEqualTo("Unable to cast object of type 'int?' to type 'int'.");

            actual3.AsTest().Must().BeOfType<InvalidCastException>();
            actual3.Message.Must().BeEqualTo("Unable to cast object of type 'string' to type 'Version'.");
        }

        [Fact]
        public static void GetPropertyValue_T___Should_throw_InvalidCastException___When_property_value_is_not_null_and_cannot_be_cast_to_T()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();
            item.ParentPublicReadWriteReferenceTypeProperty = A.Dummy<Version>();
            item.ParentPublicReadWriteNullableTypeProperty = A.Dummy<int>();
            item.ParentPublicReadWriteStringTypeProperty = A.Dummy<string>();
            item.ParentPublicReadWriteValueTypeProperty = A.Dummy<int>();

            // Act
            var actual1 = Record.Exception(() => item.GetPropertyValue<string>(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty)));
            var actual2 = Record.Exception(() => item.GetPropertyValue<Guid>(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty)));
            var actual3 = Record.Exception(() => item.GetPropertyValue<int>(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty)));
            var actual4 = Record.Exception(() => item.GetPropertyValue<Version>(nameof(ParentInstanceProperties.ParentPublicReadWriteValueTypeProperty)));

            // Assert
            actual1.AsTest().Must().BeOfType<InvalidCastException>();
            actual1.Message.Must().BeEqualTo("Unable to cast object of type 'Version' to type 'string'.");

            actual2.AsTest().Must().BeOfType<InvalidCastException>();
            actual2.Message.Must().BeEqualTo("Unable to cast object of type 'int' to type 'Guid'.");

            actual3.AsTest().Must().BeOfType<InvalidCastException>();
            actual3.Message.Must().BeEqualTo("Unable to cast object of type 'string' to type 'int'.");

            actual4.AsTest().Must().BeOfType<InvalidCastException>();
            actual4.Message.Must().BeEqualTo("Unable to cast object of type 'int' to type 'Version'.");
        }

        [Fact]
        public static void GetPropertyValue_T___Should_return_null___When_property_value_is_null_and_property_type_is_assignable_to_T()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();
            item.ParentPublicReadWriteReferenceTypeProperty = null;
            item.ParentPublicReadWriteNullableTypeProperty = null;
            item.ParentPublicReadWriteStringTypeProperty = null;

            // Act
            var actual1 = item.GetPropertyValue<Version>(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty));
            var actual2 = item.GetPropertyValue<int?>(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty));
            var actual3 = item.GetPropertyValue<string>(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty));

            // Assert
            actual1.AsTest().Must().BeNull();
            actual2.AsTest().Must().BeNull();
            actual3.AsTest().Must().BeNull();
        }

        [Fact]
        public static void GetPropertyValue_T___Should_return_property_value___When_property_value_is_not_null_and_can_be_cast_to_generic_type_parameter()
        {
            // Arrange
            var item = GetDummyParentProperties();

            var parentReadablePropertyNames = GetParentReadablePropertyNames();

            var expected = item.ToStringReadableProperties();

            // Act
            var actual = parentReadablePropertyNames
                .ToDictionary(_ => _, _ => item.GetPropertyValue<object>(_))
                .OrderBy(_ => _.Key)
                .Select(_ => _.Key + ": " + (_.Value?.ToString() ?? "<null>"))
                .ToDelimitedString("|");

            // Assert
            actual.AsTest().Must().BeEqualTo(expected);
        }

        [Fact]
        public static void GetPropertyValue___Should_throw_ArgumentNullException___When_parameter_item_is_null()
        {
            // Arrange
            var propertyName = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ReflectionHelper.GetPropertyValue(null, propertyName));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("item");
        }

        [Fact]
        public static void GetPropertyValue___Should_throw_ArgumentNullException___When_parameter_propertyName_is_null()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            // Act
            var actual = Record.Exception(() => item.GetPropertyValue(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
        }

        [Fact]
        public static void GetPropertyValue___Should_throw_ArgumentException___When_parameter_propertyName_is_white_space()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            // Act
            var actual = Record.Exception(() => item.GetPropertyValue(" \r\n "));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
            actual.Message.AsTest().Must().ContainString("white space");
        }

        [Fact]
        public static void GetPropertyValue___Should_throw_ArgumentException___When_property_does_not_exist()
        {
            // Arrange
            var item1 = A.Dummy<ParentInstanceProperties>();

            var parentPropertyNamesThatDoNotExist = GetParentPropertyNamesThatDoNotExist();

            var item2 = A.Dummy<ChildInstanceProperties>();

            var childPropertyNamesThatDoNotExist = GetChildPropertyNamesThatDoNotExist();

            // Act
            var actuals1 = parentPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => item1.GetPropertyValue(_))).ToList();
            var actuals2 = childPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => item2.GetPropertyValue(_))).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeOfType<ArgumentException>();
            actuals2.Select(_ => _.Message).AsTest().Must().Each().ContainString("There is no property named");
        }

        [Fact(Skip = "Test using these ideas: https://stackoverflow.com/questions/64487350/is-it-possible-to-create-a-type-with-two-properties-having-the-same-name/64488044#64488044")]
        public static void GetPropertyValue___Should_throw_ArgumentException___When_multiple_properties_with_the_same_name_exist()
        {
        }

        [Fact]
        public static void GetPropertyValue___Should_throw_ArgumentException___When_property_does_not_have_a_get_method()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            var writeOnlyProperties = GetParentNotReadablePropertyNames();

            // Act
            var actual = writeOnlyProperties.Select(_ => Record.Exception(() => item.GetPropertyValue(_))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("Property Get method was not found.");
        }

        [Fact]
        public static void GetPropertyValue___Should_return_null___When_property_value_is_null()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();
            item.ParentPublicReadWriteReferenceTypeProperty = null;
            item.ParentPublicReadWriteNullableTypeProperty = null;
            item.ParentPublicReadWriteStringTypeProperty = null;

            // Act
            var actual1 = item.GetPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty));
            var actual2 = item.GetPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty));
            var actual3 = item.GetPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty));

            // Assert
            actual1.AsTest().Must().BeNull();
            actual2.AsTest().Must().BeNull();
            actual3.AsTest().Must().BeNull();
        }

        [Fact]
        public static void GetPropertyValue___Should_return_property_value___When_property_value_is_not_null()
        {
            // Arrange
            var item = GetDummyParentProperties();

            var parentReadablePropertyNames = GetParentReadablePropertyNames();

            var expected = item.ToStringReadableProperties();

            // Act
            var actual = parentReadablePropertyNames
                .ToDictionary(_ => _, _ => item.GetPropertyValue(_))
                .OrderBy(_ => _.Key)
                .Select(_ => _.Key + ": " + (_.Value?.ToString() ?? "<null>"))
                .ToDelimitedString("|");

            // Assert
            actual.AsTest().Must().BeEqualTo(expected);
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange
            var propertyName = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ReflectionHelper.GetStaticPropertyValue<string>(null, propertyName));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("type");
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_throw_ArgumentNullException___When_parameter_propertyName_is_null()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            // Act
            var actual = Record.Exception(() => type.GetStaticPropertyValue<string>(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_throw_ArgumentException___When_parameter_propertyName_is_white_space()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            // Act
            var actual = Record.Exception(() => type.GetStaticPropertyValue<string>(" \r\n "));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
            actual.Message.AsTest().Must().ContainString("white space");
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_throw_ArgumentException___When_property_does_not_exist()
        {
            // Arrange
            var type1 = typeof(ParentStaticProperties);

            var parentPropertyNamesThatDoNotExist = GetParentPropertyNamesThatDoNotExist();

            var type2 = typeof(ChildStaticProperties);

            var childPropertyNamesThatDoNotExist = GetChildPropertyNamesThatDoNotExist();

            // Act
            var actuals1 = parentPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => type1.GetStaticPropertyValue<string>(_))).ToList();
            var actuals2 = childPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => type2.GetStaticPropertyValue<string>(_))).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeOfType<ArgumentException>();
            actuals2.Select(_ => _.Message).AsTest().Must().Each().ContainString("There is no property named");
        }

        [Fact(Skip = "Test using these ideas: https://stackoverflow.com/questions/64487350/is-it-possible-to-create-a-type-with-two-properties-having-the-same-name/64488044#64488044")]
        public static void GetStaticPropertyValue_T___Should_throw_ArgumentException___When_multiple_properties_with_the_same_name_exist()
        {
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_throw_ArgumentException___When_property_does_not_have_a_get_method()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            var writeOnlyProperties = GetParentNotReadablePropertyNames();

            // Act
            var actual = writeOnlyProperties.Select(_ => Record.Exception(() => type.GetStaticPropertyValue<object>(_))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("Property Get method was not found.");
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_throw_ArgumentException___When_property_is_not_static()
        {
            // Arrange
            var type = typeof(ParentInstanceProperties);

            var writeOnlyProperties = GetParentReadablePropertyNames();

            // Act
            var actual = writeOnlyProperties.Select(_ => Record.Exception(() => type.GetStaticPropertyValue<object>(_, BindingFlagsFor.AllDeclaredAndInheritedMembers))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("The property is not static.");
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_throw_InvalidCastException___When_property_value_is_null_and_property_type_is_not_assignable_to_T()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            ResetParentStaticProperties();

            ParentStaticProperties.ParentPublicReadWriteReferenceTypeProperty = null;
            ParentStaticProperties.ParentPublicReadWriteNullableTypeProperty = null;
            ParentStaticProperties.ParentPublicReadWriteStringTypeProperty = null;

            // Act
            var actual1 = Record.Exception(() => type.GetStaticPropertyValue<string>(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty)));
            var actual2 = Record.Exception(() => type.GetStaticPropertyValue<int>(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty)));
            var actual3 = Record.Exception(() => type.GetStaticPropertyValue<Version>(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty)));

            // Assert
            actual1.AsTest().Must().BeOfType<InvalidCastException>();
            actual1.Message.Must().BeEqualTo("Unable to cast object of type 'Version' to type 'string'.");

            actual2.AsTest().Must().BeOfType<InvalidCastException>();
            actual2.Message.Must().BeEqualTo("Unable to cast object of type 'int?' to type 'int'.");

            actual3.AsTest().Must().BeOfType<InvalidCastException>();
            actual3.Message.Must().BeEqualTo("Unable to cast object of type 'string' to type 'Version'.");
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_throw_InvalidCastException___When_property_value_is_not_null_and_cannot_be_cast_to_T()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            ResetParentStaticProperties();

            // Act
            var actual1 = Record.Exception(() => type.GetStaticPropertyValue<string>(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty)));
            var actual2 = Record.Exception(() => type.GetStaticPropertyValue<Guid>(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty)));
            var actual3 = Record.Exception(() => type.GetStaticPropertyValue<int>(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty)));
            var actual4 = Record.Exception(() => type.GetStaticPropertyValue<Version>(nameof(ParentInstanceProperties.ParentPublicReadWriteValueTypeProperty)));

            // Assert
            actual1.AsTest().Must().BeOfType<InvalidCastException>();
            actual1.Message.Must().BeEqualTo("Unable to cast object of type 'Version' to type 'string'.");

            actual2.AsTest().Must().BeOfType<InvalidCastException>();
            actual2.Message.Must().BeEqualTo("Unable to cast object of type 'int' to type 'Guid'.");

            actual3.AsTest().Must().BeOfType<InvalidCastException>();
            actual3.Message.Must().BeEqualTo("Unable to cast object of type 'string' to type 'int'.");

            actual4.AsTest().Must().BeOfType<InvalidCastException>();
            actual4.Message.Must().BeEqualTo("Unable to cast object of type 'int' to type 'Version'.");
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_return_null___When_property_value_is_null_and_property_type_is_assignable_to_T()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            ResetParentStaticProperties();

            ParentStaticProperties.ParentPublicReadWriteReferenceTypeProperty = null;
            ParentStaticProperties.ParentPublicReadWriteNullableTypeProperty = null;
            ParentStaticProperties.ParentPublicReadWriteStringTypeProperty = null;

            // Act
            var actual1 = type.GetStaticPropertyValue<Version>(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty));
            var actual2 = type.GetStaticPropertyValue<int?>(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty));
            var actual3 = type.GetStaticPropertyValue<string>(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty));

            // Assert
            actual1.AsTest().Must().BeNull();
            actual2.AsTest().Must().BeNull();
            actual3.AsTest().Must().BeNull();
        }

        [Fact]
        public static void GetStaticPropertyValue_T___Should_return_property_value___When_property_value_is_not_null_and_can_be_casted_to_generic_type_parameter()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            ResetParentStaticProperties();

            var parentReadablePropertyNames = GetParentReadablePropertyNames();

            var expected = ParentStaticProperties.ToStringReadableProperties();

            // Act
            var actual = parentReadablePropertyNames
                .ToDictionary(_ => _, _ => type.GetStaticPropertyValue<object>(_))
                .OrderBy(_ => _.Key)
                .Select(_ => _.Key + ": " + (_.Value?.ToString() ?? "<null>"))
                .ToDelimitedString("|");

            // Assert
            actual.AsTest().Must().BeEqualTo(expected);
        }

        [Fact]
        public static void GetStaticPropertyValue___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange
            var propertyName = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ReflectionHelper.GetStaticPropertyValue(null, propertyName));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("type");
        }

        [Fact]
        public static void GetStaticPropertyValue___Should_throw_ArgumentNullException___When_parameter_propertyName_is_null()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            // Act
            var actual = Record.Exception(() => type.GetStaticPropertyValue(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
        }

        [Fact]
        public static void GetStaticPropertyValue___Should_throw_ArgumentException___When_parameter_propertyName_is_white_space()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            // Act
            var actual = Record.Exception(() => type.GetStaticPropertyValue(" \r\n "));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
            actual.Message.AsTest().Must().ContainString("white space");
        }

        [Fact]
        public static void GetStaticPropertyValue___Should_throw_ArgumentException___When_property_does_not_exist()
        {
            // Arrange
            var type1 = typeof(ParentStaticProperties);

            var parentPropertyNamesThatDoNotExist = GetParentPropertyNamesThatDoNotExist();

            var type2 = typeof(ChildStaticProperties);

            var childPropertyNamesThatDoNotExist = GetChildPropertyNamesThatDoNotExist();

            // Act
            var actuals1 = parentPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => type1.GetStaticPropertyValue(_))).ToList();
            var actuals2 = childPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => type2.GetStaticPropertyValue(_))).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeOfType<ArgumentException>();
            actuals2.Select(_ => _.Message).AsTest().Must().Each().ContainString("There is no property named");
        }

        [Fact(Skip = "Test using these ideas: https://stackoverflow.com/questions/64487350/is-it-possible-to-create-a-type-with-two-properties-having-the-same-name/64488044#64488044")]
        public static void GetStaticPropertyValue___Should_throw_ArgumentException___When_multiple_properties_with_the_same_name_exist()
        {
        }

        [Fact]
        public static void GetStaticPropertyValue___Should_throw_ArgumentException___When_property_does_not_have_a_get_method()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            var writeOnlyProperties = GetParentNotReadablePropertyNames();

            // Act
            var actual = writeOnlyProperties.Select(_ => Record.Exception(() => type.GetStaticPropertyValue(_))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("Property Get method was not found.");
        }

        [Fact]
        public static void GetStaticPropertyValue___Should_throw_ArgumentException___When_property_is_not_static()
        {
            // Arrange
            var type = typeof(ParentInstanceProperties);

            var writeOnlyProperties = GetParentReadablePropertyNames();

            // Act
            var actual = writeOnlyProperties.Select(_ => Record.Exception(() => type.GetStaticPropertyValue(_, BindingFlagsFor.AllDeclaredAndInheritedMembers))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("The property is not static.");
        }

        [Fact]
        public static void GetStaticPropertyValue___Should_return_null___When_property_value_is_null()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            ResetParentStaticProperties();

            ParentStaticProperties.ParentPublicReadWriteReferenceTypeProperty = null;
            ParentStaticProperties.ParentPublicReadWriteNullableTypeProperty = null;
            ParentStaticProperties.ParentPublicReadWriteStringTypeProperty = null;

            // Act
            var actual1 = type.GetStaticPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty));
            var actual2 = type.GetStaticPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty));
            var actual3 = type.GetStaticPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty));

            // Assert
            actual1.AsTest().Must().BeNull();
            actual2.AsTest().Must().BeNull();
            actual3.AsTest().Must().BeNull();
        }

        [Fact]
        public static void GetStaticPropertyValue___Should_return_property_value___When_property_value_is_not_null()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            ResetParentStaticProperties();

            var parentReadablePropertyNames = GetParentReadablePropertyNames();

            var expected = ParentStaticProperties.ToStringReadableProperties();

            // Act
            var actual = parentReadablePropertyNames
                .ToDictionary(_ => _, _ => type.GetStaticPropertyValue(_))
                .OrderBy(_ => _.Key)
                .Select(_ => _.Key + ": " + (_.Value?.ToString() ?? "<null>"))
                .ToDelimitedString("|");

            // Assert
            actual.AsTest().Must().BeEqualTo(expected);
        }

        [Fact]
        public static void HasProperty___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange
            var propertyName = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ReflectionHelper.HasProperty(null, propertyName));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("type");
        }

        [Fact]
        public static void HasProperty___Should_throw_ArgumentNullException___When_parameter_propertyName_is_null()
        {
            // Arrange
            var type = typeof(ParentInstanceProperties);

            // Act
            var actual = Record.Exception(() => type.HasProperty(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
        }

        [Fact]
        public static void HasProperty___Should_throw_ArgumentException___When_parameter_propertyName_is_white_space()
        {
            // Arrange
            var type = typeof(ParentInstanceProperties);

            // Act
            var actual = Record.Exception(() => type.HasProperty(" \r\n "));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
            actual.Message.AsTest().Must().ContainString("white space");
        }

        [Fact]
        public static void HasProperty___Should_return_false___When_property_does_not_exist()
        {
            // Arrange
            var parentType = typeof(ParentInstanceProperties);

            var parentPropertyNamesThatDoNotExist = GetParentPropertyNamesThatDoNotExist();

            var childType = typeof(ChildInstanceProperties);

            var childPropertyNamesThatDoNotExist = GetChildPropertyNamesThatDoNotExist();

            // Act
            var actuals1 = parentPropertyNamesThatDoNotExist.Select(_ => parentType.HasProperty(_)).ToList();
            var actuals2 = childPropertyNamesThatDoNotExist.Select(_ => childType.HasProperty(_)).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeFalse();
            actuals2.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void HasProperty___Should_return_true___When_property_exists()
        {
            // Arrange
            var parentType = typeof(ParentInstanceProperties);

            var childType = typeof(ChildInstanceProperties);

            var childPropertyNames = new string[0]
                .Concat(GetChildPropertyNames())
                .Concat(GetParentPublicPropertyNames())
                .Concat(GetParentProtectedPropertyNames())
                .ToList();

            // Act
            var actuals1 = GetParentPropertyNames().Select(_ => parentType.HasProperty(_)).ToList();
            var actuals2 = childPropertyNames.Select(_ => childType.HasProperty(_)).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeTrue();
            actuals2.AsTest().Must().Each().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyProperty___Should_throw_ArgumentNullException___When_parameter_propertyInfo_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.IsReadOnlyProperty(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyInfo");
        }

        [Fact]
        public static void IsReadOnlyProperty___Should_return_false___When_property_is_not_read_only()
        {
            // Arrange
            var propertyNames = GetParentWritablePropertyNames();

            // Act
            var actual = propertyNames.Select(_ => typeof(ParentInstanceProperties).GetPropertyInfo(_).IsReadOnlyProperty());

            // Assert
            actual.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyProperty___Should_return_true___When_property_is_read_only()
        {
            // Arrange
            var propertyNames = GetParentNotWritablePropertyNames();

            // Act
            var actual = propertyNames.Select(_ => typeof(ParentInstanceProperties).GetPropertyInfo(_).IsReadOnlyProperty());

            // Assert
            actual.AsTest().Must().Each().BeTrue();
        }

        [Fact]
        public static void IsReadOnlyAutoProperty___Should_throw_ArgumentNullException___When_parameter_propertyInfo_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.IsReadOnlyAutoProperty(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyInfo");
        }

        [Fact]
        public static void IsReadOnlyAutoProperty___Should_return_false___When_property_is_not_getter_only()
        {
            // Arrange
            var propertyNames = GetParentPropertyNames().Where(_ => !_.Contains("ReadOnlyAuto")).ToList();

            // Act
            var actual = propertyNames.Select(_ => typeof(ParentInstanceProperties).GetPropertyInfo(_).IsReadOnlyAutoProperty());

            // Assert
            actual.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void IsReadOnlyAutoProperty___Should_return_true___When_property_is_not_getter_only()
        {
            // Arrange
            var propertyNames = GetParentPropertyNames().Where(_ => _.Contains("ReadOnlyAuto")).ToList();

            // Act
            var actual = propertyNames.Select(_ => typeof(ParentInstanceProperties).GetPropertyInfo(_).IsReadOnlyAutoProperty());

            // Assert
            actual.AsTest().Must().Each().BeTrue();
        }

        [Fact]
        public static void IsWriteOnlyProperty___Should_throw_ArgumentNullException___When_parameter_propertyInfo_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => ReflectionHelper.IsWriteOnlyProperty(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyInfo");
        }

        [Fact]
        public static void IsWriteOnlyProperty___Should_return_false___When_property_is_not_write_only()
        {
            // Arrange
            var propertyNames = GetParentReadablePropertyNames();

            // Act
            var actual = propertyNames.Select(_ => typeof(ParentInstanceProperties).GetPropertyInfo(_).IsWriteOnlyProperty());

            // Assert
            actual.AsTest().Must().Each().BeFalse();
        }

        [Fact]
        public static void IsWriteOnlyProperty___Should_return_true___When_property_is_write_only()
        {
            // Arrange
            var propertyNames = GetParentNotReadablePropertyNames();

            // Act
            var actual = propertyNames.Select(_ => typeof(ParentInstanceProperties).GetPropertyInfo(_).IsWriteOnlyProperty());

            // Assert
            actual.AsTest().Must().Each().BeTrue();
        }

        [Fact]
        public static void SetPropertyValue___Should_throw_ArgumentNullException___When_parameter_item_is_null()
        {
            // Arrange
            var propertyName = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ReflectionHelper.SetPropertyValue(null, propertyName, null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("item");
        }

        [Fact]
        public static void SetPropertyValue___Should_throw_ArgumentNullException___When_parameter_propertyName_is_null()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            // Act
            var actual = Record.Exception(() => item.SetPropertyValue(null, null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
        }

        [Fact]
        public static void SetPropertyValue___Should_throw_ArgumentException___When_parameter_propertyName_is_white_space()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            // Act
            var actual = Record.Exception(() => item.SetPropertyValue(" \r\n ", null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
            actual.Message.AsTest().Must().ContainString("white space");
        }

        [Fact]
        public static void SetPropertyValue___Should_throw_ArgumentException___When_property_does_not_exist()
        {
            // Arrange
            var item1 = A.Dummy<ParentInstanceProperties>();

            var parentPropertyNamesThatDoNotExist = GetParentPropertyNamesThatDoNotExist();

            var item2 = A.Dummy<ChildInstanceProperties>();

            var childPropertyNamesThatDoNotExist = GetChildPropertyNamesThatDoNotExist();

            // Act
            var actuals1 = parentPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => item1.SetPropertyValue(_, null))).ToList();
            var actuals2 = childPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => item2.SetPropertyValue(_, null))).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeOfType<ArgumentException>();
            actuals2.Select(_ => _.Message).AsTest().Must().Each().ContainString("There is no property named");
        }

        [Fact(Skip = "Test using these ideas: https://stackoverflow.com/questions/64487350/is-it-possible-to-create-a-type-with-two-properties-having-the-same-name/64488044#64488044")]
        public static void SetPropertyValue___Should_throw_ArgumentException___When_multiple_properties_with_the_same_name_exist()
        {
        }

        [Fact]
        public static void SetPropertyValue___Should_throw_ArgumentException___When_property_does_not_have_a_set_method()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            var notWritableProperties = GetParentNotWritablePropertyNames();

            // Act
            var actual = notWritableProperties.Select(_ => Record.Exception(() => item.SetPropertyValue(_, AD.ummy(item.GetType().GetPropertyInfo(_).PropertyType)))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("Property set method not found.");
        }

        [Fact]
        public static void SetPropertyValue___Should_throw_InvalidCastException___When_value_is_null_and_property_type_is_not_assignable_to_null()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            var propertyNames = GetParentWritablePropertyNames().Where(_ => _.Contains("ValueType")).ToList();

            // Act
            var actual = propertyNames.Select(_ => Record.Exception(() => item.SetPropertyValue(_, null)));

            // Assert
            actual.AsTest().Must().Each().BeOfType<InvalidCastException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("Unable to assign null value to property of type 'int'.");
        }

        [Fact]
        public static void SetPropertyValue___Should_throw_InvalidCastException___When_value_is_not_null_and_value_type_is_not_assignable_to_property_type()
        {
            // Arrange
            var item = A.Dummy<ParentInstanceProperties>();

            // Act
            var actual1 = Record.Exception(() => item.SetPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty), 5));
            var actual2 = Record.Exception(() => item.SetPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty), Guid.NewGuid()));
            var actual3 = Record.Exception(() => item.SetPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty), 90));
            var actual4 = Record.Exception(() => item.SetPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteValueTypeProperty), Guid.NewGuid()));

            // Assert
            actual1.AsTest().Must().BeOfType<InvalidCastException>();
            actual1.Message.Must().BeEqualTo("Unable to assign value of type 'int' to property of type 'Version'.");

            actual2.AsTest().Must().BeOfType<InvalidCastException>();
            actual2.Message.Must().BeEqualTo("Unable to assign value of type 'Guid' to property of type 'int?'.");

            actual3.AsTest().Must().BeOfType<InvalidCastException>();
            actual3.Message.Must().BeEqualTo("Unable to assign value of type 'int' to property of type 'string'.");

            actual4.AsTest().Must().BeOfType<InvalidCastException>();
            actual4.Message.Must().BeEqualTo("Unable to assign value of type 'Guid' to property of type 'int'.");
        }

        [Fact]
        public static void SetPropertyValue___Should_set_property_values___When_called()
        {
            // Arrange
            var referenceObject = GetDummyParentProperties();

            var item = GetDummyParentProperties();

            var parentWritablePropertyNames = GetParentWritablePropertyNames();

            var expected = referenceObject.ToStringWritableProperties();

            // Act
            foreach (var parentWritablePropertyName in parentWritablePropertyNames)
            {
                var propertyType = referenceObject.GetType().GetPropertyInfo(parentWritablePropertyName).PropertyType;

                var valueToWrite = parentWritablePropertyName.Contains("WriteOnly")
                    ? AD.ummy(propertyType)
                    : referenceObject.GetPropertyValue(parentWritablePropertyName);

                item.SetPropertyValue(parentWritablePropertyName, valueToWrite);
            }

            // Assert
            item.ToStringWritableProperties().AsTest().Must().BeEqualTo(expected);
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange
            var propertyName = A.Dummy<string>();

            // Act
            var actual = Record.Exception(() => ReflectionHelper.SetStaticPropertyValue(null, propertyName, null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("type");
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_throw_ArgumentNullException___When_parameter_propertyName_is_null()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            // Act
            var actual = Record.Exception(() => type.SetStaticPropertyValue(null, null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_throw_ArgumentException___When_parameter_propertyName_is_white_space()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            // Act
            var actual = Record.Exception(() => type.SetStaticPropertyValue(" \r\n ", null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentException>();
            actual.Message.AsTest().Must().ContainString("propertyName");
            actual.Message.AsTest().Must().ContainString("white space");
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_throw_ArgumentException___When_property_does_not_exist()
        {
            // Arrange
            var type1 = typeof(ParentStaticProperties);

            var parentPropertyNamesThatDoNotExist = GetParentPropertyNamesThatDoNotExist();

            var type2 = typeof(ChildStaticProperties);

            var childPropertyNamesThatDoNotExist = GetChildPropertyNamesThatDoNotExist();

            // Act
            var actuals1 = parentPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => type1.SetStaticPropertyValue(_, null))).ToList();
            var actuals2 = childPropertyNamesThatDoNotExist.Select(_ => Record.Exception(() => type2.SetStaticPropertyValue(_, null))).ToList();

            // Assert
            actuals1.AsTest().Must().Each().BeOfType<ArgumentException>();
            actuals2.Select(_ => _.Message).AsTest().Must().Each().ContainString("There is no property named");
        }

        [Fact(Skip = "Test using these ideas: https://stackoverflow.com/questions/64487350/is-it-possible-to-create-a-type-with-two-properties-having-the-same-name/64488044#64488044")]
        public static void SetStaticPropertyValue___Should_throw_ArgumentException___When_multiple_properties_with_the_same_name_exist()
        {
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_throw_ArgumentException___When_property_does_not_have_a_set_method()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            var notWritableProperties = GetParentNotWritablePropertyNames();

            // Act
            var actual = notWritableProperties.Select(_ => Record.Exception(() => type.SetStaticPropertyValue(_, AD.ummy(type.GetPropertyInfo(_).PropertyType)))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("Property set method not found.");
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_throw_InvalidCastException___When_value_is_null_and_property_type_is_not_assignable_to_null()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            var propertyNames = GetParentWritablePropertyNames().Where(_ => _.Contains("ValueType")).ToList();

            // Act
            var actual = propertyNames.Select(_ => Record.Exception(() => type.SetStaticPropertyValue(_, null)));

            // Assert
            actual.AsTest().Must().Each().BeOfType<InvalidCastException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("Unable to assign null value to property of type 'int'.");
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_throw_InvalidCastException___When_value_is_not_null_and_value_type_is_not_assignable_to_property_type()
        {
            // Arrange
            var type = typeof(ParentStaticProperties);

            // Act
            var actual1 = Record.Exception(() => type.SetStaticPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteReferenceTypeProperty), 5));
            var actual2 = Record.Exception(() => type.SetStaticPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteNullableTypeProperty), Guid.NewGuid()));
            var actual3 = Record.Exception(() => type.SetStaticPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteStringTypeProperty), 90));
            var actual4 = Record.Exception(() => type.SetStaticPropertyValue(nameof(ParentInstanceProperties.ParentPublicReadWriteValueTypeProperty), Guid.NewGuid()));

            // Assert
            actual1.AsTest().Must().BeOfType<InvalidCastException>();
            actual1.Message.Must().BeEqualTo("Unable to assign value of type 'int' to property of type 'Version'.");

            actual2.AsTest().Must().BeOfType<InvalidCastException>();
            actual2.Message.Must().BeEqualTo("Unable to assign value of type 'Guid' to property of type 'int?'.");

            actual3.AsTest().Must().BeOfType<InvalidCastException>();
            actual3.Message.Must().BeEqualTo("Unable to assign value of type 'int' to property of type 'string'.");

            actual4.AsTest().Must().BeOfType<InvalidCastException>();
            actual4.Message.Must().BeEqualTo("Unable to assign value of type 'Guid' to property of type 'int'.");
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_set_property_values___When_called()
        {
            // Arrange
            ResetParentStaticProperties();

            var type = typeof(ParentStaticProperties);

            var parentWritablePropertyNames = GetParentWritablePropertyNames();

            var expected = ParentStaticProperties.ToStringWritableProperties();

            var propertyNameToValueToWriteMap = new Dictionary<string, object>();

            foreach (var parentWritablePropertyName in parentWritablePropertyNames)
            {
                var propertyType = type.GetPropertyInfo(parentWritablePropertyName).PropertyType;

                var valueToWrite = parentWritablePropertyName.Contains("WriteOnly")
                    ? AD.ummy(propertyType)
                    : type.GetStaticPropertyValue(parentWritablePropertyName);

                propertyNameToValueToWriteMap.Add(parentWritablePropertyName, valueToWrite);
            }

            ResetParentStaticProperties();

            // Act
            foreach (var parentWritablePropertyName in parentWritablePropertyNames)
            {
                var valueToWrite = propertyNameToValueToWriteMap[parentWritablePropertyName];

                type.SetStaticPropertyValue(parentWritablePropertyName, valueToWrite);
            }

            // Assert
            ParentStaticProperties.ToStringWritableProperties().AsTest().Must().BeEqualTo(expected);
        }

        [Fact]
        public static void SetStaticPropertyValue___Should_throw_ArgumentException___When_property_is_not_static()
        {
            // Arrange
            var type = typeof(ParentInstanceProperties);

            var notWritableProperties = GetParentWritablePropertyNames();

            // Act
            var actual = notWritableProperties.Select(_ => Record.Exception(() => type.SetStaticPropertyValue(_, AD.ummy(type.GetPropertyInfo(_).PropertyType), BindingFlagsFor.AllDeclaredAndInheritedMembers))).ToList();

            // Assert
            actual.AsTest().Must().Each().BeOfType<ArgumentException>();
            actual.Select(_ => _.Message).AsTest().Must().Each().BeEqualTo("The property is not static.");
        }

        private static void ResetParentStaticProperties()
        {
            ParentStaticProperties.ParentPublicReadWriteNullableTypeProperty = A.Dummy<int>();
            ParentStaticProperties.ParentPublicReadWriteReferenceTypeProperty = A.Dummy<Version>();
            ParentStaticProperties.ParentPublicReadWriteStringTypeProperty = A.Dummy<string>();
            ParentStaticProperties.ParentPublicReadWriteValueTypeProperty = A.Dummy<int>();
        }

        private static ParentInstanceProperties GetDummyParentProperties()
        {
            var result = A.Dummy<ParentInstanceProperties>();

            result.ParentPublicReadWriteNullableTypeProperty = A.Dummy<int>();
            result.ParentPublicReadWriteReferenceTypeProperty = A.Dummy<Version>();
            result.ParentPublicReadWriteStringTypeProperty = A.Dummy<string>();
            result.ParentPublicReadWriteValueTypeProperty = A.Dummy<int>();

            return result;
        }

        private static ParentInstanceProperties GetDummyChildProperties()
        {
            var result = A.Dummy<ChildInstanceProperties>();

            result.ParentPublicReadWriteNullableTypeProperty = A.Dummy<int>();
            result.ParentPublicReadWriteReferenceTypeProperty = A.Dummy<Version>();
            result.ParentPublicReadWriteStringTypeProperty = A.Dummy<string>();
            result.ParentPublicReadWriteValueTypeProperty = A.Dummy<int>();

            result.ChildPublicReadWriteNullableTypeProperty = A.Dummy<int>();
            result.ChildPublicReadWriteReferenceTypeProperty = A.Dummy<Version>();
            result.ChildPublicReadWriteStringTypeProperty = A.Dummy<string>();
            result.ChildPublicReadWriteValueTypeProperty = A.Dummy<int>();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPropertyNamesThatDoNotExist()
        {
            var result = GetParentPropertyNames().Select(_ => _.ToUpperInvariant()).ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPropertyNamesThatDoNotExist()
        {
            var result = new string[0]
                .Concat(GetChildPropertyNames().Select(_ => _.ToUpperInvariant()))
                .Concat(GetParentPublicPropertyNames().Select(_ => _.ToUpperInvariant()))
                .Concat(GetParentProtectedPropertyNames().Select(_ => _.ToUpperInvariant()))
                .Concat(GetParentPrivatePropertyNames())
                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentReadablePropertyNames()
        {
            var result = GetParentPropertyNames().Except(GetParentNotReadablePropertyNames()).ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentNotReadablePropertyNames()
        {
            var result = GetParentPropertyNames().Where(_ => _.Contains("WriteOnly")).ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentWritablePropertyNames()
        {
            var result = GetParentPropertyNames().Where(_ => _.Contains("ReadWrite") || _.Contains("WriteOnly")).ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentNotWritablePropertyNames()
        {
            var result = GetParentPropertyNames().Except(GetParentWritablePropertyNames()).ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPropertyNames()
        {
            var result = new string[0]
                .Concat(GetParentPublicPropertyNames())
                .Concat(GetParentProtectedPropertyNames())
                .Concat(GetParentPrivatePropertyNames())
                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPublicPropertyNames()
        {
            var result = new string[0]
                .Concat(GetParentPublicReadWritePropertyNames())
                .Concat(GetParentPublicReadOnlyAutoPropertyNames())
                .Concat(GetParentPublicReadOnlyExpressionBodyPropertyNames())
                .Concat(GetParentPublicWriteOnlyPropertyNames())

                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPublicReadWritePropertyNames()
        {
            var result = new[]
            {
                "ParentPublicReadWriteValueTypeProperty",
                "ParentPublicReadWriteStringTypeProperty",
                "ParentPublicReadWriteNullableTypeProperty",
                "ParentPublicReadWriteReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPublicReadOnlyAutoPropertyNames()
        {
            var result = new[]
            {
                "ParentPublicReadOnlyAutoValueTypeProperty",
                "ParentPublicReadOnlyAutoStringTypeProperty",
                "ParentPublicReadOnlyAutoNullableTypeProperty",
                "ParentPublicReadOnlyAutoReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPublicReadOnlyExpressionBodyPropertyNames()
        {
            var result = new[]
            {
                "ParentPublicReadOnlyExpressionBodyValueTypeProperty",
                "ParentPublicReadOnlyExpressionBodyStringTypeProperty",
                "ParentPublicReadOnlyExpressionBodyNullableTypeProperty",
                "ParentPublicReadOnlyExpressionBodyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPublicWriteOnlyPropertyNames()
        {
            var result = new[]
            {
                "ParentPublicWriteOnlyValueTypeProperty",
                "ParentPublicWriteOnlyStringTypeProperty",
                "ParentPublicWriteOnlyNullableTypeProperty",
                "ParentPublicWriteOnlyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentProtectedPropertyNames()
        {
            var result = new string[0]
                .Concat(GetParentProtectedReadWritePropertyNames())
                .Concat(GetParentProtectedReadOnlyAutoPropertyNames())
                .Concat(GetParentProtectedReadOnlyExpressionBodyPropertyNames())
                .Concat(GetParentProtectedWriteOnlyPropertyNames())

                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentProtectedReadWritePropertyNames()
        {
            var result = new[]
            {
                "ParentProtectedReadWriteValueTypeProperty",
                "ParentProtectedReadWriteStringTypeProperty",
                "ParentProtectedReadWriteNullableTypeProperty",
                "ParentProtectedReadWriteReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentProtectedReadOnlyAutoPropertyNames()
        {
            var result = new[]
            {
                "ParentProtectedReadOnlyAutoValueTypeProperty",
                "ParentProtectedReadOnlyAutoStringTypeProperty",
                "ParentProtectedReadOnlyAutoNullableTypeProperty",
                "ParentProtectedReadOnlyAutoReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentProtectedReadOnlyExpressionBodyPropertyNames()
        {
            var result = new[]
            {
                "ParentProtectedReadOnlyExpressionBodyValueTypeProperty",
                "ParentProtectedReadOnlyExpressionBodyStringTypeProperty",
                "ParentProtectedReadOnlyExpressionBodyNullableTypeProperty",
                "ParentProtectedReadOnlyExpressionBodyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentProtectedWriteOnlyPropertyNames()
        {
            var result = new[]
            {
                "ParentProtectedWriteOnlyValueTypeProperty",
                "ParentProtectedWriteOnlyStringTypeProperty",
                "ParentProtectedWriteOnlyNullableTypeProperty",
                "ParentProtectedWriteOnlyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPrivatePropertyNames()
        {
            var result = new string[0]
                .Concat(GetParentPrivateReadWritePropertyNames())
                .Concat(GetParentPrivateReadOnlyAutoPropertyNames())
                .Concat(GetParentPrivateReadOnlyExpressionBodyPropertyNames())
                .Concat(GetParentPrivateWriteOnlyPropertyNames())

                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPrivateReadWritePropertyNames()
        {
            var result = new[]
            {
                "ParentPrivateReadWriteValueTypeProperty",
                "ParentPrivateReadWriteStringTypeProperty",
                "ParentPrivateReadWriteNullableTypeProperty",
                "ParentPrivateReadWriteReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPrivateReadOnlyAutoPropertyNames()
        {
            var result = new[]
            {
                "ParentPrivateReadOnlyAutoValueTypeProperty",
                "ParentPrivateReadOnlyAutoStringTypeProperty",
                "ParentPrivateReadOnlyAutoNullableTypeProperty",
                "ParentPrivateReadOnlyAutoReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPrivateReadOnlyExpressionBodyPropertyNames()
        {
            var result = new[]
            {
                "ParentPrivateReadOnlyExpressionBodyValueTypeProperty",
                "ParentPrivateReadOnlyExpressionBodyStringTypeProperty",
                "ParentPrivateReadOnlyExpressionBodyNullableTypeProperty",
                "ParentPrivateReadOnlyExpressionBodyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetParentPrivateWriteOnlyPropertyNames()
        {
            var result = new[]
            {
                "ParentPrivateWriteOnlyValueTypeProperty",
                "ParentPrivateWriteOnlyStringTypeProperty",
                "ParentPrivateWriteOnlyNullableTypeProperty",
                "ParentPrivateWriteOnlyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPropertyNames()
        {
            var result = new string[0]
                .Concat(GetChildPublicPropertyNames())
                .Concat(GetChildProtectedPropertyNames())
                .Concat(GetChildPrivatePropertyNames())
                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPublicPropertyNames()
        {
            var result = new string[0]
                .Concat(GetChildPublicReadWritePropertyNames())
                .Concat(GetChildPublicReadOnlyAutoPropertyNames())
                .Concat(GetChildPublicReadOnlyExpressionBodyPropertyNames())
                .Concat(GetChildPublicWriteOnlyPropertyNames())
                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPublicReadWritePropertyNames()
        {
            var result = new[]
            {
                "ChildPublicReadWriteValueTypeProperty",
                "ChildPublicReadWriteStringTypeProperty",
                "ChildPublicReadWriteNullableTypeProperty",
                "ChildPublicReadWriteReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPublicReadOnlyAutoPropertyNames()
        {
            var result = new[]
            {
                "ChildPublicReadOnlyAutoValueTypeProperty",
                "ChildPublicReadOnlyAutoStringTypeProperty",
                "ChildPublicReadOnlyAutoNullableTypeProperty",
                "ChildPublicReadOnlyAutoReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPublicReadOnlyExpressionBodyPropertyNames()
        {
            var result = new[]
            {
                "ChildPublicReadOnlyExpressionBodyValueTypeProperty",
                "ChildPublicReadOnlyExpressionBodyStringTypeProperty",
                "ChildPublicReadOnlyExpressionBodyNullableTypeProperty",
                "ChildPublicReadOnlyExpressionBodyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPublicWriteOnlyPropertyNames()
        {
            var result = new[]
            {
                "ChildPublicWriteOnlyValueTypeProperty",
                "ChildPublicWriteOnlyStringTypeProperty",
                "ChildPublicWriteOnlyNullableTypeProperty",
                "ChildPublicWriteOnlyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildProtectedPropertyNames()
        {
            var result = new string[0]
                .Concat(GetChildProtectedReadWritePropertyNames())
                .Concat(GetChildProtectedReadOnlyAutoPropertyNames())
                .Concat(GetChildProtectedReadOnlyExpressionBodyPropertyNames())
                .Concat(GetChildProtectedWriteOnlyPropertyNames())
                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetChildProtectedReadWritePropertyNames()
        {
            var result = new[]
            {
                "ChildProtectedReadWriteValueTypeProperty",
                "ChildProtectedReadWriteStringTypeProperty",
                "ChildProtectedReadWriteNullableTypeProperty",
                "ChildProtectedReadWriteReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildProtectedReadOnlyAutoPropertyNames()
        {
            var result = new[]
            {
                "ChildProtectedReadOnlyAutoValueTypeProperty",
                "ChildProtectedReadOnlyAutoStringTypeProperty",
                "ChildProtectedReadOnlyAutoNullableTypeProperty",
                "ChildProtectedReadOnlyAutoReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildProtectedReadOnlyExpressionBodyPropertyNames()
        {
            var result = new[]
            {
                "ChildProtectedReadOnlyExpressionBodyValueTypeProperty",
                "ChildProtectedReadOnlyExpressionBodyStringTypeProperty",
                "ChildProtectedReadOnlyExpressionBodyNullableTypeProperty",
                "ChildProtectedReadOnlyExpressionBodyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildProtectedWriteOnlyPropertyNames()
        {
            var result = new[]
            {
                "ChildProtectedWriteOnlyValueTypeProperty",
                "ChildProtectedWriteOnlyStringTypeProperty",
                "ChildProtectedWriteOnlyNullableTypeProperty",
                "ChildProtectedWriteOnlyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPrivatePropertyNames()
        {
            var result = new string[0]
                .Concat(GetChildPrivateReadWritePropertyNames())
                .Concat(GetChildPrivateReadOnlyAutoPropertyNames())
                .Concat(GetChildPrivateReadOnlyExpressionBodyPropertyNames())
                .Concat(GetChildPrivateWriteOnlyPropertyNames())
                .ToList();

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPrivateReadWritePropertyNames()
        {
            var result = new[]
            {
                "ChildPrivateReadWriteValueTypeProperty",
                "ChildPrivateReadWriteStringTypeProperty",
                "ChildPrivateReadWriteNullableTypeProperty",
                "ChildPrivateReadWriteReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPrivateReadOnlyAutoPropertyNames()
        {
            var result = new[]
            {
                "ChildPrivateReadOnlyAutoValueTypeProperty",
                "ChildPrivateReadOnlyAutoStringTypeProperty",
                "ChildPrivateReadOnlyAutoNullableTypeProperty",
                "ChildPrivateReadOnlyAutoReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPrivateReadOnlyExpressionBodyPropertyNames()
        {
            var result = new[]
            {
                "ChildPrivateReadOnlyExpressionBodyValueTypeProperty",
                "ChildPrivateReadOnlyExpressionBodyStringTypeProperty",
                "ChildPrivateReadOnlyExpressionBodyNullableTypeProperty",
                "ChildPrivateReadOnlyExpressionBodyReferenceTypeProperty",
            };

            return result;
        }

        private static IReadOnlyCollection<string> GetChildPrivateWriteOnlyPropertyNames()
        {
            var result = new[]
            {
                "ChildPrivateWriteOnlyValueTypeProperty",
                "ChildPrivateWriteOnlyStringTypeProperty",
                "ChildPrivateWriteOnlyNullableTypeProperty",
                "ChildPrivateWriteOnlyReferenceTypeProperty",
            };

            return result;
        }
    }
}