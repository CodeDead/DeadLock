using System;
using System.Xml.Serialization;

namespace DeadLock.Classes
{
    /// <summary>
    /// Represents an update with version information and URL.
    /// </summary>
    public class Update
    {
        /// <summary>
        /// Gets or sets the major version number.
        /// </summary>
        public int MajorVersion { get; set; }

        /// <summary>
        /// Gets or sets the minor version number.
        /// </summary>
        public int MinorVersion { get; set; }

        /// <summary>
        /// Gets or sets the build version number.
        /// </summary>
        public int BuildVersion { get; set; }

        /// <summary>
        /// Gets or sets the revision version number.
        /// </summary>
        public int RevisionVersion { get; set; }

        /// <summary>
        /// Gets or sets the update URL.
        /// </summary>
        public string UpdateUrl { get; set; }

        [XmlIgnore] 
        private Version _applicationVersion;

        /// <summary>
        /// Sets the application version for comparison.
        /// </summary>
        /// <param name="version">The current application version.</param>
        internal void SetApplicationVersion(Version version) => _applicationVersion = version;

        /// <summary>
        /// Checks if an update is available by comparing version numbers.
        /// </summary>
        /// <returns>True if an update is available; otherwise, false.</returns>
        internal bool CheckForUpdate()
        {
            return new Version(MajorVersion, MinorVersion, BuildVersion, RevisionVersion)
                .CompareTo(_applicationVersion) > 0;
        }
    }
}
