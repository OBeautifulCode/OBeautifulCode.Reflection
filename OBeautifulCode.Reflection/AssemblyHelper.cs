// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyHelper.cs" company="OBeautifulCode">
//   Copyright 2014 OBeautifulCode
// </copyright>
// <summary>
//   Provides useful methods for extracting information from and interacting with assemblies using reflection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using Conditions;

    /// <summary>
    /// Provides useful methods for extracting information from and 
    /// interacting with assemblies using reflection.
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Retrieves an embedded resource's stream.
        /// </summary>
        /// <param name="assembly">Calling assembly.</param>
        /// <param name="resourceName">Name of the resource in the calling assembly.</param>
        /// <returns>Returns the specified manifest resource as a stream.</returns>
        /// <exception cref="ArgumentNullException">assembly is null.</exception>
        /// <exception cref="ArgumentNullException">resourceName is null.</exception>
        /// <exception cref="ArgumentException">resourceName is whitspace.</exception>        
        /// <exception cref="InvalidOperationException">Resource was not found in the calling assembly.</exception>
        /// <exception cref="InvalidOperationException">The resource was not an embedded resource (that is, non-linked).</exception>
        /// <exception cref="NotImplementedException">Resource length is greater than Int64.MaxValue.</exception>
        public static Stream OpenEmbeddedResourceStream(this Assembly assembly, string resourceName)
        {
            // here's a good article about .net resources 
            // http://www.grimes.demon.co.uk/workshops/fusWSNine.htm
            Condition.Requires(assembly, "assembly").IsNotNull();
            Condition.Requires(resourceName, "resourceName").IsNotNullOrWhiteSpace();

            ManifestResourceInfo info = assembly.GetManifestResourceInfo(resourceName);
            if (info == null)
            {
                throw new InvalidOperationException("Resource was not found in the calling assembly: " + resourceName);
            }

            if (!info.ResourceLocation.HasFlag(ResourceLocation.Embedded))
            {
                throw new InvalidOperationException("The resource was not an embedded resource (that is, non-linked).");
            }

            // now that we're guaranteeing an embedded resource, we *should* be able to avoid these
            // execeptions from GetManifestResourceStream: FileLoadException, FileNotFoundException, BadImageFormatException
            return assembly.GetManifestResourceStream(resourceName);
        }

        /// <summary>
        /// Retrieves a stream for an embedded resource.
        /// </summary>
        /// <param name="resourceName">Name of the resource in the calling assembly.</param>
        /// <param name="addCallerNamespace">
        /// Determines whether to add the namespace of the calling method to the resource name.
        /// If false, then the resource name is used as-is.
        /// If true, then the resource name is prepended with the fully qualified namespace of the calling method, followed by a period
        /// (e.g. if resource name = "MyFile.txt" then it changed to something like "MyNamespace.MySubNamespace.MyFile.txt")
        /// </param>
        /// <returns>Returns the specified manifest resource as a stream.</returns>
        /// <exception cref="ArgumentNullException">resourceName is null.</exception>
        /// <exception cref="ArgumentException">resourceName is whitspace.</exception>
        /// <exception cref="InvalidOperationException">Resource was not found in the calling assembly.</exception>
        /// <exception cref="InvalidOperationException">The resource was not an embedded resource (that is, non-linked).</exception>
        /// <exception cref="NotImplementedException">Resource length is greater than Int64.MaxValue.</exception>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Stream OpenEmbeddedResourceStream(string resourceName, bool addCallerNamespace = false)
        {
            resourceName = ResolveResourceName(resourceName, addCallerNamespace);
            return OpenEmbeddedResourceStream(Assembly.GetCallingAssembly(), resourceName);
        }

        /// <summary>
        /// Reads an embedded resource from the calling assembly and returns as string.
        /// </summary>
        /// <param name="resourceName">Name of the resource in the calling assembly.</param>
        /// <param name="addCallerNamespace">
        /// Determines whether to add the namespace of the calling method to the resource name.
        /// If false, then the resource name is used as-is.
        /// If true, then the resource name is prepended with the fully qualified namespace of the calling method, followed by a period
        /// (e.g. if resource name = "MyFile.txt" then it changed to something like "MyNamespace.MySubNamespace.MyFile.txt")
        /// </param>
        /// <remarks>
        /// Adapted from article "Create String Variables from Embedded Resources Files" on The Code Project
        /// <a href="http://www.codeproject.com/KB/cs/embeddedresourcestrings.aspx"/>
        /// Resource information is returned only if the resource is visible to the caller, or the caller has ReflectionPermission.
        /// This method returns null if a private resource in another assembly is accessed and the caller does not have ReflectionPermission with the ReflectionPermissionFlag.MemberAccess flag.
        /// </remarks>
        /// <returns>Returns the specified manifest resource as a string.</returns>
        /// <exception cref="ArgumentNullException">resourceName is null.</exception>
        /// <exception cref="ArgumentException">resourceName is whitspace.</exception>
        /// <exception cref="InvalidOperationException">Resource was not found in the calling assembly.</exception>
        /// <exception cref="InvalidOperationException">The resource was not an embedded resource (that is, non-linked).</exception>
        /// <exception cref="NotImplementedException">Resource length is greater than Int64.MaxValue.</exception>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReadEmbeddedResourceAsString(string resourceName, bool addCallerNamespace = false)
        {
            resourceName = ResolveResourceName(resourceName, addCallerNamespace);
            using (Stream stream = OpenEmbeddedResourceStream(Assembly.GetCallingAssembly(), resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Resolves a resource name.
        /// </summary>
        /// <param name="resourceName">The supplied resource name.</param>
        /// <param name="addCallerNamespace">
        /// Determines whether to add the namespace of the calling method to the resource name.
        /// If false, then the resource name is used as-is.
        /// If true, then the resource name is prepended with the fully qualified namespace of the calling method, followed by a period
        /// (e.g. if resource name = "MyFile.txt" then it changed to something like "MyNamespace.MySubNamespace.MyFile.txt")
        /// </param>
        /// <returns>
        /// The resolved resource name.
        /// </returns>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string ResolveResourceName(string resourceName, bool addCallerNamespace)
        {
            if (addCallerNamespace)
            {
                var frame = new StackFrame(2);
                var method = frame.GetMethod();
                var type = method.DeclaringType;
                if (type != null)
                {
                    resourceName = type.Namespace + "." + resourceName;
                }
            }

            return resourceName;
        }
    }
}
