// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDescriptionExtensions.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class to hold extension method on the type object.
    /// </summary>
    public static class TypeDescriptionExtensions
    {
        /// <summary>
        /// Creates a new type description from a given type.
        /// </summary>
        /// <param name="type">Input type to use.</param>
        /// <returns>Type description describing input type.</returns>
        public static TypeDescription ToTypeDescription(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var result = new TypeDescription(type.Namespace, type.Name, type.AssemblyQualifiedName);

            return result;
        }

        /// <summary>
        /// Attempts to resolve the <see cref="TypeDescription"/> from all loaded types in all assemblies in the current app domain.
        /// </summary>
        /// <param name="typeDescription">Type description to search for.</param>
        /// <param name="typeMatchStrategy">Optional matching strategy (default is looser namespace and name match).</param>
        /// <returns>Type if found, null otherwise.</returns>
        public static Type ResolveFromLoadedTypes(this TypeDescription typeDescription, TypeMatchStrategy typeMatchStrategy = TypeMatchStrategy.NamespaceAndName)
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(_ => _.GetTypes()).ToList();
            var typeComparer = new TypeComparer(typeMatchStrategy);
            var ret = allTypes.SingleOrDefault(_ => typeComparer.Equals(_.ToTypeDescription(), typeDescription));
            return ret;
        }
    }
}
