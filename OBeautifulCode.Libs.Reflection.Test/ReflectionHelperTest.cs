// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTest.cs" company="CoMetrics">
//   Copyright 2014 CoMetrics
// </copyright>
// <summary>
//   Tests the <see cref="ReflectionHelper"/> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Libs.Reflection.Test
{
    using System;

    using Xunit;

    /// <summary>
    /// Tests the <see cref="ReflectionHelper"/> class.
    /// </summary>
    public static class ReflectionHelperTest
    {
        #region Fields (Private)
        
        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Public Methods
        // ReSharper disable InconsistentNaming

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public static void HasProperty_ItemIsNull_ThrowsArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => ReflectionHelper.HasProperty(null, "PrivateParentDoubleProperty"));
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public static void HasProperty_PropertyNameIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            var myTestClassParent = new ReflectionHelperTestParent();

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => myTestClassParent.HasProperty(null));
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public static void HasProperty_PropertyNameIsWhitespace_ThrowsArgumentException()
        {
            // Arrange
            var myTestClassParent = new ReflectionHelperTestParent();

            // Act, Assert
            Assert.Throws<ArgumentException>(() => myTestClassParent.HasProperty(string.Empty));
            Assert.Throws<ArgumentException>(() => myTestClassParent.HasProperty("    "));
            Assert.Throws<ArgumentException>(() => myTestClassParent.HasProperty("  \r\n  "));
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public static void HasProperty_PropertyDoesNotExistBecauseCaseOfNameIsWrong_ReturnsFalse()
        {
            // Arrange
            var myTestClassParent = new ReflectionHelperTestParent();

            // Act
            bool actual1 = myTestClassParent.HasProperty("privateParentDoubleProperty");
            bool actual2 = myTestClassParent.HasProperty("privateParentStringproperty");
            bool actual3 = myTestClassParent.HasProperty("PrivateStaticparentStringProperty");
            bool actual4 = myTestClassParent.HasProperty("publicParentDoubleProperty");
            bool actual5 = myTestClassParent.HasProperty("publicParentStringproperty");
            bool actual6 = myTestClassParent.HasProperty("PublicStaticparentStringProperty");
            
            // Assert
            Assert.False(actual1);
            Assert.False(actual2);
            Assert.False(actual3);
            Assert.False(actual4);
            Assert.False(actual5);
            Assert.False(actual6);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public static void HasProperty_PropertyDoesNotExist_ReturnsFalse()
        {
            // Arrange
            var myTestClassParent = new ReflectionHelperTestParent();

            // Act
            bool actual1 = myTestClassParent.HasProperty("doesnotexist");
            bool actual2 = myTestClassParent.HasProperty(" a ");
            bool actual3 = myTestClassParent.HasProperty("privateParentDoubleField");
            bool actual4 = myTestClassParent.HasProperty("PublicParentStringField");
            
            // Assert
            Assert.False(actual1);
            Assert.False(actual2);
            Assert.False(actual3);
            Assert.False(actual4);
        }


        bool actual1 = myTestClassParent.HasProperty("PrivateParentDoubleProperty");
        bool actual2 = myTestClassParent.HasProperty("PrivateParentStringProperty");

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public static void HasProperty_PropertyExists_ReturnsTrue()
        {
            // Arrange
            var myTestClassChild = new ReflectionHelperTestChild();

            // Act
            bool actual1 = myTestClassChild.HasProperty("PrivateChildDoubleProperty");
            bool actual2 = myTestClassChild.HasProperty("PrivateChildStringProperty");

            // Assert
            Assert.True(actual1);
            Assert.True(actual2);
        }

        /// <summary>
        /// Test method.
        /// </summary>
        [Fact]
        public static void HasProperty_PropertyExistsInSuperclass_ReturnsTrue()
        {
            // Arrange
            var myTestClassChild = new ReflectionHelperTestChild();

            // Act
            bool actual1 = myTestClassChild.HasProperty("PrivateParentDoubleProperty");
            bool actual2 = myTestClassChild.HasProperty("PrivateParentStringProperty");

            // Assert
            Assert.True(actual1);
            Assert.True(actual2);
        }
        
  







        ///// <summary>
        ///// Tests the GetPropertyValue extension method
        ///// </summary>
        //[Fact]
        //public static void GetPropertyValueTest()
        //{
        //    var myTestClassParent = new ReflectionHelperTestParent();

        //    // argument exceptions
        //    Assert.Throws<ArgumentNullException>(() => ReflectionHelpers.GetPropertyValue<string>(null, "PrivateParentDoubleProperty"));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.GetPropertyValue<string>(null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.GetPropertyValue<string>(""));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.GetPropertyValue<string>("\r\n"));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.GetPropertyValue<string>("      \r\n       "));

        //    // property doesn't exist - case matters
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetPropertyValue<double>("privateParentDoubleProperty"));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetPropertyValue<string>("privateParentStringproperty"));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetPropertyValue<double>("_privateParentDoubleField"));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetPropertyValue<string>("_privateParentStringField"));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetPropertyValue<string>(" a "));

        //    // property does exist, but is wrong type
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetPropertyValue<string>("PrivateParentDoubleProperty"));
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetPropertyValue<double>("PrivateParentStringProperty"));
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetPropertyValue<string>("PrivateParentStreamProperty"));
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetPropertyValue<string>("PrivateParentNullStreamProperty"));

        //    // property exists
        //    Assert.Equal(0d, myTestClassParent.GetPropertyValue<double>("PrivateParentDoubleProperty"));
        //    Assert.Null(myTestClassParent.GetPropertyValue<string>("PrivateParentStringProperty"));
        //    Assert.Equal("whatever3", myTestClassParent.GetPropertyValue<string>("PrivateStaticParentStringProperty2"));

        //    // subclasses are accessed
        //    var myTestClassChild = new ReflectionHelperTestChild();
        //    Assert.Equal(0d, myTestClassChild.GetPropertyValue<double>("PrivateParentDoubleProperty"));
        //    Assert.Null(myTestClassChild.GetPropertyValue<string>("PrivateParentStringProperty"));

        //    // property exists
        //    Assert.Equal(456d, myTestClassChild.GetPropertyValue<double>("PrivateChildDoubleProperty"));
        //    Assert.Equal("Testing456", myTestClassChild.GetPropertyValue<string>("PrivateChildStringProperty"));

        //    // try getting MemoryStream for Stream
        //    Assert.Equal(2, myTestClassParent.GetPropertyValue<Stream>("PrivateParentStreamProperty").Length);
        //    Assert.Equal(2, myTestClassParent.GetPropertyValue<MemoryStream>("PrivateParentStreamProperty").Length);

        //    // try getting FileStream for Stream
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetPropertyValue<FileStream>("PrivateParentStreamProperty").Length);

        //    // try getting MemoryStream for IDisposable
        //    Assert.Equal(3, myTestClassParent.GetPropertyValue<Stream>("PrivateParentIDisposableProperty").Length);
        //    Assert.Equal(3, myTestClassParent.GetPropertyValue<MemoryStream>("PrivateParentIDisposableProperty").Length);

        //    // try getting FileStream for IDisposable
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetPropertyValue<FileStream>("PrivateParentIDisposableProperty").Length);

        //}

        ///// <summary>
        ///// Tests the GetFieldValue extension method
        ///// </summary>
        //[Fact]
        //public static void GetFieldValueTest()
        //{
        //    var myTestClassParent = new ReflectionHelperTestParent();

        //    // argument exceptions
        //    Assert.Throws<ArgumentNullException>(() => ReflectionHelpers.GetFieldValue<string>(null, "_privateParentDoubleField"));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.GetFieldValue<string>(null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.GetFieldValue<string>(""));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.GetFieldValue<string>("\r\n"));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.GetFieldValue<string>("      \r\n       "));

        //    // field doesn't exist - case matters
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetFieldValue<double>("privateParentDoubleField"));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetFieldValue<string>("_privateParentStringfield"));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetFieldValue<double>("PrivateParentDoubleProperty"));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetFieldValue<string>("PrivateParentStringProperty"));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.GetFieldValue<string>(" a "));

        //    // field does exist, but is wrong type
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetFieldValue<string>("_privateParentDoubleField"));
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetFieldValue<double>("_privateParentStringField"));
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetFieldValue<string>("_privateParentStreamField"));
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetFieldValue<string>("_privateParentNullStreamField"));

        //    // field exists
        //    Assert.Equal(0d, myTestClassParent.GetFieldValue<double>("_privateParentDoubleField"));
        //    Assert.Null(myTestClassParent.GetFieldValue<string>("_privateParentStringField"));
        //    Assert.Equal("whatever2", myTestClassParent.GetFieldValue<string>("_privateStaticParentStringField2"));

        //    // subclasses are accessed
        //    var myTestClassChild = new ReflectionHelperTestChild();
        //    Assert.Equal(0d, myTestClassChild.GetFieldValue<double>("_privateParentDoubleField"));
        //    Assert.Null(myTestClassChild.GetFieldValue<string>("_privateParentStringField"));

        //    // field exists
        //    Assert.Equal(123d, myTestClassChild.GetFieldValue<double>("_privateChildDoubleField"));
        //    Assert.Equal("Testing123", myTestClassChild.GetFieldValue<string>("_privateChildStringField"));

        //    // try getting MemoryStream for Stream
        //    Assert.Equal(1, myTestClassParent.GetFieldValue<Stream>("_privateParentStreamField").Length);
        //    Assert.Equal(1, myTestClassParent.GetFieldValue<MemoryStream>("_privateParentStreamField").Length);

        //    // try getting FileStream for Stream
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetFieldValue<FileStream>("_privateParentStreamField").Length);

        //    // try getting MemoryStream for IDisposable
        //    Assert.Equal(0, myTestClassParent.GetFieldValue<Stream>("_privateParentIDisposableField").Length);
        //    Assert.Equal(0, myTestClassParent.GetFieldValue<MemoryStream>("_privateParentIDisposableField").Length);

        //    // try getting FileStream for IDisposable
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.GetFieldValue<FileStream>("_privateParentIDisposableField").Length);

        //}

        ///// <summary>
        ///// Tests the SetPropertyValue extension method
        ///// </summary>
        //[Fact]
        //public static void SetPropertyValueTest()
        //{
        //    var myTestClassParent = new ReflectionHelperTestParent();

        //    // argument exceptions
        //    Assert.Throws<ArgumentNullException>(() => ReflectionHelpers.SetPropertyValue<string>(null, "PrivateParentDoubleProperty", null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.SetPropertyValue<string>(null, null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.SetPropertyValue<string>("", null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.SetPropertyValue<string>("\r\n", null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.SetPropertyValue<string>("      \r\n       ", null));

        //    // property doesn't exist - case matters
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetPropertyValue<double>("privateParentDoubleProperty", 789));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetPropertyValue<string>("privateParentStringproperty", null));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetPropertyValue<double>("_privateParentDoubleField", 789));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetPropertyValue<string>("_privateParentStringField", null));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetPropertyValue<string>(" a ", null));

        //    // property does exist, but is wrong type
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.SetPropertyValue("PrivateParentDoubleProperty", "abcd"));
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.SetPropertyValue("PrivateParentStringProperty", 123d));

        //    // property exists
        //    myTestClassParent.SetPropertyValue("PrivateParentDoubleProperty", 8910d);
        //    Assert.Equal(8910d, myTestClassParent.PublicParentDoubleProperty);
        //    myTestClassParent.SetPropertyValue("PrivateParentStringProperty", "Testing8910");
        //    Assert.Equal("Testing8910", myTestClassParent.PublicParentStringProperty);
        //    myTestClassParent.SetPropertyValue("PrivateStaticParentStringProperty", "testing151617");
        //    Assert.Equal("testing151617", myTestClassParent.PublicStaticParentStringProperty);

        //    // subclasses are accessed
        //    var myTestClassChild = new ReflectionHelperTestChild();
        //    myTestClassChild.SetPropertyValue("PrivateParentDoubleProperty", 123d);
        //    Assert.Equal(123d, myTestClassChild.PublicParentDoubleProperty);
        //    myTestClassChild.SetPropertyValue("PrivateParentStringProperty", "abc");
        //    Assert.Equal("abc", myTestClassChild.PublicParentStringProperty);

        //    // property exists
        //    myTestClassChild.SetPropertyValue("PrivateChildDoubleProperty", 111213d);
        //    myTestClassChild.SetPropertyValue("PrivateChildStringProperty", "Testing111213");
        //    Assert.Equal(111213d, myTestClassChild.PublicChildDoubleProperty);
        //    Assert.Equal("Testing111213", myTestClassChild.PublicChildStringProperty);

        //    // try setting MemoryStream for Stream
        //    myTestClassParent.SetPropertyValue("PrivateParentStreamProperty", new MemoryStream(new byte[] { 0, 0, 0, 0 }, true));
        //    Assert.Equal(4, myTestClassParent.PublicParentStreamProperty.Length);

        //    // testing MemoryStream for IDisposeable
        //    myTestClassParent.SetPropertyValue("PrivateParentIDisposableProperty", new MemoryStream(new byte[] { 0, 0, 0, 0, 0 }, true));
        //    Assert.Equal(5, ((MemoryStream)myTestClassParent.PublicParentIDisposableProperty).Length);

        //}

        ///// <summary>
        ///// Tests the SetFieldValue extension method
        ///// </summary>
        //[Fact]
        //public static void SetFieldValueTest()
        //{
        //    var myTestClassParent = new ReflectionHelperTestParent();

        //    // argument exceptions
        //    Assert.Throws<ArgumentNullException>(() => ReflectionHelpers.SetFieldValue<string>(null, "_privateParentDoubleField", null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.SetFieldValue<string>(null, null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.SetFieldValue<string>("", null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.SetFieldValue<string>("\r\n", null));
        //    Assert.Throws<ArgumentException>(() => myTestClassParent.SetFieldValue<string>("      \r\n       ", null));

        //    // property doesn't exist - case matters
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetFieldValue<double>("privateParentDoubleField", 789));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetFieldValue<string>("privateParentStringfield", null));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetFieldValue<double>("PrivateParentDoubleProperty", 789));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetFieldValue<string>("PrivateParentStringProperty", null));
        //    Assert.Throws<NotFoundException>(() => myTestClassParent.SetFieldValue<string>(" a ", null));

        //    // property does exist, but is wrong type
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.SetFieldValue("_privateParentDoubleField", "abcd"));
        //    Assert.Throws<InvalidCastException>(() => myTestClassParent.SetFieldValue("_privateParentStringField", 123d));

        //    // property exists
        //    myTestClassParent.SetFieldValue("_privateParentDoubleField", 8910d);
        //    Assert.Equal(8910d, myTestClassParent.PublicParentDoubleField);
        //    myTestClassParent.SetFieldValue("_privateParentStringField", "Testing8910");
        //    Assert.Equal("Testing8910", myTestClassParent.PublicParentStringField);
        //    myTestClassParent.SetFieldValue("_privateStaticParentStringField", "Testing151617");
        //    Assert.Equal("Testing151617", myTestClassParent.PublicStaticParentStringField);

        //    // subclasses are accessed
        //    var myTestClassChild = new ReflectionHelperTestChild();
        //    myTestClassChild.SetFieldValue("_privateParentDoubleField", 123d);
        //    Assert.Equal(123d, myTestClassChild.PublicParentDoubleField);
        //    myTestClassChild.SetFieldValue("_privateParentStringField", "abc");
        //    Assert.Equal("abc", myTestClassChild.PublicParentStringField);

        //    // property exists
        //    myTestClassChild.SetFieldValue("_privateChildDoubleField", 111213d);
        //    myTestClassChild.SetFieldValue("_privateChildStringField", "Testing111213");
        //    Assert.Equal(111213d, myTestClassChild.PublicChildDoubleField);
        //    Assert.Equal("Testing111213", myTestClassChild.PublicChildStringField);

        //    // try setting MemoryStream for Stream
        //    myTestClassParent.SetFieldValue("_privateParentStreamField", new MemoryStream(new byte[] { 0, 0, 0, 0 }, true));
        //    Assert.Equal(4, myTestClassParent.PublicParentStreamField.Length);

        //    // testing MemoryStream for IDisposable
        //    myTestClassParent.SetFieldValue("_privateParentIDisposableField", new MemoryStream(new byte[] { 0, 0, 0, 0, 0 }, true));
        //    Assert.Equal(5, ((MemoryStream)myTestClassParent.PublicParentIDisposableField).Length);

        //}

        // ReSharper restore InconsistentNaming
        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
