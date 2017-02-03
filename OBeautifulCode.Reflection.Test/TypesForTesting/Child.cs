// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Child.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Test
{
    #pragma warning disable SA1309 // Field names must not begin with underscore
    // ReSharper disable ConvertToAutoProperty
    // ReSharper disable AutoPropertyCanBeMadeGetOnly.Local

    public class Child : Parent
    {
        private double _privateChildDoubleField = 123;

        private string _privateChildStringField = "Testing123";

        public Child()
        {
            this.PrivateChildDoubleProperty = 456;
            this.PrivateChildStringProperty = "Testing456";
        }

        public double PublicChildDoubleField => this._privateChildDoubleField;

        public string PublicChildStringField => this._privateChildStringField;

        public double PublicChildDoubleProperty => this.PrivateChildDoubleProperty;

        public string PublicChildStringProperty => this.PrivateChildStringProperty;

        private double PrivateChildDoubleProperty { get; set; }

        private string PrivateChildStringProperty { get; set; }
    }

    // ReSharper restore AutoPropertyCanBeMadeGetOnly.Local
    // ReSharper restore ConvertToAutoProperty
    #pragma warning restore SA1309 // Field names must not begin with underscore
}
