// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parent.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System;
    using System.IO;

    #pragma warning disable 169
    #pragma warning disable SA1124 // Do not use regions
    #pragma warning disable SA1309 // Field names must not begin with underscore
    #pragma warning disable SA1214 // Readonly fields must appear before non-readonly fields

    public class Parent : IDisposable
    {
        #region Fields to Manipulate

        private static string _privateStaticParentStringField = "whatever2";

        private static string _privateStaticParentStringField2 = "whatever2";

        private double _privateParentDoubleField = 0;

        private readonly string _privateParentStringField = null;

        private readonly Stream _privateParentStreamField = new MemoryStream(new byte[] { 1 });

        private readonly IDisposable _privateParentIDisposableField = new MemoryStream();

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields", Justification = "Required for unit tests.")]
        private readonly Stream _privateParentNullStreamField;

        #endregion

        private bool _disposed;

        public Parent()
        {
            this.PrivateParentStreamProperty = new MemoryStream(new byte[] { 1, 0 });
            this.PrivateParentIDisposableProperty = new MemoryStream(new byte[] { 1, 0, 1 });
            PrivateStaticParentStringProperty = "whatever1";
            PrivateStaticParentStringProperty2 = "whatever3";
        }

        #region Properties to Access Privates

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for unit tests.")]
        public string PublicStaticParentStringField => _privateStaticParentStringField;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for unit tests.")]
        public string PublicStaticParentStringField2 => _privateStaticParentStringField2;

        public double PublicParentDoubleField => this._privateParentDoubleField;

        public string PublicParentStringField => this._privateParentStringField;

        public Stream PublicParentStreamField => this._privateParentStreamField;

        public IDisposable PublicParentIDisposableField => this._privateParentIDisposableField;

        public double PublicParentDoubleProperty => this.PrivateParentDoubleProperty;

        public string PublicParentStringProperty => this.PrivateParentStringProperty;

        public Stream PublicParentStreamProperty => this.PrivateParentStreamProperty;

        public IDisposable PublicParentIDisposableProperty => this.PrivateParentIDisposableProperty;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for unit tests.")]
        public string PublicStaticParentStringProperty => PrivateStaticParentStringProperty;

        #endregion

        #region Properties To Manipulate

        private static string PrivateStaticParentStringProperty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Required for unit tests.")]
        private static string PrivateStaticParentStringProperty2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Required for unit tests.")]
        private double PrivateParentDoubleProperty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Required for unit tests.")]
        private string PrivateParentStringProperty { get; set; }

        private Stream PrivateParentStreamProperty { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Required for unit tests.")]
        private Stream PrivateParentNullStreamProperty { get; set; }

        private IDisposable PrivateParentIDisposableProperty { get; set; }

        #endregion

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_privateParentStreamField", Justification = "Required for unit tests.")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_privateParentIDisposableField", Justification = "Required for unit tests.")]
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this._disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    this.PrivateParentIDisposableProperty?.Dispose();
                    this.PrivateParentStreamProperty?.Dispose();
                    this._privateParentStreamField?.Dispose();
                    this._privateParentIDisposableField?.Dispose();
                }

                // Note disposing has been done.
                this._disposed = true;
            }
        }
    }

    #pragma warning restore SA1214 // Readonly fields must appear before non-readonly fields
    #pragma warning restore SA1309 // Field names must not begin with underscore
    #pragma warning restore SA1124 // Do not use regions
    #pragma warning restore 169
}
