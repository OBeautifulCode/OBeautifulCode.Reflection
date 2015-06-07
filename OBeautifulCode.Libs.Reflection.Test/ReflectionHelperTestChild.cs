// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReflectionHelperTestChild.cs" company="CoMetrics">
//   Copyright 2014 CoMetrics
// </copyright>
// <summary>
//   Class used by <see cref="ReflectionHelperTest"/>
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Libs.Reflection.Test
{
    /// <summary>
    /// Class used by <see cref="ReflectionHelperTest"/>
    /// </summary>
    public class ReflectionHelperTestChild : ReflectionHelperTestParent
    {
        #region Fields (Private)

        /// <summary>
        /// 
        /// </summary>
        private double privateChildDoubleField = 123;

        /// <summary>
        /// 
        /// </summary>
        private string privateChildStringField = "Testing123";

        
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ReflectionHelperTestChild"/> class.
        /// </summary>
        public ReflectionHelperTestChild()
        {
            PrivateChildDoubleProperty = 456;
            PrivateChildStringProperty = "Testing456";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Accesses privateChildDoubleField
        /// </summary>
        public double PublicChildDoubleField
        {
            get
            {
                return this.privateChildDoubleField;
            }
        }

        /// <summary>
        /// Accesses privateChildStringField
        /// </summary>
        public string PublicChildStringField
        {
            get
            {
                return this.privateChildStringField;
            }
        }

        /// <summary>
        /// Accesses PrivateChildDoubleProperty
        /// </summary>
        public double PublicChildDoubleProperty
        {
            get
            {
                return PrivateChildDoubleProperty;
            }
        }

        /// <summary>
        /// Accesses PrivateChildStringProperty
        /// </summary>
        public string PublicChildStringProperty
        {
            get
            {
                return PrivateChildStringProperty;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private double PrivateChildDoubleProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private string PrivateChildStringProperty { get; set; }

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
