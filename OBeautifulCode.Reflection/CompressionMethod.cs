// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompressionMethod.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Reflection
{
    /// <summary>
    /// Determines the compression algorithm and/or archive file format used to compress a resource.
    /// </summary>
    public enum CompressionMethod
    {
        /// <summary>
        /// The resource is not compressed.
        /// </summary>
        None,

        /// <summary>
        /// The resource is compressed using the gzip file format,
        /// using the DEFLATE algorithm.
        /// </summary>
        Gzip
    }
}
