// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyTestTypes.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using OBeautifulCode.Collection.Recipes;

    #pragma warning disable SA1649 // File name must match first type name
    #pragma warning disable SA1402 // File may only contain a single class
    #pragma warning disable SA1204 // Static elements should appear before instance elements

    public class ParentInstanceProperties
    {
        public ParentInstanceProperties(
            int parentPublicReadOnlyValueTypeProperty,
            string parentPublicReadOnlyStringTypeProperty,
            int? parentPublicReadOnlyNullableTypeProperty,
            Version parentPublicReadOnlyReferenceTypeProperty,
            int parentProtectedReadOnlyValueTypeProperty,
            string parentProtectedReadOnlyStringTypeProperty,
            int? parentProtectedReadOnlyNullableTypeProperty,
            Version parentProtectedReadOnlyReferenceTypeProperty,
            int parentPrivateReadOnlyValueTypeProperty,
            string parentPrivateReadOnlyStringTypeProperty,
            int? parentPrivateReadOnlyNullableTypeProperty,
            Version parentPrivateReadOnlyReferenceTypeProperty)
        {
            this.ParentPublicReadOnlyValueTypeProperty = parentPublicReadOnlyValueTypeProperty;
            this.ParentPublicReadOnlyStringTypeProperty = parentPublicReadOnlyStringTypeProperty;
            this.ParentPublicReadOnlyNullableTypeProperty = parentPublicReadOnlyNullableTypeProperty;
            this.ParentPublicReadOnlyReferenceTypeProperty = parentPublicReadOnlyReferenceTypeProperty;
            this.ParentProtectedReadOnlyValueTypeProperty = parentProtectedReadOnlyValueTypeProperty;
            this.ParentProtectedReadOnlyStringTypeProperty = parentProtectedReadOnlyStringTypeProperty;
            this.ParentProtectedReadOnlyNullableTypeProperty = parentProtectedReadOnlyNullableTypeProperty;
            this.ParentProtectedReadOnlyReferenceTypeProperty = parentProtectedReadOnlyReferenceTypeProperty;
            this.ParentPrivateReadOnlyValueTypeProperty = parentPrivateReadOnlyValueTypeProperty;
            this.ParentPrivateReadOnlyStringTypeProperty = parentPrivateReadOnlyStringTypeProperty;
            this.ParentPrivateReadOnlyNullableTypeProperty = parentPrivateReadOnlyNullableTypeProperty;
            this.ParentPrivateReadOnlyReferenceTypeProperty = parentPrivateReadOnlyReferenceTypeProperty;
        }

        public int ParentPublicReadWriteValueTypeProperty { get; set; }

        public string ParentPublicReadWriteStringTypeProperty { get; set; }

        public int? ParentPublicReadWriteNullableTypeProperty { get; set; }

        public Version ParentPublicReadWriteReferenceTypeProperty { get; set; }

        public int ParentPublicReadOnlyValueTypeProperty { get; }

        public string ParentPublicReadOnlyStringTypeProperty { get; }

        public int? ParentPublicReadOnlyNullableTypeProperty { get; }

        public Version ParentPublicReadOnlyReferenceTypeProperty { get; }

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

        public int ParentPublicExpressionBodyValueTypeProperty => this.ParentPublicReadWriteValueTypeProperty + 1;

        public string ParentPublicExpressionBodyStringTypeProperty => this.ParentPublicReadWriteStringTypeProperty + 1;

        public int? ParentPublicExpressionBodyNullableTypeProperty => this.ParentPublicReadWriteNullableTypeProperty + 1;

        public Version ParentPublicExpressionBodyReferenceTypeProperty => new Version(this.ParentPublicReadWriteReferenceTypeProperty + ".1");

        protected int ParentProtectedReadWriteValueTypeProperty { get; set; }

        protected string ParentProtectedReadWriteStringTypeProperty { get; set; }

        protected int? ParentProtectedReadWriteNullableTypeProperty { get; set; }

        protected Version ParentProtectedReadWriteReferenceTypeProperty { get; set; }

        protected int ParentProtectedReadOnlyValueTypeProperty { get; }

        protected string ParentProtectedReadOnlyStringTypeProperty { get; }

        protected int? ParentProtectedReadOnlyNullableTypeProperty { get; }

        protected Version ParentProtectedReadOnlyReferenceTypeProperty { get; }

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

        protected int ParentProtectedExpressionBodyValueTypeProperty => this.ParentPublicReadWriteValueTypeProperty + 2;

        protected string ParentProtectedExpressionBodyStringTypeProperty => this.ParentPublicReadWriteStringTypeProperty + 2;

        protected int? ParentProtectedExpressionBodyNullableTypeProperty => this.ParentPublicReadWriteNullableTypeProperty + 2;

        protected Version ParentProtectedExpressionBodyReferenceTypeProperty => new Version(this.ParentPublicReadWriteReferenceTypeProperty + ".2");

        private int ParentPrivateReadWriteValueTypeProperty { get; set; }

        private string ParentPrivateReadWriteStringTypeProperty { get; set; }

        private int? ParentPrivateReadWriteNullableTypeProperty { get; set; }

        private Version ParentPrivateReadWriteReferenceTypeProperty { get; set; }

        private int ParentPrivateReadOnlyValueTypeProperty { get; }

        private string ParentPrivateReadOnlyStringTypeProperty { get; }

        private int? ParentPrivateReadOnlyNullableTypeProperty { get; }

        private Version ParentPrivateReadOnlyReferenceTypeProperty { get; }

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

        private int ParentPrivateExpressionBodyValueTypeProperty => this.ParentPublicReadWriteValueTypeProperty + 3;

        private string ParentPrivateExpressionBodyStringTypeProperty => this.ParentPublicReadWriteStringTypeProperty + 3;

        private int? ParentPrivateExpressionBodyNullableTypeProperty => this.ParentPublicReadWriteNullableTypeProperty + 3;

        private Version ParentPrivateExpressionBodyReferenceTypeProperty => new Version(this.ParentPublicReadWriteReferenceTypeProperty + ".3");

        public string ToStringReadableProperties()
        {
            var map = new Dictionary<string, string>
            {
                { nameof(this.ParentPublicReadWriteValueTypeProperty), this.ParentPublicReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentPublicReadWriteStringTypeProperty), this.ParentPublicReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadWriteNullableTypeProperty), this.ParentPublicReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadWriteReferenceTypeProperty), this.ParentPublicReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyValueTypeProperty), this.ParentPublicReadOnlyValueTypeProperty.ToString() },
                { nameof(this.ParentPublicReadOnlyStringTypeProperty), this.ParentPublicReadOnlyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyNullableTypeProperty), this.ParentPublicReadOnlyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicReadOnlyReferenceTypeProperty), this.ParentPublicReadOnlyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicExpressionBodyValueTypeProperty), this.ParentPublicExpressionBodyValueTypeProperty.ToString() },
                { nameof(this.ParentPublicExpressionBodyStringTypeProperty), this.ParentPublicExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicExpressionBodyNullableTypeProperty), this.ParentPublicExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPublicExpressionBodyReferenceTypeProperty), this.ParentPublicExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteValueTypeProperty), this.ParentProtectedReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentProtectedReadWriteStringTypeProperty), this.ParentProtectedReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteNullableTypeProperty), this.ParentProtectedReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadWriteReferenceTypeProperty), this.ParentProtectedReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyValueTypeProperty), this.ParentProtectedReadOnlyValueTypeProperty.ToString() },
                { nameof(this.ParentProtectedReadOnlyStringTypeProperty), this.ParentProtectedReadOnlyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyNullableTypeProperty), this.ParentProtectedReadOnlyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedReadOnlyReferenceTypeProperty), this.ParentProtectedReadOnlyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedExpressionBodyValueTypeProperty), this.ParentProtectedExpressionBodyValueTypeProperty.ToString() },
                { nameof(this.ParentProtectedExpressionBodyStringTypeProperty), this.ParentProtectedExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedExpressionBodyNullableTypeProperty), this.ParentProtectedExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentProtectedExpressionBodyReferenceTypeProperty), this.ParentProtectedExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteValueTypeProperty), this.ParentPrivateReadWriteValueTypeProperty.ToString() },
                { nameof(this.ParentPrivateReadWriteStringTypeProperty), this.ParentPrivateReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteNullableTypeProperty), this.ParentPrivateReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadWriteReferenceTypeProperty), this.ParentPrivateReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyValueTypeProperty), this.ParentPrivateReadOnlyValueTypeProperty.ToString() },
                { nameof(this.ParentPrivateReadOnlyStringTypeProperty), this.ParentPrivateReadOnlyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyNullableTypeProperty), this.ParentPrivateReadOnlyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateReadOnlyReferenceTypeProperty), this.ParentPrivateReadOnlyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateExpressionBodyValueTypeProperty), this.ParentPrivateExpressionBodyValueTypeProperty.ToString() },
                { nameof(this.ParentPrivateExpressionBodyStringTypeProperty), this.ParentPrivateExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateExpressionBodyNullableTypeProperty), this.ParentPrivateExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(this.ParentPrivateExpressionBodyReferenceTypeProperty), this.ParentPrivateExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
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

    public class ChildInstanceProperties : ParentInstanceProperties
    {
        public ChildInstanceProperties(
            int parentPublicReadOnlyValueTypeProperty,
            string parentPublicReadOnlyStringTypeProperty,
            int? parentPublicReadOnlyNullableTypeProperty,
            Version parentPublicReadOnlyReferenceTypeProperty,
            int parentProtectedReadOnlyValueTypeProperty,
            string parentProtectedReadOnlyStringTypeProperty,
            int? parentProtectedReadOnlyNullableTypeProperty,
            Version parentProtectedReadOnlyReferenceTypeProperty,
            int parentPrivateReadOnlyValueTypeProperty,
            string parentPrivateReadOnlyStringTypeProperty,
            int? parentPrivateReadOnlyNullableTypeProperty,
            Version parentPrivateReadOnlyReferenceTypeProperty,
            int childPublicReadOnlyValueTypeProperty,
            string childPublicReadOnlyStringTypeProperty,
            int? childPublicReadOnlyNullableTypeProperty,
            Version childPublicReadOnlyReferenceTypeProperty,
            int childProtectedReadOnlyValueTypeProperty,
            string childProtectedReadOnlyStringTypeProperty,
            int? childProtectedReadOnlyNullableTypeProperty,
            Version childProtectedReadOnlyReferenceTypeProperty,
            int childPrivateReadOnlyValueTypeProperty,
            string childPrivateReadOnlyStringTypeProperty,
            int? childPrivateReadOnlyNullableTypeProperty,
            Version childPrivateReadOnlyReferenceTypeProperty)
        : base(parentPublicReadOnlyValueTypeProperty, parentPublicReadOnlyStringTypeProperty, parentPublicReadOnlyNullableTypeProperty, parentPublicReadOnlyReferenceTypeProperty, parentProtectedReadOnlyValueTypeProperty, parentProtectedReadOnlyStringTypeProperty, parentProtectedReadOnlyNullableTypeProperty, parentProtectedReadOnlyReferenceTypeProperty, parentPrivateReadOnlyValueTypeProperty, parentPrivateReadOnlyStringTypeProperty, parentPrivateReadOnlyNullableTypeProperty, parentPrivateReadOnlyReferenceTypeProperty)
        {
            this.ChildPublicReadOnlyValueTypeProperty = childPublicReadOnlyValueTypeProperty;
            this.ChildPublicReadOnlyStringTypeProperty = childPublicReadOnlyStringTypeProperty;
            this.ChildPublicReadOnlyNullableTypeProperty = childPublicReadOnlyNullableTypeProperty;
            this.ChildPublicReadOnlyReferenceTypeProperty = childPublicReadOnlyReferenceTypeProperty;
            this.ChildProtectedReadOnlyValueTypeProperty = childProtectedReadOnlyValueTypeProperty;
            this.ChildProtectedReadOnlyStringTypeProperty = childProtectedReadOnlyStringTypeProperty;
            this.ChildProtectedReadOnlyNullableTypeProperty = childProtectedReadOnlyNullableTypeProperty;
            this.ChildProtectedReadOnlyReferenceTypeProperty = childProtectedReadOnlyReferenceTypeProperty;
            this.ChildPrivateReadOnlyValueTypeProperty = childPrivateReadOnlyValueTypeProperty;
            this.ChildPrivateReadOnlyStringTypeProperty = childPrivateReadOnlyStringTypeProperty;
            this.ChildPrivateReadOnlyNullableTypeProperty = childPrivateReadOnlyNullableTypeProperty;
            this.ChildPrivateReadOnlyReferenceTypeProperty = childPrivateReadOnlyReferenceTypeProperty;
        }

        public int ChildPublicReadWriteValueTypeProperty { get; set; }

        public string ChildPublicReadWriteStringTypeProperty { get; set; }

        public int? ChildPublicReadWriteNullableTypeProperty { get; set; }

        public Version ChildPublicReadWriteReferenceTypeProperty { get; set; }

        public int ChildPublicReadOnlyValueTypeProperty { get; }

        public string ChildPublicReadOnlyStringTypeProperty { get; }

        public int? ChildPublicReadOnlyNullableTypeProperty { get; }

        public Version ChildPublicReadOnlyReferenceTypeProperty { get; }

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

        public int ChildPublicExpressionBodyValueTypeProperty => this.ChildPublicReadWriteValueTypeProperty;

        public string ChildPublicExpressionBodyStringTypeProperty => this.ChildPublicReadWriteStringTypeProperty;

        public int? ChildPublicExpressionBodyNullableTypeProperty => this.ChildPublicReadWriteNullableTypeProperty;

        public Version ChildPublicExpressionBodyReferenceTypeProperty => this.ChildPublicReadWriteReferenceTypeProperty;

        protected int ChildProtectedReadWriteValueTypeProperty { get; set; }

        protected string ChildProtectedReadWriteStringTypeProperty { get; set; }

        protected int? ChildProtectedReadWriteNullableTypeProperty { get; set; }

        protected Version ChildProtectedReadWriteReferenceTypeProperty { get; set; }

        protected int ChildProtectedReadOnlyValueTypeProperty { get; }

        protected string ChildProtectedReadOnlyStringTypeProperty { get; }

        protected int? ChildProtectedReadOnlyNullableTypeProperty { get; }

        protected Version ChildProtectedReadOnlyReferenceTypeProperty { get; }

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

        protected int ChildProtectedExpressionBodyValueTypeProperty => this.ChildPublicReadWriteValueTypeProperty;

        protected string ChildProtectedExpressionBodyStringTypeProperty => this.ChildPublicReadWriteStringTypeProperty;

        protected int? ChildProtectedExpressionBodyNullableTypeProperty => this.ChildPublicReadWriteNullableTypeProperty;

        protected Version ChildProtectedExpressionBodyReferenceTypeProperty => this.ChildPublicReadWriteReferenceTypeProperty;

        private int ChildPrivateReadWriteValueTypeProperty { get; set; }

        private string ChildPrivateReadWriteStringTypeProperty { get; set; }

        private int? ChildPrivateReadWriteNullableTypeProperty { get; set; }

        private Version ChildPrivateReadWriteReferenceTypeProperty { get; set; }

        private int ChildPrivateReadOnlyValueTypeProperty { get; }

        private string ChildPrivateReadOnlyStringTypeProperty { get; }

        private int? ChildPrivateReadOnlyNullableTypeProperty { get; }

        private Version ChildPrivateReadOnlyReferenceTypeProperty { get; }

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

        private int ChildPrivateExpressionBodyValueTypeProperty => this.ChildPublicReadWriteValueTypeProperty;

        private string ChildPrivateExpressionBodyStringTypeProperty => this.ChildPublicReadWriteStringTypeProperty;

        private int? ChildPrivateExpressionBodyNullableTypeProperty => this.ChildPublicReadWriteNullableTypeProperty;

        private Version ChildPrivateExpressionBodyReferenceTypeProperty => this.ChildPublicReadWriteReferenceTypeProperty;
    }

    public class ParentStaticProperties
    {
        static ParentStaticProperties()
        {
            ParentPublicReadOnlyValueTypeProperty = 1;
            ParentPublicReadOnlyStringTypeProperty = "2";
            ParentPublicReadOnlyNullableTypeProperty = 3;
            ParentPublicReadOnlyReferenceTypeProperty = new Version(4, 0);
            ParentProtectedReadOnlyValueTypeProperty = 5;
            ParentProtectedReadOnlyStringTypeProperty = "6";
            ParentProtectedReadOnlyNullableTypeProperty = 7;
            ParentProtectedReadOnlyReferenceTypeProperty = new Version(8, 0);
            ParentPrivateReadOnlyValueTypeProperty = 9;
            ParentPrivateReadOnlyStringTypeProperty = "10";
            ParentPrivateReadOnlyNullableTypeProperty = 11;
            ParentPrivateReadOnlyReferenceTypeProperty = new Version(12, 0);
        }

        public static int ParentPublicReadWriteValueTypeProperty { get; set; }

        public static string ParentPublicReadWriteStringTypeProperty { get; set; }

        public static int? ParentPublicReadWriteNullableTypeProperty { get; set; }

        public static Version ParentPublicReadWriteReferenceTypeProperty { get; set; }

        public static int ParentPublicReadOnlyValueTypeProperty { get; }

        public static string ParentPublicReadOnlyStringTypeProperty { get; }

        public static int? ParentPublicReadOnlyNullableTypeProperty { get; }

        public static Version ParentPublicReadOnlyReferenceTypeProperty { get; }

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

        public static int ParentPublicExpressionBodyValueTypeProperty => ParentPublicReadWriteValueTypeProperty + 1;

        public static string ParentPublicExpressionBodyStringTypeProperty => ParentPublicReadWriteStringTypeProperty + 1;

        public static int? ParentPublicExpressionBodyNullableTypeProperty => ParentPublicReadWriteNullableTypeProperty + 1;

        public static Version ParentPublicExpressionBodyReferenceTypeProperty => new Version(ParentPublicReadWriteReferenceTypeProperty + ".1");

        protected static int ParentProtectedReadWriteValueTypeProperty { get; set; }

        protected static string ParentProtectedReadWriteStringTypeProperty { get; set; }

        protected static int? ParentProtectedReadWriteNullableTypeProperty { get; set; }

        protected static Version ParentProtectedReadWriteReferenceTypeProperty { get; set; }

        protected static int ParentProtectedReadOnlyValueTypeProperty { get; }

        protected static string ParentProtectedReadOnlyStringTypeProperty { get; }

        protected static int? ParentProtectedReadOnlyNullableTypeProperty { get; }

        protected static Version ParentProtectedReadOnlyReferenceTypeProperty { get; }

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

        protected static int ParentProtectedExpressionBodyValueTypeProperty => ParentPublicReadWriteValueTypeProperty + 2;

        protected static string ParentProtectedExpressionBodyStringTypeProperty => ParentPublicReadWriteStringTypeProperty + 2;

        protected static int? ParentProtectedExpressionBodyNullableTypeProperty => ParentPublicReadWriteNullableTypeProperty + 2;

        protected static Version ParentProtectedExpressionBodyReferenceTypeProperty => new Version(ParentPublicReadWriteReferenceTypeProperty + ".2");

        private static int ParentPrivateReadWriteValueTypeProperty { get; set; }

        private static string ParentPrivateReadWriteStringTypeProperty { get; set; }

        private static int? ParentPrivateReadWriteNullableTypeProperty { get; set; }

        private static Version ParentPrivateReadWriteReferenceTypeProperty { get; set; }

        private static int ParentPrivateReadOnlyValueTypeProperty { get; }

        private static string ParentPrivateReadOnlyStringTypeProperty { get; }

        private static int? ParentPrivateReadOnlyNullableTypeProperty { get; }

        private static Version ParentPrivateReadOnlyReferenceTypeProperty { get; }

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

        private static int ParentPrivateExpressionBodyValueTypeProperty => ParentPublicReadWriteValueTypeProperty + 3;

        private static string ParentPrivateExpressionBodyStringTypeProperty => ParentPublicReadWriteStringTypeProperty + 3;

        private static int? ParentPrivateExpressionBodyNullableTypeProperty => ParentPublicReadWriteNullableTypeProperty + 3;

        private static Version ParentPrivateExpressionBodyReferenceTypeProperty => new Version(ParentPublicReadWriteReferenceTypeProperty + ".3");

        public static string ToStringReadableProperties()
        {
            var map = new Dictionary<string, string>
            {
                { nameof(ParentPublicReadWriteValueTypeProperty), ParentPublicReadWriteValueTypeProperty.ToString() },
                { nameof(ParentPublicReadWriteStringTypeProperty), ParentPublicReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadWriteNullableTypeProperty), ParentPublicReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadWriteReferenceTypeProperty), ParentPublicReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyValueTypeProperty), ParentPublicReadOnlyValueTypeProperty.ToString() },
                { nameof(ParentPublicReadOnlyStringTypeProperty), ParentPublicReadOnlyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyNullableTypeProperty), ParentPublicReadOnlyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicReadOnlyReferenceTypeProperty), ParentPublicReadOnlyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicExpressionBodyValueTypeProperty), ParentPublicExpressionBodyValueTypeProperty.ToString() },
                { nameof(ParentPublicExpressionBodyStringTypeProperty), ParentPublicExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicExpressionBodyNullableTypeProperty), ParentPublicExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPublicExpressionBodyReferenceTypeProperty), ParentPublicExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteValueTypeProperty), ParentProtectedReadWriteValueTypeProperty.ToString() },
                { nameof(ParentProtectedReadWriteStringTypeProperty), ParentProtectedReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteNullableTypeProperty), ParentProtectedReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadWriteReferenceTypeProperty), ParentProtectedReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyValueTypeProperty), ParentProtectedReadOnlyValueTypeProperty.ToString() },
                { nameof(ParentProtectedReadOnlyStringTypeProperty), ParentProtectedReadOnlyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyNullableTypeProperty), ParentProtectedReadOnlyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedReadOnlyReferenceTypeProperty), ParentProtectedReadOnlyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedExpressionBodyValueTypeProperty), ParentProtectedExpressionBodyValueTypeProperty.ToString() },
                { nameof(ParentProtectedExpressionBodyStringTypeProperty), ParentProtectedExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedExpressionBodyNullableTypeProperty), ParentProtectedExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentProtectedExpressionBodyReferenceTypeProperty), ParentProtectedExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteValueTypeProperty), ParentPrivateReadWriteValueTypeProperty.ToString() },
                { nameof(ParentPrivateReadWriteStringTypeProperty), ParentPrivateReadWriteStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteNullableTypeProperty), ParentPrivateReadWriteNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadWriteReferenceTypeProperty), ParentPrivateReadWriteReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyValueTypeProperty), ParentPrivateReadOnlyValueTypeProperty.ToString() },
                { nameof(ParentPrivateReadOnlyStringTypeProperty), ParentPrivateReadOnlyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyNullableTypeProperty), ParentPrivateReadOnlyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateReadOnlyReferenceTypeProperty), ParentPrivateReadOnlyReferenceTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateExpressionBodyValueTypeProperty), ParentPrivateExpressionBodyValueTypeProperty.ToString() },
                { nameof(ParentPrivateExpressionBodyStringTypeProperty), ParentPrivateExpressionBodyStringTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateExpressionBodyNullableTypeProperty), ParentPrivateExpressionBodyNullableTypeProperty?.ToString() ?? "<null>" },
                { nameof(ParentPrivateExpressionBodyReferenceTypeProperty), ParentPrivateExpressionBodyReferenceTypeProperty?.ToString() ?? "<null>" },
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

    public class ChildStaticProperties : ParentStaticProperties
    {
        static ChildStaticProperties()
        {
            ChildPublicReadOnlyValueTypeProperty = 20;
            ChildPublicReadOnlyStringTypeProperty = "21";
            ChildPublicReadOnlyNullableTypeProperty = 22;
            ChildPublicReadOnlyReferenceTypeProperty = new Version(23, 0);
            ChildProtectedReadOnlyValueTypeProperty = 24;
            ChildProtectedReadOnlyStringTypeProperty = "25";
            ChildProtectedReadOnlyNullableTypeProperty = 26;
            ChildProtectedReadOnlyReferenceTypeProperty = new Version(27, 0);
            ChildPrivateReadOnlyValueTypeProperty = 28;
            ChildPrivateReadOnlyStringTypeProperty = "29";
            ChildPrivateReadOnlyNullableTypeProperty = 30;
            ChildPrivateReadOnlyReferenceTypeProperty = new Version(31, 0);
        }

        public static int ChildPublicReadWriteValueTypeProperty { get; set; }

        public static string ChildPublicReadWriteStringTypeProperty { get; set; }

        public static int? ChildPublicReadWriteNullableTypeProperty { get; set; }

        public static Version ChildPublicReadWriteReferenceTypeProperty { get; set; }

        public static int ChildPublicReadOnlyValueTypeProperty { get; }

        public static string ChildPublicReadOnlyStringTypeProperty { get; }

        public static int? ChildPublicReadOnlyNullableTypeProperty { get; }

        public static Version ChildPublicReadOnlyReferenceTypeProperty { get; }

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

        public static int ChildPublicExpressionBodyValueTypeProperty => ChildPublicReadWriteValueTypeProperty;

        public static string ChildPublicExpressionBodyStringTypeProperty => ChildPublicReadWriteStringTypeProperty;

        public static int? ChildPublicExpressionBodyNullableTypeProperty => ChildPublicReadWriteNullableTypeProperty;

        public static Version ChildPublicExpressionBodyReferenceTypeProperty => ChildPublicReadWriteReferenceTypeProperty;

        protected static int ChildProtectedReadWriteValueTypeProperty { get; set; }

        protected static string ChildProtectedReadWriteStringTypeProperty { get; set; }

        protected static int? ChildProtectedReadWriteNullableTypeProperty { get; set; }

        protected static Version ChildProtectedReadWriteReferenceTypeProperty { get; set; }

        protected static int ChildProtectedReadOnlyValueTypeProperty { get; }

        protected static string ChildProtectedReadOnlyStringTypeProperty { get; }

        protected static int? ChildProtectedReadOnlyNullableTypeProperty { get; }

        protected static Version ChildProtectedReadOnlyReferenceTypeProperty { get; }

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

        protected static int ChildProtectedExpressionBodyValueTypeProperty => ChildPublicReadWriteValueTypeProperty;

        protected static string ChildProtectedExpressionBodyStringTypeProperty => ChildPublicReadWriteStringTypeProperty;

        protected static int? ChildProtectedExpressionBodyNullableTypeProperty => ChildPublicReadWriteNullableTypeProperty;

        protected static Version ChildProtectedExpressionBodyReferenceTypeProperty => ChildPublicReadWriteReferenceTypeProperty;

        private static int ChildPrivateReadWriteValueTypeProperty { get; set; }

        private static string ChildPrivateReadWriteStringTypeProperty { get; set; }

        private static int? ChildPrivateReadWriteNullableTypeProperty { get; set; }

        private static Version ChildPrivateReadWriteReferenceTypeProperty { get; set; }

        private static int ChildPrivateReadOnlyValueTypeProperty { get; }

        private static string ChildPrivateReadOnlyStringTypeProperty { get; }

        private static int? ChildPrivateReadOnlyNullableTypeProperty { get; }

        private static Version ChildPrivateReadOnlyReferenceTypeProperty { get; }

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

        private static int ChildPrivateExpressionBodyValueTypeProperty => ChildPublicReadWriteValueTypeProperty;

        private static string ChildPrivateExpressionBodyStringTypeProperty => ChildPublicReadWriteStringTypeProperty;

        private static int? ChildPrivateExpressionBodyNullableTypeProperty => ChildPublicReadWriteNullableTypeProperty;

        private static Version ChildPrivateExpressionBodyReferenceTypeProperty => ChildPublicReadWriteReferenceTypeProperty;
    }
#pragma warning restore SA1204 // Static elements should appear before instance elements
#pragma warning restore SA1402 // File may only contain a single class
#pragma warning restore SA1649 // File name must match first type name
}