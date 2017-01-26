// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeDescription.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection
{
    using System;

    using OBeautifulCode.Math;

    /// <summary>
    /// Model object containing a description of a type that can be serialized without knowledge of the type.
    /// </summary>
    public class TypeDescription : IEquatable<TypeDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDescription"/> class.
        /// </summary>
        public TypeDescription()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDescription"/> class.
        /// </summary>
        /// <param name="namespace">Namespace of type.</param>
        /// <param name="name">Name of type.</param>
        /// <param name="assemblyQualifiedName">Assembly qualified name of type.</param>
        public TypeDescription(string @namespace, string name, string assemblyQualifiedName)
        {
            this.Namespace = @namespace;
            this.Name = name;
            this.AssemblyQualifiedName = assemblyQualifiedName;
        }

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
        /// Compares equality of two <see cref="TypeDescription"/>'s.
        /// </summary>
        /// <param name="first">First to check.</param>
        /// <param name="second">Second to check.</param>
        /// <returns>A value indicating they are equal.</returns>
        public static bool operator ==(TypeDescription first, TypeDescription second)
        {
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }

            return (first.AssemblyQualifiedName == second.AssemblyQualifiedName) && (first.Namespace == second.Namespace) && (first.Name == second.Name);
        }

        /// <summary>
        /// Compares inequality of two <see cref="TypeDescription"/>'s.
        /// </summary>
        /// <param name="first">First to check.</param>
        /// <param name="second">Second to check.</param>
        /// <returns>A value indicating they are not equal.</returns>
        public static bool operator !=(TypeDescription first, TypeDescription second) => !(first == second);

        /// <inheritdoc />
        public bool Equals(TypeDescription other) => this == other;

        /// <inheritdoc />
        public override bool Equals(object obj) => this == (obj as TypeDescription);

        /// <inheritdoc />
        public override int GetHashCode() => HashCodeHelper.Initialize().Hash(this.AssemblyQualifiedName).Hash(this.Namespace).Hash(this.Name).Value;
    }
}