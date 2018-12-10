// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using FakeItEasy;

    using FluentAssertions;

    using OBeautifulCode.Reflection.Recipes;

    using Xunit;

    public static class TypeHelperTest
    {
        [Fact]
        public static void IsAnonymous___Should_return_true_for_anonymous_type()
        {
            // Arrange, Act, Assert
            new { SomeProp = "prop value" }.GetType().IsAnonymous().Should().BeTrue();
        }

        [Fact]
        public static void IsAnonymous___Should_return_false_for_concrete_type()
        {
            // Arrange, Act, Assert
            "string type".GetType().IsAnonymous().Should().BeFalse();
        }

        [Fact]
        public static void IsAnonymousFastCheck___Should_return_true_for_anonymous_type()
        {
            // Arrange, Act, Assert
            new { SomeProp = "prop value" }.GetType().IsAnonymousFastCheck().Should().BeTrue();
        }

        [Fact]
        public static void IsAnonymousFastCheck___Should_return_false_for_concrete_type()
        {
            // Arrange, Act, Assert
            "string type".GetType().IsAnonymousFastCheck().Should().BeFalse();
        }

        [Fact]
        public static void IsAssignableTo___Should_throw_ArgumentNullException___When_parameter_type_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => TypeHelper.IsAssignableTo(null, A.Dummy<Type>()));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("type");
        }

        [Fact]
        public static void IsAssignableTo___Should_throw_ArgumentNullException___When_parameter_otherType_is_null()
        {
            // Arrange, Act
            var actual = Record.Exception(() => A.Dummy<Type>().IsAssignableTo(null));

            // Assert
            actual.Should().BeOfType<ArgumentNullException>();
            actual.Message.Should().Contain("otherType");
        }

        [Fact]
        public static void IsAssignableTo___Should_throw_ArgumentException___When_parameter_type_is_an_unbound_generic_type()
        {
            // Arrange, Act
            var actual1 = Record.Exception(() => typeof(IEnumerable<>).IsAssignableTo(A.Dummy<Type>()));
            var actual2 = Record.Exception(() => typeof(List<>).IsAssignableTo(A.Dummy<Type>()));

            // Assert
            actual1.Should().BeOfType<ArgumentException>();
            actual1.Message.Should().Contain("type.IsGenericTypeDefinition");

            actual2.Should().BeOfType<ArgumentException>();
            actual2.Message.Should().Contain("type.IsGenericTypeDefinition");
        }

        [Fact]
        public static void IsAssignableTo___Should_return_true___When_type_is_equal_to_otherType()
        {
            // Arrange, Act
            var actual1 = typeof(string).IsAssignableTo(typeof(string));
            var actual2 = typeof(List<string>).IsAssignableTo(typeof(List<string>));
            var actual3 = typeof(IEnumerable<string>).IsAssignableTo(typeof(IEnumerable<string>));

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_true___When_IsAssignableFrom_returns_true()
        {
            // Arrange, Act
            var actual1 = typeof(string).IsAssignableTo(typeof(object));
            var actual2 = typeof(List<string>).IsAssignableTo(typeof(IList));
            var actual3 = typeof(List<string>).IsAssignableTo(typeof(IList<string>));

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_false___When_IsAssignableFrom_returns_false_and_otherType_is_not_unbound_generic_and_treatUnboundGenericAsAssignableTo_is_false()
        {
            // Arrange, Act
            var actual1 = typeof(List<string>).IsAssignableTo(typeof(List<object>));
            var actual2 = typeof(List<string>).IsAssignableTo(typeof(IList<object>));
            var actual3 = typeof(object).IsAssignableTo(typeof(string));
            var actual4 = typeof(GenericBaseClass<string>).IsAssignableTo(typeof(GenericSubclass<string>));
            var actual5 = typeof(IList<string>).IsAssignableTo(typeof(GenericBaseClass<string>));

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_false___When_IsAssignableFrom_returns_false_and_otherType_is_not_unbound_generic_and_treatUnboundGenericAsAssignableTo_is_true()
        {
            // Arrange, Act
            var actual1 = typeof(List<string>).IsAssignableTo(typeof(List<object>), treatUnboundGenericAsAssignableTo: true);
            var actual2 = typeof(List<string>).IsAssignableTo(typeof(IList<object>), treatUnboundGenericAsAssignableTo: true);
            var actual3 = typeof(object).IsAssignableTo(typeof(string), treatUnboundGenericAsAssignableTo: true);
            var actual4 = typeof(GenericBaseClass<string>).IsAssignableTo(typeof(GenericSubclass<string>), treatUnboundGenericAsAssignableTo: true);
            var actual5 = typeof(IList<string>).IsAssignableTo(typeof(GenericBaseClass<string>), treatUnboundGenericAsAssignableTo: true);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_true___When_type_GenericTypeDefinition_is_equal_to_otherType_and_treatUnboundGenericAsAssignableTo_is_true()
        {
            // Arrange, Act
            var actual1 = typeof(List<string>).IsAssignableTo(typeof(List<>), treatUnboundGenericAsAssignableTo: true);
            var actual2 = typeof(IList<string>).IsAssignableTo(typeof(IList<>), treatUnboundGenericAsAssignableTo: true);
            var actual3 = typeof(int?).IsAssignableTo(typeof(Nullable<>), treatUnboundGenericAsAssignableTo: true);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_false___When_type_GenericTypeDefinition_is_equal_to_otherType_and_treatUnboundGenericAsAssignableTo_is_false()
        {
            // Arrange, Act
            var actual1 = typeof(List<string>).IsAssignableTo(typeof(List<>));
            var actual2 = typeof(IList<string>).IsAssignableTo(typeof(IList<>));
            var actual3 = typeof(int?).IsAssignableTo(typeof(Nullable<>));

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_true___When_type_implements_or_inherits_an_interface_whose_generic_type_definition_equals_otherType_and_treatUnboundGenericAsAssignableTo_is_true()
        {
            // Arrange, Act
            var actual1 = typeof(List<string>).IsAssignableTo(typeof(IList<>), treatUnboundGenericAsAssignableTo: true);
            var actual2 = typeof(List<string>).IsAssignableTo(typeof(IEnumerable<>), treatUnboundGenericAsAssignableTo: true);
            var actual3 = typeof(IList<string>).IsAssignableTo(typeof(IEnumerable<>), treatUnboundGenericAsAssignableTo: true);
            var actual4 = typeof(GenericSubclass<string>).IsAssignableTo(typeof(IEnumerable<>), treatUnboundGenericAsAssignableTo: true);
            var actual5 = typeof(GenericSubclass<string>).IsAssignableTo(typeof(GenericBaseClass<>), treatUnboundGenericAsAssignableTo: true);

            // Assert
            actual1.Should().BeTrue();
            actual2.Should().BeTrue();
            actual3.Should().BeTrue();
            actual4.Should().BeTrue();
            actual5.Should().BeTrue();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_false___When_type_implements_or_inherits_an_interface_whose_generic_type_definition_equals_otherType_and_treatUnboundGenericAsAssignableTo_is_false()
        {
            // Arrange, Act
            var actual1 = typeof(List<string>).IsAssignableTo(typeof(IList<>));
            var actual2 = typeof(List<string>).IsAssignableTo(typeof(IEnumerable<>));
            var actual3 = typeof(IList<string>).IsAssignableTo(typeof(IEnumerable<>));
            var actual4 = typeof(GenericSubclass<string>).IsAssignableTo(typeof(IEnumerable<>));
            var actual5 = typeof(GenericSubclass<string>).IsAssignableTo(typeof(GenericBaseClass<>));

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_false___When_type_does_not_implement_nor_inherit_an_interface_whose_generic_type_definition_equals_otherType_and_treatUnboundGenericAsAssignableTo_is_true()
        {
            // Arrange, Act
            var actual1 = typeof(IList<string>).IsAssignableTo(typeof(List<>), treatUnboundGenericAsAssignableTo: true);
            var actual2 = typeof(IEnumerable<string>).IsAssignableTo(typeof(IList<>), treatUnboundGenericAsAssignableTo: true);
            var actual3 = typeof(IEnumerable<string>).IsAssignableTo(typeof(List<>), treatUnboundGenericAsAssignableTo: true);
            var actual4 = typeof(GenericBaseClass<string>).IsAssignableTo(typeof(GenericSubclass<>), treatUnboundGenericAsAssignableTo: true);
            var actual5 = typeof(IList<string>).IsAssignableTo(typeof(GenericBaseClass<>), treatUnboundGenericAsAssignableTo: true);

            // Assert
            actual1.Should().BeFalse();
            actual2.Should().BeFalse();
            actual3.Should().BeFalse();
            actual4.Should().BeFalse();
            actual5.Should().BeFalse();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_true___When_type_BaseType_implements_or_inherits_an_interface_whose_generic_type_definition_equals_otherType_and_treatUnboundGenericAsAssignableTo_is_true()
        {
            // Arrange, Act
            var actual = typeof(MyList<string>).IsAssignableTo(typeof(List<>), treatUnboundGenericAsAssignableTo: true);

            // Assert
            actual.Should().BeTrue();
        }

        [Fact]
        public static void IsAssignableTo___Should_return_false___When_type_BaseType_implements_or_inherits_an_interface_whose_generic_type_definition_equals_otherType_and_treatUnboundGenericAsAssignableTo_is_false()
        {
            // Arrange, Act
            var actual = typeof(MyList<string>).IsAssignableTo(typeof(List<>));

            // Assert
            actual.Should().BeFalse();
        }

        public class GenericBaseClass<T> : IList<T>
        {
            public int Count { get; }

            public bool IsReadOnly { get; }

            public T this[int index]
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public void Add(T item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(T item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(T[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(T item)
            {
                throw new NotImplementedException();
            }

            public int IndexOf(T item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, T item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }
        }

        public class GenericSubclass<T> : GenericBaseClass<T>
        {
        }

        public class MyList<T> : List<T>
        {
        }
    }
}
