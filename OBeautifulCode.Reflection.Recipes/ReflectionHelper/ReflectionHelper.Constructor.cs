﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelper.Constructor.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// <auto-generated>
//   Sourced from NuGet package. Will be overwritten with package update except in OBeautifulCode.Reflection.Recipes source.
// </auto-generated>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes
{
    using global::System;

#if !OBeautifulCodeReflectionSolution
    internal
#else
    public
#endif
    static partial class ReflectionHelper
    {
        /// <summary>
        /// Constructs an object of the specified type.
        /// </summary>
        /// <param name="type">The type of object to construct.</param>
        /// <param name="parameters">
        /// An array of arguments that match in number, order, and type the parameters of the constructor to invoke.
        /// If an empty array or null, the constructor that takes no parameters (the default constructor) is invoked.
        /// </param>
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="Exception">Various exceptions thrown by <see cref="Activator.CreateInstance(Type, object[])"/>.</exception>
        public static object Construct(
            this Type type,
            params object[] parameters)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var result = Activator.CreateInstance(type, parameters);

            return result;
        }

        /// <summary>
        /// Constructs an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="parameters">
        /// An array of arguments that match in number, order, and type the parameters of the constructor to invoke.
        /// If an empty array or null, the constructor that takes no parameters (the default constructor) is invoked.
        /// </param>
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <exception cref="Exception">Any exception thrown by <see cref="Activator.CreateInstance(Type, object[])"/>.</exception>
        public static T Construct<T>(
            params object[] parameters)
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
        /// An array of arguments that match in number, order, and type the parameters of the constructor to invoke.
        /// If an empty array or null, the constructor that takes no parameters (the default constructor) is invoked.
        /// </param>
        /// <returns>
        /// A reference to the newly created object.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is null.</exception>
        /// <exception cref="Exception">Any exception thrown by <see cref="Activator.CreateInstance(Type, object[])"/>.</exception>
        /// <exception cref="InvalidCastException">The created object could not be cast to a <typeparamref name="T"/>.</exception>
        public static T Construct<T>(
            this Type type,
            params object[] parameters)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            var objectResult = type.Construct(parameters);

            var result = (T)objectResult;

            return result;
        }
    }
}