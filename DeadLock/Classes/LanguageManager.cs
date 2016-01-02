using System.IO;
using System.Xml.Serialization;

namespace DeadLock.Classes
{
    internal class LanguageManager
    {
        private Language _currentLanguage;

        internal LanguageManager()
        {
            _currentLanguage = new Language();
        }

        internal void LoadLanguage(string path)
        {
            XmlSerializer serializer = new XmlSerializer(_currentLanguage.GetType());
            using (StreamReader reader = new StreamReader(path))
            {
                _currentLanguage = (Language)serializer.Deserialize(reader);
            }
        }

        internal void LoadDefaultLanguage()
        {
            XmlSerializer serializer = new XmlSerializer(_currentLanguage.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(Properties.Resources.eng);
                writer.Flush();
                stream.Position = 0;
                _currentLanguage = (Language)serializer.Deserialize(stream);
                writer.Dispose();
            }
        }

        internal Language GetLanguage()
        {
            return _currentLanguage;
        }
    }
}
