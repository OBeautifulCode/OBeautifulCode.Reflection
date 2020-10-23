// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyTestTypes.cs" company="OBeautifulCode">
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
    public class ParentInstanceProperties
    {
        public ParentInstanceProperties(
            int parentPublicReadOnlyAutoValueTypeProperty,
            string parentPublicReadOnlyAutoStringTypeProperty,
            int? parentPublicReadOnlyAutoNullableTypeProperty,
            Version parentPublicReadOnlyAutoReferenceTypeProperty,
            int parentProtectedReadOnlyAutoValueTypeProperty,
            string parentProtectedReadOnlyAutoStringTypeProperty,
            int? parentProtectedReadOnlyAutoNullableTypeProperty,
            Version parentProtectedReadOnlyAutoReferenceTypeProperty,
            int parentPrivateReadOnlyAutoValueTypeProperty,
            string parentPrivateReadOnlyAutoStringTypeProperty,
            int? parentPrivateReadOnlyAutoNullableTypeProperty,
            Version parentPrivateReadOnlyAutoReferenceTypeProperty)
        {
            this.ParentPublicReadOnlyAutoValueTypeProperty = parentPublicReadOnlyAutoValueTypeProperty;
            this.ParentPublicReadOnlyAutoStringTypeProperty = parentPublicReadOnlyAutoStringTypeProperty;
            this.ParentPublicReadOnlyAutoNullableTypeProperty = parentPublicReadOnlyAutoNullableTypeProperty;
            this.ParentPublicReadOnlyAutoReferenceTypeProperty = parentPublicReadOnlyAutoReferenceTypeProperty;
            this.ParentProtectedReadOnlyAutoValueTypeProperty = parentProtectedReadOnlyAutoValueTypeProperty;
            this.ParentProtectedReadOnlyAutoStringTypeProperty = parentProtectedReadOnlyAutoStringTypeProperty;
            this.ParentProtectedReadOnlyAutoNullableTypeProperty = parentProtectedReadOnlyAutoNullableTypeProperty;
            this.ParentProtectedReadOnlyAutoReferenceTypeProperty = parentProtectedReadOnlyAutoReferenceTypeProperty;
            this.ParentPrivateReadOnlyAutoValueTypeProperty = parentPrivateReadOnlyAutoValueTypeProperty;
            this.ParentPrivateReadOnlyAutoStringTypeProperty = parentPrivateReadOnlyAutoStringTypeProperty;
            this.ParentPrivateReadOnlyAutoNullableTypeProperty = parentPrivateReadOnlyAutoNullableTypeProperty;
            this.ParentPrivateReadOnlyAutoReferenceTypeProperty = parentPrivateReadOnlyAutoReferenceTypeProperty;
        }

        public int ParentPublicReadWriteValueTypeProperty { get; set; }

        public string ParentPublicReadWriteStringTypeProperty { get; set; }

        public int? ParentPublicReadWriteNullableTypeProperty { get; set; }

        public Version ParentPublicReadWriteReferenceTypeProperty { get; set; }

        public int ParentPublicReadOnlyAutoValueTypeProperty { get; }

        public string ParentPublicReadOnlyAutoStringTypeProperty { get; }

        public int? ParentPublicReadOnlyAutoNullableTypeProperty { get; }

        public Version ParentPublicReadOnlyAutoReferenceTypeProperty { get; }

        public int ParentPublicWriteOnlyValueTypeProperty
        {
            set { }
        }

        public string ParentPublicWriteOnlyStringTypeProperty
        {
            set { }
        }

        public int? ParentPublicWriteOnlyNullableTypeProperty
        {
            set { }
        }

        public Version ParentPublicWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        public int ParentPublicReadOnlyExpressionBodyValueTypeProperty => this.ParentPublicReadWriteValueTypeProperty + 1;

        public string ParentPublicReadOnlyExpressionBodyStringTypeProperty => this.ParentPublicReadWriteStringTypeProperty + 1;

        public int? ParentPublicReadOnlyExpressionBodyNullableTypeProperty => this.ParentPublicReadWriteNullableTypeProperty + 1;

        public Version ParentPublicReadOnlyExpressionBodyReferenceTypeProperty => new Version(this.ParentPublicReadWriteReferenceTypeProperty + ".1");

        protected int ParentProtectedReadWriteValueTypeProperty { get; set; }

        protected string ParentProtectedReadWriteStringTypeProperty { get; set; }

        protected int? ParentProtectedReadWriteNullableTypeProperty { get; set; }

        protected Version ParentProtectedReadWriteReferenceTypeProperty { get; set; }

        protected int ParentProtectedReadOnlyAutoValueTypeProperty { get; }

        protected string ParentProtectedReadOnlyAutoStringTypeProperty { get; }

        protected int? ParentProtectedReadOnlyAutoNullableTypeProperty { get; }

        protected Version ParentProtectedReadOnlyAutoReferenceTypeProperty { get; }

        protected int ParentProtectedWriteOnlyValueTypeProperty
        {
            set { }
        }

        protected string ParentProtectedWriteOnlyStringTypeProperty
        {
            set { }
        }

        protected int? ParentProtectedWriteOnlyNullableTypeProperty
        {
            set { }
        }

        protected Version ParentProtectedWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        protected int ParentProtectedReadOnlyExpressionBodyValueTypeProperty => this.ParentPublicReadWriteValueTypeProperty + 2;

        protected string ParentProtectedReadOnlyExpressionBodyStringTypeProperty => this.ParentPublicReadWriteStringTypeProperty + 2;

        protected int? ParentProtectedReadOnlyExpressionBodyNullableTypeProperty => this.ParentPublicReadWriteNullableTypeProperty + 2;

        protected Version ParentProtectedReadOnlyExpressionBodyReferenceTypeProperty => new Version(this.ParentPublicReadWriteReferenceTypeProperty + ".2");

        private int ParentPrivateReadWriteValueTypeProperty { get; set; }

        private string ParentPrivateReadWriteStringTypeProperty { get; set; }

        private int? ParentPrivateReadWriteNullableTypeProperty { get; set; }

        private Version ParentPrivateReadWriteReferenceTypeProperty { get; set; }

        private int ParentPrivateReadOnlyAutoValueTypeProperty { get; }

        private string ParentPrivateReadOnlyAutoStringTypeProperty { get; }

        private int? ParentPrivateReadOnlyAutoNullableTypeProperty { get; }

        private Version ParentPrivateReadOnlyAutoReferenceTypeProperty { get; }

        private int ParentPrivateWriteOnlyValueTypeProperty
        {
            set { }
        }

        private string ParentPrivateWriteOnlyStringTypeProperty
        {
            set { }
        }

        private int? ParentPrivateWriteOnlyNullableTypeProperty
        {
            set { }
        }

        private Version ParentPrivateWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        private int ParentPrivateReadOnlyExpressionBodyValueTypeProperty => this.ParentPublicReadWriteValueTypeProperty + 3;

        private string ParentPrivateReadOnlyExpressionBodyStringTypeProperty => this.ParentPublicReadWriteStringTypeProperty + 3;

        private int? ParentPrivateReadOnlyExpressionBodyNullableTypeProperty => this.ParentPublicReadWriteNullableTypeProperty + 3;

        private Version ParentPrivateReadOnlyExpressionBodyReferenceTypeProperty => new Version(this.ParentPublicReadWriteReferenceTypeProperty + ".3");

        public string ToStringReadableProperties()
        {
            var map = new Dictionary<string, string>
            {
                { nameof(this.ParentPublicReadWriteValueTypeProperty), this.ParentPublicReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentPublicReadWriteStringTypeProperty), this.ParentPublicReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadWriteNullableTypeProperty), this.ParentPublicReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadWriteReferenceTypeProperty), this.ParentPublicReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyAutoValueTypeProperty), this.ParentPublicReadOnlyAutoValueTypeProperty.ToString() },
                { nameof(this.ParentPublicReadOnlyAutoStringTypeProperty), this.ParentPublicReadOnlyAutoStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyAutoNullableTypeProperty), this.ParentPublicReadOnlyAutoNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyAutoReferenceTypeProperty), this.ParentPublicReadOnlyAutoReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyExpressionBodyValueTypeProperty), this.ParentPublicReadOnlyExpressionBodyValueTypeProperty.ToString() },
                { nameof(this.ParentPublicReadOnlyExpressionBodyStringTypeProperty), this.ParentPublicReadOnlyExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyExpressionBodyNullableTypeProperty), this.ParentPublicReadOnlyExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyExpressionBodyReferenceTypeProperty), this.ParentPublicReadOnlyExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteValueTypeProperty), this.ParentProtectedReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentProtectedReadWriteStringTypeProperty), this.ParentProtectedReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteNullableTypeProperty), this.ParentProtectedReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteReferenceTypeProperty), this.ParentProtectedReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyAutoValueTypeProperty), this.ParentProtectedReadOnlyAutoValueTypeProperty.ToString() },
                { nameof(this.ParentProtectedReadOnlyAutoStringTypeProperty), this.ParentProtectedReadOnlyAutoStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyAutoNullableTypeProperty), this.ParentProtectedReadOnlyAutoNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyAutoReferenceTypeProperty), this.ParentProtectedReadOnlyAutoReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyExpressionBodyValueTypeProperty), this.ParentProtectedReadOnlyExpressionBodyValueTypeProperty.ToString() },
                { nameof(this.ParentProtectedReadOnlyExpressionBodyStringTypeProperty), this.ParentProtectedReadOnlyExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyExpressionBodyNullableTypeProperty), this.ParentProtectedReadOnlyExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyExpressionBodyReferenceTypeProperty), this.ParentProtectedReadOnlyExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteValueTypeProperty), this.ParentPrivateReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentPrivateReadWriteStringTypeProperty), this.ParentPrivateReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteNullableTypeProperty), this.ParentPrivateReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteReferenceTypeProperty), this.ParentPrivateReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyAutoValueTypeProperty), this.ParentPrivateReadOnlyAutoValueTypeProperty.ToString() },
                { nameof(this.ParentPrivateReadOnlyAutoStringTypeProperty), this.ParentPrivateReadOnlyAutoStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyAutoNullableTypeProperty), this.ParentPrivateReadOnlyAutoNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyAutoReferenceTypeProperty), this.ParentPrivateReadOnlyAutoReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyExpressionBodyValueTypeProperty), this.ParentPrivateReadOnlyExpressionBodyValueTypeProperty.ToString() },
                { nameof(this.ParentPrivateReadOnlyExpressionBodyStringTypeProperty), this.ParentPrivateReadOnlyExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyExpressionBodyNullableTypeProperty), this.ParentPrivateReadOnlyExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyExpressionBodyReferenceTypeProperty), this.ParentPrivateReadOnlyExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
            };

            var result = map.OrderBy(_ => _.Key).Select(_ => _.Key + ": " + _.Value).ToDelimitedString("|");

            return result;
        }

        public string ToStringWritableProperties()
        {
            var map = new Dictionary<string, string>
            {
                { nameof(this.ParentPublicReadWriteValueTypeProperty), this.ParentPublicReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentPublicReadWriteStringTypeProperty), this.ParentPublicReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadWriteNullableTypeProperty), this.ParentPublicReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadWriteReferenceTypeProperty), this.ParentPublicReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteValueTypeProperty), this.ParentProtectedReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentProtectedReadWriteStringTypeProperty), this.ParentProtectedReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteNullableTypeProperty), this.ParentProtectedReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteReferenceTypeProperty), this.ParentProtectedReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteValueTypeProperty), this.ParentPrivateReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentPrivateReadWriteStringTypeProperty), this.ParentPrivateReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteNullableTypeProperty), this.ParentPrivateReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteReferenceTypeProperty), this.ParentPrivateReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
            };

            var result = map.OrderBy(_ => _.Key).Select(_ => _.Key + ": " + _.Value).ToDelimitedString("|");

            return result;
        }
    }

    [GeneratedCode("too many warnings", "test type")]
    public class ChildInstanceProperties : ParentInstanceProperties
    {
        public ChildInstanceProperties(
            int parentPublicReadOnlyAutoValueTypeProperty,
            string parentPublicReadOnlyAutoStringTypeProperty,
            int? parentPublicReadOnlyAutoNullableTypeProperty,
            Version parentPublicReadOnlyAutoReferenceTypeProperty,
            int parentProtectedReadOnlyAutoValueTypeProperty,
            string parentProtectedReadOnlyAutoStringTypeProperty,
            int? parentProtectedReadOnlyAutoNullableTypeProperty,
            Version parentProtectedReadOnlyAutoReferenceTypeProperty,
            int parentPrivateReadOnlyAutoValueTypeProperty,
            string parentPrivateReadOnlyAutoStringTypeProperty,
            int? parentPrivateReadOnlyAutoNullableTypeProperty,
            Version parentPrivateReadOnlyAutoReferenceTypeProperty,
            int childPublicReadOnlyAutoValueTypeProperty,
            string childPublicReadOnlyAutoStringTypeProperty,
            int? childPublicReadOnlyAutoNullableTypeProperty,
            Version childPublicReadOnlyAutoReferenceTypeProperty,
            int childProtectedReadOnlyAutoValueTypeProperty,
            string childProtectedReadOnlyAutoStringTypeProperty,
            int? childProtectedReadOnlyAutoNullableTypeProperty,
            Version childProtectedReadOnlyAutoReferenceTypeProperty,
            int childPrivateReadOnlyAutoValueTypeProperty,
            string childPrivateReadOnlyAutoStringTypeProperty,
            int? childPrivateReadOnlyAutoNullableTypeProperty,
            Version childPrivateReadOnlyAutoReferenceTypeProperty)
        : base(parentPublicReadOnlyAutoValueTypeProperty, parentPublicReadOnlyAutoStringTypeProperty, parentPublicReadOnlyAutoNullableTypeProperty, parentPublicReadOnlyAutoReferenceTypeProperty, parentProtectedReadOnlyAutoValueTypeProperty, parentProtectedReadOnlyAutoStringTypeProperty, parentProtectedReadOnlyAutoNullableTypeProperty, parentProtectedReadOnlyAutoReferenceTypeProperty, parentPrivateReadOnlyAutoValueTypeProperty, parentPrivateReadOnlyAutoStringTypeProperty, parentPrivateReadOnlyAutoNullableTypeProperty, parentPrivateReadOnlyAutoReferenceTypeProperty)
        {
            this.ChildPublicReadOnlyAutoValueTypeProperty = childPublicReadOnlyAutoValueTypeProperty;
            this.ChildPublicReadOnlyAutoStringTypeProperty = childPublicReadOnlyAutoStringTypeProperty;
            this.ChildPublicReadOnlyAutoNullableTypeProperty = childPublicReadOnlyAutoNullableTypeProperty;
            this.ChildPublicReadOnlyAutoReferenceTypeProperty = childPublicReadOnlyAutoReferenceTypeProperty;
            this.ChildProtectedReadOnlyAutoValueTypeProperty = childProtectedReadOnlyAutoValueTypeProperty;
            this.ChildProtectedReadOnlyAutoStringTypeProperty = childProtectedReadOnlyAutoStringTypeProperty;
            this.ChildProtectedReadOnlyAutoNullableTypeProperty = childProtectedReadOnlyAutoNullableTypeProperty;
            this.ChildProtectedReadOnlyAutoReferenceTypeProperty = childProtectedReadOnlyAutoReferenceTypeProperty;
            this.ChildPrivateReadOnlyAutoValueTypeProperty = childPrivateReadOnlyAutoValueTypeProperty;
            this.ChildPrivateReadOnlyAutoStringTypeProperty = childPrivateReadOnlyAutoStringTypeProperty;
            this.ChildPrivateReadOnlyAutoNullableTypeProperty = childPrivateReadOnlyAutoNullableTypeProperty;
            this.ChildPrivateReadOnlyAutoReferenceTypeProperty = childPrivateReadOnlyAutoReferenceTypeProperty;
        }

        public int ChildPublicReadWriteValueTypeProperty { get; set; }

        public string ChildPublicReadWriteStringTypeProperty { get; set; }

        public int? ChildPublicReadWriteNullableTypeProperty { get; set; }

        public Version ChildPublicReadWriteReferenceTypeProperty { get; set; }

        public int ChildPublicReadOnlyAutoValueTypeProperty { get; }

        public string ChildPublicReadOnlyAutoStringTypeProperty { get; }

        public int? ChildPublicReadOnlyAutoNullableTypeProperty { get; }

        public Version ChildPublicReadOnlyAutoReferenceTypeProperty { get; }

        public int ChildPublicWriteOnlyValueTypeProperty
        {
            set { }
        }

        public string ChildPublicWriteOnlyStringTypeProperty
        {
            set { }
        }

        public int? ChildPublicWriteOnlyNullableTypeProperty
        {
            set { }
        }

        public Version ChildPublicWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        public int ChildPublicReadOnlyExpressionBodyValueTypeProperty => this.ChildPublicReadWriteValueTypeProperty;

        public string ChildPublicReadOnlyExpressionBodyStringTypeProperty => this.ChildPublicReadWriteStringTypeProperty;

        public int? ChildPublicReadOnlyExpressionBodyNullableTypeProperty => this.ChildPublicReadWriteNullableTypeProperty;

        public Version ChildPublicReadOnlyExpressionBodyReferenceTypeProperty => this.ChildPublicReadWriteReferenceTypeProperty;

        protected int ChildProtectedReadWriteValueTypeProperty { get; set; }

        protected string ChildProtectedReadWriteStringTypeProperty { get; set; }

        protected int? ChildProtectedReadWriteNullableTypeProperty { get; set; }

        protected Version ChildProtectedReadWriteReferenceTypeProperty { get; set; }

        protected int ChildProtectedReadOnlyAutoValueTypeProperty { get; }

        protected string ChildProtectedReadOnlyAutoStringTypeProperty { get; }

        protected int? ChildProtectedReadOnlyAutoNullableTypeProperty { get; }

        protected Version ChildProtectedReadOnlyAutoReferenceTypeProperty { get; }

        protected int ChildProtectedWriteOnlyValueTypeProperty
        {
            set { }
        }

        protected string ChildProtectedWriteOnlyStringTypeProperty
        {
            set { }
        }

        protected int? ChildProtectedWriteOnlyNullableTypeProperty
        {
            set { }
        }

        protected Version ChildProtectedWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        protected int ChildProtectedReadOnlyExpressionBodyValueTypeProperty => this.ChildPublicReadWriteValueTypeProperty;

        protected string ChildProtectedReadOnlyExpressionBodyStringTypeProperty => this.ChildPublicReadWriteStringTypeProperty;

        protected int? ChildProtectedReadOnlyExpressionBodyNullableTypeProperty => this.ChildPublicReadWriteNullableTypeProperty;

        protected Version ChildProtectedReadOnlyExpressionBodyReferenceTypeProperty => this.ChildPublicReadWriteReferenceTypeProperty;

        private int ChildPrivateReadWriteValueTypeProperty { get; set; }

        private string ChildPrivateReadWriteStringTypeProperty { get; set; }

        private int? ChildPrivateReadWriteNullableTypeProperty { get; set; }

        private Version ChildPrivateReadWriteReferenceTypeProperty { get; set; }

        private int ChildPrivateReadOnlyAutoValueTypeProperty { get; }

        private string ChildPrivateReadOnlyAutoStringTypeProperty { get; }

        private int? ChildPrivateReadOnlyAutoNullableTypeProperty { get; }

        private Version ChildPrivateReadOnlyAutoReferenceTypeProperty { get; }

        private int ChildPrivateWriteOnlyValueTypeProperty
        {
            set { }
        }

        private string ChildPrivateWriteOnlyStringTypeProperty
        {
            set { }
        }

        private int? ChildPrivateWriteOnlyNullableTypeProperty
        {
            set { }
        }

        private Version ChildPrivateWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        private int ChildPrivateReadOnlyExpressionBodyValueTypeProperty => this.ChildPublicReadWriteValueTypeProperty;

        private string ChildPrivateReadOnlyExpressionBodyStringTypeProperty => this.ChildPublicReadWriteStringTypeProperty;

        private int? ChildPrivateReadOnlyExpressionBodyNullableTypeProperty => this.ChildPublicReadWriteNullableTypeProperty;

        private Version ChildPrivateReadOnlyExpressionBodyReferenceTypeProperty => this.ChildPublicReadWriteReferenceTypeProperty;
    }

    [GeneratedCode("too many warnings", "test type")]
    public class ParentStaticProperties
    {
        static ParentStaticProperties()
        {
            ParentPublicReadOnlyAutoValueTypeProperty = 1;
            ParentPublicReadOnlyAutoStringTypeProperty = "2";
            ParentPublicReadOnlyAutoNullableTypeProperty = 3;
            ParentPublicReadOnlyAutoReferenceTypeProperty = new Version(4, 0);
            ParentProtectedReadOnlyAutoValueTypeProperty = 5;
            ParentProtectedReadOnlyAutoStringTypeProperty = "6";
            ParentProtectedReadOnlyAutoNullableTypeProperty = 7;
            ParentProtectedReadOnlyAutoReferenceTypeProperty = new Version(8, 0);
            ParentPrivateReadOnlyAutoValueTypeProperty = 9;
            ParentPrivateReadOnlyAutoStringTypeProperty = "10";
            ParentPrivateReadOnlyAutoNullableTypeProperty = 11;
            ParentPrivateReadOnlyAutoReferenceTypeProperty = new Version(12, 0);
        }

        public static int ParentPublicReadWriteValueTypeProperty { get; set; }

        public static string ParentPublicReadWriteStringTypeProperty { get; set; }

        public static int? ParentPublicReadWriteNullableTypeProperty { get; set; }

        public static Version ParentPublicReadWriteReferenceTypeProperty { get; set; }

        public static int ParentPublicReadOnlyAutoValueTypeProperty { get; }

        public static string ParentPublicReadOnlyAutoStringTypeProperty { get; }

        public static int? ParentPublicReadOnlyAutoNullableTypeProperty { get; }

        public static Version ParentPublicReadOnlyAutoReferenceTypeProperty { get; }

        public static int ParentPublicWriteOnlyValueTypeProperty
        {
            set { }
        }

        public static string ParentPublicWriteOnlyStringTypeProperty
        {
            set { }
        }

        public static int? ParentPublicWriteOnlyNullableTypeProperty
        {
            set { }
        }

        public static Version ParentPublicWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        public static int ParentPublicReadOnlyExpressionBodyValueTypeProperty => ParentPublicReadWriteValueTypeProperty + 1;

        public static string ParentPublicReadOnlyExpressionBodyStringTypeProperty => ParentPublicReadWriteStringTypeProperty + 1;

        public static int? ParentPublicReadOnlyExpressionBodyNullableTypeProperty => ParentPublicReadWriteNullableTypeProperty + 1;

        public static Version ParentPublicReadOnlyExpressionBodyReferenceTypeProperty => new Version(ParentPublicReadWriteReferenceTypeProperty + ".1");

        protected static int ParentProtectedReadWriteValueTypeProperty { get; set; }

        protected static string ParentProtectedReadWriteStringTypeProperty { get; set; }

        protected static int? ParentProtectedReadWriteNullableTypeProperty { get; set; }

        protected static Version ParentProtectedReadWriteReferenceTypeProperty { get; set; }

        protected static int ParentProtectedReadOnlyAutoValueTypeProperty { get; }

        protected static string ParentProtectedReadOnlyAutoStringTypeProperty { get; }

        protected static int? ParentProtectedReadOnlyAutoNullableTypeProperty { get; }

        protected static Version ParentProtectedReadOnlyAutoReferenceTypeProperty { get; }

        protected static int ParentProtectedWriteOnlyValueTypeProperty
        {
            set { }
        }

        protected static string ParentProtectedWriteOnlyStringTypeProperty
        {
            set { }
        }

        protected static int? ParentProtectedWriteOnlyNullableTypeProperty
        {
            set { }
        }

        protected static Version ParentProtectedWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        protected static int ParentProtectedReadOnlyExpressionBodyValueTypeProperty => ParentPublicReadWriteValueTypeProperty + 2;

        protected static string ParentProtectedReadOnlyExpressionBodyStringTypeProperty => ParentPublicReadWriteStringTypeProperty + 2;

        protected static int? ParentProtectedReadOnlyExpressionBodyNullableTypeProperty => ParentPublicReadWriteNullableTypeProperty + 2;

        protected static Version ParentProtectedReadOnlyExpressionBodyReferenceTypeProperty => new Version(ParentPublicReadWriteReferenceTypeProperty + ".2");

        private static int ParentPrivateReadWriteValueTypeProperty { get; set; }

        private static string ParentPrivateReadWriteStringTypeProperty { get; set; }

        private static int? ParentPrivateReadWriteNullableTypeProperty { get; set; }

        private static Version ParentPrivateReadWriteReferenceTypeProperty { get; set; }

        private static int ParentPrivateReadOnlyAutoValueTypeProperty { get; }

        private static string ParentPrivateReadOnlyAutoStringTypeProperty { get; }

        private static int? ParentPrivateReadOnlyAutoNullableTypeProperty { get; }

        private static Version ParentPrivateReadOnlyAutoReferenceTypeProperty { get; }

        private static int ParentPrivateWriteOnlyValueTypeProperty
        {
            set { }
        }

        private static string ParentPrivateWriteOnlyStringTypeProperty
        {
            set { }
        }

        private static int? ParentPrivateWriteOnlyNullableTypeProperty
        {
            set { }
        }

        private static Version ParentPrivateWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        private static int ParentPrivateReadOnlyExpressionBodyValueTypeProperty => ParentPublicReadWriteValueTypeProperty + 3;

        private static string ParentPrivateReadOnlyExpressionBodyStringTypeProperty => ParentPublicReadWriteStringTypeProperty + 3;

        private static int? ParentPrivateReadOnlyExpressionBodyNullableTypeProperty => ParentPublicReadWriteNullableTypeProperty + 3;

        private static Version ParentPrivateReadOnlyExpressionBodyReferenceTypeProperty => new Version(ParentPublicReadWriteReferenceTypeProperty + ".3");

        public static string ToStringReadableProperties()
        {
            var map = new Dictionary<string, string>
            {
                { nameof(ParentPublicReadWriteValueTypeProperty), ParentPublicReadWriteValueTypeProperty.ToString() },
                { nameof(ParentPublicReadWriteStringTypeProperty), ParentPublicReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadWriteNullableTypeProperty), ParentPublicReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadWriteReferenceTypeProperty), ParentPublicReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyAutoValueTypeProperty), ParentPublicReadOnlyAutoValueTypeProperty.ToString() },
                { nameof(ParentPublicReadOnlyAutoStringTypeProperty), ParentPublicReadOnlyAutoStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyAutoNullableTypeProperty), ParentPublicReadOnlyAutoNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyAutoReferenceTypeProperty), ParentPublicReadOnlyAutoReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyExpressionBodyValueTypeProperty), ParentPublicReadOnlyExpressionBodyValueTypeProperty.ToString() },
                { nameof(ParentPublicReadOnlyExpressionBodyStringTypeProperty), ParentPublicReadOnlyExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyExpressionBodyNullableTypeProperty), ParentPublicReadOnlyExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyExpressionBodyReferenceTypeProperty), ParentPublicReadOnlyExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteValueTypeProperty), ParentProtectedReadWriteValueTypeProperty.ToString() },
                { nameof(ParentProtectedReadWriteStringTypeProperty), ParentProtectedReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteNullableTypeProperty), ParentProtectedReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteReferenceTypeProperty), ParentProtectedReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyAutoValueTypeProperty), ParentProtectedReadOnlyAutoValueTypeProperty.ToString() },
                { nameof(ParentProtectedReadOnlyAutoStringTypeProperty), ParentProtectedReadOnlyAutoStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyAutoNullableTypeProperty), ParentProtectedReadOnlyAutoNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyAutoReferenceTypeProperty), ParentProtectedReadOnlyAutoReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyExpressionBodyValueTypeProperty), ParentProtectedReadOnlyExpressionBodyValueTypeProperty.ToString() },
                { nameof(ParentProtectedReadOnlyExpressionBodyStringTypeProperty), ParentProtectedReadOnlyExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyExpressionBodyNullableTypeProperty), ParentProtectedReadOnlyExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyExpressionBodyReferenceTypeProperty), ParentProtectedReadOnlyExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteValueTypeProperty), ParentPrivateReadWriteValueTypeProperty.ToString() },
                { nameof(ParentPrivateReadWriteStringTypeProperty), ParentPrivateReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteNullableTypeProperty), ParentPrivateReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteReferenceTypeProperty), ParentPrivateReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyAutoValueTypeProperty), ParentPrivateReadOnlyAutoValueTypeProperty.ToString() },
                { nameof(ParentPrivateReadOnlyAutoStringTypeProperty), ParentPrivateReadOnlyAutoStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyAutoNullableTypeProperty), ParentPrivateReadOnlyAutoNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyAutoReferenceTypeProperty), ParentPrivateReadOnlyAutoReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyExpressionBodyValueTypeProperty), ParentPrivateReadOnlyExpressionBodyValueTypeProperty.ToString() },
                { nameof(ParentPrivateReadOnlyExpressionBodyStringTypeProperty), ParentPrivateReadOnlyExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyExpressionBodyNullableTypeProperty), ParentPrivateReadOnlyExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyExpressionBodyReferenceTypeProperty), ParentPrivateReadOnlyExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
            };

            var result = map.OrderBy(_ => _.Key).Select(_ => _.Key + ": " + _.Value).ToDelimitedString("|");

            return result;
        }

        public static string ToStringWritableProperties()
        {
            var map = new Dictionary<string, string>
            {
                { nameof(ParentPublicReadWriteValueTypeProperty), ParentPublicReadWriteValueTypeProperty.ToString() },
                { nameof(ParentPublicReadWriteStringTypeProperty), ParentPublicReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadWriteNullableTypeProperty), ParentPublicReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadWriteReferenceTypeProperty), ParentPublicReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteValueTypeProperty), ParentProtectedReadWriteValueTypeProperty.ToString() },
                { nameof(ParentProtectedReadWriteStringTypeProperty), ParentProtectedReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteNullableTypeProperty), ParentProtectedReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteReferenceTypeProperty), ParentProtectedReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteValueTypeProperty), ParentPrivateReadWriteValueTypeProperty.ToString() },
                { nameof(ParentPrivateReadWriteStringTypeProperty), ParentPrivateReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteNullableTypeProperty), ParentPrivateReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteReferenceTypeProperty), ParentPrivateReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
            };

            var result = map.OrderBy(_ => _.Key).Select(_ => _.Key + ": " + _.Value).ToDelimitedString("|");

            return result;
        }
    }

    [GeneratedCode("too many warnings", "test type")]
    public class ChildStaticProperties : ParentStaticProperties
    {
        static ChildStaticProperties()
        {
            ChildPublicReadOnlyAutoValueTypeProperty = 20;
            ChildPublicReadOnlyAutoStringTypeProperty = "21";
            ChildPublicReadOnlyAutoNullableTypeProperty = 22;
            ChildPublicReadOnlyAutoReferenceTypeProperty = new Version(23, 0);
            ChildProtectedReadOnlyAutoValueTypeProperty = 24;
            ChildProtectedReadOnlyAutoStringTypeProperty = "25";
            ChildProtectedReadOnlyAutoNullableTypeProperty = 26;
            ChildProtectedReadOnlyAutoReferenceTypeProperty = new Version(27, 0);
            ChildPrivateReadOnlyAutoValueTypeProperty = 28;
            ChildPrivateReadOnlyAutoStringTypeProperty = "29";
            ChildPrivateReadOnlyAutoNullableTypeProperty = 30;
            ChildPrivateReadOnlyAutoReferenceTypeProperty = new Version(31, 0);
        }

        public static int ChildPublicReadWriteValueTypeProperty { get; set; }

        public static string ChildPublicReadWriteStringTypeProperty { get; set; }

        public static int? ChildPublicReadWriteNullableTypeProperty { get; set; }

        public static Version ChildPublicReadWriteReferenceTypeProperty { get; set; }

        public static int ChildPublicReadOnlyAutoValueTypeProperty { get; }

        public static string ChildPublicReadOnlyAutoStringTypeProperty { get; }

        public static int? ChildPublicReadOnlyAutoNullableTypeProperty { get; }

        public static Version ChildPublicReadOnlyAutoReferenceTypeProperty { get; }

        public static int ChildPublicWriteOnlyValueTypeProperty
        {
            set { }
        }

        public static string ChildPublicWriteOnlyStringTypeProperty
        {
            set { }
        }

        public static int? ChildPublicWriteOnlyNullableTypeProperty
        {
            set { }
        }

        public static Version ChildPublicWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        public static int ChildPublicReadOnlyExpressionBodyValueTypeProperty => ChildPublicReadWriteValueTypeProperty;

        public static string ChildPublicReadOnlyExpressionBodyStringTypeProperty => ChildPublicReadWriteStringTypeProperty;

        public static int? ChildPublicReadOnlyExpressionBodyNullableTypeProperty => ChildPublicReadWriteNullableTypeProperty;

        public static Version ChildPublicReadOnlyExpressionBodyReferenceTypeProperty => ChildPublicReadWriteReferenceTypeProperty;

        protected static int ChildProtectedReadWriteValueTypeProperty { get; set; }

        protected static string ChildProtectedReadWriteStringTypeProperty { get; set; }

        protected static int? ChildProtectedReadWriteNullableTypeProperty { get; set; }

        protected static Version ChildProtectedReadWriteReferenceTypeProperty { get; set; }

        protected static int ChildProtectedReadOnlyAutoValueTypeProperty { get; }

        protected static string ChildProtectedReadOnlyAutoStringTypeProperty { get; }

        protected static int? ChildProtectedReadOnlyAutoNullableTypeProperty { get; }

        protected static Version ChildProtectedReadOnlyAutoReferenceTypeProperty { get; }

        protected static int ChildProtectedWriteOnlyValueTypeProperty
        {
            set { }
        }

        protected static string ChildProtectedWriteOnlyStringTypeProperty
        {
            set { }
        }

        protected static int? ChildProtectedWriteOnlyNullableTypeProperty
        {
            set { }
        }

        protected static Version ChildProtectedWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        protected static int ChildProtectedReadOnlyExpressionBodyValueTypeProperty => ChildPublicReadWriteValueTypeProperty;

        protected static string ChildProtectedReadOnlyExpressionBodyStringTypeProperty => ChildPublicReadWriteStringTypeProperty;

        protected static int? ChildProtectedReadOnlyExpressionBodyNullableTypeProperty => ChildPublicReadWriteNullableTypeProperty;

        protected static Version ChildProtectedReadOnlyExpressionBodyReferenceTypeProperty => ChildPublicReadWriteReferenceTypeProperty;

        private static int ChildPrivateReadWriteValueTypeProperty { get; set; }

        private static string ChildPrivateReadWriteStringTypeProperty { get; set; }

        private static int? ChildPrivateReadWriteNullableTypeProperty { get; set; }

        private static Version ChildPrivateReadWriteReferenceTypeProperty { get; set; }

        private static int ChildPrivateReadOnlyAutoValueTypeProperty { get; }

        private static string ChildPrivateReadOnlyAutoStringTypeProperty { get; }

        private static int? ChildPrivateReadOnlyAutoNullableTypeProperty { get; }

        private static Version ChildPrivateReadOnlyAutoReferenceTypeProperty { get; }

        private static int ChildPrivateWriteOnlyValueTypeProperty
        {
            set { }
        }

        private static string ChildPrivateWriteOnlyStringTypeProperty
        {
            set { }
        }

        private static int? ChildPrivateWriteOnlyNullableTypeProperty
        {
            set { }
        }

        private static Version ChildPrivateWriteOnlyReferenceTypeProperty
        {
            set { }
        }

        private static int ChildPrivateReadOnlyExpressionBodyValueTypeProperty => ChildPublicReadWriteValueTypeProperty;

        private static string ChildPrivateReadOnlyExpressionBodyStringTypeProperty => ChildPublicReadWriteStringTypeProperty;

        private static int? ChildPrivateReadOnlyExpressionBodyNullableTypeProperty => ChildPublicReadWriteNullableTypeProperty;

        private static Version ChildPrivateReadOnlyExpressionBodyReferenceTypeProperty => ChildPublicReadWriteReferenceTypeProperty;
    }
#pragma warning restore SA1204 // Static elements should appear before instance elements
#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}