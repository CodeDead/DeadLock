using System.IO;
using System.Xml.Serialization;

namespace DeadLock.Classes
{
    public class LanguageManager
    {
        private Language _currentLanguage;

        public LanguageManager()
        {
            _currentLanguage = new Language();
        }

        public void LoadLanguage(string path)
        {
            XmlSerializer serializer = new XmlSerializer(_currentLanguage.GetType());
            using (StreamReader reader = new StreamReader(path))
            {
                _currentLanguage = (Language)serializer.Deserialize(reader);
            }
        }

        public Language GetLanguage()
        {
            return _currentLanguage;
        }
    }
}
