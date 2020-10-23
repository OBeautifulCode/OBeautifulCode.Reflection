// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using FakeItEasy;

    using FluentAssertions;

    using Xunit;

    public static partial class ReflectionHelperTest
    {
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
