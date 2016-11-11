// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDescriptionExtensions.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection
{
    using System;

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

            var result = new TypeDescription { AssemblyQualifiedName = type.AssemblyQualifiedName, Namespace = type.Namespace, Name = type.Name };
            return result;
        }
    }
}
