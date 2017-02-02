// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Provides useful methods related to reflection.
    /// </summary>
    /// <remarks>
    /// adapted from: <a href="http://stackoverflow.com/questions/1565734/is-it-possible-to-set-private-property-via-reflection/1565766#1565766" />
    /// </remarks>
    public static class ReflectionHelper
    {
        /// <summary>
        /// Constructs an object of the specified type.
        /// </summary>
        /// <param name="type">The type of object to construct.</param>
        /// <param name="parameters">
        /// An array of arguments that match in number, order, and type the parameteres of the constructor to invoke.
        /// If an empty array or null, the constructor that takes no parameters (the default constructor) is invoked.
        /// </param>
        /// <returns>
        /// A reference to the newely created object.
        /// </returns>
        /// <exception cref="Exception">Various exceptions thrown by <see cref="Activator.CreateInstance(Type, object[])"/>.</exception>
        public static object Construct(this Type type, params object[] parameters)
        {
            var result = Activator.CreateInstance(type, parameters);
            return result;
        }

        /// <summary>
        /// Constructs an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="parameters">
        /// An array of arguments that match in number, order, and type the parameteres of the constructor to invoke.
        /// If an empty array or null, the constructor that takes no parameters (the default constructor) is invoked.
        /// </param>
        /// <returns>
        /// A reference to the newely created object.
        /// </returns>
        /// <exception cref="Exception">Any exception thrown by <see cref="Activator.CreateInstance(Type, object[])"/>.</exception>
        public static T Construct<T>(params object[] parameters)
        {
            var result = typeof(T).Construct<T>(parameters);
            return result;
        }

        /// <summary>
        /// Constructs an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        /// <param name="type">The type of object to construct.</param>
        /// <param name="parameters">
        /// An array of arguments that match in number, order, and type the parameteres of the constructor to invoke.
        /// If an empty array or null, the constructor that takes no parameters (the default constructor) is invoked.
        /// </param>
        /// <returns>
        /// A reference to the newely created object.
        /// </returns>
        /// <exception cref="Exception">Any exception thrown by <see cref="Activator.CreateInstance(Type, object[])"/>.</exception>
        /// <exception cref="InvalidCastException">The created object could not be cast to a <typeparamref name="T"/>.</exception>
        public static T Construct<T>(this Type type, params object[] parameters)
        {
            var objectResult = type.Construct(parameters);
            var result = (T)objectResult;
            return result;
        }

        /// <summary>
        /// Determines if an object has a given field.
        /// </summary>
        /// <param name="item">Object to check for field.</param>
        /// <param name="fieldName">The name of the field to check for.</param>
        /// <returns>
        /// true if the object has the specified field, false if not.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        public static bool HasField(this object item, string fieldName) => GetField(item, fieldName) != null;

        /// <summary>
        /// Determines if an object has a given property.
        /// </summary>
        /// <param name="item">Object for which to check for the given property.</param>
        /// <param name="propertyName">The name of the property to check for.</param>
        /// <returns>
        /// true if the object has the specified property, false if not.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        public static bool HasProperty(this object item, string propertyName) => GetProperty(item, propertyName) != null;

        /// <summary>
        /// Returns a field value from a given object.
        /// </summary>
        /// <typeparam name="T">Type of the field.</typeparam>
        /// <param name="item">Object from which the field value is returned.</param>
        /// <param name="fieldName">The name of the field.</param>
        /// <returns>
        /// The value of the field.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="InvalidOperationException">The field was not found.</exception>
        /// <exception cref="InvalidCastException">The field is not of type T.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static T GetFieldValue<T>(this object item, string fieldName)
        {
            FieldInfo fi = GetField(item, fieldName);
            if (fi == null)
            {
                throw new InvalidOperationException($"Field {fieldName} was not found on type {item.GetType().FullName}");
            }

            Type t = typeof(T);
            try
            {
                // can't solely rely on the ( T ) cast - if fi.GetValue returns null, then null can be casted to any reference type.
                if (!fi.FieldType.IsAssignableFrom(t))
                {
                    throw new InvalidCastException($"Unable to cast object of type '{fi.FieldType.FullName}' to type '{t.FullName}'.");
                }

                return (T)fi.GetValue(item);
            }
            catch (NullReferenceException)
            {
                // if result of GetValue is null, then attempt to cast to value type will result in NullReferenceException
                throw new InvalidCastException($"Unable to cast object of type '{fi.FieldType.FullName}' to type '{t.FullName}'.");
            }
        }

        /// <summary>
        /// Retrieves a property value from a given object.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="item">Object from which the property value is returned.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>
        /// The value of the property.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="InvalidOperationException">The property was not found.</exception>
        /// <exception cref="InvalidCastException">The property is not of the specified type.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static T GetPropertyValue<T>(this object item, string propertyName)
        {
            PropertyInfo pi = GetProperty(item, propertyName);
            if (pi == null)
            {
                throw new InvalidOperationException($"Property {propertyName} was not found on type {item.GetType().FullName}");
            }

            Type t = typeof(T);
            try
            {
                // can't solely rely on the ( T ) cast - if pi.GetValue returns null, then null can be casted to any reference type.
                if (!pi.PropertyType.IsAssignableFrom(t))
                {
                    throw new InvalidCastException($"Unable to cast object of type '{pi.PropertyType.FullName}' to type '{t.FullName}'.");
                }

                return (T)pi.GetValue(item, null);
            }
            catch (NullReferenceException)
            {
                // if result the value is null, then attempt to cast to value type will result in NullReferenceException
                throw new InvalidCastException($"Unable to cast object of type '{pi.PropertyType.FullName}' to type '{t.FullName}'.");
            }
        }

        /// <summary>
        /// Set a field value in a given Object.
        /// </summary>
        /// <typeparam name="T">Type of the field.</typeparam>
        /// <param name="item">Object containing field to set.</param>
        /// <param name="fieldName">The name of the field to set..</param>
        /// <param name="value">The value to set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="fieldName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="fieldName"/> is whitespace.</exception>
        /// <exception cref="InvalidOperationException">The field was not found.</exception>
        /// <exception cref="InvalidCastException">The property is not of type T.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static void SetFieldValue<T>(this object item, string fieldName, T value)
        {
            FieldInfo fi = GetField(item, fieldName);
            if (fi == null)
            {
                throw new InvalidOperationException($"Field {fieldName} was not found in Type {item.GetType().FullName}");
            }

            try
            {
                fi.SetValue(item, value);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidCastException(ex.Message);
            }
        }

        /// <summary>
        /// Sets a property value in a given Object.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="item">Object containing property to set.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">Value to set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is null.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="propertyName"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="propertyName"/> is whitespace.</exception>
        /// <exception cref="InvalidOperationException">The property was not found.</exception>
        /// <exception cref="InvalidCastException">The property is not of type T.</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object,System.Object)", Justification = "This is a developer-facing string, not a user-facing string.")]
        public static void SetPropertyValue<T>(this object item, string propertyName, T value)
        {
            PropertyInfo pi = GetProperty(item, propertyName);
            if (pi == null)
            {
                throw new InvalidOperationException($"Property {propertyName} was not found in Type {item.GetType().FullName}");
            }

            try
            {
                pi.SetValue(item, value, null);
            }
            catch (ArgumentException ex)
            {
                throw new InvalidCastException(ex.Message);
            }
        }

        private static FieldInfo GetField(object item, string fieldName)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (fieldName == null)
            {
                throw new ArgumentNullException(nameof(fieldName));
            }

            if (string.IsNullOrWhiteSpace(fieldName))
            {
                throw new ArgumentException("The name of the field is whitespace.", nameof(fieldName));
            }

            Type t = item.GetType();
            FieldInfo fi = null;

            while ((fi == null) && (t != null))
            {
                fi = t.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                t = t.BaseType;
            }

            return fi;
        }

        private static PropertyInfo GetProperty(object item, string propertyName)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException("The name of the property is whitespace.", nameof(propertyName));
            }

            Type t = item.GetType();
            PropertyInfo pi = null;

            while ((pi == null) && (t != null))
            {
                pi = t.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                t = t.BaseType;
            }

            return pi;
        }
    }
}
