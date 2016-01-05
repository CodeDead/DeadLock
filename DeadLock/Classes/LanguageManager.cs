using System.IO;
using System.Xml.Serialization;

namespace DeadLock.Classes
{
    /// <summary>
    /// The LanguageManager can be used to load or return a Language object.
    /// </summary>
    internal class LanguageManager
    {
        #region Variables
        private Language _currentLanguage;
        #endregion

        /// <summary>
        /// Generate a new LanguageManager.
        /// </summary>
        internal LanguageManager()
        {
            _currentLanguage = new Language();
        }

        /// <summary>
        /// Load a custom language.
        /// </summary>
        /// <param name="path">Path to the XML language file.</param>
        internal void LoadLanguage(string path)
        {
            XmlSerializer serializer = new XmlSerializer(_currentLanguage.GetType());
            using (StreamReader reader = new StreamReader(path))
            {
                _currentLanguage = (Language)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// Load a Language using the project resources, depending on the settings.
        /// </summary>
        internal void LoadLanguage()
        {
            XmlSerializer serializer = new XmlSerializer(_currentLanguage.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(stream);
                string res;
                switch (Properties.Settings.Default.Language)
                {
                    case 0:
                        res = Properties.Resources.nl;
                        break;
                    case 1:
                        res = Properties.Resources.eng;
                        break;
                    case 2:
                        res = Properties.Resources.ita;
                        break;
                    case 3:
                        res = Properties.Resources.pl;
                        break;
                    case 4:
                        res = Properties.Resources.tr;
                        break;
                    default:
                        res = Properties.Resources.eng;
                        break;
                }
                writer.Write(res);
                writer.Flush();
                stream.Position = 0;
                _currentLanguage = (Language)serializer.Deserialize(stream);
                writer.Dispose();
            }
        }

        /// <summary>
        /// Get the current language.
        /// </summary>
        /// <returns>The current language.</returns>
        internal Language GetLanguage()
        {
            return _currentLanguage;
        }
    }
}
