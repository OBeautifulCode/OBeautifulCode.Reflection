﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.Field.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Reflection.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Diagnostics.CodeAnalysis;
    using global::System.Linq;
    using global::System.Reflection;

    using OBeautifulCode.CodeAnalysis.Recipes;
    using OBeautifulCode.Type.Recipes;

    using static global::System.FormattableString;

#if !OBeautifulCodeReflectionSolution
    internal
#else
    public
#endif
    static partial class ReflectionHelper
    {
        /// <summary>
        /// Determines if a type has a field of the specified field name.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <param name="fieldName">The name of the field to check for.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <returns>
        /// true if the type has a field of the specified field name, false if not.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static bool HasField(
            this Type type,
            string fieldName,
            BindingFlags bindingFlags)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (fieldName == null)
            {
                throw new ArgumentNullException(nameof(fieldName));
            }

            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentException(Invariant($"{nameof(fieldName)} is white space."));
            }

            bool result;

            try
            {
                result = type.GetField(fieldName, bindingFlags) != null;
            }
            catch (AmbiguousMatchException)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Gets the name of all of the fields.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <returns>
        /// The field names.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static IReadOnlyCollection<string> GetFieldNames(
            this Type type,
            BindingFlags bindingFlags)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var allFields = type.GetFields(bindingFlags);

            var result = allFields.Select(_ => _.Name).ToList();

            return result;
        }

        /// <summary>
        /// Gets the <see cref="FieldInfo"/> for the specified field.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <returns>
        /// The <see cref="FieldInfo"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no field named <paramref name="fieldName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one field named <paramref name="fieldName"/> on the object type using the specified binding constraints.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static FieldInfo GetFieldInfo(
            this Type type,
            string fieldName,
            BindingFlags bindingFlags)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (fieldName == null)
            {
                throw new ArgumentNullException(nameof(fieldName));
            }

            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentException(Invariant($"{nameof(fieldName)} is white space."));
            }

            FieldInfo result;

            try
            {
                result = type.GetField(fieldName, bindingFlags);

                if (result == null)
                {
                    throw new ArgumentException(Invariant($"There is no field named '{fieldName}' on type '{type.ToStringReadable()}', using the specified binding constraints."));
                }
            }
            catch (AmbiguousMatchException)
            {
                throw new ArgumentException(Invariant($"There is more than one field named '{fieldName}' on type '{type.ToStringReadable()}', using the specified binding constraints."));
            }

            return result;
        }

        /// <summary>
        /// Gets the value of a field.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="item">The object.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <returns>
        /// The value of the field.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no field named <paramref name="fieldName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one field named <paramref name="fieldName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">The field does not have a get method.</exception>
        /// <exception cref="InvalidCastException">The field is not of the specified type.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static T GetFieldValue<T>(
            this object item,
            string fieldName,
            BindingFlags bindingFlags)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var fieldInfo = item.GetType().GetFieldInfo(fieldName, bindingFlags);

            var fieldValue = fieldInfo.GetValue(item);

            var result = fieldValue.CastOrThrowIfTypeMismatch<T>(fieldInfo);

            return result;
        }

        /// <summary>
        /// Gets the value of a field.
        /// </summary>
        /// <param name="item">The object.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <returns>
        /// The value of the field.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no field named <paramref name="fieldName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one field named <paramref name="fieldName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">The field does not have a get method.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static object GetFieldValue(
            this object item,
            string fieldName,
            BindingFlags bindingFlags)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var fieldInfo = item.GetType().GetFieldInfo(fieldName, bindingFlags);

            var result = fieldInfo.GetValue(item);

            return result;
        }

        /// <summary>
        /// Gets the value of a static field.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="type">The type that contains the field.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <returns>
        /// The value of the field.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no field named <paramref name="fieldName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one field named <paramref name="fieldName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">The field does not have a get method.</exception>
        /// <exception cref="ArgumentException">The field is not static.</exception>
        /// <exception cref="InvalidCastException">The field is not of the specified type.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static T GetStaticFieldValue<T>(
            this Type type,
            string fieldName,
            BindingFlags bindingFlags)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var fieldInfo = type.GetFieldInfo(fieldName, bindingFlags);

            object fieldValue;

            try
            {
                fieldValue = fieldInfo.GetValue(null);
            }
            catch (TargetException)
            {
                throw new ArgumentException("The field is not static.");
            }

            var result = fieldValue.CastOrThrowIfTypeMismatch<T>(fieldInfo);

            return result;
        }

        /// <summary>
        /// Gets the value of a field on a static type.
        /// </summary>
        /// <param name="type">The type that contains the field.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <returns>
        /// The value of the field.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no field named <paramref name="fieldName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one field named <paramref name="fieldName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">The field does not have a get method.</exception>
        /// <exception cref="ArgumentException">The field is not static.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static object GetStaticFieldValue(
            this Type type,
            string fieldName,
            BindingFlags bindingFlags)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var fieldInfo = type.GetFieldInfo(fieldName, bindingFlags);

            object result;

            try
            {
                result = fieldInfo.GetValue(null);
            }
            catch (TargetException)
            {
                throw new ArgumentException("The field is not static.");
            }

            return result;
        }

        /// <summary>
        /// Sets a field's value.
        /// </summary>
        /// <param name="item">The object.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="value">The value to set the field to.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no field named <paramref name="fieldName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one field named <paramref name="fieldName"/> on the object type using the specified binding constraints.</exception>
        /// <exception cref="InvalidCastException">Unable to assign null to the field's type.</exception>
        /// <exception cref="InvalidCastException">Unable to assign <paramref name="value"/> type to the field's type.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static void SetFieldValue(
            this object item,
            string fieldName,
            object value,
            BindingFlags bindingFlags)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var fieldInfo = item.GetType().GetFieldInfo(fieldName, bindingFlags);

            value.ThrowIfNotAssignableTo(fieldInfo);

            fieldInfo.SetValue(item, value);
        }

        /// <summary>
        /// Sets a static field's value.
        /// </summary>
        /// <param name="type">The type that contains the field.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <param name="value">The value to set the field to.</param>
        /// <param name="bindingFlags">Binding flags to use when searching.  See <see cref="BindingFlagsFor" /> for commonly-used binding flags.</param>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="ArgumentException">There is no field named <paramref name="fieldName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="ArgumentException">There is more than one field named <paramref name="fieldName"/> on type <paramref name="type"/> using the specified binding constraints.</exception>
        /// <exception cref="InvalidCastException">Unable to assign null to the field's type.</exception>
        /// <exception cref="InvalidCastException">Unable to assign <paramref name="value"/> type to the field's type.</exception>
        /// <exception cref="ArgumentException">The field is not static.</exception>
        [SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "Flags", Justification = ObcSuppressBecause.CA1726_UsePreferredTerms_NameOfTypeOfIdentifierUsesTheTermFlags)]
        public static void SetStaticFieldValue(
            this Type type,
            string fieldName,
            object value,
            BindingFlags bindingFlags)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var fieldInfo = type.GetFieldInfo(fieldName, bindingFlags);

            value.ThrowIfNotAssignableTo(fieldInfo);

            try
            {
                fieldInfo.SetValue(null, value);
            }
            catch (TargetException)
            {
                throw new ArgumentException("The field is not static.");
            }
        }

        private static T CastOrThrowIfTypeMismatch<T>(
            this object fieldValue,
            FieldInfo fieldInfo)
        {
            var returnType = typeof(T);

            T result;

            if (fieldValue == null)
            {
                // can't solely rely on the (T) cast - if pi.GetValue returns null, then null can be cast to any reference type.
                var fieldType = fieldInfo.FieldType;

                if (!returnType.IsAssignableFrom(fieldType))
                {
                    throw new InvalidCastException(Invariant($"Unable to cast object of type '{fieldType.ToStringReadable()}' to type '{returnType.ToStringReadable()}'."));
                }

                result = default;
            }
            else
            {
                try
                {
                    result = (T)fieldValue;
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException(Invariant($"Unable to cast object of type '{fieldValue.GetType().ToStringReadable()}' to type '{returnType.ToStringReadable()}'."));
                }
            }

            return result;
        }

        private static void ThrowIfNotAssignableTo(
            this object value,
            FieldInfo fieldInfo)
        {
            var fieldType = fieldInfo.FieldType;

            if (value == null)
            {
                if (!fieldType.IsClosedTypeAssignableToNull())
                {
                    throw new InvalidCastException(Invariant($"Unable to assign null value to field of type '{fieldType.ToStringReadable()}'."));
                }
            }
            else
            {
                var valueType = value.GetType();

                if (!fieldType.IsAssignableFrom(valueType))
                {
                    throw new InvalidCastException(Invariant($"Unable to assign value of type '{valueType.ToStringReadable()}' to field of type '{fieldType.ToStringReadable()}'."));
                }
            }
        }
    }
}
