// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.cs" company="OBeautifulCode">
//   Copyright 2014 OBeautifulCode
// </copyright>
// <summary>
//   Provides useful methods related to reflection.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Libs.Reflection
{
    using System;
    using System.Globalization;
    using System.Reflection;

    using CuttingEdge.Conditions;

    /// <summary>
    /// Provides useful methods related to reflection.
    /// </summary>
    public static class ReflectionHelper
    {
        #region Fields (Private)

        #endregion

        #region Constructors

        #endregion

        #region Properties

        #endregion

        #region Public Methods

        /// <summary>
        /// Determines if an object has a given property.
        /// </summary>
        /// <param name="item">Object for which to check for the given property.</param>
        /// <param name="propertyName">The name of the property to check for.</param>
        /// <returns>
        /// Returns true if property exists, false if not.
        /// </returns>
        /// <exception cref="ArgumentNullException">item is null.</exception>
        /// <exception cref="ArgumentNullException">propertyName is null.</exception>
        /// <exception cref="ArgumentException">propertyName is whitespace.</exception>
        public static bool HasProperty(this object item, string propertyName)
        {
            return GetProperty(item, propertyName) != null;
        }

        /// <summary>
        /// Determines if an object has a given field.
        /// </summary>
        /// <param name="item">Object for which to check for the given field.</param>
        /// <param name="fieldName">The name of the field to check for.</param>
        /// <returns>
        /// Returns true if field exists, false if not.
        /// </returns>
        /// <exception cref="ArgumentNullException">item is null.</exception>
        /// <exception cref="ArgumentException">fieldName is null.</exception>
        /// <exception cref="ArgumentException">fieldName is whitespace.</exception>
        public static bool HasField(this object item, string fieldName)
        {
            return GetField(item, fieldName) != null;
        }

        /// <summary>
        /// Retrieves a property value from a given object.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="item">Object from which the property value is returned.</param>
        /// <param name="propertyName">The name of the property.</param>
        /// <returns>
        /// Returns the property value.
        /// </returns>
        /// <exception cref="ArgumentNullException">item is null.</exception>
        /// <exception cref="ArgumentNullException">propertyName is null.</exception>
        /// <exception cref="ArgumentException">propertyName is whitespace.</exception>
        /// <exception cref="InvalidOperationException">The property was not found.</exception>
        /// <exception cref="InvalidCastException">The property is not of type T.</exception>
        public static T GetPropertyValue<T>(this object item, string propertyName)
        {
            PropertyInfo pi = GetProperty(item, propertyName);
            if (pi == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Property {0} was not found in Type {1}", propertyName, item.GetType().FullName));
            }

            Type t = typeof(T);
            try
            {
                // can't solely rely on the ( T ) cast - if pi.GetValue returns null, then null can be casted to any reference type.
                if (!pi.PropertyType.IsAssignableFrom(t))
                {
                    throw new InvalidCastException(string.Format(CultureInfo.CurrentCulture, "Unable to cast object of type '{0}' to type '{1}'.", pi.PropertyType.FullName, t.FullName));
                }

                return (T)pi.GetValue(item, null);
            }
            catch (NullReferenceException ex)
            {
                // if result the value is null, then attempt to cast to value type will result in NullReferenceException
                throw new InvalidCastException(string.Format(CultureInfo.CurrentCulture, "Unable to cast object of type '{0}' to type '{1}'.", pi.PropertyType.FullName, t.FullName), ex);
            }
        }

        ///// <summary>
        ///// Returns a field value from a given object.
        ///// </summary>
        ///// <typeparam name="T">Type of the field.</typeparam>
        ///// <param name="item">Object from which the field value is returned.</param>
        ///// <param name="fieldName">The name of the field.</param>
        ///// <exception cref="ArgumentNullException">obj is null.</exception>
        ///// <exception cref="ArgumentException">fieldName is null or whitespace.</exception>
        ///// <exception cref="NotFoundException">The field was not found.</exception>
        ///// <exception cref="InvalidCastException">The field is not of type T.</exception>
        //public static T GetFieldValue<T>(this object item, string fieldName)
        //{
        //    FieldInfo fi = GetField(item, fieldName);
        //    if (fi == null)
        //    {
        //        throw new NotFoundException("fieldName", string.Format(CultureInfo.CurrentCulture, "Field {0} was not found in Type {1}", fieldName, item.GetType().FullName));
        //    }

        //    Type t = typeof(T);
        //    try
        //    {
        //        // can't solely rely on the ( T ) cast - if fi.GetValue returns null, then null can be casted to any reference type.
        //        if (!fi.FieldType.IsAssignableFrom(t))
        //        {
        //            throw new InvalidCastException(String.Format(CultureInfo.CurrentCulture, "Unable to cast object of type '{0}' to type '{1}'.", fi.FieldType.FullName, t.FullName));
        //        }
        //        return (T)fi.GetValue(item);
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        // if result of GetValue is null, then attempt to cast to value type will result in NullReferenceException
        //        throw new InvalidCastException(String.Format(CultureInfo.CurrentCulture, "Unable to cast object of type '{0}' to type '{1}'.", fi.FieldType.FullName, t.FullName), ex);
        //    }
        //}

        /// <summary>
        /// Sets a property value in a given Object.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="item">Object containing property to set.</param>
        /// <param name="propertyName">The name of the property to set.</param>
        /// <param name="value">Value to set.</param>
        /// <exception cref="ArgumentNullException">item is null.</exception>
        /// <exception cref="ArgumentNullException">propertyName is null.</exception>
        /// <exception cref="ArgumentException">propertyName is whitespace.</exception>
        /// <exception cref="InvalidOperationException">The property was not found.</exception>
        /// <exception cref="InvalidCastException">The property is not of type T.</exception>
        public static void SetPropertyValue<T>(this object item, string propertyName, T value)
        {
            PropertyInfo pi = GetProperty(item, propertyName);
            if (pi == null)
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Property {0} was not found in Type {1}", propertyName, item.GetType().FullName));
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

        ///// <summary>
        ///// Set a field value in a given Object.
        ///// </summary>
        ///// <typeparam name="T">Type of the field.</typeparam>
        ///// <param name="item">Object containing field to set.</param>
        ///// <param name="fieldName">The name of the field to set..</param>
        ///// <param name="value">The value to set.</param>
        ///// <exception cref="ArgumentNullException">obj is null.</exception>
        ///// <exception cref="ArgumentException">fieldName is null or whitespace.</exception>
        ///// <exception cref="NotFoundException">The field was not found.</exception>
        ///// <exception cref="InvalidCastException">The property is not of type T.</exception>
        //public static void SetFieldValue<T>(this object item, string fieldName, T value)
        //{
        //    FieldInfo fi = GetField(item, fieldName);
        //    if (fi == null)
        //    {
        //        throw new NotFoundException("fieldName", string.Format(CultureInfo.CurrentCulture, "Field {0} was not found in Type {1}", fieldName, item.GetType().FullName));
        //    }
        //    try
        //    {
        //        fi.SetValue(item, value);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        throw new InvalidCastException(ex.Message);
        //    }
        //}

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets the <see cref="FieldInfo"/> for a given object and field name.  Returns null if field does not exist in object.
        /// </summary>
        /// <param name="item">The object to inspect.</param>
        /// <param name="fieldName">The name of the field to retrieve.</param>
        /// <returns>
        /// Returns the field.
        /// </returns>
        /// <exception cref="ArgumentNullException">item is null.</exception>
        /// <exception cref="ArgumentNullException">fieldName is null.</exception>
        /// <exception cref="ArgumentException">fieldName is whitespace.</exception>
        private static FieldInfo GetField(object item, string fieldName)
        {
            Condition.Requires(item, "item").IsNotNull();
            Condition.Requires(fieldName, "fieldName").IsNotNullOrWhiteSpace();

            Type t = item.GetType();
            FieldInfo fi = null;

            while ((fi == null) && (t != null))
            {
                fi = t.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                t = t.BaseType;
            }

            return fi;
        }

        /// <summary>
        /// Gets the <see cref="PropertyInfo"/> for a given object and property name.  Returns null if the property does not exist in object.
        /// </summary>
        /// <param name="item">The object to inspect.</param>
        /// <param name="propertyName">The name of the property to retrieve.</param>
        /// <returns>
        /// Returns the property.
        /// </returns>
        /// <exception cref="ArgumentNullException">item is null.</exception>
        /// <exception cref="ArgumentNullException">propertyName is null.</exception>
        /// <exception cref="ArgumentException">propertyName is whitespace.</exception>
        private static PropertyInfo GetProperty(object item, string propertyName)
        {
            Condition.Requires(item, "item").IsNotNull();
            Condition.Requires(propertyName, "propertyName").IsNotNullOrWhiteSpace();

            Type t = item.GetType();
            PropertyInfo pi = null;

            while ((pi == null) && (t != null))
            {
                pi = t.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
                t = t.BaseType;
            }

            return pi;
        }

        #endregion
    }
}
