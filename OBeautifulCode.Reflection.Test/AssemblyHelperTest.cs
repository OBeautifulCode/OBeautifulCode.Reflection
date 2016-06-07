// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyHelperTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using System;
    using System.IO;

    using Xunit;

    /// <summary>
    /// Tests the <see cref="AssemblyHelper"/> class.
    /// </summary>
    public static class AssemblyHelperTest
    {
        // ReSharper disable InconsistentNaming
        [Fact]
        public static void OpenEmbeddedResourceStream_without_assembly___Should_throw_ArgumentNullException___When_parameter_resourceName_is_null()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => AssemblyHelper.OpenEmbeddedResourceStream(null, false));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_without_assembly___Should_throw_ArgumentException___When_parameter_resourceName_is_white_space()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => AssemblyHelper.OpenEmbeddedResourceStream(string.Empty, false));
            Assert.Throws<ArgumentException>(() => AssemblyHelper.OpenEmbeddedResourceStream("   ", false));
            Assert.Throws<ArgumentException>(() => AssemblyHelper.OpenEmbeddedResourceStream("  \r\n   ", false));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_without_assembly___Should_throw_InvalidOperationException___When_resource_does_not_exist()
        {
            // Arrange
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            const string ResourceName1 = "NotThere";
            string resourceName2 = thisNamespace + "EmbeddedTextFileE.txt";

            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => AssemblyHelper.OpenEmbeddedResourceStream(ResourceName1, false));
            Assert.Throws<InvalidOperationException>(() => AssemblyHelper.OpenEmbeddedResourceStream(resourceName2, false));
        }

        [Fact(Skip = "Not sure how to test this.")]
        public static void OpenEmbeddedResourceStream_without_assembly___Should_throw_InvalidOperationException___When_resource_is_not_an_embedded_resource()
        {
        }

        [Fact(Skip = "Not practical to test, would have to create a massive file.")]
        public static void OpenEmbeddedResourceStream_without_assembly___Should_throw_InvalidOperationException___When_resource_length_is_greater_than_Int64_MaxValue()
        {
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_without_assembly___Should_return_read_only_seekable_stream_of_the_embedded_resource___When_parameter_addCallerNamespace_is_false_and_embedded_resource_exists()
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
        public static void OpenEmbeddedResourceStream_without_assembly___Should_return_read_only_seekable_stream_of_the_embedded_resource___When_parameter_addCallerNamespace_is_true_and_embedded_resource_exists()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            const string Expected = "this is an embedded text file";

            // Act
            Stream actual = AssemblyHelper.OpenEmbeddedResourceStream(ResourceName);

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
        public static void OpenEmbeddedResourceStream_without_assembly___Should_return_read_only_seekable_stream_of_the_embedded_resource___When_resource_stream_is_already_open()
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
                actual = AssemblyHelper.OpenEmbeddedResourceStream(fullyQualifiedResourceName, false);
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
        public static void OpenEmbeddedResourceStream_with_assembly___Should_throw_ArgumentNullException___When_parameter_assembly_is_null()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";

            // Act, Assert
            Assert.Throws<ArgumentNullException>(() => AssemblyHelper.OpenEmbeddedResourceStream(null, ResourceName));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_with_assembly___Should_throw_ArgumentNullException___When_parameter_resourceName_is_null()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream(null));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_with_assembly___Should_throw_ArgumentException___When_parameter_resourceName_is_white_space()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream(string.Empty));
            Assert.Throws<ArgumentException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream("   "));
            Assert.Throws<ArgumentException>(() => System.Reflection.Assembly.GetExecutingAssembly().OpenEmbeddedResourceStream("  \r\n   "));
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_with_assembly___Should_throw_InvalidOperationException___When_resource_does_not_exist()
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
        public static void OpenEmbeddedResourceStream_with_assembly___Should_throw_InvalidOperationException___When_resource_is_not_an_embedded_resource()
        {
        }

        [Fact(Skip = "Not practical to test, would have to create a massive file.")]
        public static void OpenEmbeddedResourceStream_with_assembly___Should_throw_InvalidOperationException___When_resource_length_is_greater_than_Int64_MaxValue()
        {
        }

        [Fact]
        public static void OpenEmbeddedResourceStream_with_assembly___Should_return_read_only_seekable_stream_of_the_embedded_resource___When_embedded_resource_exists()
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
        public static void OpenEmbeddedResourceStream_with_assembly___Should_return_read_only_seekable_stream_of_the_embedded_resource___When_resource_stream_is_already_open()
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
        public static void ReadEmbeddedResourceString___Should_throw_ArgumentNullException___When_parameter_resourceName_is_null()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentNullException>(() => AssemblyHelper.ReadEmbeddedResourceAsString(null, false));
        }

        [Fact]
        public static void ReadEmbeddedResourceString___Should_throw_ArgumentException___When_parameter_resourceName_is_white_space()
        {
            // Arrange, Act, Assert
            Assert.Throws<ArgumentException>(() => AssemblyHelper.ReadEmbeddedResourceAsString(string.Empty, false));
            Assert.Throws<ArgumentException>(() => AssemblyHelper.ReadEmbeddedResourceAsString("   ", false));
            Assert.Throws<ArgumentException>(() => AssemblyHelper.ReadEmbeddedResourceAsString("  \r\n   ", false));
        }

        [Fact]
        public static void ReadEmbeddedResourceString___Should_throw_InvalidOperationException___When_resource_does_not_exist()
        {
            // Arrange
            string thisNamespace = typeof(AssemblyHelperTest).Namespace;
            const string ResourceName1 = "NotThere";
            string resourceName2 = thisNamespace + "EmbeddedTextFileE.txt";

            // Act, Assert
            Assert.Throws<InvalidOperationException>(() => AssemblyHelper.ReadEmbeddedResourceAsString(ResourceName1, false));
            Assert.Throws<InvalidOperationException>(() => AssemblyHelper.ReadEmbeddedResourceAsString(resourceName2, false));
        }

        [Fact(Skip = "Not sure how to test this.")]
        public static void ReadEmbeddedResourceString___Should_throw_InvalidOperationException___When_resource_is_not_an_embedded_resource()
        {
        }

        [Fact(Skip = "Not practical to test, would have to create a massive file.")]
        public static void ReadEmbeddedResourceString___Should_throw_InvalidOperationException___When_resource_length_is_greater_than_Int64_MaxValue()
        {
        }

        [Fact]
        public static void ReadEmbeddedResourceString___Should_return_embedded_resource_as_string___When_parameter_addCallerNamespace_is_false_and_embedded_resource_exists()
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
        public static void ReadEmbeddedResourceString___Should_return_embedded_resource_as_string___When_parameter_addCallerNamespace_is_true_and_embedded_resource_exists()
        {
            // Arrange
            const string ResourceName = "EmbeddedTextFile.txt";
            const string Expected = "this is an embedded text file";

            // Act
            string actual = AssemblyHelper.ReadEmbeddedResourceAsString(ResourceName);

            // Assert
            Assert.Equal(Expected, actual);
        }

        [Fact]
        public static void ReadEmbeddedResourceString___Should_return_embedded_resource_as_string___When_resource_stream_is_already_open()
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
                    actual = AssemblyHelper.ReadEmbeddedResourceAsString(fullyQualifiedResourceName, false);
                }

                // ReSharper restore AssignNullToNotNullAttribute
            }

            // Assert
            Assert.Equal(Expected, actual);
        }

        [Fact]
        public static void ReadEmbeddedResourceString___Should_return_embedded_resource_as_string___When_parameter_addCallerNamespace_is_false_and_embedded_resource_is_not_text()
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
        public static void ReadEmbeddedResourceString___Should_return_embedded_resource_as_string___When_parameter_addCallerNamespace_is_true_and_embedded_resource_is_not_text()
        {
            // Arrange
            const string ResourceName = "EmbeddedIcon.ico";

            // Act
            string actual = AssemblyHelper.ReadEmbeddedResourceAsString(ResourceName);

            // Assert
            Assert.NotEmpty(actual);
        }

        // ReSharper restore InconsistentNaming
    }
}
