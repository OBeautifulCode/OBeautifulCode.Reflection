﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.Enum.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Math source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using OBeautifulCode.Enum.Recipes;

    using Spritely.Recipes;

    /// <summary>
    /// Provides useful methods related to reflection.
    /// </summary>
#if !OBeautifulCodeReflectionRecipesProject
    internal
#else
    public
#endif
    static partial class ReflectionHelper
    {
        /// <summary>
        /// Gets all values/members of an enum that have an attribute of a specified type.
        /// </summary>
        /// <typeparam name="TEnum">The type of the enum.</typeparam>
        /// <typeparam name="TAttribute">The type of attribute to search for.</typeparam>
        /// <param name="attributeFilter">
        /// Optional.  When provided, requires that this filter
        /// return true when attributes of the specified type are passed-in,
        /// before the enum value having the specified attribute is returned.
        /// </param>
        /// <returns>
        /// The values/members of a specified enum values where the specified
        /// attribute has been applied at least one, or an empty collection if none of the specified
        /// enum values have that attribute.
        /// </returns>
        /// <exception cref="ArgumentException"><typeparamref name="TEnum"/> is not an enum.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The type parameter is not needed.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static IReadOnlyCollection<TEnum> GetEnumValuesHaving<TEnum, TAttribute>(
            Func<TAttribute, bool> attributeFilter = null)
            where TEnum : struct
            where TAttribute : Attribute
        {
            typeof(TEnum).IsEnum.Named($"typeof {nameof(TEnum)} is Enum").Must().BeTrue().OrThrow();

            var result =
                EnumExtensions.GetEnumValues<TEnum>()
                .Cast<Enum>()
                .Where(
                        _ =>
                            attributeFilter == null
                                ? _.GetAttributesOnEnumValue<TAttribute>().Any()
                                : _.GetAttributesOnEnumValue<TAttribute>().Where(attributeFilter).Any())
                .Cast<TEnum>()
                .ToList()
                .AsReadOnly();

            return result;
        }

        /// <summary>
        /// Gets all values/members of an enum that have an attribute of a specified type.
        /// </summary>
        /// <typeparam name="TAttribute">The type of attribute to search for.</typeparam>
        /// <param name="enumType">The type of the enum.</param>
        /// <param name="attributeFilter">
        /// Optional.  When provided, requires that this filter
        /// return true when attributes of the specified type are passed-in,
        /// before the enum value having the specified attribute is returned.
        /// </param>
        /// <returns>
        /// The values/members of a specified enum values where the specified
        /// attribute has been applied at least one, or an empty collection if none of the specified
        /// enum values have that attribute.
        /// </returns>
        /// <exception cref="ArgumentException"><paramref name="enumType"/> is not an enum.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "The type parameter is not needed.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static IReadOnlyCollection<Enum> GetEnumValuesHaving<TAttribute>(
            this Type enumType,
            Func<TAttribute, bool> attributeFilter = null)
            where TAttribute : Attribute
        {
            new { enumType }.Must().NotBeNull().OrThrow();
            enumType.IsEnum.Named($"{nameof(enumType)} is Enum").Must().BeTrue().OrThrow();

            var result =
                EnumExtensions.GetEnumValues(enumType)
                    .Where(
                        _ =>
                            attributeFilter == null
                                ? _.GetAttributesOnEnumValue<TAttribute>().Any()
                                : _.GetAttributesOnEnumValue<TAttribute>().Where(attributeFilter).Any())
                    .ToList()
                    .AsReadOnly();

            return result;
        }
    }
}
