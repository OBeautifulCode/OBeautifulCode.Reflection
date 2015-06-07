// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyHelperTest.cs" company="OBeautifulCode">
//   Copyright 2014 OBeautifulCode
// </copyright>
// <summary>
//   Tests the <see cref="AssemblyHelper"/> class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using System;
    using System.IO;

    using Xunit;

    /// <summary>
    /// Tests the <see cref="AssemblyHelper"/> class.
    /// </summary>
    public class AssemblyHelperTest
    {
        // ReSharper disable InconsistentNaming
        [Fact]
        public static void OpenEmbeddedResourceStream_ResourceNameIsNull_ThrowsArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => AssemblyHelper.OpenEmbeddedResourceStream(null));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_ResourceNameIsWhitespace_ThrowsArgumentException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => AssemblyHelper.OpenEmbeddedResourceStream(string.Empty));
            Assert.Throws<ArgumentException>(() => AssemblyHelper.OpenEmbeddedResourceStream("   "));
            Assert.Throws<ArgumentException>(() => AssemblyHelper.OpenEmbeddedResourceStream("  \r\n   "));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_ResourceDoesNotExist_ThrowsInvalidOperationException()
        {
            // Arrange
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            const string ResourceName1 = "NotThere";
            string resourceName2 = thisNamespace + "EmbeddedTextFileE.txt";

            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => AssemblyHelper.OpenEmbeddedResourceStream(ResourceName1));
            Assert.Throws<InvalidOperationException>(() => AssemblyHelper.OpenEmbeddedResourceStream(resourceName2));
        }

        [Fact(Skip = "Not sure how to test this.")]
        public static void OpenEmbeddedResourceStream_ResourceIsNotAnEmbeddedResource_ThrowsInvalidOperationException()
        {
        }

        [Fact(Skip = "Not practical to test, would have to create a massive file.")]
        public static void OpenEmbeddedResourceStream_ResourceLengthIsGreaterThanInt64MaxValue_ThrowsInvalidOperationException()
        {
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_AddCallerNamespaceIsFalseAndEmbeddedResourceExists_ReturnsReadonlySeekableStreamOfEmbeddedResource()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            string fullyQualifiedResourceName = thisNamespace + "." + ResourceName;
            const string Expected = "this is an embedded text file";

            // Act
            // ReSharper disable RedundantArgumentDefaultValue
            Stream actual = AssemblyHelper.OpenEmbeddedResourceStream(fullyQualifiedResourceName, false);
            // ReSharper restore RedundantArgumentDefaultValue

            // Assert
            Assert.True(actual.CanRead);
            Assert.True(actual.CanSeek);
            Assert.False(actual.CanWrite);
            Assert.False(actual.CanTimeout);
            using (var reader = new StreamReader(actual))
            {
                Assert.Equal(Expected, reader.ReadToEnd());
            }

            // Cleanup
            actual.Dispose();
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_AddCallerNamespaceIsTrueAndEmbeddedResourceExists_ReturnsReadonlySeekableStreamOfEmbeddedResource()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            const string Expected = "this is an embedded text file";

            // Act
            Stream actual = AssemblyHelper.OpenEmbeddedResourceStream(ResourceName, true);

            // Assert
            Assert.True(actual.CanRead);
            Assert.True(actual.CanSeek);
            Assert.False(actual.CanWrite);
            Assert.False(actual.CanTimeout);
            using (var reader = new StreamReader(actual))
            {
                Assert.Equal(Expected, reader.ReadToEnd());
            }

            // Cleanup
            actual.Dispose();
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_StreamToResourceIsAlreadyOpen_ReturnsReadonlySeekableStreamOfEmbeddedResource()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            string fullyQualifiedResourceName = thisNamespace + "." + ResourceName;
            const string Expected = "this is an embedded text file";

            // Act
            Stream actual;
            using (Stream priorOpenStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(fullyQualifiedResourceName))
            {
                // ReSharper disable once PossibleNullReferenceException
                priorOpenStream.Read(new byte[1], 0, 1);
                actual = AssemblyHelper.OpenEmbeddedResourceStream(fullyQualifiedResourceName);
                // ReSharper restore PossibleNullReferenceException
            }

            // Assert
            Assert.True(actual.CanRead);
            Assert.True(actual.CanSeek);
            Assert.False(actual.CanWrite);
            Assert.False(actual.CanTimeout);
            using (var reader = new StreamReader(actual))
            {
                Assert.Equal(Expected, reader.ReadToEnd());
            }

            // Cleanup
            actual.Dispose();
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_AssemblyIsNull_ThrowsArgumentNullException()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => AssemblyHelper.OpenEmbeddedResourceStream(null, ResourceName));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_AssemblyProvidedAndResourceNameIsNull_ThrowsArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream(null));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_AssemblyProvidedAndResourceNameIsWhitespace_ThrowsArgumentException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream(string.Empty));
            Assert.Throws<ArgumentException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream("   "));
            Assert.Throws<ArgumentException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream("  \r\n   "));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_AssemblyProvidedAndResourceDoesNotExist_ThrowsInvalidOperationException()
        {
            // Arrange
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            const string ResourceName1 = "NotThere";
            string resourceName2 = thisNamespace + "EmbeddedTextFileE.txt";

            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream(ResourceName1));
            Assert.Throws<InvalidOperationException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream(resourceName2));
        }

        [Fact(Skip = "Not sure how to test this.")]
        public static void OpenEmbeddedResourceStream_AssemblyProvidedAndResourceIsNotAnEmbeddedResource_ThrowsInvalidOperationException()
        {
        }

        [Fact(Skip = "Not practical to test, would have to create a massive file.")]
        public static void OpenEmbeddedResourceStream_AssemblyProvidedAndResourceLengthIsGreaterThanInt64MaxValue_ThrowsInvalidOperationException()
        {
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_AssemblyProvidedAndEmbeddedResourceExists_ReturnsReadonlySeekableStreamOfEmbeddedResource()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            string fullyQualifiedResourceName = thisNamespace + "." + ResourceName;
            const string Expected = "this is an embedded text file";

            // Act
            // ReSharper disable RedundantArgumentDefaultValue
            Stream actual = System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream(fullyQualifiedResourceName);
            // ReSharper restore RedundantArgumentDefaultValue

            // Assert
            Assert.True(actual.CanRead);
            Assert.True(actual.CanSeek);
            Assert.False(actual.CanWrite);
            Assert.False(actual.CanTimeout);
            using (var reader = new StreamReader(actual))
            {
                Assert.Equal(Expected, reader.ReadToEnd());
            }

            // Cleanup
            actual.Dispose();
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_AssemblyProvidedAndStreamToResourceIsAlreadyOpen_ReturnsReadonlySeekableStreamOfEmbeddedResource()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            string fullyQualifiedResourceName = thisNamespace + "." + ResourceName;
            const string Expected = "this is an embedded text file";

            // Act
            Stream actual;
            using (Stream priorOpenStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(fullyQualifiedResourceName))
            {
                // ReSharper disable once PossibleNullReferenceException
                priorOpenStream.Read(new byte[1], 0, 1);
                actual = System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream(fullyQualifiedResourceName);
                // ReSharper restore PossibleNullReferenceException
            }

            // Assert
            Assert.True(actual.CanRead);
            Assert.True(actual.CanSeek);
            Assert.False(actual.CanWrite);
            Assert.False(actual.CanTimeout);
            using (var reader = new StreamReader(actual))
            {
                Assert.Equal(Expected, reader.ReadToEnd());
            }

            // Cleanup
            actual.Dispose();
        }

        [Fact]
        public static void ReadEmbeddedResourceString_ResourceNameIsNull_ThrowsArgumentNullException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => AssemblyHelper.ReadEmbeddedResourceAsString(null));
        }

        [Fact]
        public static void ReadEmbeddedResourceString_ResourceNameIsWhitespace_ThrowsArgumentException()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => AssemblyHelper.ReadEmbeddedResourceAsString(string.Empty));
            Assert.Throws<ArgumentException>(() => AssemblyHelper.ReadEmbeddedResourceAsString("   "));
            Assert.Throws<ArgumentException>(() => AssemblyHelper.ReadEmbeddedResourceAsString("  \r\n   "));
        }

        [Fact]
        public static void ReadEmbeddedResourceString_ResourceDoesNotExist_ThrowsInvalidOperationException()
        {
            // Arrange
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            const string ResourceName1 = "NotThere";
            string resourceName2 = thisNamespace + "EmbeddedTextFileE.txt";

            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => AssemblyHelper.ReadEmbeddedResourceAsString(ResourceName1));
            Assert.Throws<InvalidOperationException>(() => AssemblyHelper.ReadEmbeddedResourceAsString(resourceName2));
        }

        [Fact(Skip = "Not sure how to test this.")]
        public static void ReadEmbeddedResourceString_ResourceIsNotAnEmbeddedResource_ThrowsInvalidOperationException()
        {
        }

        [Fact(Skip = "Not practical to test, would have to create a massive file.")]
        public static void ReadEmbeddedResourceString_ResourceLengthIsGreaterThanInt64MaxValue_ThrowsInvalidOperationException()
        {
        }

        [Fact]
        public static void ReadEmbeddedResourceString_AddCallerNamespaceIsFalseAndEmbeddedResourceExists_ReturnsEmbeddedResourceAsString()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            string fullyQualifiedResourceName = thisNamespace + "." + ResourceName;
            const string Expected = "this is an embedded text file";

            // Act
            // ReSharper disable RedundantArgumentDefaultValue
            string actual = AssemblyHelper.ReadEmbeddedResourceAsString(fullyQualifiedResourceName, false);
            // ReSharper restore RedundantArgumentDefaultValue

            // Assert
            Assert.Equal(Expected, actual);
        }

        [Fact]
        public static void ReadEmbeddedResourceString_AddCallerNamespaceIsTrueAndEmbeddedResourceExists_ReturnsEmbeddedResourceAsString()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            const string Expected = "this is an embedded text file";

            // Act
            string actual = AssemblyHelper.ReadEmbeddedResourceAsString(ResourceName, true);

            // Assert
            Assert.Equal(Expected, actual);
        }

        [Fact]
        public static void ReadEmbeddedResourceString_StreamToResourceIsAlreadyOpen_ReturnsEmbeddedResourceAsString()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            string fullyQualifiedResourceName = thisNamespace + "." + ResourceName;
            const string Expected = "this is an embedded text file";

            // Act
            string actual;
            using (Stream priorOpenStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(fullyQualifiedResourceName))
            {
                // ReSharper disable AssignNullToNotNullAttribute
                using (var reader = new StreamReader(priorOpenStream))
                {
                    reader.Read();
                    actual = AssemblyHelper.ReadEmbeddedResourceAsString(fullyQualifiedResourceName);
                }
                // ReSharper restore AssignNullToNotNullAttribute
            }

            // Assert
            Assert.Equal(Expected, actual);
        }

        [Fact]
        public static void ReadEmbeddedResourceString_AddCallerNamespaceIsFalseAndEmbeddedResourceIsNotText_ReturnsEmbeddedResourceAsString()
        {
            // Arrange
            const string ResourceName = "EmbeddedIcon.ico";
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            string fullyQualifiedResourceName = thisNamespace + "." + ResourceName;

            // Act
            // ReSharper disable RedundantArgumentDefaultValue
            string actual = AssemblyHelper.ReadEmbeddedResourceAsString(fullyQualifiedResourceName, false);
            // ReSharper restore RedundantArgumentDefaultValue

            // Assert
            Assert.NotEmpty(actual);
        }

        [Fact]
        public static void ReadEmbeddedResourceString_AddCallerNamespaceIsTrueAndEmbeddedResourceIsNotText_ReturnsEmbeddedResourceAsString()
        {
            // Arrange
            const string ResourceName = "EmbeddedIcon.ico";

            // Act
            string actual = AssemblyHelper.ReadEmbeddedResourceAsString(ResourceName, true);

            // Assert
            Assert.NotEmpty(actual);
        }

        // ReSharper restore InconsistentNaming        
    }
}
