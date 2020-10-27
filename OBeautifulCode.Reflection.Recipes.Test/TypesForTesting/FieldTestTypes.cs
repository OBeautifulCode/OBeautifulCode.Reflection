// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldTestTypes.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Linq;

    using OBeautifulCode.Collection.Recipes;

#pragma warning disable SA1649 // File name must match first type name
#pragma warning disable SA1402 // File may only contain a single class
#pragma warning disable SA1204 // Static elements should appear before instance elements

    [GeneratedCode("too many warnings", "test type")]
    public class FieldMutability
    {
        public readonly string ReadOnlyInstanceField = "read-only string field";

        public static readonly string ReadOnlyStaticField = "read-only string field";

        public const int ConstField = 10;

        public string InstanceField = "string-field";

        public static string StaticField = "string-field";
    }
#pragma warning restore SA1204 // Static elements should appear before instance elements
#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}