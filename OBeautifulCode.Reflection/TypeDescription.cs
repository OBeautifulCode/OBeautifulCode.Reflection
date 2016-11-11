// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDescription.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection
{
    using System;

    /// <summary>
    /// Model object containing a description of a type that can be serialized without knowledge of the type.
    /// </summary>
    public class TypeDescription : IEquatable<TypeDescription>
    {
        /// <summary>
        /// Gets or sets the namespace of the type.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the qualified name of the assembly of the type.
        /// </summary>
        public string AssemblyQualifiedName { get; set; }

        /// <summary>
        /// Determines whether two objects of type <see cref="TypeDescription"/> are equal.
        /// </summary>
        /// <param name="description1">The first type description to compare.</param>
        /// <param name="description2">The second type description to compare.</param>
        /// <returns>
        /// true if the two type descriptions are equal; false otherwise.
        /// </returns>
        public static bool operator ==(TypeDescription description1, TypeDescription description2)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(description1, description2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (ReferenceEquals(description1, null) || ReferenceEquals(description2, null))
            {
                return false;
            }

            var result = (description1.AssemblyQualifiedName == description2.AssemblyQualifiedName) &&
                         (description1.Namespace == description2.Namespace) &&
                         (description1.Name == description2.Name);

            return result;
        }

        /// <summary>
        /// Determines whether two objects of type <see cref="TypeDescription"/> are not equal.
        /// </summary>
        /// <param name="description1">The first type description to compare.</param>
        /// <param name="description2">The second type description to compare.</param>
        /// <returns>
        /// true if the two type descriptions are not equal; false otherwise.
        /// </returns>
        public static bool operator !=(TypeDescription description1, TypeDescription description2) => !(description1 == description2);

        /// <inheritdoc />
        public bool Equals(TypeDescription other) => this == other;

        /// <inheritdoc />
        public override bool Equals(object obj) => this == obj as TypeDescription;

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 37) + (this.AssemblyQualifiedName?.GetHashCode() ?? 0);
                hash = (hash * 37) + (this.Namespace?.GetHashCode() ?? 0);
                hash = (hash * 37) + (this.Name?.GetHashCode() ?? 0);
                return hash;
            }
        }
    }
}