using System;
using System.Xml.Serialization;

namespace DeadLock.Classes
{
    public class Update
    {
        public int MajorVersion;
        public int MinorVersion;
        public int BuildVersion;
        public int RevisionVersion;
        public string UpdateUrl;
        [XmlIgnore] private Version _applicationVersion;

        internal void SetApplicationVersion(Version version) => _applicationVersion = version;

        internal bool CheckForUpdate()
        {
            return new Version(MajorVersion, MinorVersion, BuildVersion, RevisionVersion)
                .CompareTo(_applicationVersion) > 0;
        }
    }
}
