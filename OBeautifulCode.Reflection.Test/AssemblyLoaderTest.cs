// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyLoaderTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    using System;
    using System.IO;

    using FluentAssertions;

    using OBeautifulCode.Reflection.Recipes;

    using Xunit;

    using static System.FormattableString;

    public static class AssemblyLoaderTest
    {
        [Fact]
        public static void LoadFromDirectory___Null_directory___Throws()
        {
            // Arrange
            Action action = () => AssemblyLoader.CreateAndLoadFromDirectory(null);

            // Act
            var exception = Record.Exception(action);

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ArgumentNullException>();
            exception.Message.Should().Be("parameter 'directoryPath' is null");
        }

        [Fact]
        public static void LoadFromDirectory___Empty_string_directory___Throws()
        {
            // Arrange
            Action action = () => AssemblyLoader.CreateAndLoadFromDirectory(string.Empty);

            // Act
            var exception = Record.Exception(action);

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Be("parameter 'directoryPath' is white space");
        }

        [Fact]
        public static void LoadFromDirectory___WhiteSpace_directory___Throws()
        {
            // Arrange
            Action action = () => AssemblyLoader.CreateAndLoadFromDirectory('\t'.ToString());

            // Act
            var exception = Record.Exception(action);

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Be("parameter 'directoryPath' is white space");
        }

        [Fact]
        public static void LoadFromDirectory___Missing_directory___Throws()
        {
            // Arrange
            var fakePath = Invariant($"C:\\{Guid.NewGuid()}\\");
            var expectedExceptionMessage = Invariant($"parameter 'directoryPathMustBeDirectoryAndExist-{fakePath}-DoesNotExist' is not true");
            Action action = () => AssemblyLoader.CreateAndLoadFromDirectory(fakePath);

            // Act
            var exception = Record.Exception(action);

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<ArgumentException>();
            exception.Message.Should().Be(expectedExceptionMessage);
        }

        [Fact]
        public static void LoadFromDirectory___Valid_path_with_no_files___Works_with_currently_loaded_assemblies()
        {
            // Arrange
            var fakePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(fakePath);

            // Act
            AssemblyLoader assemblyLoader;
            try
            {
                assemblyLoader = AssemblyLoader.CreateAndLoadFromDirectory(fakePath);
            }
            finally
            {
                if (Directory.Exists(fakePath))
                {
                    Directory.Delete(fakePath);
                }
            }

            // Assert
            try
            {
                assemblyLoader.AssemblyFileExtensionsWithoutPeriodToLoad.Should().Equal(AssemblyLoader.DefaultAssemblyFileExtensionsWithoutPeriodToLoad);
                assemblyLoader.SymbolFileExtensionsWithoutPeriodToConsider.Should().Equal(AssemblyLoader.DefaultSymbolFileExtensionsWithoutPeriodToLoad);
                assemblyLoader.AssemblyFileNameRegexBlacklist.Should().Equal(AssemblyLoader.DefaultAssemblyFileNameRegexBlacklist);
                assemblyLoader.DirectoryPath.Should().Be(fakePath);
                assemblyLoader.FilePathToAssemblyMap.Should().NotBeNull();
                assemblyLoader.FilePathToAssemblyMap.Count.Should().Be(0);
                assemblyLoader.LoadRecursively.Should().BeTrue();
                assemblyLoader.SymbolFilePaths.Should().NotBeNull();
                assemblyLoader.SymbolFilePaths.Count.Should().Be(0);
            }
            finally
            {
                assemblyLoader?.Dispose();
            }
        }

        [Fact(Skip = "Debug test to test actual load logic.")]
        public static void LoadFromDirectory___Packages_path___Works()
        {
            // Arrange
            var packagesPath = Path.Combine(
                Path.GetDirectoryName(typeof(AssemblyLoader).Assembly.GetCodeBaseAsPathInsteadOfUri() ?? string.Empty) ?? string.Empty,
                @"..\..\..\packages");

            // Act & Assert
            using (var assemblyLoader = AssemblyLoader.CreateAndLoadFromDirectory(packagesPath))
            {
                assemblyLoader.AssemblyFileExtensionsWithoutPeriodToLoad.Should().Equal(AssemblyLoader.DefaultAssemblyFileExtensionsWithoutPeriodToLoad);
                assemblyLoader.SymbolFileExtensionsWithoutPeriodToConsider.Should().Equal(AssemblyLoader.DefaultSymbolFileExtensionsWithoutPeriodToLoad);
                assemblyLoader.AssemblyFileNameRegexBlacklist.Should().Equal(AssemblyLoader.DefaultAssemblyFileNameRegexBlacklist);
                assemblyLoader.DirectoryPath.Should().Be(packagesPath);
                assemblyLoader.FilePathToAssemblyMap.Should().NotBeNull();
                assemblyLoader.FilePathToAssemblyMap.Count.Should().NotBe(0);
                assemblyLoader.LoadRecursively.Should().BeTrue();
                assemblyLoader.SymbolFilePaths.Should().NotBeNull();
                assemblyLoader.SymbolFilePaths.Count.Should().NotBe(0);
            }
        }
    }
}
