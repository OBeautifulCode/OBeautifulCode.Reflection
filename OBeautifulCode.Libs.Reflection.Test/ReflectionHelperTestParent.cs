// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTestParent.cs" company="CoMetrics">
//   Copyright 2014 CoMetrics
// </copyright>
// <summary>
//   Class used by <see cref="ReflectionHelperTest"/>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Libs.Reflection.Test
{
    using System;
    using System.IO;

    /// <summary>
    /// Class used by <see cref="ReflectionHelperTest"/>
    /// </summary>
    public class ReflectionHelperTestParent
    {
        #region Fields (Private)

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a instance of the <see cref="ReflectionHelperTestParent"/>
        /// </summary>
        public ReflectionHelperTestParent()
        {
            PrivateParentStreamProperty = new MemoryStream(new byte[] { 1, 0 });
            PrivateStaticParentStringProperty = "whatever1";            
        }

        #endregion

        #region Properties

        /// <summary>
        /// Accesses PrivateParentDoubleProperty
        /// </summary>
        public double PublicParentDoubleProperty { get; set; }

        /// <summary>
        /// Accesses PrivateParentStringProperty
        /// </summary>
        public string PublicParentStringProperty { get; set; }

        /// <summary>
        /// Accesses PrivateParentStreamProperty
        /// </summary>
        public Stream PublicParentStreamProperty { get; set; }

        /// <summary>
        /// Accesses PrivateStaticParentStringProperty property.
        /// </summary>
        public string PublicStaticParentStringProperty { get; set; }

        /// <summary>
        /// Accesses PrivateStaticParentStringProperty property.
        /// </summary>
        public string PublicStaticParentDoubleProperty { get; set; }

        /// <summary>
        /// Accesses PrivateStaticParentStringProperty property.
        /// </summary>
        public Stream PublicStaticParentStreamProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private double PrivateParentDoubleProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string PrivateParentStringProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private Stream PrivateParentStreamProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private static string PrivateStaticParentStringProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private static double PrivateStaticParentDoubleProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private static Stream PrivateStaticParentStreamProperty { get; set; }

        #endregion

        #region Public Methods

        #endregion

        #region Internal Methods

        #endregion

        #region Protected Methods

        #endregion

        #region Private Methods

        #endregion
    }
}
