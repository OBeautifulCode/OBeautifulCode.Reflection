// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Construct.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable CheckNamespace
namespace OBeautifulCode.Reflection.Test
{
#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1040:AvoidEmptyInterfaces", Justification = "This is for testing purposes.")]
    public interface IAnimal
    {
    }

    public class Dog : IAnimal
    {
    }

    public class Cat : IAnimal
    {
        public Cat(int numberOfLives)
        {
            this.NumberOfLives = numberOfLives;
        }

        public int NumberOfLives { get; }
    }

#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}

// ReSharper restore CheckNamespace