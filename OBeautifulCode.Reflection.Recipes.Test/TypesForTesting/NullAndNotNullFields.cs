// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NullAndNotNullFields.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection.Recipes.Test
{
    using System.Diagnostics.CodeAnalysis;

    public class NullAndNotNullFields
    {
#pragma warning disable 169
#pragma warning disable SA1401 // Fields should be private
        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "For testing purposes.")]
        public string NotNullString;

        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "For testing purposes.")]
        public string NullString;

        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "For testing purposes.")]
        public object NotNullObject;

        [SuppressMessage("Microsoft.Design", "CA1051:DoNotDeclareVisibleInstanceFields", Justification = "For testing purposes.")]
        public object NullObject;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore 169
    }
}
