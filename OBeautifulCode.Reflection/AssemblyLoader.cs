﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyLoader.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Math source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;

    using OBeautifulCode.Collection.Recipes;

    using Spritely.Recipes;

    using static System.FormattableString;

    /// <summary>
    /// Helper that will load all the assemblies in a directory and wire up all the necessary <see cref="AppDomain" /> logic to allow them to be reflected into.
    /// </summary>
#if !OBeautifulCodeReflectionRecipesProject
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [System.CodeDom.Compiler.GeneratedCode("OBeautifulCode.Reflection", "See package version number")]
#endif
#if !OBeautifulCodeReflectionRecipesProject
    internal
#else
    public
#endif
        sealed class AssemblyLoader : IDisposable
    {
        /// <summary>
        /// Default assembly file extensions to process; ONLY the file extension not including the period e.g. "dll" NOT ".dll".
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly IReadOnlyCollection<string> DefaultAssemblyFileExtensionsWithoutPeriodToLoad = new[] { "exe", "dll" };

        /// <summary>
        /// Default symbol file extensions to process; ONLY the file extension not including the period e.g. "pdb" NOT ".pdb".
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly IReadOnlyCollection<string> DefaultSymbolFileExtensionsWithoutPeriodToLoad = new[] { "pdb" };

        /// <summary>
        /// Default list of regular expressions to evaluate against each file name and skip loading on matches.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly IReadOnlyCollection<string> DefaultAssemblyFileNameRegexBlacklist = new[] { "Microsoft\\.Bcl" };

        private readonly IReadOnlyCollection<Regex> regexBlacklistObjects;

        private readonly Action<string> logger;

        private AssemblyLoader(
            string directoryPath,
            bool loadRecursively,
            IReadOnlyCollection<string> assemblyFileExtensionsWithoutPeriodToLoad,
            IReadOnlyCollection<string> symbolFileExtensionsWithoutPeriodToConsider,
            IReadOnlyCollection<string> assemblyFileNameRegexBlacklist,
            Action<string> logger)
        {
            new { directoryPath }.Must().NotBeNull().And().NotBeWhiteSpace().OrThrowFirstFailure();
            new { assemblyFileExtensionsWithoutPeriodToLoad }.Must().NotBeNull().And().NotBeEmptyEnumerable<string>().OrThrowFirstFailure();
            new { symbolFileExtensionsWithoutPeriodToConsider, assemblyFileNameRegexBlacklist, logger }.Must().NotBeNull().OrThrowFirstFailure();

            Directory.Exists(directoryPath).Named(Invariant($"{nameof(directoryPath)}MustBeDirectoryAndExist-{directoryPath}-DoesNotExist")).Must().BeTrue().OrThrowFirstFailure();

            this.FilePathToAssemblyMap = new Dictionary<string, Assembly>();

            this.DirectoryPath = directoryPath;
            this.LoadRecursively = loadRecursively;
            this.AssemblyFileExtensionsWithoutPeriodToLoad = assemblyFileExtensionsWithoutPeriodToLoad;
            this.SymbolFileExtensionsWithoutPeriodToConsider = symbolFileExtensionsWithoutPeriodToConsider;
            this.AssemblyFileNameRegexBlacklist = assemblyFileNameRegexBlacklist ?? new List<string>();
            this.regexBlacklistObjects = this.AssemblyFileNameRegexBlacklist.Select(_ => new Regex(_, RegexOptions.Compiled | RegexOptions.IgnoreCase)).ToList();
            this.logger = logger;

            // add an unknown assembly resolver to go try to find the dll in one of the files we have discovered...
            AppDomain.CurrentDomain.AssemblyResolve += this.ObcResolveAssembly;
        }

        /// <summary>
        /// Gets a map of the file paths discovered to the <see cref="Assembly" /> loaded.
        /// </summary>
        public IReadOnlyDictionary<string, Assembly> FilePathToAssemblyMap { get; private set; }

        /// <summary>
        /// Gets a list of the discovered symbol file paths.
        /// </summary>
        public IReadOnlyCollection<string> SymbolFilePaths { get; private set; }

        /// <summary>
        /// Gets the directory path to discover assemblies in.
        /// </summary>
        public string DirectoryPath { get; }

        /// <summary>
        /// Gets a value indicating whether or not to discover recursively within the directory.
        /// </summary>
        public bool LoadRecursively { get; }

        /// <summary>
        /// Gets the assembly file extensions to process; ONLY the file extension not including the period e.g. "dll" NOT ".dll".
        /// </summary>
        public IReadOnlyCollection<string> AssemblyFileExtensionsWithoutPeriodToLoad { get; }

        /// <summary>
        /// Gets the symbol file extensions to process; ONLY the file extension not including the period e.g. "pdb" NOT ".pdb".
        /// </summary>
        public IReadOnlyCollection<string> SymbolFileExtensionsWithoutPeriodToConsider { get; }

        /// <summary>
        /// Gets the list of regular expressions to evaluate against each file name and skip loading on matches.
        /// </summary>
        public IReadOnlyCollection<string> AssemblyFileNameRegexBlacklist { get; }

        /// <summary>
        /// Initializes the manager by configuring <see cref="AppDomain" /> hooks and discovering then loading the assemblies in the given path.
        /// </summary>
        /// <param name="suppressFileLoadException">Optionally suppress <see cref="FileLoadException"/></param>
        /// <param name="suppressBadImageFormatException">Optinally suppress <see cref="BadImageFormatException"/></param>
        /// <param name="suppressReflectionTypeLoadException">Optionally suppress <see cref="ReflectionTypeLoadException"/></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "This is a complex method by it's nature.")]
        public void Initialize(
            bool suppressFileLoadException = false,
            bool suppressBadImageFormatException = false,
            bool suppressReflectionTypeLoadException = false)
        {
            // find all assemblies files to search for handlers.
            var searchOption = this.LoadRecursively ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            var filesRaw = this.AssemblyFileExtensionsWithoutPeriodToLoad.SelectMany(_ => Directory.GetFiles(this.DirectoryPath, "*." + _, searchOption)).ToList();

            var assemblyFilePaths = filesRaw.Where(_ => !this.regexBlacklistObjects.Any(r => r.IsMatch(Path.GetFileName(_) ?? string.Empty))).ToList();
            this.SymbolFilePaths = this.SymbolFileExtensionsWithoutPeriodToConsider.SelectMany(_ => Directory.GetFiles(this.DirectoryPath, "*." + _, searchOption)).ToList();

            this.FilePathToAssemblyMap = assemblyFilePaths.ToDictionary(
                k => k,
                v =>
                {
                    var assemblyNameWithoutExtension = Path.GetFileName(v) ?? string.Empty;

                    try
                    {
                        foreach (var extension in this.AssemblyFileExtensionsWithoutPeriodToLoad)
                        {
                            assemblyNameWithoutExtension =
                                assemblyNameWithoutExtension.Replace("." + extension, string.Empty);
                        }

                        // since the assembly might have been already loaded as a depdendency of another assembly...
                        var alreadyLoaded = TryResolveAssemblyFromLoaded(v);

                        // Can't use Assembly.LoadFrom() here because it fails for some reason.
                        var assembly = alreadyLoaded ?? this.LoadAssemblyFromDisk(assemblyNameWithoutExtension, v);
                        return assembly;
                    }
                    catch (ReflectionTypeLoadException reflectionTypeLoadException)
                    {
                        if (suppressReflectionTypeLoadException)
                        {
                            return null;
                        }
                        else
                        {
                            var loaderExceptions = reflectionTypeLoadException.LoaderExceptions?.Select(_ => _?.ToString() ?? "<null>").ToCsv();
                            var typesLoaded = reflectionTypeLoadException.Types?.Select(_ => _?.ToString() ?? "<null>").ToCsv();
                            var message = Invariant($"{nameof(ReflectionTypeLoadException)} was thrown when loading assembly: {assemblyNameWithoutExtension}.{Environment.NewLine}The loader exceptions are: {loaderExceptions ?? "<null>"}.{Environment.NewLine}{Environment.NewLine}The types loaded are: {typesLoaded ?? "<null>"}.{Environment.NewLine}{Environment.NewLine}See inner exception for the original exception.");
                            throw new TypeLoadException(message, reflectionTypeLoadException);
                        }
                    }
                    catch (FileLoadException)
                    {
                        if (suppressFileLoadException)
                        {
                            return null;
                        }
                        else
                        {
                            throw;
                        }
                    }
                    catch (BadImageFormatException)
                    {
                        if (suppressBadImageFormatException)
                        {
                            return null;
                        }
                        else
                        {
                            throw;
                        }
                    }
                });

            this.FilePathToAssemblyMap = this.FilePathToAssemblyMap.Where(_ => _.Value != null).ToDictionary(_ => _.Key, _ => _.Value);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom", Justification = "Other methods don't load dependent assemblies correctly.")]
        private Assembly ObcResolveAssembly(object sender, ResolveEventArgs args)
        {
            var assemblyNameWithoutExtension = args.Name.Split(',')[0];
            var assemblyCandidates = this.AssemblyFileExtensionsWithoutPeriodToLoad.Select(_ => assemblyNameWithoutExtension + "." + _).ToList();
            var fullAssemblyPath = this.FilePathToAssemblyMap.Keys.FirstOrDefault(
                _ => assemblyCandidates.Any(candidate => _.EndsWith(candidate, StringComparison.CurrentCultureIgnoreCase)));

            if (fullAssemblyPath == null)
            {
                var message = Invariant($"Assembly not found Name: {args.Name}, Requesting Assembly FullName: {args.RequestingAssembly?.FullName}");
                throw new TypeInitializationException(message, null);
            }

            // Can't use Assembly.Load() here because it fails when you have different versions of N-level dependencies...I have no idea why Assembly.LoadFrom works.
            this.logger("Loaded Assembly (in AppDomain.CurrentDomain.AssemblyResolve): " + assemblyNameWithoutExtension + " From: " + fullAssemblyPath);

            // since the assembly might have been already loaded as a depdendency of another assembly...
            var alreadyLoaded = TryResolveAssemblyFromLoaded(fullAssemblyPath);

            // seems like only LoadFrom works with dependent assemblies correctly, it is deprecated and will have to be udpated eventually.
            var ret = alreadyLoaded ?? Assembly.LoadFrom(fullAssemblyPath);

            return ret;
        }

        private Assembly LoadAssemblyFromDisk(string assemblyNameWithoutExtension, string fullAssemblyPath)
        {
            var symbolCandidates = this.SymbolFileExtensionsWithoutPeriodToConsider.Select(_ => assemblyNameWithoutExtension + "." + _).ToList();
            var fullSymbolPath = this.SymbolFilePaths.FirstOrDefault(
                _ => symbolCandidates.Any(candidate => _.EndsWith(candidate, StringComparison.CurrentCultureIgnoreCase)));

            // since the assembly might have been already loaded as a depdendency of another assembly...
            var alreadyLoaded = TryResolveAssemblyFromLoaded(fullAssemblyPath);

            Assembly ret;
            if (alreadyLoaded != null)
            {
                ret = alreadyLoaded;
            }
            else if (fullSymbolPath == null)
            {
                var assemblyBytes = File.ReadAllBytes(fullAssemblyPath);
                this.logger("Loaded Assembly (in GetAssembly): " + assemblyNameWithoutExtension + " From: " + fullAssemblyPath + " Without Symbols.");
                ret = Assembly.Load(assemblyBytes);
            }
            else
            {
                var dllBytes = File.ReadAllBytes(fullAssemblyPath);
                var pdbBytes = File.ReadAllBytes(fullSymbolPath);
                this.logger("Loaded Assembly (in GetAssembly): " + assemblyNameWithoutExtension + " From: " + fullAssemblyPath + " With Symbols: " + fullSymbolPath);
                ret = Assembly.Load(dllBytes, pdbBytes);
            }

            return ret;
        }

        private static Assembly TryResolveAssemblyFromLoaded(string fullAssemblyPath)
        {
            var pathAsUri = new Uri(fullAssemblyPath).ToString();
            var assembly = GetLoadedAssemblies().SingleOrDefault(_ => _.CodeBase == pathAsUri || _.Location == pathAsUri);
            return assembly;
        }

        /// <summary>
        /// Gets the currently loaded assemblies (excluding dynamic ones).
        /// </summary>
        /// <remarks>
        /// If you want to get all types, then pass-in the result of this call into AssemblyHelper.GetTypesFromAssemblies()
        /// </remarks>
        /// <returns>Currently loaded assemblies.</returns>
        public static IReadOnlyCollection<Assembly> GetLoadedAssemblies()
        {
            try
            {
                return AppDomain.CurrentDomain.GetAssemblies().Where(a => !a.IsDynamic).ToList();
            }
            catch (ReflectionTypeLoadException reflectionTypeLoadException)
            {
                var loaderExceptions = reflectionTypeLoadException.LoaderExceptions?.Select(_ => _?.ToString() ?? "<null>").ToCsv();
                var typesLoaded = reflectionTypeLoadException.Types?.Select(_ => _?.ToString() ?? "<null>").ToCsv();
                var message = Invariant($"{nameof(ReflectionTypeLoadException)} was thrown when getting loaded assemblies.{Environment.NewLine}The loader exceptions are: {loaderExceptions ?? "<null>"}.{Environment.NewLine}{Environment.NewLine}The types loaded are: {typesLoaded ?? "<null>"}.{Environment.NewLine}{Environment.NewLine}See inner exception for the original exception.");
                throw new TypeLoadException(message, reflectionTypeLoadException);
            }
        }

        /// <summary>
        /// Factory method to build an initialized <see cref="AssemblyLoader" />.
        /// </summary>
        /// <param name="directoryPath">Directory path to discover and load assemblies from.</param>
        /// <param name="logger">Optional logger action to log progress and messages; DEFAULT is none.</param>
        /// <param name="loadRecursively">Optional value indicating whether or not to discover recursively within the directory; DEFAULT is true.</param>
        /// <param name="assemblyFileExtensionsWithoutDotToLoad">Optional list of assembly file extensions to process; ONLY the file extension not including the period e.g. "dll" NOT ".dll"; DEFAULT is <see cref="DefaultAssemblyFileExtensionsWithoutPeriodToLoad" />.</param>
        /// <param name="symbolFileExtensionsWithoutPeriodToConsider">Optional list of symbol file extensions to process; ONLY the file extension not including the period e.g. "pdb" NOT ".pdb"; DEFAULT is <see cref="DefaultSymbolFileExtensionsWithoutPeriodToLoad" />.</param>
        /// <param name="assemblyFileNameRegexBlacklist">Optional list of regular expressions to evaluate against each file name and skip loading on matches; DEFAULT is <see cref="DefaultAssemblyFileNameRegexBlacklist" />.</param>
        /// <param name="suppressFileLoadException">Optionally suppress <see cref="FileLoadException"/></param>
        /// <param name="suppressBadImageFormatException">Optionally suppress <see cref="BadImageFormatException"/></param>
        /// <param name="suppressReflectionTypeLoadException">Optionally suppress <see cref="ReflectionTypeLoadException"/></param>
        /// <returns>Initialized <see cref="AssemblyLoader" /> this needs to be in scope and is dispoable so keep this alive at your most top level while reflecting.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Factory method function and not intended to deal with disposing.")]
        public static AssemblyLoader CreateAndLoadFromDirectory(
            string directoryPath,
            Action<string> logger = null,
            bool loadRecursively = true,
            IReadOnlyCollection<string> assemblyFileExtensionsWithoutDotToLoad = null,
            IReadOnlyCollection<string> symbolFileExtensionsWithoutPeriodToConsider = null,
            IReadOnlyCollection<string> assemblyFileNameRegexBlacklist = null,
            bool suppressFileLoadException = false,
            bool suppressBadImageFormatException = false,
            bool suppressReflectionTypeLoadException = false)
        {
            void NullLogger(string message)
            {
                /* no-op */
            }

            var ret = new AssemblyLoader(
                directoryPath,
                loadRecursively,
                assemblyFileExtensionsWithoutDotToLoad ?? DefaultAssemblyFileExtensionsWithoutPeriodToLoad,
                symbolFileExtensionsWithoutPeriodToConsider ?? DefaultSymbolFileExtensionsWithoutPeriodToLoad,
                assemblyFileNameRegexBlacklist ?? DefaultAssemblyFileNameRegexBlacklist,
                logger ?? NullLogger);
            ret.Initialize(suppressFileLoadException, suppressBadImageFormatException, suppressReflectionTypeLoadException);
            return ret;
        }

        /// <inheritdoc cref="IDisposable" />
        public void Dispose()
        {
            // clean up by removing
            try
            {
                AppDomain.CurrentDomain.AssemblyResolve -= this.ObcResolveAssembly;
            }
            catch (Exception)
            {
                /* no-op */
            }
        }
    }
}