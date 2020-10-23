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

    public class ParentProperties
    {
        public ParentProperties(
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

    public class ChildProperties : ParentProperties
    {
        public ChildProperties(
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

    #pragma warning restore SA1402 // File may only contain a single class
    #pragma warning restore SA1649 // File name must match first type name
}